using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tarzi_Backend.Models;
using Tarzi_Backend.ViewModels;

namespace Tarzi_Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<DraperiesType> DraperiesTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Customer>()
            //       .HasMany(o => o.Orders)
            //       .WithOne(c => c.Customer);

            //builder.Entity<Client>()
            //       .HasMany(o => o.Orders)
            //       .WithOne(c=>c.Client)
            //       .HasForeignKey(fk=>fk.ClientId);dotnet 
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasData(new ApplicationUser
                {
                    Email = "Admin@Admin.com",
                    PasswordHash = "Admin",
                    FirstName = "Admin",
                    LastName = "Admin",
                });
            });
            builder.Entity<Order>()
            .HasOne<Customer>(s => s.Customer)
            .WithMany(g => g.Orders)
            .HasForeignKey(s => s.CustomerId);

            builder.Entity<Order>().Ignore(cusId => cusId.CustomerId);
            builder.Entity<Order>()
                .Property(p => p.CustomerId)
                .HasDefaultValue(0);

            builder.Entity<ApplicationUser>().ToTable("Users", "Security");
            builder.Entity<IdentityRole>().ToTable("Roles", "Security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClims", "Security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Security");
        }
    }
}
