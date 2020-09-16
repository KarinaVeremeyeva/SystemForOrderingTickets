using System;

namespace WebProject.Models
{
    [Serializable]
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalTickets { get; set; }

        public decimal TicketPrice { get; set; }

        public Category() { }
    }
}