﻿using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Repositories
{
    public interface IMesaRepository : IGenericRepository<Mesa>
    {
        Task<List<Mesa>> GetAllWithOrdersAsync();

        Task<Mesa> GetByIdWithOrdersAsync(int id);
    }
}
