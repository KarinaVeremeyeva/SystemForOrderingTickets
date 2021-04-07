using System.Collections.Generic;
using System.Linq;
using SystemForOrderingTickets.Models;

namespace SystemForOrderingTickets.Repositories
{
    public class LoginsRepository
    {
        public List<Login> GetLogins()
        {
            List<Login> result = null;

            using (var db = new PlayContext())
            {
                result = db.Logins.ToList();
            }

            return result;
        }

        public void Create(Login login)
        {
            using (var db = new PlayContext())
            {
                db.Logins.Add(login);
                db.SaveChanges();
            }
        }
    }
}