using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Shared.JSONSerializer;
using IPSA.Shared.Responses;

namespace IPSA.Web.Client.Services
{
    public class TariffService(HttpClient httpClient) : ITariffService
    {
        private readonly HttpClient _httpClient = httpClient;
        private const string BaseUrl = "API/Tariffs";

        public async Task<List<TariffDto>> GetTariffsList()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null!;
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    return [.. JSONSerializer.DeserializeJsonStringList<TariffDto>(result)];
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
