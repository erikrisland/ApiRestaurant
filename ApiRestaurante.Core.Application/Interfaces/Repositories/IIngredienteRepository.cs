﻿using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Repositories
{
    public interface IIngredienteRepository : IGenericRepository<Ingrediente>
    {
        Task<IEnumerable<Ingrediente>> GetByNamesAsync(List<string> names);
    }
}
