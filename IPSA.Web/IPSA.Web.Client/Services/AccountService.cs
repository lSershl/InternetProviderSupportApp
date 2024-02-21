using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;
using System.Net.Http.Json;

namespace IPSA.Web.Client.Services
{
    public class AccountService(HttpClient httpClient) : IAccountService
    {
        private readonly HttpClient _httpClient = httpClient;
        private const string BaseUrl = "API/Account";

        public async Task<LoginResponse> LoginAsync(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/Login", loginDto);
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return result!;
        }
    }
}
