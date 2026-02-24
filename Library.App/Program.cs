using Library.App.Data;

namespace Library.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // vytvorenie databázy a naplnenie testovacími dátami
            using (var db = new ApplicationDbContext())
            {
                db.Database.EnsureCreated();
                DbSeeder.Seed(db);
            }

            Application.Run(new Form1());
        }
    }
}