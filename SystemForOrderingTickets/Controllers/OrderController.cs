using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using SystemForOrderingTickets.Filters;
using SystemForOrderingTickets.Models;
using SystemForOrderingTickets.Models.ViewModels;
using SystemForOrderingTickets.Services;
using static SystemForOrderingTickets.Models.ViewModels.ReportViewModel;

namespace SystemForOrderingTickets.Controllers
{
    [CourierCheckAddingFilter]
    public class OrderController : Controller
    {
        private readonly OrdersService ordersService = new OrdersService();
        private readonly LoginService loginService = new LoginService();
        private readonly CategoriesService categoriesService = new CategoriesService();
        private readonly DateService dateService = new DateService();
        private readonly PlayService playService = new PlayService();

        [HttpPost]
        public ActionResult CreateOrder(OrderCreateViewModel order)
        {
            var orderQuantitiesToSave = order.Quantities
                .Where(q => q.Quantity > 0);

            foreach(var orderQuantity in orderQuantitiesToSave)
            {
                ordersService.CreateOrder(new Order
                {
                    CategoryId = orderQuantity.CategoryId,
                    DateId = order.DateId,
                    LoginId = order.LoginId,
                    IsPaid = false,
                    Quantity = orderQuantity.Quantity
                });
            }
            return RedirectToAction("OrdersPageForDate", "Order", new { dateId = order.DateId });
        }

        [HttpPost]
        public ActionResult CancelOrder(int DateId, int LoginId)
        {
            ordersService.CancelOrders(LoginId, DateId);

            return RedirectToAction("OrdersPageForDate", "Order", new { dateId = DateId });
        }

        public ActionResult OrdersPageForDate(int dateId)
        {
            var userName = User.Identity.Name.ToLower();
            var loginId = loginService.GetLoginByName(userName)?.Id ?? 0;
            
            var date = dateService.GetDate(dateId);
            var play = playService.GetPlay(date.PlayId);
            var datesOfPlay = dateService.GetDatesOfPlay(play.Id).ToList();

            var dates = datesOfPlay.Select(q => new DateViewModel { Id = q.Id,
                Date = q.PlayDate }).ToList();

            var orders = new OrdersForDateViewModel
            {
                DateId = dateId,
                LoginId = loginId,
                Categories = new List<CategoriesForTableViewModel>(),
                Dates = dates,
                PlayName = play.Name,
                AuthorName = play.Author.Name
            };

            var categories = categoriesService.GetCategories();

            orders.Categories = categories.Select(category =>
            {
                var ticketsPaidCount = ordersService.GetPaidOrders(category.Id, dateId);
                var orderedTicketsCount = ordersService.GetNonPaidOrders(category.Id, dateId);

                return new CategoriesForTableViewModel
                {
                    Category = category.Name,
                    AvailableTickets = category.TotalTickets - ticketsPaidCount - orderedTicketsCount,
                    TicketPrice = category.TicketPrice,
                    TotalTickets = category.TotalTickets,
                    OrderedTickets = orderedTicketsCount,
                    PaidTickets = ticketsPaidCount,
                    CategoryId = category.Id,
                    Quantity = 0
                };
            }).ToList();

            return View(orders);
        }

        public ActionResult GetOrderedTickets()
        {
            var nonPaidOrders = ordersService.GetUnpaidOrders();

            var nonPaidOrdersViewModels = nonPaidOrders.Select(q =>
            {
                var category = categoriesService.GetCategory(q.CategoryId);

                return new UnpaidOrdersViewModel
                {
                    Id = q.Id,
                    CategoryName = category.Name,
                    UserName = q.Login.Name,
                    PlayDate = q.Date.PlayDate,
                    Quantity = q.Quantity
                };
            }).ToList();

            return View(nonPaidOrdersViewModels);
        }

        public ActionResult MarkOrderAsPaid(int paidOrderId)
        {
            ordersService.MarkOrderAsPaid(paidOrderId);

            return RedirectToAction("GetOrderedTickets", "Order");
        }

        public ActionResult CreateReport()
        {
            var categories = categoriesService.GetCategories();

            var reportViewModel = new ReportViewModel
            {
                Categories = categories.Select(category =>
                {
                    var orderedTicketsCount = ordersService.GetNonPaidOrders(category.Id);

                    return new CategoryReportViewModel
                    {
                        CategoryName = category.Name,
                        Price = category.TicketPrice * category.TotalTickets,
                        Quantity = category.TotalTickets
                    };
                }).ToList()
            };
            reportViewModel.TotalTicketsCount = reportViewModel.Categories.Sum(q => q.Quantity);
            reportViewModel.TotalTicketsPrice = reportViewModel.Categories.Sum(q => q.Price);

            return View(reportViewModel);

        }

        [HttpPost]
        public ActionResult ConfirmOrder(OrderCreateViewModel createOrderViewModel)
        {
            return View(createOrderViewModel);
        }  
    }
}