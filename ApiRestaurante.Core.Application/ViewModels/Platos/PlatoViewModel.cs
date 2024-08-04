﻿using ApiRestaurante.Core.Application.ViewModels.Ingredientes;
using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.ViewModels.Platos
{
    public class PlatoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CantidadPersonas { get; set; }
        public List<IngredienteViewModel> Ingredientes { get; set; }
        public string Categoria { get; set; }
    }
}