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
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {

            if (studentDto == null) 
            {
                return BadRequest("Invalid Student Data");
            }

            BaseResponse<StudentResponseDto> result = await _studentManager.AddStudent(studentDto);
            return Ok(result);
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            BaseResponse<List<StudentDto>> result = await _studentManager.GetAllStudents();
            return Ok(result);
        }

        [HttpGet("students/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid Student Data");
            }

            BaseResponse<StudentResponseDto> result = await _studentManager.GetStudentById(id);
            return Ok(result);
        }
    }
}
