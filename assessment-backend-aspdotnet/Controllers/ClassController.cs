using assessment_backend_aspdotnet.Interfaces.Manager;
using assessment_backend_aspdotnet.Interfaces.ManagerInterfaces;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assessment_backend_aspdotnet.Controllers
{
    [ApiController]
    public class ClassController : CoreController
    {
        private readonly IClassManager _classManager;

        public ClassController(IClassManager classManager)
        {
            _classManager = classManager;
        }

        [HttpPost("classes")]
        public async Task<IActionResult> AddClass([FromBody] ClassDto classDto)
        {
            if (classDto == null)
            {
                return BadRequest("Invalid Class Data");
            }

            BaseResponse<ClassResponseDto> result = await _classManager.AddClass(classDto);
            return Ok(result);
        }

        [HttpGet("classes/{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid Class Data");
            }

            BaseResponse<ClassResponseDto> result = await _classManager.GetClassById(id);
            return Ok(result);
        }
    }
}
