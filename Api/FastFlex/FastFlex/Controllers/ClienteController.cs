using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFlex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository; 
        }
        
        [AllowAnonymous]
        [HttpGet("ListaClientes")]
        public async Task<IActionResult> ListaClientes()
        {
            return Json(await _clienteRepository.GetAll());
        }

        [AllowAnonymous]
        [HttpPost("AdicionaCliente")]
        public async Task AdicionaCliente(ClienteDto cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        [HttpPost("ListaClientePorId")]
        public async Task<IActionResult> ListaClientePorId(int Id)
        {
            return Json(await _clienteRepository.GetEntityById(Id));
        }

        [HttpPut("AlteraCliente")]
        public async Task AlteraDestinatario(ClienteDto cliente)
        {
            await _clienteRepository.Update(cliente);
        }

        [HttpDelete("DeletaCliente")]
        public async Task DeletaDestinatario(ClienteDto cliente)
        {
            await _clienteRepository.Delete(cliente);
        }
    }
}