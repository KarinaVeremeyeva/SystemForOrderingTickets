using System;
using System.Data.Entity;
using System.Linq;
using SystemForOrderingTickets.Services;

namespace SystemForOrderingTickets.Models
{
    public class PlayDbInitializer : CreateDatabaseIfNotExists<PlayContext>
    {
        protected override void Seed(PlayContext db)
        {
            var service = new XMLReaderService();
            var plays = service.ReadXMLFile<Play>("file-path");
            var authors = service.ReadXMLFile<Author>("file-path");
            var genres = service.ReadXMLFile<Genre>("file-path");

            // Устранение дубляжей
            var existingPlaysIds = db.Plays.Select(q => q.Id).ToList();
            var playsToSave = plays.Where(q => !existingPlaysIds.Contains(q.Id));
            db.Plays.AddRange(playsToSave);

            var existingAuthorsIds = db.Authors.Select(q => q.Id).ToList();
            var authorsToSave = authors.Where(q => !existingAuthorsIds.Contains(q.Id));
            db.Authors.AddRange(authorsToSave);

            var existingGenresIds = db.Genres.Select(q => q.Id).ToList();
            var genresToSave = genres.Where(q => !existingGenresIds.Contains(q.Id));
            db.Genres.AddRange(genresToSave);

            db.Authors.Add(new Author { Id = 0, Name = "A. Eykborn" });
            db.Authors.Add(new Author { Id = 1, Name = "A. Dudarau" });
            db.Authors.Add(new Author { Id = 2, Name = "M. Zadornov" });
            db.Authors.Add(new Author { Id = 3, Name = "W. Shakespeare" });
            db.Authors.Add(new Author { Id = 4, Name = "H. Ibsen" });
            db.Authors.Add(new Author { Id = 5, Name = "A. Chekhov" });
            db.Authors.Add(new Author { Id = 6, Name = "N. Gogol" });

            db.Genres.Add(new Genre { Id = 0, Name = "Comedy" });
            db.Genres.Add(new Genre { Id = 1, Name = "Dramatic ballad" });
            db.Genres.Add(new Genre { Id = 2, Name = "Play" });
            db.Genres.Add(new Genre { Id = 3, Name = "Tragedy" });
            db.Genres.Add(new Genre { Id = 4, Name = "Realism" });
            db.Genres.Add(new Genre { Id = 5, Name = "Drama" });
            db.Genres.Add(new Genre { Id = 6, Name = "Satire" });

            db.Plays.Add(new Play { Id = 0, Name = "Synthesizer love", AuthorId = 1, GenreId = 1 });
            db.Plays.Add(new Play { Id = 1, Name = "Do not leave me …", AuthorId = 2, GenreId = 2 });
            db.Plays.Add(new Play { Id = 2, Name = "Love adventure", AuthorId = 0, GenreId = 1 });
            db.Plays.Add(new Play { Id = 3, Name = "Hamlet", AuthorId = 3, GenreId = 3 });
            db.Plays.Add(new Play { Id = 4, Name = "A Doll's House", AuthorId = 4, GenreId = 4 });
            db.Plays.Add(new Play { Id = 5, Name = "Three Sisters", AuthorId = 5, GenreId = 5 });
            db.Plays.Add(new Play { Id = 6, Name = "Dead Souls", AuthorId = 6, GenreId = 6 });

            db.Dates.Add(new Date { Id = 0, PlayId = 0, PlayDate = new DateTime(2020, 1, 1) });
            db.Dates.Add(new Date { Id = 1, PlayId = 0, PlayDate = new DateTime(2020, 1, 2) });
            db.Dates.Add(new Date { Id = 2, PlayId = 1, PlayDate = new DateTime(2020, 1, 3) });
            db.Dates.Add(new Date { Id = 3, PlayId = 1, PlayDate = new DateTime(2020, 1, 4) });
            db.Dates.Add(new Date { Id = 4, PlayId = 2, PlayDate = new DateTime(2020, 1, 5) });
            db.Dates.Add(new Date { Id = 5, PlayId = 2, PlayDate = new DateTime(2020, 1, 6) });

            db.Dates.Add(new Date { Id = 6, PlayId = 3, PlayDate = new DateTime(2020, 1, 10) });
            db.Dates.Add(new Date { Id = 7, PlayId = 3, PlayDate = new DateTime(2020, 1, 12) });
            db.Dates.Add(new Date { Id = 8, PlayId = 3, PlayDate = new DateTime(2020, 1, 14) });
            db.Dates.Add(new Date { Id = 9, PlayId = 4, PlayDate = new DateTime(2020, 1, 16) });
            db.Dates.Add(new Date { Id = 10, PlayId = 4, PlayDate = new DateTime(2020, 1, 18) });
            db.Dates.Add(new Date { Id = 11, PlayId = 5, PlayDate = new DateTime(2020, 1, 20) });

            db.Dates.Add(new Date { Id = 12, PlayId = 5, PlayDate = new DateTime(2020, 1, 26) });
            db.Dates.Add(new Date { Id = 13, PlayId = 5, PlayDate = new DateTime(2020, 1, 30) });
            db.Dates.Add(new Date { Id = 14, PlayId = 6, PlayDate = new DateTime(2020, 2, 1) });
            db.Dates.Add(new Date { Id = 15, PlayId = 6, PlayDate = new DateTime(2020, 2, 3) });
            db.Dates.Add(new Date { Id = 16, PlayId = 6, PlayDate = new DateTime(2020, 2, 5) });
            db.Dates.Add(new Date { Id = 17, PlayId = 6, PlayDate = new DateTime(2020, 2, 6) });

            db.Logins.Add(new Login { Id = 0, Name ="user1", Password = "123456a", RoleId = 1, Email = "email@com", Phone = 123456 });
            db.Logins.Add(new Login { Id = 1, Name = "user2", Password = "asdfgh", RoleId = 1, Email = "email2@com", Phone = 987654 });
            db.Logins.Add(new Login { Id = 2, Name = "user3", Password = "567890a", RoleId = 1, Email = "emailqwerty@com", Phone = 456789 });
            db.Logins.Add(new Login { Id = 3, Name = "user4", Password = "zxcvbn", RoleId = 1, Email = "tre@com", Phone = 1212133 });
            db.Logins.Add(new Login { Id = 4, Name = "user5", Password = "qazwsx", RoleId = 1, Email = "email123@com", Phone = 1002030 });
            db.Logins.Add(new Login { Id = 5, Name = "courier01", Password = "mnbvcx", RoleId = 2, Email = "courier01@mail.com", Phone = 9008070 });
            db.Logins.Add(new Login { Id = 6, Name = "courier02", Password = "lkjhgf", RoleId = 2, Email = "courier02@mail.com", Phone = 7897000 });
            db.Logins.Add(new Login { Id = 7, Name = "admin", Password = "poiuyt", RoleId = 3, Email = "eafddwd@mail.com", Phone = 1230000 });
            db.Logins.Add(new Login { Id = 8, Name = "admin", Password = "567890b", RoleId = 3, Email = "admin@com", Phone = 8765432 });

            db.SaveChanges();
        }
    }
}