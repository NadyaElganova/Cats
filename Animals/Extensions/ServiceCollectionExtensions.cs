using Animals.Options;
using Animals.Services;

namespace Animals.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCatService(this IServiceCollection services, Action<CatApiOptions> options)
        {
            services.AddTransient<ICatApiServices, CatApiService>();
            services.Configure(options);
            return services;
        }
    }
}
