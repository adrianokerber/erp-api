﻿using Domain.Contracts.Repositories;
using FluentAssertions;
using Infraestructure.SqlDatabase.Repositories;
using System.Linq;
using WebAPI.Tests.Repositories.Bases;
using Xunit;

namespace WebAPI.Tests.Repositories.CollaboratorRepository
{
    public class CollaboratorRepositoryTests : RepositoryTestBase
    {
        [Trait("Collaborator", "Sucess")]
        [Fact]
        public void WhenICall_GetAll_AListWith5CollaboratorsShouldBeReturned()
        {
            // Given
            SetupDBWithThisSql(); // TODO: insert data here via parameter
            ICollaboratorRepository sut = new CollaboratorRepository(Context);

            // When
            var actualResult = sut.GetAll()
                                  .GetAwaiter()
                                  .GetResult();

            // Then
            actualResult.ToList()
                        .Should()
                        .NotBeNull().And
                        .HaveCount(5);
        }
    }
}
