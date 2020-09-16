using System.Collections.Generic;

namespace WebProject.Models
{
    public class Play
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }

        public List<Date> Dates { get; set; }
    }
}