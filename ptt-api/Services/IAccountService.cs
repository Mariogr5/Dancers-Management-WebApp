using ptt_api.Models;

namespace ptt_api.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwtToken(LoginDto dto);
    }
}