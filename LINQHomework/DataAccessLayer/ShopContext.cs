using LINQHomework.Domain;
using Microsoft.EntityFrameworkCore;

namespace LINQHomework.DataAccessLayer
{
    public class ShopContext : DbContext
    {
        public ShopContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Refrigerator> Refrigerators { get; set; }
        public DbSet<Smartphone> Smartphones { get; set; }
        public DbSet<StationeryKnife> StationeryKnives { get; set; }
        public DbSet<TV> TVSets { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WW\\MSSQLSERVER2017; Database=LINQHomeworkDb; Trusted_Connection=True;");
        }
    }
}
