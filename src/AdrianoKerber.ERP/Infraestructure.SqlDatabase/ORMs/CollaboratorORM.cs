namespace Infraestructure.SqlDatabase.ORMs
{
    public record CollaboratorOrm
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Document { get; }

        public CollaboratorOrm(string firstName, string lastName, string document)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
        }

        public CollaboratorOrm(int id, string firstName, string lastName, string document)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Document = document;
        }
    }
}
