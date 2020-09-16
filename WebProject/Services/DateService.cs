using System.Collections.Generic;
using System.Linq;
using WebProject.Models;
using WebProject.Repositories;

namespace WebProject.Services
{
    public class DateService
    {
        private readonly DatesRepository datesRepository = new DatesRepository();

        public Date GetDate(int dateId)
        {
            var date = datesRepository.GetDates().FirstOrDefault(q => q.Id == dateId);

            return date;
        }

        public List<Date> GetDatesOfPlay(int playId)
        {
            var dates = datesRepository.GetDates().Where(q => q.PlayId == playId).ToList();

            return dates;
        }
    }
}