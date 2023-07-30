namespace Domain.Entities
{
    public record Collaborator
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Document { get; }

        public Collaborator(string firstName, string lastName, string document)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
        }
    }
}