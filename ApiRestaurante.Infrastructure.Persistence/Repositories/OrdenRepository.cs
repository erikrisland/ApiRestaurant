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
    public class OrdenRepository : GenericRepository<Orden>, IOrdenRepository
    {
        private readonly ApplicationContext _dbContext;

        public OrdenRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Orden>> GetAllWithPlatosAsync()
        {
            return await _dbContext.Ordenes.Include(p => p.Platos).ToListAsync();
        }

        public async Task<Orden> GetByIdWithPlatosAsync(int id)
        {
            return await _dbContext.Set<Orden>()
                .Include(p => p.Platos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
