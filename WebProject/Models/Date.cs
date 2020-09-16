using System;

namespace WebProject.Models
{
    public class Date
    {
        public int Id { get; set; }

        public int PlayId { get; set; }

        public Play Play { get; set; }

        public DateTime PlayDate { get; set; }
    }
}