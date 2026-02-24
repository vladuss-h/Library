namespace Library.App.Models
{
    public class Loan : BaseEntity
    {
        public int Id { get; set; }   // primárny kľúč

        public int BookId { get; set; }   // FK na knihu
        public Book Book { get; set; }   // navigačná vlastnosť

        public int ReaderId { get; set; }   // FK na čitateľa
        public Reader Reader { get; set; }   // navigačná vlastnosť

        public DateTime BorrowedAt { get; set; }   // dátum požičania

        public DateTime? ReturnedAt { get; set; }   // dátum vrátenia ak ešte nevrátená tak null
    }
}