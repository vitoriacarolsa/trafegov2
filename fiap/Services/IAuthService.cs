using fiap.Models;

namespace Fiap.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);

    }
}
