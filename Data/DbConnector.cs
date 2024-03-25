using DeveloperAssessmentFor_KnilaItSolutions.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperAssessmentFor_KnilaItSolutions.Data
{
    public class DbConnector:DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Bulkdata> Bulkdatas { get; set; }
        // Other DbSet properties and configuration here

        public DbConnector(DbContextOptions<DbConnector> options) : base(options)
        {
        }

    }
}
