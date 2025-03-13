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

            _dbContext.Remove(student);

            return true;
        }

        public async Task<List<StudentResponseDto>> GetAllStudents()
        {
            List<Student> data = await _dbContext.Students.ToListAsync<Student>();
            
            return _mapper.Map<List<StudentResponseDto>>(data);
        }

        public async Task<StudentResponseDto?> GetStudentById(int id)
        {
            Student? result = await _dbContext.Students.Where(s => s.Id == id).FirstOrDefaultAsync();
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
