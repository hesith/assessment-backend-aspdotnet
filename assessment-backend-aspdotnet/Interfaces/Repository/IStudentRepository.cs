using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Model.Dto;

namespace assessment_backend_aspdotnet.Interfaces.Repository
{
    public interface IStudentRepository
    {
        Task<StudentDto> CreateStudent(StudentDto student);
        //Task<StudentDto> UpdateStudent(Student student);
        //Task<StudentDto> GetStudentById(String id);
        //Task<IQueryable<StudentDto>> GetAllStudents();
        //Task<StudentDto> DeleteStudentById(String id);




    }
}
