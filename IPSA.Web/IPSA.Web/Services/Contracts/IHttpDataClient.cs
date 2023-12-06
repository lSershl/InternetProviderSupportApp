using IPSA.Web.Dtos;

namespace IPSA.Web.Services.Contracts
{
    public interface IHttpDataClient
    {
        Task SendNewAbonentToApi(AbonentReadDto abonent);
    }
}
