namespace assessment_backend_aspdotnet.Model.Dto
{
    public class StudentDto
    {
        //public decimal Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Age { get; set; }

        public string? Address { get; set; }

        public decimal? ClassId { get; set; }
    }
}
