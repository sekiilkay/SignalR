using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalR.Repository.Context;

namespace SignalR.Repository.Extensions
{
    public static class SqlConfigExtension
    {
        public static IServiceCollection AddSqlConfigExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SignalRContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlCon"));
            });

            return services;
        }
    }
}
