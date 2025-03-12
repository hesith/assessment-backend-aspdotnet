using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using AutoMapper;

namespace assessment_backend_aspdotnet.CustomConfig
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            var mappings = new MapperConfiguration(config =>
            {
                config.CreateMap<StudentDto, Student>();
                config.CreateMap<StudentDto, StudentResponseDto>();

                config.CreateMap<ClassDto, Class>();
                config.CreateMap<ClassDto, ClassResponseDto>();

            });

            return mappings;
        }
    }
}
