using AutoMapper;
using Domain.Entities;
using ErpApi.Service.ViewModels.Collaborator.Response;

namespace ErpApi.Service.MapperProfiles
{
    public class CollaboratorMapperProfile : Profile
    {
        public CollaboratorMapperProfile() {
            CreateMap<CollaboratorEntity, ListCollaboratorResponse>();
            CreateMap<CollaboratorEntity, GetByIdCollaboratorResponse>();
        }
    }
}
