using Domain.Films.Entities;

namespace Application.Films.Interfaces
{
    public interface IGeneroService
    {
        Task<IEnumerable<Genero>> GetAllAsync();
    }
}
