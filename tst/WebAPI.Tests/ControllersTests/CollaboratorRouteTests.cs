using Domain.Contracts.Repositories;
using Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Controllers;
using Xunit;

namespace WebAPI.Tests.ControllersTests
{
    public class CollaboratorRouteTests
    {
        private readonly IReadOnlyList<Collaborator> _listOfFiveCollaborators = new List<Collaborator> {
                new Collaborator("FirstOne", "Surname1", "12345678901"),
                new Collaborator("SecondOne", "Surname2", "22345678902"),
                new Collaborator("ThirdOne", "Surname3", "32345678903"),
                new Collaborator("FourthOne", "Surname4", "42345678904"),
                new Collaborator("FiftOne", "Surname5", "52345678905"),
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
            mockCollaboratorRepository.Setup(x => x.GetAll())
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
            actualResult.Value.As<List<Collaborator>>()
                              .Should()
                              .NotBeNull().And
                              .BeEquivalentTo(expectedResult).And
                              .HaveCount(5);
        }
        #endregion

        #region GET /collaborator/{Id}
        [Trait("Collaborator", "Sucess")]
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        public void When_GetCollaboratorById_IsCalledAndTheCollaboratorExists_TheSpecificCollaboratorShouldReturn(string idParam)
        {
            // Given
            var collaboratorSearchFilter = (Collaborator collaborator)
                => collaborator.Document[0] == idParam[0]; // TODO: search by externalId once it's added to the database and exposed to domain

            var expectedResult = _listOfFiveCollaborators
                .FirstOrDefault(collaboratorSearchFilter);
            Mock<ILogger<CollaboratorController>> mockLogger = new();
            Mock<ICollaboratorRepository> mockCollaboratorRepository = new();
            mockCollaboratorRepository.Setup(x => x.GetCollaborator(int.Parse(idParam)))
                                      .ReturnsAsync(_listOfFiveCollaborators.FirstOrDefault(collaboratorSearchFilter));
            var sut = new CollaboratorController(mockLogger.Object, mockCollaboratorRepository.Object);

            // When
            var rawResult = sut.GetCollaboratorById(idParam)
                               .GetAwaiter()
                               .GetResult();

            // Then
            rawResult.Should()
                     .BeOfType<OkObjectResult>().And
                     .NotBeNull();
            var actualResult = (rawResult as OkObjectResult)!;


            actualResult.StatusCode.Should()
                                   .Be(200);
            actualResult.Value.As<Collaborator>()
                              .Should()
                              .NotBeNull().And
                              .BeEquivalentTo(expectedResult);
        }
        #endregion
    }
}