using fiap.Models;
using fiap.Data.Repository;

namespace Fiap.Services
{
    public class AuthService : IAuthService
    {
        private List<UserModel> _users = new List<UserModel>
                {
                    new UserModel { UserId = 1, Username = "vitoria", Password = "123456", Role = "admin" },
                    new UserModel { UserId = 2, Username = "caroline", Password = "1234566", Role = "user" },
                   
                };


        public UserModel Authenticate(string username, string password)
        {
            
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
