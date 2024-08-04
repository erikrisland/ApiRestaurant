using ApiRestaurante.Core.Application.ViewModels.Mesas;
using ApiRestaurante.Core.Application.ViewModels.Ordenes;
using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IMesaService : IGenericService<SaveMesaViewModel, MesaViewModel, Mesa>
    {
        Task<List<OrdenViewModel>> GetOrdenesByMesaId(int mesaId);
        Task<bool> ChangeStatus(int mesaId, string nuevoEstado);
    }
}
