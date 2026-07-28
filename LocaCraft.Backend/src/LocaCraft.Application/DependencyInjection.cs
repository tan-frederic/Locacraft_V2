using LocaCraft.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LocaCraft.Application
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRealEstateService, RealEstateService>();
        }
    }
}
