using ErpApi.WebAPI.ActionFilters;

namespace ErpApi.WebAPI.Extensions
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
