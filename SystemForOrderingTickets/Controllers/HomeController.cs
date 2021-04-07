using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SystemForOrderingTickets.Filters;
using SystemForOrderingTickets.Models;

namespace SystemForOrderingTickets.Controllers
{
    public class HomeController : Controller
    {
        [CourierCheckAddingFilter]
        public ActionResult Index()
        {
            using (var db = new PlayContext())
            {
                var plays = db.Plays.Include("Author").Include("Genre");
                var playsIds = plays.Select(p => p.Id);

                plays.ForEachAsync(p =>
                {
                    db.Entry(p).Collection("Dates").Load();
                }).Wait();

                ViewBag.Plays = plays.ToList();
            }

            return View();
        }
    }
}