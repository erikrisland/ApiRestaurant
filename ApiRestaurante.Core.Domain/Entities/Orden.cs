using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class Orden
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public Mesa Mesa { get; set; }
        public List<Plato> Platos { get; set; }
        public decimal Subtotal { get; set; }
        public string Estado { get; set; }
    }
}
