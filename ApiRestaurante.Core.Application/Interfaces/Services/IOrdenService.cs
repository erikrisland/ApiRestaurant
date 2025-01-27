﻿using ApiRestaurante.Core.Application.ViewModels.Ordenes;
using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IOrdenService : IGenericService<SaveOrdenViewModel, OrdenViewModel, Orden>
    {

    }
}
