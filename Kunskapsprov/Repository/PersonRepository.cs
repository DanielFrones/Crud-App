using Kunskapsprov.Connection;
using Kunskapsprov.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kunskapsprov.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private IApplicationDbContext _dbcontext;
        public PersonRepository(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Create(Person Person)
        {
            _dbcontext.Person.Add(Person);
            await _dbcontext.SaveChanges();
            return Person.Id;
        }
        public async Task<List<Person>> GetAll()
        {
            var Person = await _dbcontext.Person.ToListAsync<Person>();
            return Person;
        }
        public async Task<Person> GetById(int id)
        {
            var Person = await _dbcontext.Person.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            return Person;
        }
        public async Task<string> Update(int id, Person Person)
        {
            var person = await _dbcontext.Person.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            if (person == null) return "Person does not exists";
            person.FirstName = Person.FirstName;
            person.LastName= Person.LastName;
            person.Address = Person.Address;
            await _dbcontext.SaveChanges();
            return "Person details successfully modified";
        }
        public async Task<string> Delete(int id)
        {
            var Person = _dbcontext.Person.Where(empid => empid.Id == id).FirstOrDefault();
            if (Person == null) return "Person does not exists";
            _dbcontext.Person.Remove(Person);
            await _dbcontext.SaveChanges();
            return "Person details deleted modified";
        }
    }
}
