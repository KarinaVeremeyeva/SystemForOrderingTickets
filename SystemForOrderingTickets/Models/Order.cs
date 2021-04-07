namespace SystemForOrderingTickets.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int DateId { get; set; }

        public int LoginId { get; set; }

        public int CategoryId { get; set; }

        public int Quantity { get; set; }

        public bool IsPaid { get; set; }

        public Date Date { get; set; }

        public Login Login { get; set; }
    }
}