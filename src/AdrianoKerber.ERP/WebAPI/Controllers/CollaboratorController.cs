using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly ILogger<CollaboratorController> _logger;

        public CollaboratorController(ILogger<CollaboratorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Collaborator> GetCollaborators()
        {
            _logger.LogDebug("Collaborators' :GET called!"); // TODO: add sirilog!
            //throw new NotImplementedException();
            return new List<Collaborator> { new Collaborator("Adriano", "Kerber", "12345678910") };
        }
    }
}
