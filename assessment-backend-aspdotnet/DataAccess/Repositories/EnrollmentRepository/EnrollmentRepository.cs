using assessment_backend_aspdotnet.DataAccess.Context;
using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static assessment_backend_aspdotnet.CustomConfig.UserDefinedException;

namespace assessment_backend_aspdotnet.DataAccess.Repositories.EnrollmentRepository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AssessmentContext _dbContext;
        private readonly IMapper _mapper;

        public EnrollmentRepository(AssessmentContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;   
        }

        public async Task<EnrollmentDto> AddEnrollment(EnrollmentDto enrollment)
        {
            Enrollment convDbObj = _mapper.Map<Enrollment>(enrollment);

            decimal maxId = _dbContext.Enrollments.Any<Enrollment>() ? _dbContext.Enrollments.Max<Enrollment, decimal>(s => s.Id) : 0;
            convDbObj.Id = maxId + 1;

            _dbContext.Enrollments.Add(convDbObj);
            await _dbContext.SaveChangesAsync();

            return enrollment;
        }

        public async Task<bool> DeleteEnrollmentById(int id)
        {
            Enrollment? enrollment = await _dbContext.Enrollments.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (enrollment == null)
            {
                throw new UDNotFoundException("Enrollment Not Found");
            }

            _dbContext.Remove(enrollment);

            return true;
        }
    }
}
