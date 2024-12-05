using CajemesFoodAlejandro_Aimara.Data.Models;
using CajemesFoodAlejandro_Aimara.Data.Services;
using CajemesFoodAlejandro_Aimara.Data.ViewModels;
using CajemesFoodAlejandro_Aimara.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CajemesFoodAlejandro_Aimara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private AdministradoresService _administradoresService;

        public AdministradoresController(AdministradoresService administradoresService)
        {
            _administradoresService = administradoresService;
        }

        [HttpPost("add-administrador")]
        public IActionResult AddAdministrador([FromBody] AdministradorVM administrador)
        {
            try
            {
                var newAdministrador = _administradoresService.AddAdministrador(administrador);
                return Created(nameof(AddAdministrador), newAdministrador);
            }
            catch (AdministradorNameException ex)
            {
                return BadRequest($"{ex.Message}, Nombre del administrador: {ex.Administradornombre}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-administrador-by-id/{id}")]
        public IActionResult GetAdministradorById(int id)
        {
            var response = _administradoresService.GetAdministradorByID(id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("get-administrador-locals/{id}")]
        public IActionResult GetAdministradorLocals(int id)
        {
            var response = _administradoresService.GetAdministradorLocals(id);
            return Ok(response);
        }

        [HttpDelete("delete-administrador-by-id/{id}")]
        public IActionResult DeleteAdministradorById(int id)
        {
            try
            {
                _administradoresService.DeleteAdministradorById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
