using Kunskapsprov.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Kunskapsprov.Connection
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }

        public new async Task<int> SaveChanges()
    {
        return await base.SaveChangesAsync();
    }
    }
}
