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
    public class PaymentsControllerTests
    {
        private PaymentsController _paymentsController;
        private IPaymentRepository _paymentRepository;
        private IConnectedTariffsRepository _connectedTariffsRepository;
        private IMapper? _mapper;

        public PaymentsControllerTests() 
        {
            // Dependencies
            _paymentRepository = A.Fake<IPaymentRepository>();
            _connectedTariffsRepository = A.Fake<IConnectedTariffsRepository>();

            // SUT - System Under Test
            _paymentsController = new PaymentsController(
                _paymentRepository,
                _connectedTariffsRepository,
                _mapper!);
        }

        [Fact]
        public void PaymentsController_GetAllPaymentsList_ReturnOK()
        {
            // Arrange

            // Act
            var result = _paymentsController.GetAllPaymentsList();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<PaymentDto>>>));
        }

        [Fact]
        public void PaymentsController_GetAbonentPaymentsList_ReturnOK()
        {
            // Arrange
            int abonentId = 1;

            // Act
            var result = _paymentsController.GetAbonentPaymentsList(abonentId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<PaymentDto>>>));
        }

        [Fact]
        public void PaymentsController_AddNewPayment_ReturnOK()
        {
            // Arrange
            PaymentDto paymentDto = A.Fake<PaymentDto>();

            // Act
            var result = _paymentsController.AddNewPayment(paymentDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }

        [Fact]
        public void PaymentsController_CancelPayment_ReturnOK()
        {
            // Arrange
            int paymentId = 1;

            // Act
            var result = _paymentsController.CancelPayment(paymentId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }
    }
}
