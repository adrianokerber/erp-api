using Domain.Contracts.Repositories;
using ErpBackend.Service.Contracts;
using ErpBackend.Service.Services;
using Infraestructure.SqlDatabase.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Otimizador.Infra.CrossCutting
{
    public static class NativeInjectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
            services.AddScoped<ICollaboratorService, CollaboratorService>();
        }
    }
}
