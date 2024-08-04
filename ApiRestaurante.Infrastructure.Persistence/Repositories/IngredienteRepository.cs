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
    public class IngredienteRepository : GenericRepository<Ingrediente>, IIngredienteRepository
    {
        private readonly ApplicationContext _dbContext;

        public IngredienteRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Ingrediente>> GetByNamesAsync(List<string> names)
        {
            return await _dbContext.Ingredientes.Where(i => names.Contains(i.Nombre)).ToListAsync();
        }
    }
}
