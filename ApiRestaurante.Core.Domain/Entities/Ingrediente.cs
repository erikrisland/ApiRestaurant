using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Plato> Platos { get; set; }
    }
}
