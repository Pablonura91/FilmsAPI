using Domain.Films.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Films.Interfaces
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task<Actor> AddAsync(Actor genero);
        Task<Actor> UpdateAsync(Actor genero);
        Task DeleteAsync(Actor genero);
    }
}
