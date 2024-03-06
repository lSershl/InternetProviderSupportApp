using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;

namespace IPSA.API.Repositories
{
    public class EmployeeRepository(AppDbContext appDbContext) : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public List<Employee> GetAllEmployeesOfTheDepartment(int departmentId)
        {
            return _appDbContext.Employees.Where(e => e.DepartmentId == departmentId).ToList();
        }
    }
}
