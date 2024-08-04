using ApiRestaurante.Core.Application.ViewModels.Ordenes;
using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.ViewModels.Mesas
{
    public class MesaViewModel
    {
        public int Id { get; set; }
        public int CantidadPersonas { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public List<OrdenViewModel> Ordenes { get; set; }
    }
}
