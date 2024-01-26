using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            baseDir = baseDir.Substring(0, baseDir.LastIndexOf("lab_asp_net")) + "lab_asp_net";
            optionsBuilder.UseSqlite($"data source={baseDir}\\data.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string ADMIN_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            // dodanie roli administratora
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });
            // dodanie roli użytkownika
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });

            // utworzenie administratora jako użytkownika
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                NormalizedEmail = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adam",
                NormalizedUserName = "ADMIN"
            };

            // utworzenie użytkownika jako użytkownika
            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "user@wsei.edu.pl",
                NormalizedEmail = "user@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "user",
                NormalizedUserName = "USER"
            };


            // haszowanie hasła
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");
            user.PasswordHash = ph.HashPassword(user, "12qw!@QW");

            // zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(user);


            // przypisanie roli administratora użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = USER_ID
            });

            modelBuilder.Entity<ContactEntity>().HasKey(e => e.Id);
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity { Id = 1, Name = "Test", Email = "aaa@aaa.aaa", Phone = "1111111", Priority = 1, Birth = new DateTime(2000, 10, 11) },
                new ContactEntity { Id = 2, Name = "Ewewe", Email = "asd@fg.sss", Phone = "552325", Priority = 0, Birth = new DateTime(2004, 1, 11) }
                );
            modelBuilder.Entity<ProductEntity>().HasKey(e => e.Id);
            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity { Id = 1, Name = "Product1 abc", Producent = "Producent1", Price = 10.0m, ProductionDate = new DateTime(2000, 10, 10), Description = "Description1" },
                new ProductEntity { Id = 2, Name = "Product2 def", Producent = "Producent2", Price = 0.99m, ProductionDate = new DateTime(2018, 1, 15) },
                new ProductEntity { Id = 3, Name = "Product3 ghi", Producent = "Producent3", Price = 389.99m, ProductionDate = new DateTime(2021, 6, 7), Description = "Description3" }
                );
        }

    }
}
