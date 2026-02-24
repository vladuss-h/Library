using Library.App.Models;

namespace Library.App.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext db)
        {
            // kontrola dát v DB - ak už existujú, tak sa nevykoná žiadna operácia
            if (db.Books.Any() || db.Readers.Any() || db.Loans.Any())
                return;

            var books = new List<Book>
            {
                new Book { BookId = 1001, Title = "Hobit", Author = "J R R Tolkien", IsBorrowed = false },
                new Book { BookId = 1002, Title = "1984", Author = "George Orwell", IsBorrowed = true },
                new Book { BookId = 1003, Title = "Duna", Author = "Frank Herbert", IsBorrowed = false },
                new Book { BookId = 1004, Title = "Malý princ", Author = "Antoine de Saint Exupéry", IsBorrowed = false },
                new Book { BookId = 1005, Title = "Červenáči", Author = "Juraj Červenák", IsBorrowed = false }
            };

            var readers = new List<Reader>
            {
                new Reader { IdNumber = "EA123456", FirstName = "Jana", LastName = "Nováková", DateOfBirth = new DateTime(1995, 3, 12) },
                new Reader { IdNumber = "EB654321", FirstName = "Peter", LastName = "Kováč", DateOfBirth = new DateTime(1990, 11, 2) },
                new Reader { IdNumber = "EC777888", FirstName = "Veronika", LastName = "Rusnáková", DateOfBirth = new DateTime(1998, 6, 25) }
            };

            db.Books.AddRange(books);
            db.Readers.AddRange(readers);
            db.SaveChanges();

            // aktívna výpožička (napr.:kniha 1002 je označená ako požičaná)
            var book1984 = db.Books.First(b => b.BookId == 1002);
            var reader1 = db.Readers.First();

            db.Loans.Add(new Loan
            {
                BookId = book1984.Id,
                ReaderId = reader1.Id,
                BorrowedAt = DateTime.Now.AddDays(-2),
                ReturnedAt = null
            });

            db.SaveChanges();
        }
    }
}