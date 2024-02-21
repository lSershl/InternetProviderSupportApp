using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;

namespace IPSA.Shared.Contracts
{
    public interface IAccountService
    {
        Task<LoginResponse> LoginAsync(LoginDto loginDto);
    }
}
