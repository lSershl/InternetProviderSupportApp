using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using IPSA.API.Controllers;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.Tests.API.Controller
{
    public class StreetsControllerTests
    {
        private StreetsController _streetsController;
        private IStreetRepository _streetRepository;
        private IMapper? _mapper;

        public StreetsControllerTests()
        {
            // Dependencies
            _streetRepository = A.Fake<IStreetRepository>();

            // SUT - System Under Test
            _streetsController = new StreetsController(_streetRepository, _mapper!);
        }

        [Fact]
        public void StreetsController_GetAllStreetsList_ReturnOK()
        {
            // Arrange
            var streetsModelList = A.Fake<List<Street>>();
            A.CallTo(() => _streetRepository.GetAllStreetsList()).Returns(streetsModelList);

            // Act
            var result = _streetsController.GetAllStreetsList();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<StreetReadDto>>>));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void StreetsController_GetStreetsListByCity_ReturnOk(int cityId)
        {
            // Arrange

            // Act
            var result = _streetsController.GetStreetsListByCity(cityId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<StreetReadDto>>>));
        }
    }
}
