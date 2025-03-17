namespace assessment_backend_aspdotnet.Model.Response
{
    public class PaginatedClassResponseDto
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<ClassResponseDto>? Data { get; set; }
    }
}
