using Kunskapsprov.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Kunskapsprov.Connection
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Person { get; set; }
        Task<int> SaveChanges();
    }
}