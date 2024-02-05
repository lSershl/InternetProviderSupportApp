using IPSA.Shared.Dtos;
using IPSA.Shared.Contracts;
using System.Text;
using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Reflection;
using IPSA.Shared.Responses;

namespace IPSA.Web.Client.Services
{
    public class AbonentService(HttpClient httpClient) : IAbonentService
    {
        private readonly HttpClient _httpClient = httpClient;

        private const string BaseUrl = "API/Abonents";
        private static string SerializeObj(object dto) => JsonSerializer.Serialize(dto, JsonOptions());
        private static T DeserializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;
        private static StringContent GenerateStringContent(string serializedObj) => new(serializedObj, Encoding.UTF8, "application/json");
        //private static IList<T> DeserializeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IList<T>>(jsonString, JsonOptions())!;
        private static IEnumerable<T> DeserializeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IEnumerable<T>>(jsonString, JsonOptions())!;
        private static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
            };
        }

        public async Task<IEnumerable<AbonentReadDto>> GetAllAbonents()
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<AbonentReadDto>();
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    return [.. DeserializeJsonStringList<AbonentReadDto>(result)];
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
                var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");

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

        public async Task<ServiceResponse> AddNewAbonent(AbonentCreateDto abonentCreateDto)
        {
            try
            {
                //var httpContent = new StringContent(
                //JsonSerializer.Serialize(abonentCreateDto),
                //Encoding.UTF8,
                //"application/json");

                //var abonent = await _httpClient.PostAsJsonAsync("API/Abonents/NewAbonent", abonentCreateDto);

                //var response = await abonent.Content.ReadFromJsonAsync<AbonentCreateDto>();

                //var response = await _httpClient.PostAsJsonAsync("API/Abonents/NewAbonent", httpContent);

                var response = await _httpClient.PostAsync($"{BaseUrl}/NewAbonent", GenerateStringContent(SerializeObj(abonentCreateDto)));

                if (response.IsSuccessStatusCode)
                {
                    return new ServiceResponse("Абонент успешно зарегистрирован в базе");
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
