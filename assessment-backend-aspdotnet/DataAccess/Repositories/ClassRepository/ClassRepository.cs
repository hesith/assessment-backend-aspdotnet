using assessment_backend_aspdotnet.DataAccess.Context;
using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static assessment_backend_aspdotnet.CustomConfig.UserDefinedException;

namespace assessment_backend_aspdotnet.DataAccess.Repositories.ClassRepository
{
    public class ClassRepository : IClassRepository
    {
        private readonly AssessmentContext _dbContext;
        private readonly IMapper _mapper;
        public ClassRepository(AssessmentContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<ClassDto> AddClass(ClassDto cls)
        {
            Class convDbObj = _mapper.Map<Class>(cls);

            decimal maxId = _dbContext.Classes.Any<Class>() ? _dbContext.Classes.Max<Class, decimal>(c => c.Id) : 0;
            convDbObj.Id = maxId + 1;

            _dbContext.Classes.Add(convDbObj);
            await _dbContext.SaveChangesAsync();

            return cls;
        }

        public async Task<ClassDto> UpdateClass(int id, ClassDto cls)
        {
            Class convDbObj = _mapper.Map<Class>(cls);
            convDbObj.Id = id;

            _dbContext.Classes.Update(convDbObj);
            await _dbContext.SaveChangesAsync();

            return cls;
        }
        public async Task<bool> DeleteClassById(int id)
        {
            Class? cls = await _dbContext.Classes.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (cls == null)
            {
                throw new UDNotFoundException("Class Not Found");
            }

            _dbContext.Classes.Remove(cls);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<ClassResponseDto?> GetClassById(int id)
        {
            Class? result = await _dbContext.Classes.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            ClassResponseDto convDbObj = _mapper.Map<ClassResponseDto>(result);

            return convDbObj;
        }

        public async Task<List<ClassResponseDto>> GetAllClasses()
        {
            List<Class> data = await _dbContext.Classes.ToListAsync<Class>();
            return _mapper.Map<List<ClassResponseDto>>(data);
        }
    }
}
