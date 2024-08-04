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
    public class MesaRepository : GenericRepository<Mesa>, IMesaRepository
    {
        private readonly ApplicationContext _dbContext;

        public MesaRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Mesa>> GetAllWithOrdersAsync()
        {
            var mesas = await _dbContext.Set<Mesa>()
                .Include(m => m.Ordenes)
                .ThenInclude(o => o.Platos)
                .ToListAsync();

            if (mesas == null)
            {
                return new List<Mesa>();
            }

            return mesas;
        }

        public async Task<Mesa> GetByIdWithOrdersAsync(int id)
        {
            return await _dbContext.Mesas
                .Include(m => m.Ordenes)
                .ThenInclude(o => o.Platos)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

    }
}
