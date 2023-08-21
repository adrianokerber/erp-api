using Domain.Contracts.Repositories;
using Infraestructure.SqlDatabase;
using Infraestructure.SqlDatabase.Repositories;
using WebAPI.ActionFilters;

namespace WebAPI
{
    public static class DIConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            InjectServiceFilters(services);
            InjectRepositories(services);
        }

        private static void InjectServiceFilters(IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
        }

        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
        }
    }
}
