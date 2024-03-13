using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using IPSA.API.Controllers;
using IPSA.API.Repositories.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.Tests.API.Controller
{
    public class AbonentsControllerTests
    {
        private AbonentsController _abonentsController;
        private IAbonentRepository _abonentRepository;
        private IMapper? _mapper;

        public AbonentsControllerTests()
        {
            // Dependencies
            _abonentRepository = A.Fake<IAbonentRepository>();

            // SUT - System Under Test
            _abonentsController = new AbonentsController(
                _abonentRepository,
                _mapper!);
        }

        [Fact]
        public void AbonentsController_GetAllAbonents_ReturnOK()
        {
            // Arrange

            // Act
            var result = _abonentsController.GetAllAbonents();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<IEnumerable<AbonentReadDto>>>));
        }

        [Fact]
        public void AbonentsController_GetAbonent_ReturnOK()
        {
            // Arrange
            int abonentId = 1;

            // Act
            var result = _abonentsController.GetAbonent(abonentId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<AbonentReadDto>>));
        }

        [Fact]
        public void AbonentsController_SearchAbonentsByFilter_ReturnOK()
        {
            // Arrange
            SearchAbonentFilter searchAbonentFilter = A.Fake<SearchAbonentFilter>();

            // Act
            var result = _abonentsController.SearchAbonentsByFilter(searchAbonentFilter);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<IEnumerable<AbonentReadDto>>>));
        }

        [Fact]
        public void AbonentsController_AddNewAbonent_ReturnOK()
        {
            // Arrange
            AbonentCreateDto abonentCreateDto = A.Fake<AbonentCreateDto>();

            // Act
            var result = _abonentsController.AddNewAbonent(abonentCreateDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<ServiceResponse>>));
        }

        [Fact]
        public void AbonentsController_UpdateAbonent_ReturnOK()
        {
            // Arrange
            int abonentId = 1;
            AbonentCreateDto abonentUpdateDto = A.Fake<AbonentCreateDto>();

            // Act
            var result = _abonentsController.UpdateAbonent(abonentId, abonentUpdateDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }

        [Fact]
        public void AbonentsController_ApplyPaymentToAbonentBalance_ReturnOK()
        {
            // Arrange
            PaymentDto paymentDto = A.Fake<PaymentDto>();

            // Act
            var result = _abonentsController.ApplyPaymentToAbonentBalance(paymentDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }
    }
}
