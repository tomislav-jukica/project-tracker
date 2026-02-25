using MediatR;
using ProjectTracker.Application.Projects.Interfaces;
using ProjectTracker.Domain.Projects;

namespace ProjectTracker.Application.Projects.Commands.CreateProject
{
    public class CreateProjectHandler(IProjectRepository repository) : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectRepository _repository = repository;

        public async Task<Guid> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
        {
            var project = new Project(command.Name, command.RootFolderPath);

            await _repository.AddAsync(project);

            return project.Id;
        }
    }
}
