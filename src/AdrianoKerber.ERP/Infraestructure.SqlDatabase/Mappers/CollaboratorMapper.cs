using Domain.Entities;
using Infraestructure.SqlDatabase.ORMs;

namespace Infraestructure.SqlDatabase.Mappers
{
    public static class CollaboratorMapper
    {
        public static Collaborator ToDomain(this CollaboratorOrm orm)
            => new Collaborator(orm.FirstName,
                                orm.LastName,
                                orm.Document);

        public static IEnumerable<Collaborator> ToDomainList(this IEnumerable<CollaboratorOrm> orms)
        {
            foreach (var orm in orms)
            {
                yield return orm.ToDomain();
            }
        }
    }
}
