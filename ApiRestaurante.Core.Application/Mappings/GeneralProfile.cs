using ApiRestaurante.Core.Application.Dtos.Account;
using ApiRestaurante.Core.Application.ViewModels.Ingredientes;
using ApiRestaurante.Core.Application.ViewModels.Mesas;
using ApiRestaurante.Core.Application.ViewModels.Ordenes;
using ApiRestaurante.Core.Application.ViewModels.Platos;
using ApiRestaurante.Core.Application.ViewModels.Users;
using ApiRestaurante.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Ingrediente, IngredienteViewModel>();

            CreateMap<IngredienteViewModel, SaveIngredienteViewModel>();

            CreateMap<Ingrediente, SaveIngredienteViewModel>()
                .ReverseMap();

            CreateMap<Mesa, MesaViewModel>();

            CreateMap<Mesa, SaveMesaViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Ordenes, opt => opt.Ignore());

            CreateMap<Orden, OrdenViewModel>();

            CreateMap<Orden, SaveOrdenViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Mesa, opt => opt.Ignore())
                .ForMember(dest => dest.Platos, opt => opt.Ignore());

            CreateMap<Plato, PlatoViewModel>()
            .ForMember(dest => dest.Ingredientes, opt => opt.MapFrom(src => src.Ingredientes));

            CreateMap<Plato, SavePlatoViewModel>()
                .ReverseMap();

            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
