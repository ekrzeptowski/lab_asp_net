using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }

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
        }

    }
}
