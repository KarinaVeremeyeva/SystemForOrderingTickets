using System.Web.Mvc;
using SystemForOrderingTickets.Models;
using SystemForOrderingTickets.Services;

namespace SystemForOrderingTickets.Filters
{
    public class CourierCheckAddingFilterAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userName = filterContext.HttpContext.User.Identity.Name.ToLower();
            var login = new LoginService().GetLoginByName(userName);
            filterContext.Controller.ViewBag.IsCourier = new bool?(login?.RoleId == 2);
        }
    }
}