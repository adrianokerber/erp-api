namespace Infraestructure.SqlDatabase.Orms
{
    public record CollaboratorOrm
    {
        public int Id { get; }
        public Guid PublicId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateOnly? Birthday { get; }
        public long DocumentNumber { get; }
        public string DocumentType { get; }
        public DateOnly HiredAt { get; }
        public DateOnly? ResignationAt { get; }

        public CollaboratorOrm(int id, Guid publicId, string firstName, string lastName, DateTime? birthday, long documentNumber, string documentType, DateTime hiredAt, DateTime? resignationAt)
        {
            Id = id;
            PublicId = publicId;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Birthday = birthday.HasValue
                ? DateOnly.FromDateTime(birthday.Value)
                : null;
            DocumentNumber = documentNumber;
            DocumentType = documentType ?? throw new ArgumentNullException(nameof(documentType));
            HiredAt = DateOnly.FromDateTime(hiredAt);
            ResignationAt = resignationAt.HasValue
                ? DateOnly.FromDateTime(resignationAt.Value)
                : null;
        }
    }
}
