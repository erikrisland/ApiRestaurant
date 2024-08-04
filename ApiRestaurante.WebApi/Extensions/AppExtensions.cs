using Microsoft.AspNetCore.Mvc;

namespace ApiRestaurante.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtensions (this IApplicationBuilder app)
        {
            app.UseSwagger ();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurante Api");
            });
           
        }
    }
}
