using System;

namespace WebProject.Models.ViewModels
{
    public class UnpaidOrdersViewModel
    {
        public int Id { get; set; }

        public DateTime PlayDate { get; set; }

        public string UserName { get; set; }

        public string CategoryName { get; set; }

        public int Quantity { get; set; }
    }
}