using Microsoft.EntityFrameworkCore;
namespace Contacts.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Models.Contacts> MyContacts { get; set; }
    }
}
