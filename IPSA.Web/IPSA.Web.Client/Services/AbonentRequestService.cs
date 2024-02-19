using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;
using IPSA.Shared.JSONSerializer;
using System.Net;

namespace IPSA.Web.Client.Services
{
    public class AbonentRequestService(HttpClient httpClient) : IAbonentRequestService
    {
        private readonly HttpClient _httpClient = httpClient;
        private const string BaseUrl = "API/AbonentRequests";

        public async Task<List<AbonentRequestDto>> GetAllAbonentsRequests()
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null!;
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    return [.. JSONSerializer.DeserializeJsonStringList<AbonentRequestDto>(result)];
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

        public async Task<List<AbonentRequestDto>> GetAbonentRequests(int abonId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/Abonent/{abonId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode is HttpStatusCode.NoContent)
                    {
                        return null!;
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    return [.. JSONSerializer.DeserializeJsonStringList<AbonentRequestDto>(result)];
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

        public async Task<List<AbonentRequestDto>> GetAbonentRequestsByDate(DateDto dateDto)
        {
            try
            {
                var response = await _httpClient.PutAsync($"{BaseUrl}/Date", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(dateDto)));
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode is HttpStatusCode.NoContent)
                    {
                        return null!;
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    return [.. JSONSerializer.DeserializeJsonStringList<AbonentRequestDto>(result)];
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

        public async Task<AbonentRequestDto> GetAbonentRequestById(int requestId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/Request/{requestId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode is HttpStatusCode.NoContent)
                    {
                        return null!;
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    return JSONSerializer.DeserializeJsonString<AbonentRequestDto>(result);
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

        public async Task<ServiceResponse> CreateAbonentRequest(AbonentRequestDto abonentRequestDto)
        {
            try
            {
                var response = await _httpClient.PostAsync($"{BaseUrl}", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(abonentRequestDto)));

                if (response.IsSuccessStatusCode)
                {
                    return new ServiceResponse("Заявка успешно сохранена");
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

        public async Task<ServiceResponse> UpdateAbonentRequest(AbonentRequestDto abonentRequestDto)
        {
            try
            {
                var response = await _httpClient.PatchAsync($"{BaseUrl}", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(abonentRequestDto)));

                if (response.IsSuccessStatusCode)
                {
                    return new ServiceResponse("Заявка успешно изменена");
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
