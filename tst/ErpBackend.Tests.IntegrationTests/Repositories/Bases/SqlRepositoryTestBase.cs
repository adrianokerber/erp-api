using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ErpBackend.Tests.IntegrationTests.Repositories.Bases
{
    public abstract class SqlRepositoryTestBase : IDisposable
    {
        private readonly string _dbName;
        private readonly IDbConnection _dbContext;
        protected IDbConnection DbContext { get { return _dbContext; } }

        // Before
        public SqlRepositoryTestBase()
        {
            _dbName = GetRandomDatabaseName();
            CreateTestDatabase(_dbName);
            var configuration = BuildServerConfiguration(_dbName);
            _dbContext = CreateSqlConnectionWith(configuration);
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
            var configuration = BuildServerConfiguration();
            var dbContext = CreateSqlConnectionWith(configuration);
            var sqlCreateDbCommand = $"CREATE DATABASE {dbName};";
            ExecuteSql(sqlCreateDbCommand, dbContext);
        }

        private static IConfiguration BuildServerConfiguration(string dbName)
        {
            return BuildConfigurationWithSqlConnection(
                SqlConnectionString(withDbName: dbName)
            );
        }

        private static IConfiguration BuildServerConfiguration()
        {
            return BuildConfigurationWithSqlConnection(
                SqlConnectionString()
            );
        }

        private IDbConnection CreateSqlConnectionWith(IConfiguration configuration)
            => new SqlConnection(configuration.GetConnectionString("SqlConnection"));

        private static IConfiguration BuildConfigurationWithSqlConnection(string dbServerConnectionString)
        {
            var inMemorySettings = new Dictionary<string, string> {
                { "ConnectionStrings:SqlConnection", dbServerConnectionString }
            };
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            return configuration;
        }

        private static string SqlConnectionString(string? withDbName = null)
        {
            var dbNameConfiguration = withDbName != null
                                        ? $"database={withDbName};"
                                        : "";
            return $"server=(localdb)\\MSSQLLocalDB; {dbNameConfiguration} Integrated Security=true; Encrypt=false";
        }

        // After
        public void Dispose()
        {
            DeleteTestDatabase();
        }

        private void ExecuteSql(string sql)
        {
            ExecuteSql(sql, _dbContext);
        }

        private void ExecuteSql(string sql, IDbConnection connection)
        {
            connection.Execute(sql);
        }

        private void DeleteTestDatabase()
        {
            var sqlToRemoveActiveConnectionsToDb = $"ALTER DATABASE {_dbName} SET OFFLINE WITH ROLLBACK IMMEDIATE;";
            var sqlToDeleteDb = $"DROP DATABASE {_dbName};";
            ExecuteSql(sqlToRemoveActiveConnectionsToDb +
                       sqlToDeleteDb);
        }

        public void ExecuteOnDb(string sqlFilePath)
        {
            var sql = ReadAndPrepareSqlFromFile(sqlFilePath);
            ExecuteSql(sql);
        }

        private string ReadAndPrepareSqlFromFile(string sqlFilePath)
        {
            var setCurrentDbSqlCommand = $"USE [{_dbName}];";
            var sqlCommandsFromFile = ReadSqlFileAsString(sqlFilePath);

            var sqlCommandsBlock = setCurrentDbSqlCommand
                                 + sqlCommandsFromFile;

            return sqlCommandsBlock;
        }

        private static string ReadSqlFileAsString(string sqlFilePath) => File.ReadAllText(sqlFilePath);
    }
}