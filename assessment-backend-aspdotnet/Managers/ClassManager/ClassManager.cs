using assessment_backend_aspdotnet.CustomConfig;
using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.DataAccess.Repositories.StudentRepository;
using assessment_backend_aspdotnet.Interfaces.Manager;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using AutoMapper;
using static assessment_backend_aspdotnet.CustomConfig.UserDefinedException;

namespace assessment_backend_aspdotnet.Managers.ClassManager
{
    public class ClassManager : IClassManager
    {
        private readonly IMapper _mapper;
        private readonly IClassRepository _classRepository;
        public ClassManager(IMapper mapper, IClassRepository classRepository)
        {
            _mapper = mapper;
            _classRepository = classRepository;
        }

        public async Task<BaseResponse<ClassResponseDto>> AddClass(ClassDto cls)
        {
            ClassDto newClass = new ClassDto
            {
                Name = cls.Name,
                Grade = cls.Grade,
            };

            ClassDto result = await _classRepository.AddClass(newClass);

            ClassResponseDto responseData = _mapper.Map<ClassResponseDto>(result);

            return new BaseResponse<ClassResponseDto>
            {
                Success = true,
                Message = "Class Created",
                Data = responseData
            };
        }

        public async Task<BaseResponse<ClassResponseDto>> GetClassById(int id)
        {
            ClassDto? result = await _classRepository.GetClassById(id);

            if (result == null) 
            {
                throw new UDNotFoundException("Class ID Not Found");
            }

            ClassResponseDto responseData = _mapper.Map<ClassResponseDto>(result);

            return new BaseResponse<ClassResponseDto>
            {
                Success = true,
                Message = "Class Recieved",
                Data = responseData
            };
        }

        public async Task<BaseResponse<List<ClassDto>>> GetAllClasses()
        {
            List<ClassDto> responseData = await _classRepository.GetAllClasses();

            return new BaseResponse<List<ClassDto>>
            {
                Success = true,
                Message = "Classes Received",
                Data = responseData
            };
        }
    }
}
