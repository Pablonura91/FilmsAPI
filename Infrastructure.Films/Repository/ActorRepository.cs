using Domain.Films.Entities;
using Domain.Films.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Films;

namespace Infrastructure.Films.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _context;

        public ActorRepository(AppDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        public async Task<Actor> AddAsync(Actor actor)
        {
            _context.Actores.Add(actor);
            await _context.SaveChangesAsync();

            return actor;
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _context.Actores.ToListAsync();

            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            return await _context.Actores.Where(g => g.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Actor> UpdateAsync(Actor actor)
        {
            _context.Entry(actor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task DeleteAsync(Actor actor)
        {
            _context.Remove(actor);
            await _context.SaveChangesAsync();
        }
    }
}
