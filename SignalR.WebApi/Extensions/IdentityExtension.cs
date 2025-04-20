using Microsoft.AspNetCore.Identity;
using SignalR.Core.Entities;
using SignalR.Repository.Context;

namespace SignalR.WebApi.Extensions
{
    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentityExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, AppRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<SignalRContext>();

            return services;
        }
    }
}
