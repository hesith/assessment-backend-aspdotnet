using assessment_backend_aspdotnet.Interfaces.ManagerInterfaces;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assessment_backend_aspdotnet.Controllers
{
    [ApiController]
    public class StudentController : CoreController
    {
        private readonly IStudentManager _studentManager;

        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        [HttpPost("student")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto studentDto)
        {
            if (studentDto == null) 
            {
                return BadRequest("Invalid Student Data");
            }

            BaseResponse<StudentResponseDto> result = await _studentManager.CreateStudent(studentDto);
            return Ok(result);
        }
    }
}
