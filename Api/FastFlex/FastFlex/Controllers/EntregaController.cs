using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFlex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class EntregaController : Controller
    {
        private readonly IEntregaRepository _entregaRepository;

        public EntregaController(IEntregaRepository entregaRepository)
        {
            _entregaRepository = entregaRepository; 
        }

        [HttpGet("ListaEntrega")]
        public async Task<IActionResult> ListaEntrega()
        {
            return Json(await _entregaRepository.GetAll());
        }

        [HttpPost("AdicionaEntrega")]
        public async Task<IActionResult> AdicionaEntrega(EntregaDto entrega)
        {
            return Json(await _entregaRepository.AdicionaEntrega(entrega));
        }

        [HttpPost("ListaEntregaPorId")]
        public async Task<IActionResult> ListaEntregaPorId(int Id)
        {
            return Json(await _entregaRepository.GetEntityById(Id));
        }

        [HttpPut("AlteraEntrega")]
        public async Task AlteraEntrega(EntregaDto entrega)
        {
            await _entregaRepository.Update(entrega);
        }

        [HttpDelete("DeletaEntrega")]
        public async Task DeletaEntrega(EntregaDto entrega)
        {
            await _entregaRepository.Delete(entrega);
        }
    }
}