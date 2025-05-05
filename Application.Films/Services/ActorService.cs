using Application.Films.Interfaces;
using Domain.Films.Entities;
using Domain.Films.Interfaces;

namespace Application.Films.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            this._actorRepository = actorRepository;
        }

        public async Task<Actor> AddAsync(Actor actor)
        {
            return await _actorRepository.AddAsync(actor);
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            return await _actorRepository.GetAllAsync();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            return await _actorRepository.GetByIdAsync(id);
        }

        public async Task<Actor> UpdateAsync(Actor actor)
        {
            return await _actorRepository.UpdateAsync(actor);
        }

        public async Task DeleteAsync(Actor actor)
        {
            await _actorRepository.DeleteAsync(actor);
        }
    }
}
