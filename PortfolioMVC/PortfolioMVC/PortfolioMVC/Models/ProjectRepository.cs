using Microsoft.EntityFrameworkCore;

namespace PortfolioMVC.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProjectRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Project> GetAll => _appDbContext.Projects.Include(i => i.Image);

        public Project Add(Project newItem)
        {
            _appDbContext.Add(newItem);
            return newItem;
        }

        public Project GetById(int id)
        {
            return _appDbContext.Projects.Include(i => i.Image).Where(p => p.Id == id).FirstOrDefault();
        }

        public Project Remove(int id)
        {
            var project = GetById(id);
            if (project != null)
                _appDbContext.Projects.Remove(project);
            return project;
        }

        public Project Update(Project updatedItem)
        {
            var entity = _appDbContext.Projects.Attach(updatedItem);
            entity.State = EntityState.Modified;
            return updatedItem;
        }
    }
}
