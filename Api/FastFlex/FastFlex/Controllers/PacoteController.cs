using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFlex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class PacoteController : Controller
    {
        private readonly IPacoteRepository _pacoteRepository;

        public PacoteController(IPacoteRepository pacoteRepository)
        {
            _pacoteRepository = pacoteRepository;
        }

        [HttpGet("ListaPacote")]
        public async Task<IActionResult> ListaPacote()
        {
            return Json(await _pacoteRepository.GetAll());
        }

        [HttpPost("AdicionaPacote")]
        public async Task AdicionaPacote(PacoteDto pacote)
        {
            await _pacoteRepository.Add(pacote);
        }

        [HttpPost("ListaPacotePorId")]
        public async Task<IActionResult> ListaPacotePorId(int Id)
        {
            return Json(await _pacoteRepository.GetEntityById(Id));
        }

        [HttpPut("AlteraPacote")]
        public async Task AlteraPacote(PacoteDto pacote)
        {
            await _pacoteRepository.Update(pacote);
        }

        [HttpDelete("DeletaPacote")]
        public async Task DeletaPacote(PacoteDto pacote)
        {
            await _pacoteRepository.Delete(pacote);
        }
    }
}