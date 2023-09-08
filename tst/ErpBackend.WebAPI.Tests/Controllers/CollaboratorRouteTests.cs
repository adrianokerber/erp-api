using Domain.Contracts.Repositories;
using Domain.Entities;
using ErpBackend.WebAPI.Controllers.v1;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Tests.Controllers
{
    public class CollaboratorRouteTests
    {
        private readonly IReadOnlyList<CollaboratorEntity> _listOfFiveCollaborators = new List<CollaboratorEntity> {
                new CollaboratorEntity(Guid.Parse("a1a6d54d-5631-ee11-b64e-0862662cf4c1"), "FirstOne", "Surname1", null, 12345678901, "CPF", DateOnly.Parse("2018-12-10"), null),
                new CollaboratorEntity(Guid.Parse("b1a6d54d-5631-ee11-b64e-0862662cf4c1"), "SecondOne", "Surname2", null, 22345678902, "CPF", DateOnly.Parse("2018-12-11"), null),
                new CollaboratorEntity(Guid.Parse("c1a6d54d-5631-ee11-b64e-0862662cf4c1"), "ThirdOne", "Surname3", null, 32345678903, "CPF", DateOnly.Parse("2018-12-12"), null),
                new CollaboratorEntity(Guid.Parse("d1a6d54d-5631-ee11-b64e-0862662cf4c1"), "FourthOne", "Surname4", null, 42345678904, "CPF", DateOnly.Parse("2018-12-13"), null),
                new CollaboratorEntity(Guid.Parse("e1a6d54d-5631-ee11-b64e-0862662cf4c1"), "FifthOne", "Surname5", null, 52345678905, "CPF", DateOnly.Parse("2018-12-14"), null),
            };

        #region GET /collaborator
        [Trait("Collaborator", "Sucess")]
        [Fact]
        public void When_GetCollaborators_IsCalled_AListWith5CollaboratorsShouldReturn()
        {
            // Given
            var expectedResult = _listOfFiveCollaborators;
            Mock<ILogger<CollaboratorController>> mockLogger = new();
            Mock<ICollaboratorRepository> mockCollaboratorRepository = new();
            mockCollaboratorRepository.Setup(x => x.GetAllAsync())
                                      .ReturnsAsync(expectedResult);
            var sut = new CollaboratorController(mockLogger.Object, mockCollaboratorRepository.Object);

            // When
            var rawResult = sut.GetCollaborators()
                               .GetAwaiter()
                               .GetResult();

            // Then
            rawResult.Should()
                     .BeOfType<OkObjectResult>().And
                     .NotBeNull();
            var actualResult = (rawResult as OkObjectResult)!;


            actualResult.StatusCode.Should()
                                   .Be(200);
            actualResult.Value.As<List<CollaboratorEntity>>()
                              .Should()
                              .NotBeNull().And
                              .BeEquivalentTo(expectedResult).And
                              .HaveCount(5);
        }
        #endregion

        #region GET /collaborator/{id}
        [Trait("Collaborator", "Sucess")]
        [Theory]
        [InlineData("a1a6d54d-5631-ee11-b64e-0862662cf4c1")]
        [InlineData("b1a6d54d-5631-ee11-b64e-0862662cf4c1")]
        [InlineData("c1a6d54d-5631-ee11-b64e-0862662cf4c1")]
        [InlineData("d1a6d54d-5631-ee11-b64e-0862662cf4c1")]
        [InlineData("e1a6d54d-5631-ee11-b64e-0862662cf4c1")]
        public void When_GetCollaboratorById_IsCalledAndTheCollaboratorExists_TheSpecificCollaboratorShouldReturn(string idParam)
        {
            // Given
            var id = Guid.Parse(idParam);
            var collaboratorSearchFilter = (CollaboratorEntity collaborator)
                => collaborator.Id == id;

            var expectedResult = _listOfFiveCollaborators
                .FirstOrDefault(collaboratorSearchFilter);
            Mock<ILogger<CollaboratorController>> mockLogger = new();
            Mock<ICollaboratorRepository> mockCollaboratorRepository = new();
            mockCollaboratorRepository.Setup(x => x.GetByIdAsync(id))
                                      .ReturnsAsync(_listOfFiveCollaborators.FirstOrDefault(collaboratorSearchFilter));
            var sut = new CollaboratorController(mockLogger.Object, mockCollaboratorRepository.Object);

            // When
            var rawResult = sut.GetCollaboratorById(id)
                               .GetAwaiter()
                               .GetResult();

            // Then
            rawResult.Should()
                     .BeOfType<OkObjectResult>().And
                     .NotBeNull();
            var actualResult = (rawResult as OkObjectResult)!;


            actualResult.StatusCode.Should()
                                   .Be(200);
            actualResult.Value.As<CollaboratorEntity>()
                              .Should()
                              .NotBeNull().And
                              .BeEquivalentTo(expectedResult);
        }

        [Trait("Collaborator", "Sucess")]
        [Fact]
        public void When_GetCollaboratorById_IsCalledAndTheCollaboratorDoNotExists_ShouldRespond_NotFound()
        {
            // Given
            var id = Guid.NewGuid();
            Mock<ILogger<CollaboratorController>> mockLogger = new();
            Mock<ICollaboratorRepository> mockCollaboratorRepository = new();
            mockCollaboratorRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                                      .Returns(Task.FromResult<CollaboratorEntity?>(null));
            var sut = new CollaboratorController(mockLogger.Object, mockCollaboratorRepository.Object);

            // When
            var rawResult = sut.GetCollaboratorById(id)
                               .GetAwaiter()
                               .GetResult();

            // Then
            rawResult.Should()
                     .NotBeNull();
            var actualResult = (rawResult as NotFoundResult)!;


            actualResult.StatusCode.Should()
                                   .Be(404);
        }
        #endregion
    }
}