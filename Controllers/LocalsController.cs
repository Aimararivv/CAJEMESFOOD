using CajemesFoodAlejandro_Aimara.Data.Services;
using CajemesFoodAlejandro_Aimara.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CajemesFoodAlejandro_Aimara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalesController : ControllerBase
    {
        private LocalsService _localsService;

        public LocalesController(LocalsService localsService)
        {
            _localsService = localsService;
        }

        [HttpGet("get-local-by-id/{id}")]
        public IActionResult GetLocalById(int id)
        {
            var local = _localsService.GetLocalById(id);
            return Ok(local);
        }

        [HttpPost("add-local-with-platillo")]
        public IActionResult AddLocal([FromBody] LocalVM local)
        {
            _localsService.AddLocalWithPlatillos(local);
            return Ok();
        }

        [HttpPut("update-local-by-id/{id}")]
        public IActionResult UpdateLocalById(int id, [FromBody] LocalVM local)
        {
            var updatedLocal = _localsService.UpdateLocalByID(id, local);
            return Ok(updatedLocal);
        }

        [HttpDelete("delete-local-by-id/{id}")]
        public IActionResult DeleteLocalById(int id)
        {
            _localsService.DeleteLocalById(id);
            return Ok();
        }
    }
}
