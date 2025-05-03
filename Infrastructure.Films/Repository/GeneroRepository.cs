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

        public async Task<Genero> AddAsync(Genero genero)
        {
            _context.Generos.Add(genero);
            await _context.SaveChangesAsync();

            return genero;
        }

        public async Task<IEnumerable<Genero>> GetAllAsync()
        {
            var result = await _context.Generos.ToListAsync();

            return result;
        }

        public async Task<Genero> GetByIdAsync(int id)
        {
            return await _context.Generos.Where(g => g.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Genero> UpdateAsync(Genero genero)
        {
            _context.Entry(genero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return genero;
        }

        public async Task DeleteAsync(Genero genero)
        {
            _context.Remove(genero);
            await _context.SaveChangesAsync();
        }
    }
}
