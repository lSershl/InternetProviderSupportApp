using IPSA.Shared.Dtos;
using IPSA.Shared.Contracts;
using System.Net.Http.Json;
using IPSA.Shared.Responses;
using IPSA.Shared.JSONSerializer;

namespace IPSA.Web.Client.Services
{
    public class AbonentService(HttpClient httpClient) : IAbonentService
    {
        private readonly HttpClient _httpClient = httpClient;

        private const string BaseUrl = "API/Abonents";

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
                    return [.. JSONSerializer.DeserializeJsonStringList<AbonentReadDto>(result)];
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

        public async Task<AbonentReadDto> GetAbonent(int abonId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/{abonId}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(AbonentReadDto)!;
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

        public async Task<IEnumerable<AbonentReadDto>> GetAbonentsByFilter(SearchAbonentFilter filter)
        {
            try
            {
                var response = await _httpClient.PutAsync($"{BaseUrl}/Search", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(filter)));

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<AbonentReadDto>();
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    return [.. JSONSerializer.DeserializeJsonStringList<AbonentReadDto>(result)];
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

        public async Task<AbonentCreateDto> GetAbonentForEdit(int abonId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/{abonId}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(AbonentCreateDto)!;
                    }

                    return await response.Content.ReadFromJsonAsync<AbonentCreateDto>();
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
                var response = await _httpClient.PostAsync($"{BaseUrl}/NewAbonent", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(abonentCreateDto)));

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

        public async Task<ServiceResponse> UpdateAbonent(int abonId, AbonentCreateDto abonentToUpdateDto)
        {
            try
            {
                var response = await _httpClient.PatchAsync($"{BaseUrl}/UpdateAbonent/{abonId}", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(abonentToUpdateDto)));

                if (response.IsSuccessStatusCode)
                {
                    return new ServiceResponse("Изменения успешно сохранены");
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

        public async Task<ServiceResponse> ApplyPaymentToAbonentBalance(PaymentDto paymentDto)
        {
            try
            {
                var response = await _httpClient.PutAsync($"{BaseUrl}/ApplyPayment", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(paymentDto)));

                if (response.IsSuccessStatusCode)
                {
                    return new ServiceResponse("Платёж успешно внесён на баланс");
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
