using Library.App.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=library.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // unikátne ID knihy 
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.BookId)
                .IsUnique();

            // unikátne číslo občianskeho preukazu
            modelBuilder.Entity<Reader>()
                .HasIndex(r => r.IdNumber)
                .IsUnique();

            // vzťah Loan -> Book
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany()
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // vzťah Loan -> Reader
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Reader)
                .WithMany()
                .HasForeignKey(l => l.ReaderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}