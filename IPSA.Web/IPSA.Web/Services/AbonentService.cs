using IPSA.Models;
using IPSA.Web.Services.Contracts;
using System.Net.Http;

namespace IPSA.Web.Services
{
    public class AbonentService : IAbonentService
    {
        private readonly HttpClient _httpClient;
        public AbonentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Abonent>> GetAllAbonents()
        {
            try
            {
                var response = await _httpClient.GetAsync("API/Abonents");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<Abonent>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<Abonent>>();
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

        public async Task<Abonent> GetAbonent(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Abonents/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Abonent);
                    }

                    return await response.Content.ReadFromJsonAsync<Abonent>();
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
