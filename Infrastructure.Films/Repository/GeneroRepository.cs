using Domain.Films.Entities;
using Domain.Films.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Films;

namespace Infrastructure.Films.Repository
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly AppDbContext _context;

        public GeneroRepository(AppDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        public async Task<IEnumerable<Genero>> GetAllAsync()
        {
            var result = await _context.Generos.ToListAsync();

            return result;
        }
    }
}
