using AutoMapper;
using Domain.Entities;
using ErpBackend.Service.ViewModels.Collaborator.Response;

namespace ErpBackend.Service.MapperProfiles
{
    public class CollaboratorMapperProfile : Profile
    {
        public CollaboratorMapperProfile() {
            CreateMap<CollaboratorEntity, ListCollaboratorResponse>();
            CreateMap<CollaboratorEntity, GetByIdCollaboratorResponse>();
        }
    }
}
