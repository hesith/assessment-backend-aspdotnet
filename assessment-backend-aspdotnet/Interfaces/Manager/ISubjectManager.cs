using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;

namespace assessment_backend_aspdotnet.Interfaces.Manager
{
    public interface ISubjectManager
    {
        Task<BaseResponse<SubjectResponseDto>> AddSubject(SubjectDto subject);
        Task<BaseResponse<SubjectResponseDto>> UpdateSubject(int id, SubjectDto cls);
        Task<BaseResponse<bool>> DeleteSubjectById(int id);
        Task<BaseResponse<SubjectResponseDto>> GetSubjectById(int id);
        Task<BaseResponse<PaginatedSubjectResponseDto>> GetAllSubjects(string? code, int? pageNo, int? pageSize);
        Task<BaseResponse<List<StudentResponseDto>>> GetStudentsBySubject(int id);


    }
}
