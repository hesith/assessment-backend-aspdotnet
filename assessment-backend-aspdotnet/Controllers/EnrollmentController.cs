using assessment_backend_aspdotnet.Interfaces.Manager;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assessment_backend_aspdotnet.Controllers
{
    [ApiController]
    public class EnrollmentController : CoreController
    {
        private readonly IEnrollmentManager _enrollmentManager;

        public EnrollmentController(IEnrollmentManager enrollmentManager)
        {
            _enrollmentManager = enrollmentManager;
        }

        [HttpPost("enrollemnts")]
        public async Task<IActionResult> AddEnrollment([FromBody] EnrollmentDto enrollmentDto)
        {

            if (enrollmentDto == null)
            {
                return BadRequest("Invalid Enrollment Data");
            }

            BaseResponse<EnrollmentResponseDto> result = await _enrollmentManager.AddEnrollment(enrollmentDto);
            return Ok(result);
        }

        [HttpDelete("enrollments/{id}")]
        public async Task<IActionResult> DeleteEnrollmentById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid Enrollment Data");
            }

            BaseResponse<bool> result = await _enrollmentManager.DeleteEnrollmentById(id);
            return Ok(result);
        }
    }
}
