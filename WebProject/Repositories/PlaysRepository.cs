using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebProject.Models;
using WebProject.Services;

namespace WebProject.Repositories
{
    public class PlaysRepository
    {
        private static List<Play> Plays;

        public PlaysRepository()
        {
        }

        public PlaysRepository(string playsPath)
        {
            if (Plays == null)
            {
                var xmlService = new XMLReaderService();
                Plays = xmlService.ReadXMLFile<Play>(playsPath).ToList();
            }
        }

        public Play GetPlay(int playId)
        {
            Play result = null;

            using (var db = new PlayContext())
            {
                result = db.Plays.Where(q => q.Id == playId).Include(q => q.Author).FirstOrDefault();
            }

            return result;
        }
         
        public List<Play> GetPlays()
        {
            List<Play> result = null;

            using (var db = new PlayContext())
            {
                result = db.Plays.ToList();
            }

            return result;
        }
    }
}