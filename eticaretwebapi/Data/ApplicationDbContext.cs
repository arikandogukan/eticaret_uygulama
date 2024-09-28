using eticaret_uygulama.Models;
using Microsoft.EntityFrameworkCore;

namespace eticaretwebapi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
    }
}