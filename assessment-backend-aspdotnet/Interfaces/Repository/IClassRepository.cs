using assessment_backend_aspdotnet.Model.Dto;

namespace assessment_backend_aspdotnet.Interfaces.Repository
{
    public interface IClassRepository
    {
        Task<ClassDto> CreateClass(ClassDto cls);

    }
}
