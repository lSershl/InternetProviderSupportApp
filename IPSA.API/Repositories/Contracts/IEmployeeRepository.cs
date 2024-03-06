using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployeesOfTheDepartment(int departmentId);
    }
}
