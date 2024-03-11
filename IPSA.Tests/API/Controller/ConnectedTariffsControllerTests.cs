using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using IPSA.API.Controllers;
using IPSA.API.Repositories.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.Tests.API.Controller
{
    public class ConnectedTariffsControllerTests
    {
        private ConnectedTariffsController _connectedTariffsController;
        private IAbonentRepository _abonentRepository;
        private ITariffRepository _tariffRepository;
        private IConnectedTariffsRepository _connectedTariffsRepository;
        private IFeeWithdrawRepository _feeWithdrawRepository;
        private IScheduledMonthlyFeesRepository _monthlyFeesRepository;
        private IMapper? _mapper;

        public ConnectedTariffsControllerTests()
        {
            // Dependencies
            _abonentRepository = A.Fake<IAbonentRepository>();
            _tariffRepository = A.Fake<ITariffRepository>();
            _connectedTariffsRepository = A.Fake<IConnectedTariffsRepository>();
            _feeWithdrawRepository = A.Fake<IFeeWithdrawRepository>();
            _monthlyFeesRepository = A.Fake<IScheduledMonthlyFeesRepository>();

            // SUT - System Under Test
            _connectedTariffsController = new ConnectedTariffsController(
                _abonentRepository,
                _connectedTariffsRepository,
                _tariffRepository,
                _feeWithdrawRepository,
                _monthlyFeesRepository,
                _mapper!);
        }

        [Fact]
        public void ConnectedTariffsController_GetConnectedTariffsByAbonent_ReturnOK()
        {
            // Arrange
            int abonentId = 1;

            // Act
            var result = _connectedTariffsController.GetConnectedTariffsByAbonent(abonentId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<ConnectedTariffDto>>>));
        }

        [Fact]
        public void ConnectedTariffsController_AddNewConnectedTariff_ReturnOK()
        {
            // Arrange
            ConnectedTariffDto connectedTariffDto = A.Fake<ConnectedTariffDto>();

            // Act
            var result = _connectedTariffsController.AddNewConnectedTariff(connectedTariffDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }

        [Fact]
        public void ConnectedTariffsController_BlockAllAbonentTariffs_ReturnOK()
        {
            // Arrange
            int abonentId = 1;

            // Act
            var result = _connectedTariffsController.BlockAllAbonentTariffs(abonentId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }

        [Fact]
        public void ConnectedTariffsController_BlockConnectedTariffByRequest_ReturnOK()
        {
            // Arrange
            int connTariffId = 1;

            // Act
            var result = _connectedTariffsController.BlockConnectedTariffByRequest(connTariffId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }

        [Fact]
        public void ConnectedTariffsController_UnblockConnectedTariff_ReturnOK()
        {
            // Arrange
            int connTariffId = 1;

            // Act
            var result = _connectedTariffsController.UnblockConnectedTariff(connTariffId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }

        [Fact]
        public void ConnectedTariffsController_DeleteConnectedTariff_ReturnOK()
        {
            // Arrange
            int connTariffId = 1;

            // Act
            var result = _connectedTariffsController.DeleteConnectedTariff(connTariffId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }
    }
}
