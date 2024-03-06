using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IDepartmentRepository
    {
        List<Department> GetDepartmentsList();
        Department GetDepartmentById(int departmentId);
        int GetDepartmentIdByName(string departmentName);
    }
}
