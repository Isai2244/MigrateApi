using Crate.MigrateMap.CrateDal;
using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MigrateMap.Bal.Interfaces;
using MigrateMap.Bal.Models.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MigrateMap.Bal.Implementation
{
    public class UserService : IUserService
    {
        private MapperRepository _repository;
        private IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public UserService(IUnitOfWork unitOfWork, IConfiguration config)
        {
            this._unitOfWork = unitOfWork;
            _repository = new MapperRepository();
            _config = config;
        }
        public async Task<string> ValidateLogin(UserLoginRequest request)
        {
            var userDetails = _unitOfWork.Users.Find(a => a.email.Trim().ToLower().Equals(request.UserName)).ToList();
            if (userDetails.Count > 0)
            {
                return await GenerateToken(new users { first_name = "Test", role = "Admin" });
            }
            else
            {
                return string.Empty;
            }
        }
        private async Task<string> GenerateToken(users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.first_name),
                new Claim(ClaimTypes.Role,user.role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
