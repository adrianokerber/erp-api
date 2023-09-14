namespace ErpApi.Service.ViewModels
{
    public record ViewModel<T>
    {
        public bool Success => !Errors.Any();
        public List<string> Errors { get; } = new();
        public T? Data { get; }

        public ViewModel(T data)
        {
            Data = data;
        }

        public ViewModel(string error)
        {
            Errors.Add(error);
        }

        public ViewModel(List<string> errors)
        {
            Errors = errors;
        }
    }
}
