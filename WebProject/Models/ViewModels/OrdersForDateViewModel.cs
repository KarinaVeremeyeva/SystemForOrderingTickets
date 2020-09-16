using System.Collections.Generic;
using WebProject.Models.ViewModels;

namespace WebProject.Models
{
    public class OrdersForDateViewModel
    {
        public int DateId { get; set; }

        public int LoginId { get; set; }

        public List<CategoriesForTableViewModel> Categories { get; set; }

        public string PlayName { get; set; }

        public string AuthorName { get; set; }

        public List<DateViewModel> Dates { get; set; }
    }
}