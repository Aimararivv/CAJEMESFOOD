using CajemesFoodAlejandro_Aimara.Data.Services;
using CajemesFoodAlejandro_Aimara.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CajemesFoodAlejandro_Aimara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatillosController : ControllerBase
    {
        private PlatillosService _platillosService;

        public PlatillosController(PlatillosService platillosService)
        {
            _platillosService = platillosService;
        }

        [HttpPost("add-platillo")]
        public IActionResult AddPlatillo([FromBody] PlatilloVM platillo)
        {
            _platillosService.AddPlatillo(platillo);
            return Ok();
        }

        [HttpGet("get-platillo-with-locals-by-id/{id}")]
        public IActionResult GetPlatilloWithLocals(int id)
        {
            var response = _platillosService.GetPlatilloWithLocals(id);
            return Ok(response);
        }
    }
}
