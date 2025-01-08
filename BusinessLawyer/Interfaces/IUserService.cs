using MigrateMap.Bal.Models.Request;

namespace MigrateMap.Bal.Interfaces
{
    public interface IUserService
    {
        Task<string> ValidateLogin(UserLoginRequest request);
    }
}
