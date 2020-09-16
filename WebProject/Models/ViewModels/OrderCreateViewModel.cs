using System.Collections.Generic;
using WebProject.Models.ViewModels;

namespace WebProject.Models
{
    public class OrderCreateViewModel
    {
        public int DateId { get; set; }

        public int LoginId { get; set; }

        public List<CategoryQuantityViewModel> Quantities { get; set; }
    }
}