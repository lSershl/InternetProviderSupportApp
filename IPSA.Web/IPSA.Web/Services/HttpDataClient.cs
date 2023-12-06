using IPSA.Web.Dtos;
using IPSA.Web.Services.Contracts;
using System.Text;
using System.Text.Json;

namespace IPSA.Web.Services
{
    public class HttpDataClient : IHttpDataClient
    {
        private readonly HttpClient _httpClient;

        public HttpDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendNewAbonentToApi(AbonentReadDto abonent)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(abonent),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync($"API/Abonents/NewAbonent", httpContent);
        }
    }
}
