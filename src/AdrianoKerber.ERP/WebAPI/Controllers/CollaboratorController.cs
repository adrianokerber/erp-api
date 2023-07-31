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
        public async Task<IActionResult> GetCollaboratorById(string id)
        {
            if (!int.TryParse(id, out int idNumber))
                return BadRequest(ModelState);
            try
            {
                var collaborator = await _collaboratorRepository.GetCollaborator(idNumber);
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
