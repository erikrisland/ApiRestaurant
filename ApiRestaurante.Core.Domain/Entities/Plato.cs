using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class Plato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CantidadPersonas { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public string Categoria { get; set; }
    }
}
