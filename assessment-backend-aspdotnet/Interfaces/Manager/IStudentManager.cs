using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;

namespace assessment_backend_aspdotnet.Interfaces.ManagerInterfaces
{
    public interface IStudentManager
    {
        Task<BaseResponse<StudentResponseDto>> AddStudent(StudentDto student);
        Task<BaseResponse<StudentResponseDto>> UpdateStudent(int id, StudentDto student);
        Task<BaseResponse<bool>> DeleteStudentById(int id);
        Task<BaseResponse<List<StudentResponseDto>>> GetAllStudents();
        Task<BaseResponse<StudentResponseDto>> GetStudentById(int id);

    }
}
