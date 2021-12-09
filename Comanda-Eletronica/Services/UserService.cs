using Comanda_Eletronica.Services.Interfaces;

namespace Comanda_Eletronica.Services
{
    public class UserService : IUserService
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username.Equals("admin") && password.Equals("47E9C885476DB53CBDDE82E7475DA8C0B4D0DE91FE689088EEF509AD4886EAC7");
        }
    }
}