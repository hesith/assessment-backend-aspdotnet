using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;

namespace assessment_backend_aspdotnet.Interfaces.Manager
{
    public interface IEnrollmentManager
    {
        Task<BaseResponse<EnrollmentResponseDto>> AddEnrollment(EnrollmentDto enrollment);
        Task<BaseResponse<bool>> DeleteEnrollmentById(int id);

    }
}
