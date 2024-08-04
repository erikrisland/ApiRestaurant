using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.ViewModels.Ingredientes
{
    public class SaveIngredienteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
