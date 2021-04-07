using System.Collections.Generic;
using System.Linq;
using SystemForOrderingTickets.Models;

namespace SystemForOrderingTickets.Repositories
{
    public class DatesRepository
    {
        private static readonly List<Date> Dates;

        public List<Date> GetDates()
        {
            List<Date> result = null;

            using (var db = new PlayContext())
            {
                result = db.Dates.ToList();
            }

            return result;
        }

        public Date Get(int dateId)
        {
            return Dates.FirstOrDefault(q => q.Id == dateId);
        }
    }
}