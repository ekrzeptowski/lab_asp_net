using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
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
