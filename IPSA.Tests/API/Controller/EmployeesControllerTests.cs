using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using IPSA.API.Controllers;
using IPSA.API.Repositories.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.Tests.API.Controller
{
    public class EmployeesControllerTests
    {
        private EmployeesController _employeesController;
        private IEmployeeRepository _employeeRepository;
        private IDepartmentRepository _departmentRepository;

        public EmployeesControllerTests()
        {
            // Dependencies
            _employeeRepository = A.Fake<IEmployeeRepository>();
            _departmentRepository = A.Fake<IDepartmentRepository>();

            // SUT - System Under Test
            _employeesController = new EmployeesController(_employeeRepository, _departmentRepository);
        }

        [Fact]
        public void EmployeesController_GetEmployeesNamesInTheDepartment_ReturnOK()
        {
            // Arrange
            string departmentName = "Менеджеры сети";

            // Act
            var result = _employeesController.GetEmployeesNamesInTheDepartment(departmentName);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<EmployeeNameDto>>>));
        }
    }
}