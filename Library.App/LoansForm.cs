using Library.App.Data;
using Library.App.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.App
{
    public partial class LoansForm : Form
    {
        private readonly ApplicationDbContext _context;

        public LoansForm()
        {
            InitializeComponent();

            _context = new ApplicationDbContextFactory().CreateDbContext(new string[] { });

            this.Load += LoansForm_Load;
            btnBorrow.Click += BtnBorrow_Click;
            btnReturn.Click += BtnReturn_Click;
        }

        private async void LoansForm_Load(object sender, EventArgs e)
        {
            await LoadReadersAndBooks();
            await LoadActiveLoans();
        }

        private async Task LoadReadersAndBooks()
        {
            var readers = await _context.Readers
                .OrderBy(r => r.LastName)
                .ThenBy(r => r.FirstName)
                .ToListAsync();

            cbReaders.DataSource = readers;
            cbReaders.DisplayMember = "FullName";
            cbReaders.ValueMember = "Id";

            var books = await _context.Books
                .OrderBy(b => b.Title)
                .ToListAsync();

            cbBooks.DataSource = books;
            cbBooks.DisplayMember = "Title";
            cbBooks.ValueMember = "Id";
        }

        private async Task LoadActiveLoans()
        {
            var activeLoans = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .Where(l => l.ReturnedAt == null)
                .OrderByDescending(l => l.BorrowedAt)
                .Select(l => new
                {
                    l.Id,
                    Book = l.Book.Title,
                    Reader = l.Reader.FirstName + " " + l.Reader.LastName,
                    BorrowedAt = l.BorrowedAt
                })
                .ToListAsync();

            dgActiveLoans.DataSource = activeLoans;
            dgActiveLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgActiveLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgActiveLoans.MultiSelect = false;
            dgActiveLoans.ReadOnly = true;
        }

        private async void BtnBorrow_Click(object sender, EventArgs e)
        {
            if (cbReaders.SelectedValue == null || cbBooks.SelectedValue == null)
            {
                MessageBox.Show("Vyber čitateľa aj knihu.");
                return;
            }

            int readerId = (int)cbReaders.SelectedValue;
            int bookId = (int)cbBooks.SelectedValue;

            bool alreadyLoaned = await _context.Loans
                .AnyAsync(l => l.BookId == bookId && l.ReturnedAt == null);

            if (alreadyLoaned)
            {
                MessageBox.Show("Táto kniha je už požičaná.");
                return;
            }

            var loan = new Loan
            {
                ReaderId = readerId,
                BookId = bookId,
                BorrowedAt = DateTime.Now,
                ReturnedAt = null
            };

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            await LoadActiveLoans();
            MessageBox.Show("Výpožička bola vytvorená.");
        }

        private async void BtnReturn_Click(object sender, EventArgs e)
        {
            if (dgActiveLoans.CurrentRow == null)
            {
                MessageBox.Show("Vyber výpožičku v tabuľke.");
                return;
            }

            int loanId = (int)dgActiveLoans.CurrentRow.Cells["Id"].Value;

            var loan = await _context.Loans.FirstOrDefaultAsync(l => l.Id == loanId);
            if (loan == null)
            {
                MessageBox.Show("Výpožička sa nenašla.");
                return;
            }

            loan.ReturnedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            await LoadActiveLoans();
            MessageBox.Show("Kniha bola vrátená.");
        }
    }
}