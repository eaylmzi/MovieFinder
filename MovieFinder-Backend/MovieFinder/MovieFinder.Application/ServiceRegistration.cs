using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace MovieFinder.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();

            //services.AddMediatR(assm);
            //services.AddAutoMapper(assm);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assm)); //For MediatR version above 12.0.1
            services.AddAutoMapper(assm); // AutoMapper yapılandırması

            return services;
        }
    }
}
