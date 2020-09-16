using WebProject.Models;
using WebProject.Repositories;

namespace WebProject.Services
{
    public class PlayService
    {
        private readonly PlaysRepository playsRepository = new PlaysRepository();

        public Play GetPlay(int playId)
        {
            var play = playsRepository.GetPlay(playId);

            return play;
        }

    }
}