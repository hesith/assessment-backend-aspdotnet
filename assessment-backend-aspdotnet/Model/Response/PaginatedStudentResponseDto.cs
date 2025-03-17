namespace assessment_backend_aspdotnet.Model.Response
{
    public class PaginatedStudentResponseDto
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<StudentResponseDto>? Data { get; set; }
    }
}
