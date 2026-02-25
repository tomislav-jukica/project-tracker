using Microsoft.EntityFrameworkCore;
using ProjectTracker.Application.Projects.Interfaces;
using ProjectTracker.Domain.Projects;
using ProjectTracker.Infrastructure.Persistence;

namespace ProjectTracker.Infrastructure.Repositories
{
    public class ProjectRepository(AssetDbContext context) : IProjectRepository
    {
        private readonly AssetDbContext _context = context;

        public async Task AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task<Project?> GetAsync(string name)
        {
            return await _context.Projects.Where(x => x.Name == name).SingleOrDefaultAsync();
        }

        public async Task<Project?> GetAsync(Guid id)
        {
            return await _context.Projects.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task RemoveAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
