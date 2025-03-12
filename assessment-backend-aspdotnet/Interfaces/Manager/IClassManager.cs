using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;

namespace assessment_backend_aspdotnet.Interfaces.Manager
{
    public interface IClassManager
    {
        Task<BaseResponse<ClassResponseDto>> CreateClass(ClassDto cls);
    }
}
