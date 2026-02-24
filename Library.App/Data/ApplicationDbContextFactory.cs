using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Library.App.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Data Source=library.db")
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}