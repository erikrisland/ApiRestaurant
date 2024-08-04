using ApiRestaurante.Core.Application.ViewModels.Platos;
using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.ViewModels.Ordenes
{
    public class OrdenViewModel
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public List<PlatoViewModel> Platos { get; set; }
        public decimal Subtotal { get; set; }
        public string Estado { get; set; }
    }
}
