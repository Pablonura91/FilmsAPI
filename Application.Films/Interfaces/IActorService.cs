using Domain.Films.Entities;

namespace Application.Films.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task<Actor> AddAsync(Actor actor);
        Task<Actor> UpdateAsync(Actor actor);
        Task DeleteAsync(Actor actor);
    }
}
