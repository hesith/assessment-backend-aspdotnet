using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;

namespace assessment_backend_aspdotnet.Interfaces.Repository
{
    public interface IStudentRepository
    {
        Task<StudentDto> AddStudent(StudentDto student);
        Task<StudentDto> UpdateStudent(int id, StudentDto student);
        Task<bool> DeleteStudentById(int id);
        Task<StudentResponseDto?> GetStudentById(int id);
        Task<PaginatedStudentResponseDto> GetAllStudents(string? name, int? pageNo, int? pageSize);
        Task<List<StudentResponseDto>> GetStudentsByClassId(int id);





    }
}
