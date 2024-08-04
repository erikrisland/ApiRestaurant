using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services;
using ApiRestaurante.Core.Application.ViewModels.Ingredientes;
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
    public class IngredienteService : GenericService<SaveIngredienteViewModel, IngredienteViewModel, Ingrediente>, IIngredienteService
    {
        private readonly IIngredienteRepository _ingredienteRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public IngredienteService(IIngredienteRepository ingredienteRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(ingredienteRepository, mapper)
        {
            _ingredienteRepository = ingredienteRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

    }
}
