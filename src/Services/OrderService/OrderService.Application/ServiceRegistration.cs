using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Features.Commands.CreateOrder;
using System;
using System.Reflection;

namespace OrderService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services, Type startup)
        {
            var assembly = Assembly.GetExecutingAssembly();
            //var startupAssembly = startup.GetTypeInfo().Assembly;

            services.AddAutoMapper(assembly);

            //services.AddMediatR(assembly, startupAssembly, typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(assembly);

            return services;
        }
    }
}
