namespace PortfolioMVC.Models
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAll { get; }
        Project GetById(int id);
        Project Add(Project newItem);
        Project Update(Project updatedItem);
        Project Remove(int id);
    }
}
