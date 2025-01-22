using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().HasData
            (
                new Genre { Id = 1, Name = "Фантастика" },
                new Genre { Id = 2, Name = "Повест" },
                new Genre { Id = 3, Name = "Роман" },
                new Genre { Id = 4, Name = "Жанр" }
            );
        }
    }
}     