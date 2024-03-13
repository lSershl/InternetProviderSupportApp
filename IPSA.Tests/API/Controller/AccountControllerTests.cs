using FakeItEasy;
using FluentAssertions;
using IPSA.API.Controllers;
using IPSA.API.Repositories.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.Tests.API.Controller
{
    public class AccountControllerTests
    {
        private AccountController _accountController;
        private IAccountRepository _accountRepository;

        public AccountControllerTests()
        {
            // Dependencies
            _accountRepository = A.Fake<IAccountRepository>();

            // SUT - System Under Test
            _accountController = new AccountController(_accountRepository);
        }

        [Fact]
        public void AccountController_Login_ReturnOK()
        {
            // Arrange
            LoginDto loginDto = A.Fake<LoginDto>();

            // Act
            var result = _accountController.Login(loginDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<LoginResponse>>));
        }
    }
}
