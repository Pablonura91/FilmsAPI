using Domain.Films.Entities;

namespace Application.Films.Interfaces
{
    public interface IGeneroService
    {
        Task<IEnumerable<Genero>> GetAllAsync();
        Task<Genero> GetByIdAsync(int id);
        Task<Genero> AddAsync(Genero genero);
        Task<Genero> UpdateAsync(Genero genero);
        Task DeleteAsync(Genero genero);
    }
}
