using Microsoft.EntityFrameworkCore;

namespace PortfolioMVC.Models
{
    public class PersonRepository :IPersonRepository
    {
        private readonly AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Person> GetAll => _appDbContext.Person.Include(i=>i.Image);

        public Person Add(Person newItem)
        {
            _appDbContext.Add(newItem);
            return newItem;
        }

        public Person GetById(int id)
        {
            return _appDbContext.Person.Include(i=>i.Image).Where(p => p.Id == id).FirstOrDefault();
        }

        public Person Remove(int id)
        {
            var person = GetById(id);
            if (person != null)
                _appDbContext.Person.Remove(person);
            return person;
        }

        public Person Update(Person updatedItem)
        {
            var entity = _appDbContext.Person.Attach(updatedItem);
            entity.State = EntityState.Modified;
            return updatedItem;
        }
    }
}
