namespace assessment_backend_aspdotnet.Model.Response
{
    public class BaseResponse <T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}
