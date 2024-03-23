using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFlex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class EntregadorController : Controller
    {
        private readonly IEntregadorRepository _entregadorRepository;

        public EntregadorController(IEntregadorRepository entregadorRepository)
        {
            _entregadorRepository = entregadorRepository;
        }

        [HttpGet("ListaEntregador")]
        public async Task<IActionResult> ListaEntregador()
        {
            return Json(await _entregadorRepository.GetAll());
        }

        [HttpPost("AdicionaEntregador")]
        public async Task AdicionaEntregador(EntregadorDto entregador)
        {
            await _entregadorRepository.Add(entregador);
        }

        [HttpPost("ListaEntregadorPorId")]
        public async Task<IActionResult> AdicionaEntregador(int Id)
        {
            return Json(await _entregadorRepository.GetEntityById(Id));
        }

        [HttpPut("AlteraEntregador")]
        public async Task AlteraEntregador(EntregadorDto entregador)
        {
            await _entregadorRepository.Update(entregador);
        }

        [HttpDelete("DeletaEntregador")]
        public async Task DeletaEntregador(EntregadorDto entregador)
        {
            await _entregadorRepository.Delete(entregador);
        }
    }
}