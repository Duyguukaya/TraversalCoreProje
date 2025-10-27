using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Member.Models;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = values.Name;
            userEditViewModel.Surname = values.Surname;
            userEditViewModel.Phonenumber = values.PhoneNumber;
            userEditViewModel.Mail = values.Email;

            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (model.Image != null)
            {
                var resorce = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resorce + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await model.Image.CopyToAsync(stream);
                user.ImageUrl = "/userimages/" + imagename;
            }
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.PhoneNumber = model.Phonenumber;
            user.Email = model.Mail;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login", new { Area = "" });
            }
            return View();
        }
    }
}
