namespace Domain.Entities
{
    public record Collaborator
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateOnly? Birthday { get; }
        public long DocumentNumber { get; }
        public string DocumentType { get; }
        public DateOnly HiredAt { get; }
        public DateOnly? ResignationAt { get; }

        public Collaborator(Guid id, string firstName, string lastName, DateOnly? birthday, long documentNumber, string documentType, DateOnly hiredAt, DateOnly? resignationAt)
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Birthday = birthday;
            DocumentNumber = documentNumber;
            DocumentType = documentType ?? throw new ArgumentNullException(nameof(documentType));
            HiredAt = hiredAt;
            ResignationAt = resignationAt;
        }
    }
}