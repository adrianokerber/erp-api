using Dapper;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Infraestructure.SqlDatabase.Mappers;
using Infraestructure.SqlDatabase.Orms;

namespace Infraestructure.SqlDatabase.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly DapperContext _context;

        public CollaboratorRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Collaborator>> GetAll()
        {
            var query = "SELECT * FROM Collaborators";

            using (var connection = _context.CreateConnection())
            {
                var collaborators = await connection.QueryAsync<CollaboratorOrm>(query);
                return collaborators.ToDomainList();
            }
        }

        public async Task<Collaborator?> GetById(Guid id)
        {
            var query = "SELECT Id, PublicId, FirstName, LastName, Birthday, DocumentNumber, DocumentType, HiredAt, ResignationAt FROM Collaborators WHERE PublicId = @Id";

            using (var connection = _context.CreateConnection())
            {
                var collaborator = await connection.QuerySingleOrDefaultAsync<CollaboratorOrm>(query, new { id });
                return collaborator?.ToDomain();
            }
        }
    }
}
