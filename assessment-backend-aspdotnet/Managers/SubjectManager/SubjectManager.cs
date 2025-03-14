using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.DataAccess.Repositories.ClassRepository;
using assessment_backend_aspdotnet.DataAccess.Repositories.StudentRepository;
using assessment_backend_aspdotnet.Interfaces.Manager;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using AutoMapper;
using static assessment_backend_aspdotnet.CustomConfig.UserDefinedException;

namespace assessment_backend_aspdotnet.Managers.SubjectManager
{
    public class SubjectManager : ISubjectManager
    {
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public SubjectManager(IMapper mapper, ISubjectRepository subjectRepository, IEnrollmentRepository enrollmentRepository)
        {
            _mapper = mapper;
            _subjectRepository  = subjectRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<BaseResponse<SubjectResponseDto>> AddSubject(SubjectDto subject)
        {
            SubjectDto newSubject = new SubjectDto
            {
                Name = subject.Name,
                Code = subject.Code,
                Teacher = subject.Teacher,
            };

            SubjectDto result = await _subjectRepository.AddSubject(newSubject);

            SubjectResponseDto responseData = _mapper.Map<SubjectResponseDto>(result);

            return new BaseResponse<SubjectResponseDto>
            {
                Success = true,
                Message = "Subject Created",
                Data = responseData
            };
        }

        public async Task<BaseResponse<SubjectResponseDto>> GetSubjectById(int id)
        {
            SubjectResponseDto? responseData = await _subjectRepository.GetSubjectById(id);

            if (responseData == null)
            {
                throw new UDNotFoundException("Subject ID Not Found");
            }

            return new BaseResponse<SubjectResponseDto>
            {
                Success = true,
                Message = "Subject Recieved",
                Data = responseData
            };
        }

        public async Task<BaseResponse<List<SubjectResponseDto>>> GetAllSubjects()
        {
            List<SubjectResponseDto> responseData = await _subjectRepository.GetAllSubjects();

            return new BaseResponse<List<SubjectResponseDto>>
            {
                Success = true,
                Message = "Subjects Received",
                Data = responseData
            };
        }

        public async Task<BaseResponse<List<StudentResponseDto>>> GetStudentsBySubject(int id)
        {
            List<StudentResponseDto>? responseData = await _enrollmentRepository.GetStudentsBySubject(id);

            if (responseData == null)
            {
                throw new UDNotFoundException("Students Not Found");
            }

            return new BaseResponse<List<StudentResponseDto>>
            {
                Success = true,
                Message = "Students Recieved",
                Data = responseData
            };
        }
    }
}
