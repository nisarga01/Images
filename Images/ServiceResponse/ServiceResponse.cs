namespace Images.ServiceResponse
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string ResultMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}
