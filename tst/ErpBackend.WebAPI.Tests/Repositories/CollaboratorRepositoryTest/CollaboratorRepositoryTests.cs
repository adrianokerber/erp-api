using Domain.Contracts.Repositories;
using FluentAssertions;
using Infraestructure.SqlDatabase.Repositories;
using System;
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
            var actualResult = sut.GetAllAsync()
                                  .GetAwaiter()
                                  .GetResult();

            // Then
            actualResult.ToList()
                        .Should()
                        .NotBeNull().And
                        .HaveCount(5);

            ExecuteOnDb("./Repositories/CollaboratorRepositoryTest/Sqls/RemoveTheFiveEntriesOnCollaboratorTable.sql"); // Dump data from test
        }

        [Trait("Collaborator", "Sucess")]
        [Fact]
        public void WhenICall_GetAll_AndThereAreNoCollaboratorsRegistered_AnEmptyListShouldBeReturned()
        {
            // Given
            ICollaboratorRepository sut = new CollaboratorRepository(DbContext);

            // When
            var actualResult = sut.GetAllAsync()
                                  .GetAwaiter()
                                  .GetResult();

            // Then
            actualResult.ToList()
                        .Should()
                        .BeNullOrEmpty();
        }

        [Trait("Collaborator", "Sucess")]
        [Theory]
        [InlineData("a1a6d54d-5631-ee11-b64e-0862662cf4c1")]
        [InlineData("b1a6d54d-5631-ee11-b64e-0862662cf4c1")]
        [InlineData("c1a6d54d-5631-ee11-b64e-0862662cf4c1")]
        [InlineData("d1a6d54d-5631-ee11-b64e-0862662cf4c1")]
        [InlineData("e1a6d54d-5631-ee11-b64e-0862662cf4c1")]
        public void WhenICall_GetById_TheSpecificCollaboratorShouldBeReturned(Guid id)
        {
            // Given
            ExecuteOnDb("./Repositories/CollaboratorRepositoryTest/Sqls/AddCollaboratorsByIdEntriesOnCollaboratorTable.sql"); // Set data for test
            ICollaboratorRepository sut = new CollaboratorRepository(DbContext);

            // When
            var collaboratorFound = sut.GetByIdAsync(id)
                                       .GetAwaiter()
                                       .GetResult();

            // Then
            collaboratorFound.Should()
                             .NotBeNull();
            collaboratorFound!.Id.Should()
                                 .Be(id);

            //ExecuteOnDb("./Repositories/CollaboratorRepositoryTest/Sqls/RemoveTheFiveEntriesOnCollaboratorTable.sql"); // Dump data from test
        }

        [Trait("Collaborator", "Failure")]
        [Fact]
        public void WhenICall_GetById_WithAUnregisteredId_WeMustNotFoundACollaborator()
        {
            // Given
            var unregisteredId = Guid.NewGuid();
            ICollaboratorRepository sut = new CollaboratorRepository(DbContext);

            // When
            var collaboratorFound = sut.GetByIdAsync(unregisteredId)
                                       .GetAwaiter()
                                       .GetResult();

            // Then
            collaboratorFound.Should()
                             .BeNull();
        }
    }
}
