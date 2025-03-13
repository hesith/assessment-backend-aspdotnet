using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Interfaces.ManagerInterfaces;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using AutoMapper;
using static assessment_backend_aspdotnet.CustomConfig.UserDefinedException;

namespace assessment_backend_aspdotnet.Managers.StudentManager
{
    public class StudentManager : IStudentManager
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        public StudentManager(IMapper mapper, IStudentRepository studentRepository, IClassRepository classRepository) 
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _classRepository = classRepository;
        }

        public async Task<BaseResponse<StudentResponseDto>> AddStudent(StudentDto student)
        {
            var existingClass = await _classRepository.GetClassById((int)(student.ClassId ?? -1m));

            if (existingClass == null) 
            {
                throw new UDNotFoundException("Class ID Not Found");
            }

            StudentDto newStudent = new StudentDto{
                Name = student.Name,
                Age = student.Age,
                Address = student.Address,
                ClassId = student.ClassId
            };

            StudentDto result = await _studentRepository.AddStudent(newStudent);

            StudentResponseDto responseData = _mapper.Map<StudentResponseDto>(result);

            return new BaseResponse<StudentResponseDto>{ 
                Success = true, Message = "Student Created", Data = responseData
            };
        }
    }
}
