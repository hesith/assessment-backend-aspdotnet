namespace assessment_backend_aspdotnet.Model.Response
{
    public class PaginatedSubjectResponseDto
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<SubjectResponseDto>? Data { get; set; }
    }
}
