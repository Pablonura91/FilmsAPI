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

        public async Task<IEnumerable<Genero>> GetAllAsync()
        {
            return await _generoRepository.GetAllAsync();
        }
    }
}
