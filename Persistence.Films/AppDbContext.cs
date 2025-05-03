using Domain.Films.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Films
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<Genero> Generos { get; set; }
    }
}
