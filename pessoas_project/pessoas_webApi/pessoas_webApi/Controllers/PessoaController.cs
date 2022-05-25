using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pessoas_webApi.Domains;
using pessoas_webApi.Interfaces;
using pessoas_webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace pessoas_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IPessoaRepository _pessoaRepository { get; set; }

        public PessoaController()
        {
            _pessoaRepository = new PessoaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Pessoa> listaPessoas = _pessoaRepository.ReadAll();
            return Ok(listaPessoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Pessoa pessoa = _pessoaRepository.GetById(id);

            if(pessoa == null)
            {
                return NotFound(new {
                    mensagem = "Pessoa não encontrada",
                });
            }

            try
            {
                return Ok(pessoa);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult Post(Pessoa pessoa)
        {
            _pessoaRepository.Create(pessoa);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                Pessoa pessoaBuscada = _pessoaRepository.GetById(id);   
                
                if (pessoaBuscada != null)
                {
                    _pessoaRepository.Delete(id);
                    return NoContent();
                }

                return NotFound(new
                {
                    mensagem = "Pessoa não encontrada"
                });
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPatch("login")]
        public IActionResult Login(string cpf)
        {
            Pessoa pessoaBuscada = _pessoaRepository.Login(cpf);
            
            try
            {
                if (pessoaBuscada != null)
                {
                    //Payload
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, pessoaBuscada.IdPessoa.ToString()),
                        new Claim(JwtRegisteredClaimNames.Name, pessoaBuscada.Nome),
                        new Claim("CPF", pessoaBuscada.Cpf)
                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-secreta-pessoas"));

                    var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var myToken = new JwtSecurityToken(
                            issuer: "pessoas_webApi",
                            audience: "pessoas_webApi",
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

                return NotFound(new
                {
                    mensagem = "Pessoa não encontrada"
                });

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
