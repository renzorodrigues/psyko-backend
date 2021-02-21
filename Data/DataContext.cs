using CCAU.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CCAU.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        
            this.User(modelBuilder);
        }

        private void User(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasKey(p => p.Id);

            modelBuilder.Entity<User>()
            .Property(p => p.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
            .Property(p => p.Name).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<User>()
            .Property(p => p.Email).IsRequired().HasMaxLength(100);
        }
    }
}