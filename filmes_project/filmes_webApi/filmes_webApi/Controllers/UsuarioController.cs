using filmes_webApi.Domains;
using filmes_webApi.Interfaces;
using filmes_webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace filmes_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("login")]
        public IActionResult Login(UsuarioDomain usuario)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

            if (usuarioBuscado != null)
            {
               // return Ok(usuarioBuscado);

               var claims = new[]
               {
                   new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                   new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                   new Claim(ClaimTypes.Role, usuarioBuscado.Permissao.ToString()),
                   new Claim("Role", usuarioBuscado.Permissao.ToString())
               };
            }

            return NotFound("Email e/ou senha incorretos!");

        }
    }
}
