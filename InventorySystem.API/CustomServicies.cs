using System;
using System.Reflection;
using InventorySystem.Application.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace InventorySystem.API
{
    /// <summary>
    /// Servicios especificos para el API.
    /// </summary>
    public static class CustomServicies
    {
        /// <summary>
        /// Agrega los diferentes servicio personalizados de la aplicación.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        /// <returns>IServiceCollection with dependencies.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // Add MediatR Commands/Events.
            services.AddMediatR(typeof(Application.Commands.CreateProductCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(Application.Commands.DeleteProductCommand).GetTypeInfo().Assembly);

            // Add IoC references.
            services.AddTransient<Application.Interfaces.IProductQueries, Application.Queries.ProductQueries>();
            services.AddTransient<Application.Interfaces.IProductQueryRepository, Infrastructure.Queries.ProductQuery>();
            services.AddScoped<Application.Interfaces.IProductRepository, Infrastructure.Rpositories.ProductRepository>();

            // Add auto mapper
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
