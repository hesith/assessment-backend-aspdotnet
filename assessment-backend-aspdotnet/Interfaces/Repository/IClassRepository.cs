using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;

namespace assessment_backend_aspdotnet.Interfaces.Repository
{
    public interface IClassRepository
    {
        Task<ClassDto> AddClass(ClassDto cls);
        Task<ClassDto> UpdateClass(int id, ClassDto cls);
        Task<bool> DeleteClassById(int id);
        Task<ClassResponseDto?> GetClassById(int id);
        Task<PaginatedClassResponseDto> GetAllClasses(string? name, int? pageNo, int? pageSize);



    }
}
