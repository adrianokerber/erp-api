using AutoMapper;
using Domain.Contracts.Repositories;
using ErpBackend.Service.Contracts;
using ErpBackend.Service.ViewModels;
using ErpBackend.Service.ViewModels.Collaborator.Response;

namespace ErpBackend.Service.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly IMapper _mapper;

        public CollaboratorService(ICollaboratorRepository collaboratorRepository, IMapper mapper)
        {
            _collaboratorRepository = collaboratorRepository;
            _mapper = mapper;
        }

        public async Task<ViewModel<IEnumerable<ListCollaboratorResponse>>> ListAsync()
        {
            var collaborators = await _collaboratorRepository.GetAllAsync().ConfigureAwait(false);
            if (collaborators == default)
                return new ViewModel<IEnumerable<ListCollaboratorResponse>>("Collaborators not found");

            return new ViewModel<IEnumerable<ListCollaboratorResponse>>(collaborators.Select(x => _mapper.Map<ListCollaboratorResponse>(x)));
        }

        public async Task<ViewModel<GetByIdCollaboratorResponse>> GetByIdAsync(Guid id)
        {
            var collaborator = await _collaboratorRepository.GetByIdAsync(id).ConfigureAwait(false);
            if (collaborator == default)
                return new ViewModel<GetByIdCollaboratorResponse>("Collaborator not found");

            return new ViewModel<GetByIdCollaboratorResponse>(_mapper.Map<GetByIdCollaboratorResponse>(collaborator));
        }
    }
}
