using WebAPI.ActionFilters;

namespace ErpBackend.WebAPI.Extensions
{
    public static class FilterExtensions
    {
        public static IServiceCollection RegisterFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();

            return services;
        }
    }
}
