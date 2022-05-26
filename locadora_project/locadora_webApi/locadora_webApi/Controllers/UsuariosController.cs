using locadora_webApi.Domains;
using locadora_webApi.Interfaces;
using locadora_webApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTiposUsuario.ToString()),
                    new Claim("Role", usuarioBuscado.IdTiposUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-secreta-locadora"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var myToken = new JwtSecurityToken(
                        issuer: "Minha API",
                        audience: "Minha API",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials : creds
                    );

                return Ok(
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(myToken)
                        }
                    );
            }

            return NotFound("Email e/ou senha incorretos!");
        }
    }
}
