using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Shared.JSONSerializer;
using IPSA.Shared.Responses;

namespace IPSA.Web.Client.Services
{
    public class PaymentService(HttpClient httpClient) : IPaymentService
    {
        private readonly HttpClient _httpClient = httpClient;
        private const string BaseUrl = "API/Payments";


        public async Task<ServiceResponse> AddNewPayment(PaymentDto paymentDto)
        {
            try
            {
                var response = await _httpClient.PostAsync($"{BaseUrl}", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(paymentDto)));

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

        public async Task<List<PaymentDto>> GetAllPaymentsList()
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
                    return [.. JSONSerializer.DeserializeJsonStringList<PaymentDto>(result)];
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

        public Task<PaymentDto> GetPayment(int paymentId)
        {
            throw new NotImplementedException();
        }
    }
}
