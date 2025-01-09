using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql; // For database connection
using MigrateMap.Bal.Interfaces;
using MigrateMap.Bal.Models.Request;
using AutoMapper;
using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Repository;

namespace MigrateMap.Bal.Implementation
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IConfiguration config, HttpClient httpClient, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _config = config;
            _httpClient = httpClient;
             _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> ValidateLogin(UserLoginRequest request)
        {
            // Step 1: Validate user in the database
            var isValidUser = await ValidateUserInDatabase(request.UserName, request.Password);
            if (!isValidUser)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            // Step 2: Generate token from Auth0
            return await GenerateAuth0Token();
        }

        private async Task<bool> ValidateUserInDatabase(string username, string password)
        {
            // Fetch the user from the database using the email
            var existingUser = _unitOfWork.Users
                .Find(a => a.email.Trim().ToLower().Equals(username.Trim().ToLower()))
                .FirstOrDefault();

            if (existingUser == null)
            {
                return false; // User does not exist
            }
            else
            {
                return true; // User is valid
            }
        }


        private async Task<string> GenerateAuth0Token()
        {
            var domain = _config["Auth0:Domain"];
            var clientId = _config["Auth0:ClientId"];
            var clientSecret = _config["Auth0:ClientSecret"];
            var audiences = _config["Auth0:Audience"];
            var tokenUrl = $"https://{domain}/oauth/token";

            var payload = new
            {
                client_id = clientId,
                client_secret = clientSecret,
                audience = audiences,
                grant_type = "client_credentials"
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(tokenUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to generate token from Auth0.");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);

            return tokenResponse.GetProperty("access_token").GetString();
        }
    }
}
