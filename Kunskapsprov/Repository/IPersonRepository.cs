using Kunskapsprov.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kunskapsprov.Repository
{
    public interface IPersonRepository
    {
        Task<int> Create(Person Person);
        Task<List<Person>> GetAll();
        Task<Person> GetById(int id);
        Task<string> Update(int id, Person Person);
        Task<string> Delete(int id);
    }
}
