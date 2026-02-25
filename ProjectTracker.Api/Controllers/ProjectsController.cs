using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Application.Projects.Commands.CreateProject;
using ProjectTracker.Application.Projects.Commands.DeleteProject;

namespace ProjectTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
        {
            var projectId = await _mediator.Send(command);
            return Ok(projectId);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProjectCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
