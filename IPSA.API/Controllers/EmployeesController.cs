using IPSA.API.Repositories.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository) : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        [HttpGet("InDepartment/{departmentName}/Names")]
        public async Task<ActionResult<List<EmployeeNameDto>>> GetEmployeesNamesInTheDepartment(string departmentName)
        {
            try
            {
                List<EmployeeNameDto> employeesNames = new();
                int departmentId = _departmentRepository.GetDepartmentIdByName(departmentName);
                var employeesList = _employeeRepository.GetAllEmployeesOfTheDepartment(departmentId);

                if (employeesList is null)
                {
                    return NoContent();
                }

                foreach (var employee in employeesList)
                {
                    employeesNames.Add(new EmployeeNameDto { Name = employee.ShortName });
                }

                return Ok(employeesNames);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }
    }
}
