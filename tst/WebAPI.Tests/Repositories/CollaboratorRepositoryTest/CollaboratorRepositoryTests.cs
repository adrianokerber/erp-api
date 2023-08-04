using Domain.Contracts.Repositories;
using FluentAssertions;
using Infraestructure.SqlDatabase.Repositories;
using System.Linq;
using WebAPI.Tests.Repositories.Bases;
using Xunit;

namespace WebAPI.Tests.Repositories.CollaboratorRepositoryTest
{
    public class CollaboratorRepositoryTests : SqlRepositoryTestBase
    {
        public CollaboratorRepositoryTests() : base()
        {
            // Set test schema
            ExecuteOnDb("./Repositories/ConfigureDbSchema.sql");
        }

        [Trait("Collaborator", "Sucess")]
        [Fact]
        public void WhenICall_GetAll_AListWith5CollaboratorsShouldBeReturned()
        {
            // Given
            ExecuteOnDb("./Repositories/CollaboratorRepositoryTest/Sqls/AddFiveEntriesOnCollaboratorTable.sql"); // Set data for test
            ICollaboratorRepository sut = new CollaboratorRepository(DbContext);

            // When
            var actualResult = sut.GetAll()
                                  .GetAwaiter()
                                  .GetResult();

            // Then
            actualResult.ToList()
                        .Should()
                        .NotBeNull().And
                        .HaveCount(5);

            ExecuteOnDb("./Repositories/CollaboratorRepositoryTest/Sqls/RemoveTheFiveEntriesOnCollaboratorTable.sql"); // Dump data from test
        }
    }
}
