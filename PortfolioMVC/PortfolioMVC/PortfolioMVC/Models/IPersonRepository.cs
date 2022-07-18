namespace PortfolioMVC.Models
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll { get; }
        Person GetById(int id);
        Person Add(Person newItem);
        Person Update(Person updatedItem);
        Person Remove(int id);
    }
}