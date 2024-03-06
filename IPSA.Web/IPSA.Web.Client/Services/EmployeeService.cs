using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Shared.JSONSerializer;
using System.Net;

namespace IPSA.Web.Client.Services
{
    public class EmployeeService(HttpClient httpClient) : IEmployeeService
    {
        private readonly HttpClient _httpClient = httpClient;
        private const string BaseUrl = "API/Employees";

        public async Task<List<EmployeeNameDto>> GetNamesOfAllEmployeesOfTheDepartment(string departmentName)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/InDepartment/{departmentName}/Names");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode is HttpStatusCode.NoContent)
                    {
                        return null!;
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    return [.. JSONSerializer.DeserializeJsonStringList<EmployeeNameDto>(result)];
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }
    }
}
