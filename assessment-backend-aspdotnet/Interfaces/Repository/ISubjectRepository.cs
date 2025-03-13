using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Model.Dto;

namespace assessment_backend_aspdotnet.Interfaces.Repository
{
    public interface ISubjectRepository
    {
        Task<SubjectDto> AddSubject(SubjectDto subject);
        Task<SubjectDto?> GetSubjectById(int id);
        Task<List<SubjectDto>> GetAllSubjects();


    }
}
