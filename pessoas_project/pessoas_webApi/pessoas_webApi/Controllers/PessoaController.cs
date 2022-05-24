using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pessoas_webApi.Domains;
using pessoas_webApi.Interfaces;
using pessoas_webApi.Repositories;

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
    }
}
