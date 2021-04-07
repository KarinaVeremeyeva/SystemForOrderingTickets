using System.Collections.Generic;

namespace SystemForOrderingTickets.Models.ViewModels
{
    public class ReportViewModel
    {
        public int TotalTicketsCount { get; set; }

        public decimal TotalTicketsPrice { get; set; }

        public List<CategoryReportViewModel> Categories { get; set; }

        public class CategoryReportViewModel
        {
            public string CategoryName { get; set; }

            public int Quantity { get; set; }

            public decimal Price { get; set; }

        }
    }
}