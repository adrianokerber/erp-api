using ErpBackend.Service.Contracts;
using ErpBackend.Service.ViewModels;
using ErpBackend.Service.Views.Collaborator.Response;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly ILogger<CollaboratorController> _logger;
        private readonly ICollaboratorService _collaboratorService;

        public CollaboratorController(ILogger<CollaboratorController> logger, ICollaboratorService collaboratorService)
        {
            _logger = logger;
            _collaboratorService = collaboratorService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModel<IEnumerable<ListCollaboratorResponse>>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCollaborators()
        {
            var collaborators = await _collaboratorService.ListAsync().ConfigureAwait(false);

            _logger.LogDebug(">>>>>>>>>> GetCollaborators result:\n{@collaborators}", collaborators);

            return Ok(collaborators);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModel<GetByIdCollaboratorResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> GetCollaboratorById(Guid id)
        {
            var collaborator = await _collaboratorService.GetByIdAsync(id).ConfigureAwait(false);
            if (collaborator == null)
                return NotFound();

            return Ok(collaborator);
        }
    }
}
