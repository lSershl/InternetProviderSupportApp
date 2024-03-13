using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using IPSA.API.Controllers;
using IPSA.API.Repositories.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSA.Tests.API.Controller
{
    public class ReportsControllerTests
    {
        private ReportsController _reportsController;
        private IPaymentRepository _paymentRepository;
        private IFeeWithdrawRepository _feeWithdrawRepository;
        private IMapper? _mapper;

        public ReportsControllerTests()
        {
            // Dependencies
            _paymentRepository = A.Fake<IPaymentRepository>();
            _feeWithdrawRepository = A.Fake<IFeeWithdrawRepository>();

            // SUT - System Under Test
            _reportsController = new ReportsController(
                _feeWithdrawRepository,
                _paymentRepository,
                _mapper!);
        }

        [Fact]
        public void ReportsController_GetFeeWithdrawsReport_ReturnOK()
        {
            // Arrange
            int abonentId = 1;
            DatePeriodDto datePeriodDto = A.Fake<DatePeriodDto>();

            // Act
            var result = _reportsController.GetFeeWithdrawsReport(abonentId, datePeriodDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<FeeWithdrawRecordDto>>>));
        }

        [Fact]
        public void ReportsController_GetPaymentsReport_ReturnOK()
        {
            // Arrange
            int abonentId = 1;
            DatePeriodDto datePeriodDto = A.Fake<DatePeriodDto>();

            // Act
            var result = _reportsController.GetPaymentsReport(abonentId, datePeriodDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<PaymentDto>>>));
        }
    }
}
