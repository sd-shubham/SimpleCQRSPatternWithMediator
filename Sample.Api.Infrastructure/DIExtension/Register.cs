using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Api.Infrastructure.Persistence;
using Sample.Api.Application.Common;

namespace Sample.Api.Infrastructure
{
    public static class Register
    {
        public static IServiceCollection AddInfrasStructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DbConnection")));
            return services;
        }
    }
}
