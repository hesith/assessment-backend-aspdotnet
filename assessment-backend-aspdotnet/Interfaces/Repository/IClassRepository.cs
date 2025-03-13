using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Model.Dto;

namespace assessment_backend_aspdotnet.Interfaces.Repository
{
    public interface IClassRepository
    {
        Task<ClassDto> AddClass(ClassDto cls);
        Task<ClassDto?> GetClassById(int id);
        Task<List<ClassDto>> GetAllClasses();



    }
}
