using Domain.Films.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Films.Interfaces
{
    public interface IGeneroRepository
    {
        Task<IEnumerable<Genero>> GetAllAsync();
    }
}
