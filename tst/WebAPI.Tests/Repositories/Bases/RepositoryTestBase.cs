using Dapper;
using Infraestructure.SqlDatabase;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace WebAPI.Tests.Repositories.Bases
{
    public abstract class RepositoryTestBase : IDisposable
    {
        private readonly DapperContext _dapperContext;
        protected DapperContext Context { get { return _dapperContext; } }

        // Before
        public RepositoryTestBase()
        {
            //var databaseName = Guid.NewGuid;
            var databaseName = "TestDB";
            var inMemorySettings = new Dictionary<string, string> {
                { "ConnectionStrings:SqlConnection", $"server=(localdb)\\MSSQLLocalDB; database={databaseName}; Integrated Security=true; Encrypt=false" }
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                //.AddJsonFile("testsettings.json")
                .Build();
            _dapperContext = new DapperContext(configuration);
        }

        protected void SetupDBWithThisSql() // Add SQL path as parameter
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var command = File.ReadAllText("./Repositories/SetupTestDB.sql");
                connection.Execute(command);
            }
        }

        // After
        public void Dispose()
        {
            // Add database clean-up here if necessary!
        }
    }
}
