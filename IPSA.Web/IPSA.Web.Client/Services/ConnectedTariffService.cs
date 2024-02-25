using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Shared.JSONSerializer;
using IPSA.Shared.Responses;

namespace IPSA.Web.Client.Services
{
    public class ConnectedTariffService(HttpClient httpClient) : IConnectedTariffService
    {
        private readonly HttpClient _httpClient = httpClient;
        private const string BaseUrl = "API/ConnectedTariffs";


        public async Task<ServiceResponse> AddNewConnectedTariff(ConnectedTariffDto connTariffDto)
        {
            try
            {
                var response = await _httpClient.PostAsync($"{BaseUrl}", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(connTariffDto)));

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

        public async Task<List<ConnectedTariffDto>> GetConnectedTariffsListByAbonent(int abonId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/Abonent/{abonId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null!;
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    return [.. JSONSerializer.DeserializeJsonStringList<ConnectedTariffDto>(result)];
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

        public async Task<ServiceResponse> BlockAllAbonentConnectedTariffs(int abonId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/Abonent/{abonId}/BlockAll");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null!;
                    }

                    return new ServiceResponse("Все услуги абонента заблокированы");
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

        public async Task<ServiceResponse> BlockConnectedTariff(int connTariffId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/Block/{connTariffId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null!;
                    }

                    return new ServiceResponse("Услуга успешно заблокирована");
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

        public async Task<ServiceResponse> UnblockConnectedTariff(int connTariffId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/Unblock/{connTariffId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null!;
                    }

                    return new ServiceResponse("Услуга успешно разблокирована");
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

        public async Task<ServiceResponse> DeleteConnectedTariff(int connectedTariffId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null!;
                    }

                    return new ServiceResponse("Услуга успешно разблокирована");
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
