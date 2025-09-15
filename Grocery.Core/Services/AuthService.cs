using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClientService _clientService;
        public AuthService(IClientService clientService)
        {
            _clientService = clientService;
        }
        public Client? Login(string email, string password)
        {
            // Vraag de klantgegevens op met het opgegeven e-mailadres
            var client = _clientService.Get(email);

            // Controleer of de klant bestaat en of het wachtwoord klopt
            if (client != null && PasswordHelper.VerifyPassword(password, client._password))
            {
                return client; // Geef de klantgegevens terug als alles klopt
            }

            return null; // Geef null terug als de klant niet bestaat of het wachtwoord niet klopt
        }

    }
}
