using eticaret_uygulama.Models;
using Microsoft.EntityFrameworkCore;

namespace eticaret_uygulama.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Products>? Products { get; set; } 
        public DbSet<Slider>? Sliders { get; set; }
    }
}
