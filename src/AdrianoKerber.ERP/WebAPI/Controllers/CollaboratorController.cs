using Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCollaborators()
        {
            try
            {
                var collaborators = await _collaboratorRepository.GetAll();

                _logger.LogDebug(">>>>>>>>>> GetCollaborators result:\n{@collaborators}", collaborators);

                return Ok(collaborators);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error!");

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCollaboratorById(string id)
        {
            // TODO: add validator for input parameters
            if (!Guid.TryParse(id, out var collaboratorId))
                return BadRequest(ModelState);
            try
            {
                var collaborator = await _collaboratorRepository.GetById(collaboratorId);
                return Ok(collaborator);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error!");

                return StatusCode(500, ex.Message);
            }
        }
    }
}
