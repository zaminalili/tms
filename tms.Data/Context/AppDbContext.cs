using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using tms.Entity.Entities;

namespace tms.Data.Context
{
    public class AppDbContext: IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        DbSet<Product> Products { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Offer> Offers { get; set; }
        DbSet<PriceView> PriceViews { get; set; }
        DbSet<About> Abouts { get; set; }
        DbSet<Brend> Brends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
