using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Infrastructure.Persistence.Repositories
{
    public class PlatoRepository : GenericRepository<Plato>, IPlatoRepository
    {
        private readonly ApplicationContext _dbContext;

        public PlatoRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Plato>> GetAllWithIngredientesAsync()
        {
            return await _dbContext.Platos.Include(p => p.Ingredientes).ToListAsync();
        }

        public async Task<Plato> GetByIdWithIngredientesAsync(int id)
        {
            return await _dbContext.Set<Plato>()
                .Include(p => p.Ingredientes)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Plato>> GetByNamesAsync(List<string> names)
        {
            return await _dbContext.Platos.Where(i => names.Contains(i.Nombre)).ToListAsync();
        }

    }
}
