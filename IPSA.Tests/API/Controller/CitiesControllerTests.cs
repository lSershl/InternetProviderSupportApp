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
    public class CitiesControllerTests
    {
        private CitiesController _citiesController;
        private ICityRepository _cityRepository;
        private IMapper? _mapper;

        public CitiesControllerTests()
        {
            // Dependencies
            _cityRepository = A.Fake<ICityRepository>();

            // SUT - System Under Test
            _citiesController = new CitiesController(_cityRepository, _mapper!);
        }

        [Fact]
        public void CitiesController_GetAllCitiesList_ReturnOK()
        {
            // Arrange
            var citiesModelList = A.Fake<List<City>>();
            A.CallTo(() => _cityRepository.GetCitiesList()).Returns(citiesModelList);

            // Act
            var result = _citiesController.GetAllCitiesList();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<CityReadDto>>>));
        }
    }
}