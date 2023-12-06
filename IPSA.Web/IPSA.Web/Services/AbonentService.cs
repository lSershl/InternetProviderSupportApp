using IPSA.Web.Dtos;
using IPSA.Web.Services.Contracts;
using System.Text;
using System.Text.Json;

namespace IPSA.Web.Services
{
    public class AbonentService : IAbonentService
    {
        private readonly HttpClient _httpClient;
        public AbonentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AbonentReadDto>> GetAllAbonents()
        {
            try
            {
                var response = await _httpClient.GetAsync("API/Abonents");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<AbonentReadDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<AbonentReadDto>>();
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

        public async Task<AbonentReadDto> GetAbonent(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"API/Abonents/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(AbonentReadDto);
                    }

                    return await response.Content.ReadFromJsonAsync<AbonentReadDto>();
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

        public async Task AddNewAbonent(AbonentCreateDto abonentCreateDto)
        {
            try
            {
                var httpContent = new StringContent(
                JsonSerializer.Serialize(abonentCreateDto),
                Encoding.UTF8,
                "application/json");

                var response = await _httpClient.PostAsync("API/Abonents/NewAbonent", httpContent);
                //var response = await _httpClient.PostAsJsonAsync("API/Abonents/NewAbonent", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    return;
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
