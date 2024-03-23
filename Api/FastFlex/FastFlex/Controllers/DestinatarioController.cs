using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFlex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class DestinatarioController : Controller
    {
        private readonly IDestinatarioRepository _destinatarioRepository;

        public DestinatarioController(IDestinatarioRepository destinatarioRepository)
        {
            _destinatarioRepository = destinatarioRepository;
        }

        [HttpGet("ListaDestinatarios")]
        public async Task<IActionResult> ListaDestinatarios()
        {
            return Json(await _destinatarioRepository.GetAll());
        }

        [HttpPost("AdicionaDestinatario")]
        public async Task AdicionaDestinatario(DestinatarioDto destinatario)
        {
            await _destinatarioRepository.AdicionaDestinatario(destinatario);
        }

        [HttpPost("ListarDestinatariosPorId")]
        public async Task<IActionResult> ListarDestinatariosPorId(int Id)
        {
            return Json(await _destinatarioRepository.GetEntityById(Id));
        }

        [HttpPut("AlteraDestinatario")]
        public async Task AlteraDestinatario(DestinatarioDto destinatario)
        {
            await _destinatarioRepository.Update(destinatario);
        }

        [HttpDelete("DeletaDestinatario")]
        public async Task DeletaDestinatario(DestinatarioDto destinatario)
        {
            await _destinatarioRepository.Delete(destinatario);
        }
    }
}