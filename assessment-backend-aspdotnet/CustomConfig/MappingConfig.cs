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
                config.CreateMap<Student, StudentDto>();
                config.CreateMap<Student, StudentResponseDto>();
                config.CreateMap<StudentDto, StudentResponseDto>();

                config.CreateMap<ClassDto, Class>();
                config.CreateMap<Class, ClassDto>();
                config.CreateMap<ClassDto, ClassResponseDto>();
                config.CreateMap<Class, ClassResponseDto>();

                config.CreateMap<SubjectDto, Subject>();
                config.CreateMap<SubjectDto, SubjectResponseDto>();
                config.CreateMap<Subject, SubjectResponseDto>();
                config.CreateMap<Subject, SubjectDto>();

                config.CreateMap<EnrollmentDto, Enrollment>();
                config.CreateMap<Enrollment, EnrollmentDto>();
                config.CreateMap<Enrollment, EnrollmentResponseDto>();
                config.CreateMap<EnrollmentDto, EnrollmentResponseDto>();
            });

            return mappings;
        }
    }
}
