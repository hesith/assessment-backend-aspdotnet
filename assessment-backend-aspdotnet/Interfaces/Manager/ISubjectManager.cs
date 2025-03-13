using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;

namespace assessment_backend_aspdotnet.Interfaces.Manager
{
    public interface ISubjectManager
    {
        Task<BaseResponse<SubjectResponseDto>> AddSubject(SubjectDto subject);
        Task<BaseResponse<SubjectResponseDto>> GetSubjectById(int id);
        Task<BaseResponse<List<SubjectResponseDto>>> GetAllSubjects();


    }
}
