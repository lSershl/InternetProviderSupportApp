using FakeItEasy;
using FluentAssertions;
using IPSA.API.Controllers;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.Tests.API.Controller
{
    public class TariffsControllerTests
    {
        private TariffsController _tariffController;
        private ITariffRepository _tariffRepository;

        public TariffsControllerTests()
        {
            // Dependencies
            _tariffRepository = A.Fake<ITariffRepository>();

            // SUT - System Under Test
            _tariffController = new TariffsController(_tariffRepository);
        }

        [Fact]
        public void TariffsController_GetTariffsList_ReturnOK()
        {
            // Arrange
            var tariffModelList = A.Fake<List<Tariff>>();
            A.CallTo(() => _tariffRepository.GetTariffsList()).Returns(tariffModelList);

            // Act
            var result = _tariffController.GetTariffsList();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<TariffDto>>>));
        }
    }
}
