using Library.App.Data;
using Library.App.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Library.App
{
    public partial class ReadersForm : Form
    {
        private int? _editingReaderId = null;
        public ReadersForm()
        {
            InitializeComponent();

            dgvReaders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReaders.MultiSelect = false;
            dgvReaders.ReadOnly = true;
            dgvReaders.AllowUserToAddRows = false;

            LoadReaders();
        }

        private void LoadReaders()
        {
            using (var db = new ApplicationDbContext())
            {
                dgvReaders.AutoGenerateColumns = true;
                dgvReaders.DataSource = db.Readers.ToList();
            }

            // UI
            if (dgvReaders.Columns.Contains("Id")) dgvReaders.Columns["Id"].Visible = false;
            if (dgvReaders.Columns.Contains("CreatedAt")) dgvReaders.Columns["CreatedAt"].Visible = false;
            if (dgvReaders.Columns.Contains("Loans")) dgvReaders.Columns["Loans"].Visible = false;
            if (dgvReaders.Columns.Contains("FullName")) dgvReaders.Columns["FullName"].Visible = false;

            if (dgvReaders.Columns.Contains("IdNumber")) dgvReaders.Columns["IdNumber"].HeaderText = "Číslo OP";
            if (dgvReaders.Columns.Contains("FirstName")) dgvReaders.Columns["FirstName"].HeaderText = "Meno";
            if (dgvReaders.Columns.Contains("LastName")) dgvReaders.Columns["LastName"].HeaderText = "Priezvisko";
            if (dgvReaders.Columns.Contains("DateOfBirth")) dgvReaders.Columns["DateOfBirth"].HeaderText = "Dátum narodenia";
        }

        private void btnAddReader_Click(object sender, EventArgs e)
        {
            var idNumber = txtIdNumber.Text.Trim();
            var firstName = txtFirstName.Text.Trim();
            var lastName = txtLastName.Text.Trim();
            var dob = dtpDateOfBirth.Value.Date;

            // povinné polia
            if (string.IsNullOrWhiteSpace(idNumber) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Vyplň Číslo OP, Meno a Priezvisko.");
                return;
            }

            using (var db = new ApplicationDbContext())
            {
                // duplicita OP
                if (db.Readers.Any(r => r.IdNumber == idNumber))
                {
                    MessageBox.Show("Čitateľ s týmto číslom OP už existuje.");
                    return;
                }

                db.Readers.Add(new Reader
                {
                    IdNumber = idNumber,
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dob
                });

                db.SaveChanges();
            }

            txtIdNumber.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";

            LoadReaders();
        }

        private void btnDeleteReader_Click(object sender, EventArgs e)
        {
            if (dgvReaders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vyber čitateľa, ktorého chceš zmazať.");
                return;
            }

            var row = dgvReaders.SelectedRows[0];
            int readerId = (int)row.Cells["Id"].Value;

            var confirm = MessageBox.Show("Naozaj chceš zmazať čitateľa?", "Potvrdenie", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No) return;

            using (var db = new ApplicationDbContext())
            {
                var reader = db.Readers.FirstOrDefault(r => r.Id == readerId);
                if (reader != null)
                {
                    db.Readers.Remove(reader);
                    db.SaveChanges();
                }
            }

            LoadReaders();
        }
        private void dgvReaders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReaders.SelectedRows.Count == 0) return;

            var row = dgvReaders.SelectedRows[0];

            _editingReaderId = (int)row.Cells["Id"].Value;

            txtIdNumber.Text = row.Cells["IdNumber"].Value?.ToString() ?? "";
            txtFirstName.Text = row.Cells["FirstName"].Value?.ToString() ?? "";
            txtLastName.Text = row.Cells["LastName"].Value?.ToString() ?? "";

            if (row.Cells["DateOfBirth"].Value != null)
                dtpDateOfBirth.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
        }

        private void btnEditReader_Click(object sender, EventArgs e)
        {
            if (_editingReaderId == null)
            {
                MessageBox.Show("Vyber čitateľa na úpravu.");
                return;
            }

            btnAddReader.Enabled = false;
            btnSaveReader.Visible = true;
        }

        private void btnSaveReader_Click(object sender, EventArgs e)
        {
            if (_editingReaderId == null)
            {
                MessageBox.Show("Vyber čitateľa na úpravu.");
                return;
            }

            var idNumber = txtIdNumber.Text.Trim();
            var firstName = txtFirstName.Text.Trim();
            var lastName = txtLastName.Text.Trim();
            var dob = dtpDateOfBirth.Value.Date;

            if (string.IsNullOrWhiteSpace(idNumber) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Vyplň všetky povinné polia.");
                return;
            }

            using (var db = new ApplicationDbContext())
            {
                var reader = db.Readers.FirstOrDefault(r => r.Id == _editingReaderId.Value);

                if (reader == null)
                {
                    MessageBox.Show("Čitateľ sa nenašiel.");
                    return;
                }

                reader.IdNumber = idNumber;
                reader.FirstName = firstName;
                reader.LastName = lastName;
                reader.DateOfBirth = dob;

                db.SaveChanges();
            }

            _editingReaderId = null;
            txtIdNumber.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";

            btnAddReader.Enabled = true;
            btnSaveReader.Visible = false;

            LoadReaders();
        }
    }
}