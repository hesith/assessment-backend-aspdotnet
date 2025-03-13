using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;

namespace assessment_backend_aspdotnet.Interfaces.Manager
{
    public interface IClassManager
    {
        Task<BaseResponse<ClassResponseDto>> AddClass(ClassDto cls);
        Task<BaseResponse<ClassResponseDto>> GetClassById(int id);
        Task<BaseResponse<List<ClassDto>>> GetAllClasses();

    }
}
