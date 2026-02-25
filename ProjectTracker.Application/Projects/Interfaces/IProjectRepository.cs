using ProjectTracker.Domain.Projects;

namespace ProjectTracker.Application.Projects.Interfaces
{
    public interface IProjectRepository
    {
        Task AddAsync(Project project);
        Task RemoveAsync(Project project);
        Task<Project?> GetAsync(string name);
        Task<Project?> GetAsync(Guid id);
    }
}
