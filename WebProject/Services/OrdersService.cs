using System.Collections.Generic;
using System.Linq;
using WebProject.Models;
using WebProject.Repositories;

namespace WebProject.Services
{
    public class OrdersService
    {
        private static OrdersRepository ordersRepository = new OrdersRepository();

        public void CreateOrder(Order order)
        {
            ordersRepository.Create(order);
        }

        private List<Order> GetOrdersForDate(int dateId)
        {
            var ordersForDate = ordersRepository.GetOrders().Where(q => q.DateId == dateId).ToList();

            return ordersForDate;
        }

        private List<Order> GetTicketsForCategory(int categoryId, int dateId)
        {
            var ticketsForCategory = GetOrdersForDate(dateId).Where(q => q.CategoryId == categoryId).ToList();

            return ticketsForCategory;
        }

        private List<Order> GetTicketsForCategory(int categoryId)
        {
            var ticketsForCategory = ordersRepository.GetOrders().Where(q => q.CategoryId == categoryId).ToList();

            return ticketsForCategory;
        }

        public int GetPaidOrders(int categoryId, int dateId)
        {
            var ticketsPaidCount = GetTicketsForCategory(categoryId, dateId).Where(q => q.IsPaid).Sum(q => q.Quantity);

            return ticketsPaidCount;
        }

        public int GetNonPaidOrders(int categoryId, int dateId)
        {
            var orderedTicketsCount = GetTicketsForCategory(categoryId, dateId).Where(q => !q.IsPaid).Sum(q => q.Quantity);

            return orderedTicketsCount;
        }

        public int GetNonPaidOrders(int categoryId)
        {
            var orderedTicketsCount = GetTicketsForCategory(categoryId).Where(q => !q.IsPaid).Sum(q => q.Quantity);

            return orderedTicketsCount;
        }

        public void CancelOrders(int loginId, int dateId)
        {
            var ordersToCancelIds = ordersRepository.GetOrders()
                .Where(q => !q.IsPaid 
                    && q.LoginId == loginId 
                    && q.DateId == dateId)
                .Select(q => q.Id);

            ordersRepository.RemoveRange(ordersToCancelIds);
        }

        public List<Order> GetUnpaidOrders()
        {
            var unpaidOrders = ordersRepository.GetOrders().Where(q => !q.IsPaid).ToList();

            return unpaidOrders;
        }

        public void MarkOrderAsPaid(int paidOrderId)
        {
            ordersRepository.Update(paidOrderId);
        }
    }
 }