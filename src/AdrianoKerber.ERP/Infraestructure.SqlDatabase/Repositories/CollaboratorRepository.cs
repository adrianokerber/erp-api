using Dapper;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Infraestructure.SqlDatabase.Mappers;
using Infraestructure.SqlDatabase.ORMs;

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
            var query = "select * from Collaborators";

            using (var connection = _context.CreateConnection())
            {
                var collaborators = await connection.QueryAsync<CollaboratorOrm>(query);
                return collaborators.ToDomainList();
            }
        }

        public Task<Collaborator> GetCollaborator(int id)
        {
            throw new NotImplementedException();
        }
    }
}
