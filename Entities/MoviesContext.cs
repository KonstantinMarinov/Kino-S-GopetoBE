
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace KinoSGopeto.Entities
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options): base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
