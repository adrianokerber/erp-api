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
        private readonly string _dbName;
        private readonly DapperContext _dbContext;
        protected DapperContext DbContext { get { return _dbContext; } }

        // Before
        public RepositoryTestBase()
        {
            _dbName = GetRandomDatabaseName();
            CreateTestDatabase(_dbName);
            var configuration = CreateDbServerConfiguration(_dbName);
            _dbContext = new DapperContext(configuration);
        }

        private static IConfiguration CreateDbServerConfiguration(string databaseName)
        {
            var inMemorySettings = new Dictionary<string, string> {
                { "ConnectionStrings:SqlConnection", $"server=(localdb)\\MSSQLLocalDB; database={databaseName}; Integrated Security=true; Encrypt=false" }
            };
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            return configuration;
        }

        // After
        public void Dispose()
        {
            DeleteTestDatabase();
        }

        private static string GetRandomDatabaseName()
        {
            var dbPrefix = "tst_";
            var dbRandomName = Guid.NewGuid()
                                   .ToString()
                                   .Replace("-", "_");
            var dbNormalizedName = dbPrefix + dbRandomName;
            
            return dbNormalizedName;
        }

        private void CreateTestDatabase(string dbName)
        {
            var configuration = CreateDbServerConfiguration();
            var dbContext = new DapperContext(configuration);
            var sqlCreateDbCommand = $"CREATE DATABASE {dbName};";
            ExecuteSql(sqlCreateDbCommand, dbContext);
        }

        private static IConfiguration CreateDbServerConfiguration()
        {
            var inMemorySettings = new Dictionary<string, string> {
                { "ConnectionStrings:SqlConnection", $"server=(localdb)\\MSSQLLocalDB; Integrated Security=true; Encrypt=false" }
            };
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            return configuration;
        }

        private void ExecuteSql(string sql)
        {
            ExecuteSql(sql, _dbContext);
        }

        private void ExecuteSql(string sql, DapperContext dbContext)
        {
            using (var connection = dbContext.CreateConnection())
            {
                connection.Execute(sql);
            }
        }

        private void DeleteTestDatabase()
        {
            var sqlToRemoveActiveConnectionsToDb = $"ALTER DATABASE {_dbName} SET OFFLINE WITH ROLLBACK IMMEDIATE;";
            var sqlToDeleteDb = $"DROP DATABASE {_dbName};";
            ExecuteSql(sqlToRemoveActiveConnectionsToDb +
                       sqlToDeleteDb);
        }

        // TODO: Add methods of SetupTestSchema and SetupTestData

        protected void SetupDatabaseWith(string sqlFilePath)
        {
            var sqlCommandsBlock = GetSqlAsString(sqlFilePath);
            sqlCommandsBlock = GetSqlBlockInjectedWithDatabaseName(sqlCommandsBlock, _dbName);
            ExecuteSql(sqlCommandsBlock);
        }

        private static string GetSqlAsString(string sqlFilePath) => File.ReadAllText(sqlFilePath);

        private static string GetSqlBlockInjectedWithDatabaseName(string sqlBlock, string databaseName)
            => sqlBlock.Replace("@InjectedDbName", databaseName);
    }
}