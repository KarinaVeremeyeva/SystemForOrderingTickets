using System.Linq;
using SystemForOrderingTickets.Models;
using SystemForOrderingTickets.Repositories;

namespace SystemForOrderingTickets.Services
{
    public class LoginService
    {
        private readonly LoginsRepository loginsRepository = new LoginsRepository();

        public Login GetLoginByName(string userName)
        {
            var logins = loginsRepository.GetLogins();

            return logins.FirstOrDefault(q => q.Name.ToLower() == userName);
        }

        public void CreateLogin(Login login)
        {
            loginsRepository.Create(login);
        }
    }
}