using filmes_webApi.Domains;
using filmes_webApi.Interfaces;
using filmes_webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

               // Payload
               var claims = new[]
               {
                   new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                   new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                   new Claim(ClaimTypes.Role, usuarioBuscado.Permissao.ToString()),
                   new Claim("Role", usuarioBuscado.Permissao.ToString())
               };

                // Key
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("minha-chave-segura-filmes"));

                // Signature
                var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Token
                var myToken = new JwtSecurityToken(
                        issuer: "filmes_webApi",
                        audience: "filmes_webApi",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signature
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
