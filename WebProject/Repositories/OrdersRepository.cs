using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebProject.Models;

namespace WebProject.Repositories
{
    public class OrdersRepository
    {
        private static List<Order> Orders;

        public Order Get(int orderId)
        {
            return Orders.FirstOrDefault(q => q.Id == orderId);
        }

        public List<Order> GetCurrentDate(int orderId)
        {
            List<Order> result = null;

            using (var db = new PlayContext())
            {
                result = db.Orders.Where(q => q.Id == orderId).Include(q => q.Date).ToList();
            }

            return result;
        }

        public List<Order> GetOrders()
        {
            List<Order> result = null;

            using (var db = new PlayContext())
            {
                result = db.Orders
                    .Include(q => q.Login)
                    .Include(q => q.Date)
                    .ToList();
            }

            return result;
        }

        public void Create(Order order)
        {
            using (var db = new PlayContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public void RemoveRange(IEnumerable<int> ordersToRemoveIds)
        {
            using (var db = new PlayContext())
            {
                var ordersToCancel = db.Orders
                    .Where(q => ordersToRemoveIds.Contains(q.Id));

                db.Orders.RemoveRange(ordersToCancel);

                db.SaveChanges();
            }
        }

        public void Update(int orderId)
        {
            using (var db = new PlayContext())
            {
                var order = db.Orders.First(q => q.Id == orderId);
                order.IsPaid = true;
                db.Entry(order).State = EntityState.Modified;

                db.SaveChanges();
            }       
        }
    }
}