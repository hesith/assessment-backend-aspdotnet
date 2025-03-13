using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Model.Dto;

namespace assessment_backend_aspdotnet.Interfaces.Repository
{
    public interface IStudentRepository
    {
        Task<StudentDto> AddStudent(StudentDto student);
        //Task<StudentDto> UpdateStudent(Student student);
        Task<StudentDto?> GetStudentById(int id);
        Task<List<StudentDto>> GetAllStudents();
        //Task<StudentDto> DeleteStudentById(String id);




    }
}
