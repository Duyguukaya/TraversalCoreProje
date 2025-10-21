using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DUYGUKAYA\\SQLEXPRESS;database=TraversalDb;integrated security=true;TrustServerCertificate=true;");
        }
        DbSet<About> Abouts { get; set; }
        DbSet<About2> About2s { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Destination> Destinations { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<Feature2> Feature2s { get; set; }
        DbSet<Guide> Guides { get; set; }
        DbSet<Newsletter> Newsletters { get; set; }
        DbSet<SubAbout> SubAbouts { get; set; }
        DbSet<Testimonial> Testimonials { get; set; }

    }
}
