using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services;
using ApiRestaurante.Core.Application.ViewModels.Ingredientes;
using ApiRestaurante.Core.Application.ViewModels.Platos;
using ApiRestaurante.Core.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Services
{
    public class PlatoService : GenericService<SavePlatoViewModel, PlatoViewModel, Plato>, IPlatoService
    {
        private readonly IPlatoRepository _platoRepository;
        private readonly IIngredienteRepository _ingredienteRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public PlatoService(IPlatoRepository platoRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper, IIngredienteRepository ingredienteRepository) : base(platoRepository, mapper)
        {
            _platoRepository = platoRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _ingredienteRepository = ingredienteRepository;
        }

        public async override Task<List<PlatoViewModel>> GetAllViewModel()
        {
            var platos = await _platoRepository.GetAllWithIngredientesAsync();

            var platoViewModels = platos.Select(p => new PlatoViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                CantidadPersonas = p.CantidadPersonas,
                Categoria = p.Categoria,
                Ingredientes = p.Ingredientes.Select(i => new IngredienteViewModel
                {
                    Id = i.Id,
                    Nombre = i.Nombre
                }).ToList()
            }).ToList();

            return platoViewModels;
        }

        public override async Task<SavePlatoViewModel> GetByIdSaveViewModel(int id)
        {
            var plato = await _platoRepository.GetByIdWithIngredientesAsync(id);

            if (plato == null)
            {
                return null;
            }

            var savePlatoViewModel = new SavePlatoViewModel
            {
                Id = plato.Id,
                Nombre = plato.Nombre,
                Precio = plato.Precio,
                CantidadPersonas = plato.CantidadPersonas,
                Categoria = plato.Categoria,
                IngredienteNombres = plato.Ingredientes.Select(i => i.Nombre).ToList()
            };

            return savePlatoViewModel;
        }

        public override async Task<SavePlatoViewModel> Add(SavePlatoViewModel vm)
        {
            var plato = _mapper.Map<Plato>(vm);

            var ingredientes = await _ingredienteRepository.GetByNamesAsync(vm.IngredienteNombres);
            plato.Ingredientes = ingredientes.ToList();

            await _platoRepository.AddAsync(plato);

            var result = _mapper.Map<SavePlatoViewModel>(plato);
            return result;
        }

    }
}
