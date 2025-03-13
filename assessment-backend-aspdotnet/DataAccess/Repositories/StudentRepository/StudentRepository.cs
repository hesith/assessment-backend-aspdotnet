using assessment_backend_aspdotnet.DataAccess.Context;
using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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
    }
}
