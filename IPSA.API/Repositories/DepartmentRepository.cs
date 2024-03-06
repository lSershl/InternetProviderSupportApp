using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;

namespace IPSA.API.Repositories
{
    public class DepartmentRepository(AppDbContext appDbContext) : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public Department GetDepartmentById(int departmentId)
        {
            return _appDbContext.Departments.First(d => d.Id == departmentId);
        }

        public int GetDepartmentIdByName(string departmentName)
        {
            return _appDbContext.Departments.First(d => d.Name == departmentName).Id;
        }

        public List<Department> GetDepartmentsList()
        {
            return _appDbContext.Departments.ToList();
        }
    }
}
