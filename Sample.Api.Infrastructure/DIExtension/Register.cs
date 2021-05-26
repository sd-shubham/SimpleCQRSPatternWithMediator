using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Api.Infrastructure.Persistence;
using Sample.Api.Application.Common;
using System.Linq;
using System.Reflection;
using Scrutor;

namespace Sample.Api.Infrastructure
{
    public static class Register
    {
        public static IServiceCollection AddInfrasStructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DbConnection")));
            RegisterCustomeServices(services);
            return services;
        }
        private static void RegisterCustomeServices(IServiceCollection services)
        {

            var assembly = Assembly.LoadFrom(
                $"{System.IO.Path.GetDirectoryName(typeof(Injectable).Assembly.Location)}\\Sample.Api.Infrastructure.dll"

            );
            services.Scan(scan =>
            scan.FromAssemblies(assembly)
            .AddClasses(classes => classes.WithAttribute<Injectable>(), true)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            );
        }
    }
}
