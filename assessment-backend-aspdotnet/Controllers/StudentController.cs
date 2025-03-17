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

        [HttpPost("students")]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {

            if (studentDto == null) 
            {
                return BadRequest("Invalid Student Data");
            }

            BaseResponse<StudentResponseDto> result = await _studentManager.AddStudent(studentDto);
            return Ok(result);
        }

        [HttpPut("students/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {

            if (studentDto == null)
            {
                return BadRequest("Invalid Student Data");
            }

            BaseResponse<StudentResponseDto> result = await _studentManager.UpdateStudent(id, studentDto);
            return Ok(result);
        }

        [HttpDelete("students/{id}")]
        public async Task<IActionResult> DeleteStudentById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid Student Data");
            }

            BaseResponse<bool> result = await _studentManager.DeleteStudentById(id);
            return Ok(result);
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents(string? name, int? pageNo, int? pageSize)
        {
            BaseResponse<PaginatedStudentResponseDto> result = await _studentManager.GetAllStudents(name, pageNo, pageSize);
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
