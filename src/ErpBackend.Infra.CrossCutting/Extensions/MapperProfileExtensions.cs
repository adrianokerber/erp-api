using AutoMapper;
using ErpBackend.Service.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace ErpBackend.Infra.CrossCutting.Extensions
{
    public static class MapperProfileExtensions
    {
        public static IServiceCollection RegisterMapperProfiles(this IServiceCollection services)
        {
            var configuration = GetProfilesConfiguration();
            IMapper mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        private static MapperConfiguration GetProfilesConfiguration()
        {
            return new MapperConfiguration(x =>
            {
                x.AddProfile(new CollaboratorMapperProfile());
            });
        }
    }
}
