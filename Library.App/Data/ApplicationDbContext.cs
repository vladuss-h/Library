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

        public DbSet<Book> Books { get; set; }///repezentuje tabuľku kníh v databáze
        public DbSet<Reader> Readers { get; set; }///reprezentuje tabuľku čitateľov v databáze
        public DbSet<Loan> Loans { get; set; }///reprezentuje tabuľku výpožičiek v databáze

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=library.db");///nastavenie pripojenia k SQLite databáze, ak ešte není nakonfigurované
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.BookId)
                .IsUnique();

            modelBuilder.Entity<Reader>()
                .HasIndex(r => r.IdNumber)
                .IsUnique();

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)         
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Reader)
                .WithMany(r => r.Loans)          
                .HasForeignKey(l => l.ReaderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}