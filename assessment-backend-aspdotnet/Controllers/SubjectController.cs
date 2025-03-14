using assessment_backend_aspdotnet.Interfaces.Manager;
using assessment_backend_aspdotnet.Interfaces.ManagerInterfaces;
using assessment_backend_aspdotnet.Managers.ClassManager;
using assessment_backend_aspdotnet.Managers.StudentManager;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assessment_backend_aspdotnet.Controllers
{
    [ApiController]
    public class SubjectController : CoreController
    {
        private readonly ISubjectManager _subjectManager;

        public SubjectController(ISubjectManager subjectManager)
        {
            _subjectManager = subjectManager;
        }

        [HttpPost("subjects")]
        public async Task<IActionResult> AddSubject([FromBody] SubjectDto subjectDto)
        {
            if (subjectDto == null)
            {
                return BadRequest("Invalid Subject Data");
            }

            BaseResponse<SubjectResponseDto> result = await _subjectManager.AddSubject(subjectDto);
            return Ok(result);
        }

        [HttpPut("subjects/{id}")]
        public async Task<IActionResult> UpdateSubject(int id, [FromBody] SubjectDto subjectDto)
        {

            if (subjectDto == null)
            {
                return BadRequest("Invalid Subject Data");
            }

            BaseResponse<SubjectResponseDto> result = await _subjectManager.UpdateSubject(id, subjectDto);
            return Ok(result);
        }

        [HttpDelete("subjects/{id}")]
        public async Task<IActionResult> DeleteSubjectById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid Subject Data");
            }

            BaseResponse<bool> result = await _subjectManager.DeleteSubjectById(id);
            return Ok(result);
        }
        [HttpGet("subjects/{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid Subject Data");
            }

            BaseResponse<SubjectResponseDto> result = await _subjectManager.GetSubjectById(id);
            return Ok(result);
        }

        [HttpGet("subjects")]
        public async Task<IActionResult> GetAllSubjects()
        {
            BaseResponse<List<SubjectResponseDto>> result = await _subjectManager.GetAllSubjects();
            return Ok(result);
        }

        [HttpGet("subjects/{id}/students")]
        public async Task<IActionResult> GetStudentsBySubject(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid Subject Data");
            }

            BaseResponse<List<StudentResponseDto>> result = await _subjectManager.GetStudentsBySubject(id);
            return Ok(result);
        }
    }
}
