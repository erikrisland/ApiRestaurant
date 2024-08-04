using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services;
using ApiRestaurante.Core.Application.ViewModels.Ingredientes;
using ApiRestaurante.Core.Application.ViewModels.Ordenes;
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
    public class OrdenService : GenericService<SaveOrdenViewModel, OrdenViewModel, Orden>, IOrdenService
    {
        private readonly IOrdenRepository _ordenRepository;
        private readonly IPlatoRepository _platoRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public OrdenService(IOrdenRepository ordenRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper, IPlatoRepository platoRepository) : base(ordenRepository, mapper)
        {
            _ordenRepository = ordenRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _platoRepository = platoRepository;
        }

        public async override Task<List<OrdenViewModel>> GetAllViewModel()
        {
            var ordenes = await _ordenRepository.GetAllWithPlatosAsync();

            var ordenViewModels = ordenes.Select(o => new OrdenViewModel
            {
                Id = o.Id,
                MesaId = o.MesaId,
                Estado = o.Estado,
                Subtotal = o.Platos.Sum(p => p.Precio),
                Platos = o.Platos.Select(p => new PlatoViewModel
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    CantidadPersonas = p.CantidadPersonas,
                    Categoria = p.Categoria,

                }).ToList()
            }).ToList();

            return ordenViewModels;
        }

        public override async Task<SaveOrdenViewModel> GetByIdSaveViewModel(int id)
        {
            var orden = await _ordenRepository.GetByIdWithPlatosAsync(id);

            if (orden == null)
            {
                return null;
            }

            var saveOrdenViewModel = new SaveOrdenViewModel
            {
                Id = orden.Id,
                MesaId = orden.MesaId,
                Estado = orden.Estado,
                PlatosNombres = orden.Platos.Select(i => i.Nombre).ToList()
            };

            return saveOrdenViewModel;
        }

        public override async Task<SaveOrdenViewModel> Add(SaveOrdenViewModel vm)
        {
            var orden = _mapper.Map<Orden>(vm);

            var ingredientes = await _platoRepository.GetByNamesAsync(vm.PlatosNombres);

            orden.Platos = ingredientes.Select(i => new Plato
            {
                Nombre = i.Nombre,
                Precio = i.Precio,
                CantidadPersonas = i.CantidadPersonas,
                Categoria = i.Categoria
            }).ToList();

            await _ordenRepository.AddAsync(orden);

            var result = _mapper.Map<SaveOrdenViewModel>(orden);
            return result;
        }

        public override async Task Delete(int id)
        {
            var orden = await _ordenRepository.GetByIdAsync(id);

            if (orden == null)
            {
                throw new Exception($"Orden with id {id} not found");
            }

            await _ordenRepository.DeleteAsync(orden);
        }


    }
}
