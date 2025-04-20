using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.Cores.Contexts
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            // Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }

}
