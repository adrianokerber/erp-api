using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace ErpApi.Infra.CrossCutting.Extensions
{
    public static class RegisterSqlServerExtensions
    {
        public static IServiceCollection RegisterSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            string connectionString = configuration.GetConnectionString("SqlConnection");
            services.AddScoped<IDbConnection>(_ => new SqlConnection(connectionString));

            return services;
        }
    }
}