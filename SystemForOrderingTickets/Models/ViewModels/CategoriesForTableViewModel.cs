namespace SystemForOrderingTickets.Models.ViewModels
{
    public class CategoriesForTableViewModel
    {
        public string Category { get; set; }

        public int CategoryId { get; set; }

        public int Quantity { get; set; }

        public decimal TicketPrice { get; set; }

        public int TotalTickets { get; set; }

        public int AvailableTickets { get; set; }

        public int PaidTickets { get; set; }

        public int OrderedTickets { get; set; }
    }
}