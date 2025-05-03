using Domain.Films.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
