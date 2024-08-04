using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IIngredienteService, IngredienteService>();
            services.AddTransient<IMesaService, MesaService>();
            services.AddTransient<IOrdenService, OrdenService>();
            services.AddTransient<IPlatoService, PlatoService>();
            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
