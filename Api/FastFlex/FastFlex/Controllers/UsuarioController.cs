using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFlex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [AllowAnonymous]
        /// <summary>
        /// Ready
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListaUsuarios")]
        public async Task<IActionResult> ListaUsuarios()
        {
            return Json(await _usuarioRepository.GetAll());
        }

        /// <summary>
        /// Ready
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("AdicionaUsuario")]
        public async Task AdicionaUsuario(UsuarioDto usuario)
        {
            await _usuarioRepository.Add(usuario);
        }

        [HttpPost("ListaUsuarioPorId")]
        public async Task<IActionResult> ListaUsuarioPorId(int Id)
        {
            return Json(await _usuarioRepository.GetEntityById(Id));
        }

        [AllowAnonymous]
        [HttpGet("ListaUsuarioPorCredenciais")]
        public int ListaUsuarioPorCredenciais(string email, string senha)
        {
            return _usuarioRepository.GetUserId(email, senha);
        }

        [HttpPut("AlteraUsuario")]
        public async Task AlteraUsuario(UsuarioDto usuario)
        {
            await _usuarioRepository.Update(usuario);
        }

        [HttpDelete("DeletaUsuario")]
        public async Task DeletaUsuario(UsuarioDto usuario)
        {
            await _usuarioRepository.Delete(usuario);
        }
    }
}