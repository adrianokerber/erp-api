namespace ErpBackend.Service.Views.Collaborator.Response
{
    public class ListCollaboratorResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly? Birthday { get; set; }
        public long DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public DateOnly HiredAt { get; set; }
        public DateOnly? ResignationAt { get; set; }
    }
}
