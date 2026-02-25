namespace Library.App.Models
{
    public class Reader : BaseEntity
    {
        public int Id { get; set; }   // primárny kľúč pre databázu
        public string IdNumber { get; set; }   // číslo občianskeho preukazu
        public string FirstName { get; set; }  // meno
        public string LastName { get; set; }   // priezvisko
        public DateTime DateOfBirth { get; set; }  // dátum narodenia

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public string FullName => $"{FirstName} {LastName}";
    }
}