using MediatR;

namespace ProjectTracker.Application.Projects.Commands.DeleteProject
{
    public record DeleteProjectCommand(Guid Id) : IRequest;
}
