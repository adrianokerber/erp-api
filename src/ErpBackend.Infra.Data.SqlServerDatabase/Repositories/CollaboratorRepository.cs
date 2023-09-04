using Dapper;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Infraestructure.SqlDatabase.Mappers;
using Infraestructure.SqlDatabase.Orms;
using System.Data;

namespace Infraestructure.SqlDatabase.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly IDbConnection _dbConnection;

        public CollaboratorRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<CollaboratorEntity>> GetAllAsync()
        {
            var query = "SELECT * FROM Collaborators";

            var collaborators = await _dbConnection.QueryAsync<CollaboratorOrm>(query);
            return collaborators.ToDomainList();
        }

        public async Task<CollaboratorEntity?> GetByIdAsync(Guid id)
        {
            var query = "SELECT Id, PublicId, FirstName, LastName, Birthday, DocumentNumber, DocumentType, HiredAt, ResignationAt FROM Collaborators WHERE PublicId = @Id";

            var collaborator = await _dbConnection.QuerySingleOrDefaultAsync<CollaboratorOrm>(query, new { id });
            return collaborator?.ToDomain();
        }
    }
}
