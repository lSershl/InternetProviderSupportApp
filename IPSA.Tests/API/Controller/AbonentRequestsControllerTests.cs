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
    public class AbonentRequestsControllerTests
    {
        private AbonentRequestsController _abonentRequestsController;
        private IAbonentRequestRepository _abonentRequestRepository;
        private IMapper? _mapper;

        public AbonentRequestsControllerTests()
        {
            // Dependencies
            _abonentRequestRepository = A.Fake<IAbonentRequestRepository>();

            // SUT - System Under Test
            _abonentRequestsController = new AbonentRequestsController(
                _abonentRequestRepository,
                _mapper!);
        }

        [Fact]
        public void AbonentRequestsController_GetAllAbonentsRequestsList_ReturnOK()
        {
            // Arrange

            // Act
            var result = _abonentRequestsController.GetAllAbonentsRequestsList();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<AbonentRequestDto>>>));
        }

        [Fact]
        public void AbonentRequestsController_GetRequestsListByDate_ReturnOK()
        {
            // Arrange
            DateDto dateDto = A.Fake<DateDto>();

            // Act
            var result = _abonentRequestsController.GetRequestsListByDate(dateDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<AbonentRequestDto>>>));
        }

        [Fact]
        public void AbonentRequestsController_GetRequestsListByDatePeriod_ReturnOK()
        {
            // Arrange
            DatePeriodDto datePeriodDto = A.Fake<DatePeriodDto>();

            // Act
            var result = _abonentRequestsController.GetRequestsListByDatePeriod(datePeriodDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<AbonentRequestDto>>>));
        }

        [Fact]
        public void AbonentRequestsController_GetRequestsListByAbonent_ReturnOK()
        {
            // Arrange
            int abonentId = 1;

            // Act
            var result = _abonentRequestsController.GetRequestsListByAbonent(abonentId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<AbonentRequestDto>>>));
        }

        [Fact]
        public void AbonentRequestsController_GetRequestById_ReturnOK()
        {
            // Arrange
            int requestId = 1;

            // Act
            var result = _abonentRequestsController.GetRequestById(requestId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<AbonentRequestDto>>));
        }

        [Fact]
        public void AbonentRequestsController_CreateAbonentRequest_ReturnOK()
        {
            // Arrange
            AbonentRequestDto abonentRequestDto = A.Fake<AbonentRequestDto>();

            // Act
            var result = _abonentRequestsController.CreateAbonentRequest(abonentRequestDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }

        [Fact]
        public void AbonentRequestsController_UpdateAbonentRequest_ReturnOK()
        {
            // Arrange
            AbonentRequestDto updatedAbonentRequestDto = A.Fake<AbonentRequestDto>();

            // Act
            var result = _abonentRequestsController.UpdateAbonentRequest(updatedAbonentRequestDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }


    }
}
