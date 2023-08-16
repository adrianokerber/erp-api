using Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly ILogger<CollaboratorController> _logger;
        private readonly ICollaboratorRepository _collaboratorRepository;

        public CollaboratorController(ILogger<CollaboratorController> logger, ICollaboratorRepository collaboratorRepository)
        {
            _logger = logger;
            _collaboratorRepository = collaboratorRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCollaborators()
        {
            var collaborators = await _collaboratorRepository.GetAll();

            _logger.LogDebug(">>>>>>>>>> GetCollaborators result:\n{@collaborators}", collaborators);

            return Ok(collaborators);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> GetCollaboratorById(Guid id)
        {
            var collaborator = await _collaboratorRepository.GetById(id);
            if (collaborator == null)
                return NotFound();

            return Ok(collaborator);
        }
    }
}
