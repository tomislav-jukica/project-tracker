using MediatR;
using ProjectTracker.Application.Projects.Interfaces;

namespace ProjectTracker.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectHandler(IProjectRepository projectRepository) : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetAsync(request.Id);
            if (project == null) throw new KeyNotFoundException($"Project with ID '{request.Id}' not found");
            await _projectRepository.RemoveAsync(project);
        }
    }
}
