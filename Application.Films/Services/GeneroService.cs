using Application.Films.Interfaces;
using Domain.Films.Entities;
using Domain.Films.Interfaces;

namespace Application.Films.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository)
        {
            this._generoRepository = generoRepository;
        }

        public async Task<Genero> AddAsync(Genero genero)
        {
            return await _generoRepository.AddAsync(genero);
        }

        public async Task<IEnumerable<Genero>> GetAllAsync()
        {
            return await _generoRepository.GetAllAsync();
        }

        public async Task<Genero> GetByIdAsync(int id)
        {
            return await _generoRepository.GetByIdAsync(id);
        }

        public async Task<Genero> UpdateAsync(Genero genero)
        {
            return await _generoRepository.UpdateAsync(genero);
        }

        public async Task DeleteAsync(Genero genero)
        {
            await _generoRepository.DeleteAsync(genero);
        }
    }
}
