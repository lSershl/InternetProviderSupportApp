using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;
using IPSA.Shared.JSONSerializer;
using System.Net;

namespace IPSA.Web.Client.Services
{
    public class AbonPageCommentService(HttpClient httpClient) : IAbonPageCommentService
    {
        private readonly HttpClient _httpClient = httpClient;
        private const string BaseUrl = "API/AbonPageComments";

        public async Task<List<AbonPageCommentDto>> GetAbonentPageComments(int abonId)
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
                    return [.. JSONSerializer.DeserializeJsonStringList<AbonPageCommentDto>(result)];
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

        public async Task<ServiceResponse> AddNewAbonentPageComment(AbonPageCommentDto commentDto)
        {
            try
            {
                var response = await _httpClient.PostAsync($"{BaseUrl}", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(commentDto)));

                if (response.IsSuccessStatusCode)
                {
                    return new ServiceResponse("Комментарий успешно зарегистрирован в базе");
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

        public async Task<ServiceResponse> UpdateAbonPageComment(AbonPageCommentDto commentDto)
        {
            try
            {
                var response = await _httpClient.PutAsync($"{BaseUrl}", JSONSerializer.GenerateStringContent(JSONSerializer.SerializeObj(commentDto)));

                if (response.IsSuccessStatusCode)
                {
                    return new ServiceResponse("Комментарий успешно изменён");
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

        public async Task<ServiceResponse> DeleteAbonPageComment(int commentId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}");

                if (response.IsSuccessStatusCode)
                {
                    return new ServiceResponse("Комментарий успешно удалён");
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
