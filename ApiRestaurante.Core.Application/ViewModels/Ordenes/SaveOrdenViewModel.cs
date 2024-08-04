using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.ViewModels.Ordenes
{
    public class SaveOrdenViewModel
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public string Estado { get; set; }
        public List<string> PlatosNombres { get; set; }
    }
}
