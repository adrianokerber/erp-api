using Domain.Entities;
using Infraestructure.SqlDatabase.Orms;

namespace Infraestructure.SqlDatabase.Mappers
{
    public static class CollaboratorMapper
    {
        public static Collaborator ToDomain(this CollaboratorOrm orm)
            => new Collaborator(orm.PublicId,
                                orm.FirstName,
                                orm.LastName,
                                orm.Birthday,
                                orm.DocumentNumber,
                                orm.DocumentType,
                                orm.HiredAt,
                                orm.ResignationAt);

        public static IEnumerable<Collaborator> ToDomainList(this IEnumerable<CollaboratorOrm> orms)
        {
            foreach (var orm in orms)
            {
                yield return orm.ToDomain();
            }
        }
    }
}
