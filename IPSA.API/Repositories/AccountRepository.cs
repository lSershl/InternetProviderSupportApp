using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IPSA.API.Repositories
{
    public class AccountRepository(AppDbContext appDbContext, IConfiguration configuration) : IAccountRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        private readonly IConfiguration _configuration = configuration;
        
        public LoginResponse Login(LoginDto loginDto)
        {
            var findUser = GetEmployeeForAuth(loginDto.Login);
            if (findUser is null) 
                return new LoginResponse("Ошибка. Пользователь не найден.");

            if (loginDto.Password != findUser.Password)
                return new LoginResponse("Неверный логин или пароль");

            string jwtToken = GenerateToken(findUser);
            return new LoginResponse("Успешный вход в систему", jwtToken);
        }

        private Employee GetEmployeeForAuth(string login)
            => _appDbContext.Employees.First(x => x.Login == login);

        private string GenerateToken(Employee user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.ShortName),
                new Claim(ClaimTypes.Role, _appDbContext.Departments.First(x => x.Id == user.DepartmentId).EmloyeeRole)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
