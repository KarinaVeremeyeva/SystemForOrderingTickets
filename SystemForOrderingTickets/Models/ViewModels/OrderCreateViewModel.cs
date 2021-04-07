using System.Collections.Generic;
using SystemForOrderingTickets.Models.ViewModels;

namespace SystemForOrderingTickets.Models
{
    public class OrderCreateViewModel
    {
        public int DateId { get; set; }

        public int LoginId { get; set; }

        public List<CategoryQuantityViewModel> Quantities { get; set; }
    }
}