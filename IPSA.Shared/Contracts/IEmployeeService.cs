using IPSA.Shared.Dtos;

namespace IPSA.Shared.Contracts
{
    public interface IEmployeeService
    {
        Task<List<EmployeeNameDto>> GetNamesOfAllEmployeesOfTheDepartment(string departmentName);
    }
}
