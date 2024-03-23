using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFlex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TipoUsuarioController : Controller
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        [HttpGet("ListaTipoUser")]
        public async Task<IActionResult> ListaTipoUser()
        {
            return Json(await _tipoUsuarioRepository.GetAll());
        }

        [HttpPost("AdicionaTipoUser")]
        public async Task AdicionaTipoUser(TipoUsuarioDto tipoUsuario)
        {
            await _tipoUsuarioRepository.Add(tipoUsuario);
        }

        [HttpPost("ListaTipoUserPorId")]
        public async Task<IActionResult> ListaTipoUserPorId(int Id)
        {
            return Json(await _tipoUsuarioRepository.GetEntityById(Id));
        }

        [HttpPut("AlteraTipoUser")]
        public async Task AlteraTipoUser(TipoUsuarioDto tipoUsuario)
        {
            await _tipoUsuarioRepository.Update(tipoUsuario);
        }

        [HttpDelete("DeletaTipoUser")]
        public async Task DeletaTipoUser(TipoUsuarioDto tipoUsuario)
        {
            await _tipoUsuarioRepository.Delete(tipoUsuario);
        }
    }
}