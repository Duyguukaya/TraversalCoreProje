using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation; // Eklendi
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using TraversalCoreProje.Models;
using BusinessLayer.ValidationRule.AnnouncementValidationRules;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using MediatR; // Validator'ýn bulunduðu klasör

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationByIdQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<RemoveDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();
});

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddHttpClient();

builder.Services.ContainerDependences();
builder.Services.CustomValidator();

builder.Services.AddAutoMapper(typeof(Program));

// --- FLUENT VALIDATION MODERN YAPILANDIRMA ---
// 1. Validator'larý sisteme kaydediyoruz (AnnouncementUpdateValidator üzerinden tüm assembly taranýr)
builder.Services.AddValidatorsFromAssemblyContaining<AnnouncementUpdateValidator>();

// 2. Eskimiþ olan .AddFluentValidation() yerine yeni servisleri ekliyoruz
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// 3. Buradaki .AddFluentValidation() kýsmýný sildik, sadece standart metod kaldý
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Login/SignIn";
});

var app = builder.Build();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var path = Directory.GetCurrentDirectory();
loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();