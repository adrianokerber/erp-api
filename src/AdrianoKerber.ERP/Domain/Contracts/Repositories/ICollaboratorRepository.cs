using Domain.Entities;

namespace Domain.Contracts.Repositories
{
    public interface ICollaboratorRepository
    {
        Task<IEnumerable<Collaborator>> GetAll();
        Task<Collaborator> GetById(Guid id);
    }
}
