using ClosedXML.Excel;
using Library.App.Data; //prepojenie knižníc s DB
using Library.App.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ClosedXML.Excel;

namespace Library.App
{
    public partial class Form1 : Form
    {
        private int? _editingBookId = null;
        public Form1()
        {
            InitializeComponent();
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = false;
            LoadBooks();
        }

        private void LoadBooks()
        {
            using (var db = new ApplicationDbContext())
            {
                dgvBooks.AutoGenerateColumns = true;
                dgvBooks.DataSource = db.Books
    .Select(b => new
    {
        b.Id,
        b.BookId,
        b.Title,
        b.Author,
    })
    .ToList();
            }

            // UI formátovanie tabuľky:
            // po nastavení DataSource upravujeme viditeľnosť a názvy stĺpcov,
            // aby boli zrozumiteľné pre používateľa
            HideIfExists("Id");
            HideIfExists("CreatedAt");

            SetHeaderIfExists("BookId", "ID");
            SetHeaderIfExists("Title", "Názov");
            SetHeaderIfExists("Author", "Autor");
            SetHeaderIfExists("IsBorrowed", "Požičaná");
        }
        private void HideIfExists(string colName)
        {
            if (dgvBooks.Columns.Contains(colName))
                dgvBooks.Columns[colName].Visible = false;
        }

        private void SetHeaderIfExists(string colName, string header)
        {
            if (dgvBooks.Columns.Contains(colName))
                dgvBooks.Columns[colName].HeaderText = header;
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0) return;

            var row = dgvBooks.SelectedRows[0];

            _editingBookId = (int)row.Cells["BookId"].Value;
            txtTitle.Text = row.Cells["Title"].Value?.ToString() ?? "";
            txtAuthor.Text = row.Cells["Author"].Value?.ToString() ?? "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            var title = txtTitle.Text.Trim();
            var author = txtAuthor.Text.Trim();

            // jednoducha kontrola povinnych poli
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Zadaj názov knihy");
                return;
            }

            using (var db = new ApplicationDbContext())
            {
                var nextBookId = 1;
                if (db.Books.Any())
                    nextBookId = db.Books.Max(b => b.BookId) + 1;

                // kontrola duplicity
                if (db.Books.Any(b => b.BookId == nextBookId))
                {
                    MessageBox.Show("Duplicita ID knihy");
                    return;
                }

                var book = new Book
                {
                    BookId = nextBookId,
                    Title = title,
                    Author = author,
                    IsBorrowed = false
                };

                db.Books.Add(book);
                db.SaveChanges();
            }

            // vycistit polia
            txtTitle.Text = "";
            txtAuthor.Text = "";

            // refresh grid
            LoadBooks();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Kontrola, či je vybraný riadok
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vyber knihu, ktorú chceš zmazať.");
                return;
            }

            // Získame ID vybranej knihy z tabuľky
            var selectedRow = dgvBooks.SelectedRows[0];
            int bookId = (int)selectedRow.Cells["BookId"].Value;

            // Potvrdenie od používateľa
            var confirmResult = MessageBox.Show(
                "Naozaj chceš zmazať túto knihu?",
                "Potvrdenie",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.No)
                return;

            // Vymazanie z databázy
            using (var db = new ApplicationDbContext())
            {
                var book = db.Books.FirstOrDefault(b => b.BookId == bookId);

                if (book != null)
                {
                    bool hasAnyLoans = db.Loans.Any(l => l.BookId == book.Id);
                    bool isCurrentlyBorrowed = db.Loans.Any(l => l.BookId == book.Id && l.ReturnedAt == null);

                    if (isCurrentlyBorrowed)
                    {
                        MessageBox.Show("Knihu nie je možné zmazať, pretože je momentálne požičaná.");
                        return;
                    }

                    if (hasAnyLoans)
                    {
                        MessageBox.Show("Knihu nie je možné zmazať, pretože má históriu výpožičiek.");
                        return;
                    }

                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }

            // Obnovenie tabuľky
            LoadBooks();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_editingBookId == null)
            {
                MessageBox.Show("Vyber knihu na úpravu.");
                return;
            }

            btnAddBook.Enabled = false;
            btnSaveEdit.Visible = true;
        }

        private void btnOpenReaders_Click(object sender, EventArgs e)
        {
            var f = new ReadersForm();
            f.ShowDialog();
        }
        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (_editingBookId == null)
            {
                MessageBox.Show("Vyber knihu na úpravu.");
                return;
            }

            var title = txtTitle.Text.Trim();
            var author = txtAuthor.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Názov je povinný.");
                return;
            }

            using (var db = new ApplicationDbContext())
            {
                var book = db.Books.FirstOrDefault(b => b.BookId == _editingBookId.Value);

                if (book == null)
                {
                    MessageBox.Show("Kniha sa nenašla (možno bola zmazaná).");
                    return;
                }

                book.Title = title;
                book.Author = author;

                db.SaveChanges();
            }

            // reset režimu
            _editingBookId = null;
            txtTitle.Text = "";
            txtAuthor.Text = "";
            btnAddBook.Enabled = true;
            btnSaveEdit.Visible = false;

            LoadBooks();
        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            new LoansForm().ShowDialog();
        }

        private void btnOpenReaders_Click_1(object sender, EventArgs e)
        {
            var readersForm = new ReadersForm();
            readersForm.ShowDialog();
        }

        private void btnLoans_Click_1(object sender, EventArgs e)
        {
            new LoansForm().ShowDialog();
            LoadBooks();
        }

        private void btnWhoHasBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null)
            {
                MessageBox.Show("Vyber knihu v tabuľke.");
                return;
            }

            int bookDbId = Convert.ToInt32(dgvBooks.CurrentRow.Cells["Id"].Value);

            using (var db = new ApplicationDbContext())
            {
                var loan = db.Loans
                    .Include(l => l.Reader)
                    .FirstOrDefault(l => l.BookId == bookDbId && l.ReturnedAt == null);

                if (loan == null)
                {
                    MessageBox.Show("Kniha nie je požičaná.");
                    return;
                }

                MessageBox.Show($"Knihu má požičanú: {loan.Reader.FirstName} {loan.Reader.LastName}");
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Filter = "Excel súbory (*.xlsx)|*.xlsx";
            dialog.Title = "Vyber Excel súbor s knihami";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            int imported = 0;
            int skipped = 0;

            using (var db = new ApplicationDbContext())
            using (var wb = new XLWorkbook(dialog.FileName))
            {
                var ws = wb.Worksheets.First(); // prvý sheet
                var rows = ws.RangeUsed().RowsUsed().Skip(1); // preskoč hlavičku

                foreach (var row in rows)
                {
                    // A=BookId, B=Title, C=Author
                    var bookIdText = row.Cell(1).GetString().Trim();
                    var title = row.Cell(2).GetString().Trim();
                    var author = row.Cell(3).GetString().Trim();

                    if (!int.TryParse(bookIdText, out int bookId) || string.IsNullOrWhiteSpace(title))
                    {
                        skipped++;
                        continue;
                    }

                    // kontrola duplicity BookId
                    if (db.Books.Any(b => b.BookId == bookId))
                    {
                        skipped++;
                        continue;
                    }

                    db.Books.Add(new Book
                    {
                        BookId = bookId,
                        Title = title,
                        Author = author
                    });

                    imported++;
                }

                db.SaveChanges();
            }

            LoadBooks(); // refresh tabuľky kníh
            MessageBox.Show($"Import hotový.\nPridané: {imported}\nPreskočené: {skipped}");
        }
    }
}