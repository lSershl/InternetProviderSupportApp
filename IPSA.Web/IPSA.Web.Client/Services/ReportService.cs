using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Shared.JSONSerializer;
using System.Net;

namespace IPSA.Web.Client.Services
{
    public class ReportService(HttpClient httpClient) : IReportService
    {
        private readonly HttpClient _httpClient = httpClient;
        private const string BaseUrl = "API/Reports";

        public async Task<List<PaymentDto>> GetPaymentRecordsByAbonent(int abonId, DatePeriodDto datePeriodDto)
        {
            try
            {
                var response = await _httpClient.PutAsync($"{BaseUrl}/Abonent/{abonId}/Payments", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(datePeriodDto)));
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode is HttpStatusCode.NoContent)
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

        public async Task<List<FeeWithdrawRecordDto>> GetFeeWithdrawRecordsByAbonent(int abonId, DatePeriodDto datePeriodDto)
        {
            try
            {
                var response = await _httpClient.PutAsync($"{BaseUrl}/Abonent/{abonId}/FeeWithdraws", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(datePeriodDto)));
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode is HttpStatusCode.NoContent)
                    {
                        return null!;
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    return [.. JSONSerializer.DeserializeJsonStringList<FeeWithdrawRecordDto>(result)];
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
