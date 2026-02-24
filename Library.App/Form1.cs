using Library.App.Data; //prepojenie knižníc s DB
using System.Linq;

namespace Library.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            using (var db = new ApplicationDbContext())
            {
                dgvBooks.DataSource = db.Books.ToList();
            }
        }
    }
}
