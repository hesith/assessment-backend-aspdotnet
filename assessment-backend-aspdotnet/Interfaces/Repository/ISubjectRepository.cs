using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;

namespace assessment_backend_aspdotnet.Interfaces.Repository
{
    public interface ISubjectRepository
    {
        Task<SubjectDto> AddSubject(SubjectDto subject);
        Task<SubjectResponseDto?> GetSubjectById(int id);
        Task<List<SubjectResponseDto>> GetAllSubjects();


    }
}
