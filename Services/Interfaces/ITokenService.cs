using Prospectos.Models;

namespace Prospectos.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(SignIn sign);

        string DecodeToken(string token);

        bool ValidateToken(string token);
    }
}
