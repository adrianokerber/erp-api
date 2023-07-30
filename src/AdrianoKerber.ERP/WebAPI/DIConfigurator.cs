using Domain.Contracts.Repositories;
using Infraestructure.SqlDatabase;
using Infraestructure.SqlDatabase.Repositories;

namespace WebAPI
{
    public static class DIConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();

            InjectRepositories(services);
        }

        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
        }
    }
}
