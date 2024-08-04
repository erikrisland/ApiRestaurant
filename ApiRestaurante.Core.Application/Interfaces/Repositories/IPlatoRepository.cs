using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Repositories
{
    public interface IPlatoRepository : IGenericRepository<Plato>
    {
        Task<List<Plato>> GetAllWithIngredientesAsync();
        Task<Plato> GetByIdWithIngredientesAsync(int id);
        Task<IEnumerable<Plato>> GetByNamesAsync(List<string> names);
    }
}
