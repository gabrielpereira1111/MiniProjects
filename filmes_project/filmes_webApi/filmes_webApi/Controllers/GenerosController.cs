using filmes_webApi.Domains;
using filmes_webApi.Interfaces;
using filmes_webApi.Repositories;
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
        public IActionResult Post(GeneroDomain genero)
        {
            _GeneroRepository.Create(genero);
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _GeneroRepository.Delete(id);
            return StatusCode(204);
        }

        [HttpPut]
        public IActionResult PutBody(GeneroDomain genero)
        { 
            _GeneroRepository.UpdateBody(genero);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
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

            _GeneroRepository.UpdateUrl(genero, id);
            return Ok(201);
        }
    }
}
