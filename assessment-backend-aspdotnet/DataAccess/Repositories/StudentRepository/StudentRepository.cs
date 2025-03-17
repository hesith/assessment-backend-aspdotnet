using assessment_backend_aspdotnet.DataAccess.Context;
using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static assessment_backend_aspdotnet.CustomConfig.UserDefinedException;

namespace assessment_backend_aspdotnet.DataAccess.Repositories.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AssessmentContext _dbContext;
        private readonly IMapper _mapper;
        public StudentRepository(AssessmentContext context, IMapper mapper) 
        { 
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<StudentDto> AddStudent(StudentDto student)
        {
            Student convDbObj = _mapper.Map<Student>(student);

            decimal maxId = _dbContext.Students.Any<Student>() ?  _dbContext.Students.Max<Student,decimal>(s => s.Id) : 0;
            convDbObj.Id = maxId+1;

            _dbContext.Students.Add(convDbObj);
            await _dbContext.SaveChangesAsync();

            return student;
        }

        public async Task<StudentDto> UpdateStudent(int id, StudentDto student)
        {
            Student convDbObj = _mapper.Map<Student>(student);
            convDbObj.Id = id;

            _dbContext.Students.Update(convDbObj);
            await _dbContext.SaveChangesAsync();

            return student;
        }
        public async Task<bool> DeleteStudentById(int id)
        {
            Student? student = await _dbContext.Students.Where(s => s.Id == id).FirstOrDefaultAsync();
            
            if (student == null)
            {
                throw new UDNotFoundException("Student Not Found");
            }

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PaginatedStudentResponseDto> GetAllStudents(string? name, int? pageNo, int? pageSize)
        {
            int totalMatching = await _dbContext.Students
                .Where(s => string.IsNullOrWhiteSpace(name) || s.Name.Contains(name.Trim()))
                .CountAsync<Student>();

            int totalPages = totalMatching == 0 ? 0 :
                ((pageNo.HasValue && pageSize.HasValue) ? (int)Math.Ceiling((decimal)(totalMatching / pageSize)) : 1);

            List<Student> data = await _dbContext.Students
                .Where(s => string.IsNullOrWhiteSpace(name) || s.Name.Contains(name.Trim()))
                .Skip((int)((pageNo.HasValue && pageSize.HasValue) ? (pageNo - 1) * pageSize : 0))
                .Take((int)((pageNo.HasValue && pageSize.HasValue) ? pageSize : totalMatching))
                .ToListAsync<Student>();

            PaginatedStudentResponseDto responseObj = new PaginatedStudentResponseDto()
            {
                TotalPages = totalPages,
                PageNo = pageNo ?? 1,
                PageSize = pageSize ?? totalMatching,
                Data = _mapper.Map<List<StudentResponseDto>>(data)
            };

            return responseObj;
        }

        public async Task<StudentResponseDto?> GetStudentById(int id)
        {
            Student? result = await _dbContext.Students.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();
            StudentResponseDto convDbObj = _mapper.Map<StudentResponseDto>(result);

            return convDbObj;
        }

        public async Task<List<StudentResponseDto>> GetStudentsByClassId(int id)
        {
            List<Student> data = await _dbContext.Students.Where<Student>(s => s.ClassId == id).ToListAsync<Student>();

            return _mapper.Map<List<StudentResponseDto>>(data);
        }
    }
}
