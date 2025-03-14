using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;

namespace assessment_backend_aspdotnet.Interfaces.Repository
{
    public interface IEnrollmentRepository
    {
        Task<EnrollmentDto> AddEnrollment(EnrollmentDto cls);
        Task<List<StudentResponseDto>> GetStudentsBySubject(int id);
        Task<bool> DeleteEnrollmentById(int id);
    }
}
