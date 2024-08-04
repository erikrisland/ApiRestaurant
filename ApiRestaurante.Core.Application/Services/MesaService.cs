using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services;
using ApiRestaurante.Core.Application.ViewModels.Mesas;
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
    public class MesaService : GenericService<SaveMesaViewModel, MesaViewModel, Mesa>, IMesaService
    {
        private readonly IMesaRepository _mesaRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public MesaService(IMesaRepository mesaRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(mesaRepository, mapper)
        {
            _mesaRepository = mesaRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public override async Task<List<MesaViewModel>> GetAllViewModel()
        {
            var mesas = await _mesaRepository.GetAllWithOrdersAsync();

            if (mesas == null)
            {
                throw new ArgumentNullException(nameof(mesas), "No se encontraron mesas en la base de datos.");
            }

            var mesasViewModel = mesas.Select(m => new MesaViewModel
            {
                Id = m.Id,
                CantidadPersonas = m.CantidadPersonas,
                Descripcion = m.Descripcion,
                Estado = m.Estado,
                Ordenes = m.Ordenes?.Select(o => new OrdenViewModel
                {
                    Id = o.Id,
                    MesaId = o.MesaId,
                    Estado = o.Estado,
                    Subtotal = o.Platos?.Sum(p => p.Precio) ?? 0,
                    Platos = o.Platos?.Select(p => new PlatoViewModel
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                        Precio = p.Precio,
                        CantidadPersonas = p.CantidadPersonas,
                        Categoria = p.Categoria
                    }).ToList() ?? new List<PlatoViewModel>()
                }).ToList() ?? new List<OrdenViewModel>()
            }).ToList();

            return mesasViewModel;
        }

        public async Task<List<OrdenViewModel>> GetOrdenesByMesaId(int mesaId)
        {
            var mesa = await _mesaRepository.GetByIdWithOrdersAsync(mesaId);

            if (mesa == null || mesa.Ordenes == null)
            {
                return new List<OrdenViewModel>();
            }

            var ordenes = mesa.Ordenes.Select(o => new OrdenViewModel
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
                    Categoria = p.Categoria
                }).ToList()
            }).ToList();

            return ordenes;
        }

        public async Task<bool> ChangeStatus(int mesaId, string nuevoEstado)
        {
            var mesa = await _mesaRepository.GetByIdAsync(mesaId);

            if (mesa == null)
            {
                return false;
            }

            mesa.Estado = nuevoEstado;
            await _mesaRepository.UpdateAsync(mesa, mesaId);
            return true;
        }

    }
}
