using locadora_webApi.Domains;
using locadora_webApi.Interfaces;
using locadora_webApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace locadora_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IUsuariosRepository _usuariosRepository { get; set; } = null!;
        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpPost("login")]
        public IActionResult Login(Usuarios usuario)
        {
            Usuarios usuarioBuscado = _usuariosRepository.Login(usuario.Email, usuario.Senha);
            if (usuarioBuscado != null)
            {
                return Ok(usuarioBuscado);
            }

            return NotFound("Email e/ou senha incorretos!");
        }
    }
}
