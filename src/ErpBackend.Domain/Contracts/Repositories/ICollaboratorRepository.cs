using Domain.Entities;

namespace Domain.Contracts.Repositories
{
    public interface ICollaboratorRepository
    {
        Task<IEnumerable<CollaboratorEntity>> GetAllAsync();
        Task<CollaboratorEntity?> GetByIdAsync(Guid id);
    }
}
