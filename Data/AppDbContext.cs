using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

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
            string USER_ID2 = Guid.NewGuid().ToString();
            string USER_ID3 = Guid.NewGuid().ToString();
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
                NormalizedEmail = "adam@wsei.edu.pl".ToUpper(),
                EmailConfirmed = true,
                UserName = "adam",
                NormalizedUserName = "ADAM"
            };

            // utworzenie użytkownika jako użytkownika
            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "user@wsei.edu.pl",
                NormalizedEmail = "user@wsei.edu.pl".ToUpper(),
                EmailConfirmed = true,
                UserName = "user",
                NormalizedUserName = "USER"
            };


            var user2 = new IdentityUser
            {
                Id = USER_ID2,
                Email = "user2@wsei.edu.pl",
                NormalizedEmail = "user2@wsei.edu.pl".ToUpper(),
                EmailConfirmed = true,
                UserName = "user2",
                NormalizedUserName = "USER2"
            };

            var user3 = new IdentityUser
            {
                Id = USER_ID3,
                Email = "user3@wsei.edu.pl",
                NormalizedEmail = "user3@wsei.edu.pl".ToUpper(),
                EmailConfirmed = true,
                UserName = "user3",
                NormalizedUserName = "USER3"
            };


            // haszowanie hasła
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");
            user.PasswordHash = ph.HashPassword(user, "12qw!@QW");
            user2.PasswordHash = ph.HashPassword(user2, "34erdf!@#$ERDF");
            user3.PasswordHash = ph.HashPassword(user3, "78tygh!@#$TYGH");


            // zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(user);
            modelBuilder.Entity<IdentityUser>().HasData(user2);
            modelBuilder.Entity<IdentityUser>().HasData(user3);

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
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID2
                });
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID3
                });

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(e => e.Address);

            modelBuilder.Entity<ContactEntity>().HasKey(e => e.Id);
            modelBuilder.Entity<ContactEntity>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>().HasData(
                new OrganizationEntity()
                {
                    Id = 1,
                    Title = "WSEI",
                    Nip = "83492384",
                    Regon = "13424234",
                },
                new OrganizationEntity()
                {
                    Id = 2,
                    Title = "Firma",
                    Nip = "2498534",
                    Regon = "0873439249",
                }
            );

            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity
                {
                    Id = 1, Name = "Test", Email = "aaa@aaa.aaa", Phone = "1111111", Priority = 1,
                    Birth = new DateTime(2000, 10, 11), OrganizationId = 1
                },
                new ContactEntity
                {
                    Id = 2, Name = "Ewewe", Email = "asd@fg.sss", Phone = "552325", Priority = 0,
                    Birth = new DateTime(2004, 1, 11), OrganizationId = 2
                }
            );

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(e => e.Address)
                .HasData(
                    new
                    {
                        OrganizationEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150",
                        Region = "małopolskie"
                    },
                    new
                    {
                        OrganizationEntityId = 2, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150",
                        Region = "małopolskie"
                    }
                );

            modelBuilder.Entity<ProductEntity>().HasKey(e => e.Id);
            modelBuilder.Entity<ProductEntity>().HasMany(e => e.Reviews).WithOne(r => r.Product)
                .HasForeignKey(e => e.ProductId).IsRequired();
            modelBuilder.Entity<ProductEntity>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(e => e.CategoryId).IsRequired();

            modelBuilder.Entity<ReviewEntity>().HasKey(e => e.Id);
            modelBuilder.Entity<ReviewEntity>()
                .HasOne(e => e.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Entity<CategoryEntity>().HasKey(e => e.Id);
            modelBuilder.Entity<CategoryEntity>()
                .HasMany(e => e.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity { Id = 1, Name = "Dom i ogród" },
                new CategoryEntity { Id = 2, Name = "Odzież i akcesoria" },
                new CategoryEntity { Id = 3, Name = "Sport i turystyka" }
            );

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity
                {
                    Id = 1, Name = "Młynek do pieprzu", CategoryId = 1, Producent = "Producent1", Price = 15.0m,
                    ProductionDate = new DateTime(2023, 6, 22), Description = "Opis młynka do pieprzu"
                },
                new ProductEntity
                {
                    Id = 4, Name = "Mop z mikrofibry", CategoryId = 1, Producent = "Producent76", Price = 70.0m,
                    ProductionDate = new DateTime(2021, 10, 15), Description = "Opis mopa z mikrofibry"
                },
                new ProductEntity
                {
                    Id = 5, Name = "Waga cyfrowa", CategoryId = 1, Producent = "Producent1", Price = 150.0m,
                    ProductionDate = new DateTime(2022, 3, 7), Description = "Opis wagi cyfrowej"
                },
                new ProductEntity
                {
                    Id = 2, Name = "Rękawiczki wełniane zimowe", CategoryId = 2, Producent = "Producent2",
                    Price = 241.13m, ProductionDate = new DateTime(2018, 1, 15),
                    Description = "Opis rękawiczek wełnianych zimowych"
                },
                new ProductEntity
                {
                    Id = 3, Name = "Mata do ćwiczeń", CategoryId = 3, Producent = "Producent3", Price = 39.99m,
                    ProductionDate = new DateTime(2021, 6, 7), Description = "Opis maty do ćwiczeń"
                }
            );

            for (var i = 6; i <= 25; i++)
            {
                modelBuilder.Entity<ProductEntity>().HasData(
                    new ProductEntity
                    {
                        Id = i,
                        Name = $"Produkt nr {i}",
                        CategoryId = i % 3 + 1,
                        Producent = $"Producent{i / 3 % 3 + 1}",
                        Price = 9.9m * i,
                        ProductionDate = new DateTime(2023, 6, 22),
                        Description = $"Opis produktu nr {i}"
                    }
                );
            }

            modelBuilder.Entity<ReviewEntity>().HasData(
                new ReviewEntity
                {
                    Id = 1, UserId = USER_ID2, Comment = "Bardzo fajny produkt", Rating = 5, ProductId = 1
                },
                new ReviewEntity
                {
                    Id = 2, UserId = USER_ID, Comment = "Nie polecam", Rating = 1, ProductId = 1
                },
                new ReviewEntity
                {
                    Id = 3, UserId = USER_ID2, Comment = "Bardzo fajny produkt", Rating = 5, ProductId = 2
                },
                new ReviewEntity
                {
                    Id = 4, UserId = USER_ID3, Comment = "Bardzo fajny produkt", Rating = 5, ProductId = 3
                }
            );

            string[] users = { USER_ID, USER_ID2, USER_ID3 };

            for (var i = 5; i <= 300; i++)
            {
                modelBuilder.Entity<ReviewEntity>().HasData(
                    new ReviewEntity
                    {
                        Id = i,
                        UserId = users[i % 3],
                        Comment = $"Komentarz produktu nr {i % 25 + 1}",
                        Rating = i % 5 + 1,
                        ProductId = i % 25 + 1
                    }
                );
            }
        }
    }
}