using System.Linq;
using WebProject.Models;
using WebProject.Repositories;

namespace WebProject.Services
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