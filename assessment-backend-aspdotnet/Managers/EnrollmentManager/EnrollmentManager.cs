using assessment_backend_aspdotnet.DataAccess.Repositories.ClassRepository;
using assessment_backend_aspdotnet.DataAccess.Repositories.StudentRepository;
using assessment_backend_aspdotnet.Interfaces.Manager;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using AutoMapper;
using static assessment_backend_aspdotnet.CustomConfig.UserDefinedException;

namespace assessment_backend_aspdotnet.Managers.EnrollmentManager
{
    public class EnrollmentManager : IEnrollmentManager
    {
        private readonly IMapper _mapper;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;

        public EnrollmentManager(IMapper mapper, IEnrollmentRepository enrollmentRepository, ISubjectRepository subjectRepository, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
        }

        public async Task<BaseResponse<EnrollmentResponseDto>> AddEnrollment(EnrollmentDto enrollment)
        {
            var existingStudent = await _studentRepository.GetStudentById((int)(enrollment.StudentId));

            if (existingStudent == null)
            {
                throw new UDNotFoundException("Student ID Not Found");
            }

            var existingSubject = await _subjectRepository.GetSubjectById((int)(enrollment.SubjectId));

            if (existingSubject == null)
            {
                throw new UDNotFoundException("Subject ID Not Found");
            }

            EnrollmentDto newEnrollment = new EnrollmentDto
            {
                StudentId = enrollment.StudentId,
                SubjectId = enrollment.SubjectId,
            };

            EnrollmentDto result = await _enrollmentRepository.AddEnrollment(newEnrollment);

            EnrollmentResponseDto responseData = _mapper.Map<EnrollmentResponseDto>(result);

            return new BaseResponse<EnrollmentResponseDto>
            {
                Success = true,
                Message = "Enrollment Created",
                Data = responseData
            };
        }

        public async Task<BaseResponse<bool>> DeleteEnrollmentById(int id)
        {
            bool responseData = await _enrollmentRepository.DeleteEnrollmentById(id);

            return new BaseResponse<bool>
            {
                Success = true,
                Message = "Enrollment Removed",
                Data = responseData
            };
        }
    }
}
