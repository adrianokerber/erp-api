using ErpApi.Service.ViewModels;
using ErpApi.Service.ViewModels.Collaborator.Response;

namespace ErpApi.Service.Contracts
{
    public interface ICollaboratorService
    {
        Task<ViewModel<IEnumerable<ListCollaboratorResponse>>> ListAsync(); // TODO: pagination is required
        Task<ViewModel<GetByIdCollaboratorResponse>> GetByIdAsync(Guid id);
    }
}
