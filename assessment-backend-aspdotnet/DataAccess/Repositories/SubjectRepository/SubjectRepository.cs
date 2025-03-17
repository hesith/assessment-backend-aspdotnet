using assessment_backend_aspdotnet.DataAccess.Context;
using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static assessment_backend_aspdotnet.CustomConfig.UserDefinedException;

namespace assessment_backend_aspdotnet.DataAccess.Repositories.SubjectRepository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AssessmentContext _dbContext;
        private readonly IMapper _mapper;

        public SubjectRepository(AssessmentContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<SubjectDto> AddSubject(SubjectDto subject)
        {
            Subject convDbObj = _mapper.Map<Subject>(subject);

            decimal maxId = _dbContext.Subjects.Any<Subject>() ? _dbContext.Subjects.Max<Subject, decimal>(s => s.Id) : 0;
            convDbObj.Id = maxId + 1;

            _dbContext.Subjects.Add(convDbObj);
            await _dbContext.SaveChangesAsync();

            return subject;
        }
        public async Task<SubjectDto> UpdateSubject(int id, SubjectDto subject)
        {
            Subject convDbObj = _mapper.Map<Subject>(subject);
            convDbObj.Id = id;

            _dbContext.Subjects.Update(convDbObj);
            await _dbContext.SaveChangesAsync();

            return subject;
        }
        public async Task<bool> DeleteSubjectById(int id)
        {
            Subject? subject = await _dbContext.Subjects.Where(s => s.Id == id).FirstOrDefaultAsync();

            if (subject == null)
            {
                throw new UDNotFoundException("Subject Not Found");
            }

            _dbContext.Subjects.Remove(subject);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<SubjectResponseDto?> GetSubjectById(int id)
        {
            Subject? result = await _dbContext.Subjects.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();
            SubjectResponseDto convDbObj = _mapper.Map<SubjectResponseDto>(result);

            return convDbObj;
        }

        public async Task<PaginatedSubjectResponseDto> GetAllSubjects(string? code, int? pageNo, int? pageSize)
        {
            int totalMatching = await _dbContext.Subjects
                .Where(s => string.IsNullOrWhiteSpace(code) || s.Name.Contains(code.Trim()))
                .CountAsync<Subject>();

            int totalPages = totalMatching == 0 ? 0 :
                ((pageNo.HasValue && pageSize.HasValue) ? (int)Math.Ceiling((decimal)(totalMatching / pageSize)) : 1);

            List<Subject> data = await _dbContext.Subjects
                .Where(s => string.IsNullOrWhiteSpace(code) || s.Name.Contains(code.Trim()))
                .Skip((int)((pageNo.HasValue && pageSize.HasValue) ? (pageNo - 1) * pageSize : 0))
                .Take((int)((pageNo.HasValue && pageSize.HasValue) ? pageSize : totalMatching))
                .ToListAsync<Subject>();

            PaginatedSubjectResponseDto responseObj = new PaginatedSubjectResponseDto()
            {
                TotalPages = totalPages,
                PageNo = pageNo ?? 1,
                PageSize = pageSize ?? totalMatching,
                Data = _mapper.Map<List<SubjectResponseDto>>(data)
            };

            return responseObj;

        }
    }
}
