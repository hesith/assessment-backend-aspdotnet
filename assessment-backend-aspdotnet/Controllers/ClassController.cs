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
        public async Task<IActionResult> CreateClass([FromBody] ClassDto classDto)
        {
            if (classDto == null)
            {
                return BadRequest("Invalid Class Data");
            }

            BaseResponse<ClassResponseDto> result = await _classManager.CreateClass(classDto);
            return Ok(result);
        }
    }
}
