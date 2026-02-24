namespace Library.App.Models
{
    public class Book : BaseEntity
    {
        public int Id { get; set; }   // primárny kľúč pre databázu
        public int BookId { get; set; }  // ID knihy podľa zadania
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; set; }
    }
}