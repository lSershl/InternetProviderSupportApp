using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;

namespace IPSA.API.Repositories.Contracts
{
    public interface IAccountRepository
    {
        LoginResponse Login(LoginDto loginDto);
    }
}
