using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

namespace IPSA.Web.Client.Services
{
    public class StreetService(HttpClient httpClient) : IStreetService
    {
        private readonly HttpClient _httpClient = httpClient;

        private const string BaseUrl = "API/Streets";
        //private static string SerializeObj(object dto) => JsonSerializer.Serialize(dto, JsonOptions());
        //private static T DeserializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;
        //private static StringContent GenerateStringContent(string serializedObj) => new(serializedObj, Encoding.UTF8, "application/json");
        private static IList<T> DeserializeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IList<T>>(jsonString, JsonOptions())!;
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
        public async Task<List<StreetReadDto>> GetAllStreetsList()
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null;
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    return [.. DeserializeJsonStringList<StreetReadDto>(result)];
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
        public async Task<List<StreetReadDto>> GetStreetsListByCity(int cityId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/ByCity/{cityId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null;
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    return [.. DeserializeJsonStringList<StreetReadDto>(result)];
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
