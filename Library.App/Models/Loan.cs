namespace Library.App.Models
{
    public class Loan : BaseEntity
    {
        public int BookId { get; set; }//FK
        public Book Book { get; set; }

        public int ReaderId { get; set; }//FK
        public Reader Reader { get; set; }

        public DateTime BorrowedAt { get; set; }
        public DateTime? ReturnedAt { get; set; } // nullable, protože kniha môže byť stále požičaná (aktívna výpožička = ReturnDate je null)
    }
}