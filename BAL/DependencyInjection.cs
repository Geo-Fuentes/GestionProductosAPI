using BAL.UseCases;
using DAL.Commands;
using DAL.Conexion;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMyDependencies(this IServiceCollection services, string connection)
        {
            services.AddScoped<ProductosUseCase>();
            services.AddScoped<ProductosCommands>();
            services.AddSingleton(new DbConnect(connection));

            return services;
        }
    }
}
