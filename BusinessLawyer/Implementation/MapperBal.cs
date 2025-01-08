using Crate.MigrateMap.CrateDal;
using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MigrateMap.Bal.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MigrateMap.Bal.Implementation
{
    public class MapperBal : IMapperBal
    {
        private MapperRepository _repository;
        private IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public MapperBal(IUnitOfWork unitOfWork, IConfiguration config)
        {
            this._unitOfWork = unitOfWork;
            _repository = new MapperRepository();
            _config = config;
        }
        public async Task<List<string>> GetAvailableTables()
        {
            //var userList = this._unitOfWork.CorpMappingDB.GetAll();
            var corp = this._unitOfWork.Corporation.GetAll();
            var userList = this._unitOfWork.Users.GetAll();
            var token = GenerateToken(userList.FirstOrDefault());
            var data = await _repository.GetCorpMappingDB();
            return await _repository.GetAvailableTables();
        }
        private string GenerateToken(users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.first_name),
                new Claim(ClaimTypes.Role,user.last_name)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<List<MapperResponse>> GetAvailableTableColumns(string tableName)
        {
            return await _repository.GetAvailableTableColumns(tableName);

        }
    }
}
