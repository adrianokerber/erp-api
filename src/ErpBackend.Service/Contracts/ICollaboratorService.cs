using ErpBackend.Service.ViewModels;
using ErpBackend.Service.ViewModels.Collaborator.Response;

namespace ErpBackend.Service.Contracts
{
    public interface ICollaboratorService
    {
        Task<ViewModel<IEnumerable<ListCollaboratorResponse>>> ListAsync(); // TODO: pagination is required
        Task<ViewModel<GetByIdCollaboratorResponse>> GetByIdAsync(Guid id);
    }
}
