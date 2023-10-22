using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EBill.Models.Domain
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base (options)
        {

        }

        public DbSet<pcModel> pcModel { get; set; }
        public DbSet<Warranty> Warranty { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Bill> Bill{ get; set; }
    }
}
