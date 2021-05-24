using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sample.Api.Application.Common.Mapper;
using System.Reflection;

namespace Sample.Api.Application
{
    public static class Register
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(MapperConfig));
            return services;
        }
    }
}