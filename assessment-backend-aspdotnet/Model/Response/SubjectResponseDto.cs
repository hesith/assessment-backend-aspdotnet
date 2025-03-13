namespace assessment_backend_aspdotnet.Model.Response
{
    public class SubjectResponseDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Teacher { get; set; } = null!;
    }
}
