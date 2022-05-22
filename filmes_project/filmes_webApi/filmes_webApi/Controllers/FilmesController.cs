using filmes_webApi.Domains;
using filmes_webApi.Interfaces;
using filmes_webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmes_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _FilmeRepository { get; set; }
        public FilmesController()
        {
            _FilmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Retorna uma lista de filmes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<FilmeDomain> listaFilmes = _FilmeRepository.Read();
            return Ok(listaFilmes);
        }

        [HttpPost]
        [Authorize(Roles = "True")]
        public IActionResult Post(FilmeDomain filme)
        {
            _FilmeRepository.Create(filme);
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "True")]
        public IActionResult Delete(int id)
        {
            _FilmeRepository.Delete(id);
            return StatusCode(204);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FilmeDomain filmeBuscado = _FilmeRepository.GetById(id);
            
            if (filmeBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "[ERRO] Filme não encontrado",
                            erro = true
                        }
                    );
            }

            return Ok(filmeBuscado);
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "True")]
        public IActionResult PutUrl(FilmeDomain filme , int id)
        {
            FilmeDomain filmeBuscado = _FilmeRepository.GetById(id);
            if(filmeBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "[ERRO] Filme não encontrado",
                            erro = true
                        }
                    );
            }

            
            _FilmeRepository.UpdateUrl(filme , id);
            return StatusCode(201);
            
        }
    }
}
