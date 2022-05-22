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
    public class GenerosController : ControllerBase
    {
        private IGeneroRepository _GeneroRepository { get; set; }
        public GenerosController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GeneroDomain> listaGeneros = _GeneroRepository.ReadAll();
            return Ok(listaGeneros);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _GeneroRepository.GetById(id);
            if(generoBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "[ERRO] Gênero não encontrado",
                            erro = true
                        }
                    );
            }

            return Ok(generoBuscado);
        }

        [HttpPost]
        [Authorize(Roles = "True")]
        public IActionResult Post(GeneroDomain genero)
        {
            _GeneroRepository.Create(genero);
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "True")]
        public IActionResult Delete(int id)
        {
            _GeneroRepository.Delete(id);
            return StatusCode(204);
        }

        [HttpPut]
        [Authorize(Roles = "True")]
        public IActionResult PutBody(GeneroDomain genero)
        {
            try
            {
                _GeneroRepository.UpdateBody(genero);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "True")]
        public IActionResult PutUrl(GeneroDomain genero, int id)
        {
            GeneroDomain generoBuscado = _GeneroRepository.GetById(id);
            if(generoBuscado == null)
            {
                return NotFound(
                new
                {
                    mensagem="[ERRO] Gênero não encontrado",
                    erro=true
                });
            }

            try
            {
                _GeneroRepository.UpdateUrl(genero, id);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
