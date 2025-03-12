using assessment_backend_aspdotnet.Interfaces.Manager;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using AutoMapper;

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

        public async Task<BaseResponse<ClassResponseDto>> CreateClass(ClassDto cls)
        {
            ClassDto newClass = new ClassDto
            {
                Name = cls.Name,
                Grade = cls.Grade,
            };

            ClassDto result = await _classRepository.CreateClass(newClass);

            ClassResponseDto responseData = _mapper.Map<ClassResponseDto>(result);

            return new BaseResponse<ClassResponseDto>
            {
                Success = true,
                Message = "Class Created",
                Data = responseData
            };
        }
    }
}
