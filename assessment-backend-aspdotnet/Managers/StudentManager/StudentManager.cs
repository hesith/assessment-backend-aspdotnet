using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Interfaces.ManagerInterfaces;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using AutoMapper;

namespace assessment_backend_aspdotnet.Managers.StudentManager
{
    public class StudentManager : IStudentManager
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public StudentManager(IMapper mapper, IStudentRepository studentRepository) 
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<BaseResponse<StudentResponseDto>> CreateStudent(StudentDto student)
        {
            StudentDto newStudent = new StudentDto{
                Name = student.Name,
                Age = student.Age,
                Address = student.Address,
                ClassId = student.ClassId
            };

            StudentDto result = await _studentRepository.CreateStudent(newStudent);

            StudentResponseDto responseData = _mapper.Map<StudentResponseDto>(result);

            return new BaseResponse<StudentResponseDto>{ 
                Success = true, Message = "Student Created", Data = responseData
            };
        }
    }
}
