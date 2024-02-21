using IPSA.API.Repositories.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class AccountController(IAccountRepository accountRepository) : ControllerBase
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginDto loginDto)
        {
            var result = _accountRepository.Login(loginDto);
            return Ok(result);
        }
    }
}
