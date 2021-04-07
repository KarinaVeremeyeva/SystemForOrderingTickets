using System.Data.Entity;

namespace SystemForOrderingTickets.Models
{
    public class PlayContext : DbContext
    {
        public PlayContext() : base("TheaterDb")
        { }
        public DbSet<Play> Plays { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Date> Dates { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}