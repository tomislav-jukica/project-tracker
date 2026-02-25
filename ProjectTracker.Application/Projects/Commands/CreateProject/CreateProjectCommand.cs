using MediatR;

namespace ProjectTracker.Application.Projects.Commands.CreateProject
{
    public record CreateProjectCommand(string Name, string RootFolderPath) : IRequest<Guid>;
}
