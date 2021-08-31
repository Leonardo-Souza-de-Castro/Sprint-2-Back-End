using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Controllers
{
    // Define que o tipo de resposta da Api sera no formato JSON
    [Produces("application/json")]

    // Define que a rota será no formato dominio/api/nomeController
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {

        private IGeneroRepository _GeneroRepository { get; set; }

        /// <summary>
        /// Instancia de um objeto _GeneroRepository para que haja a referencia dos método no repositório
        /// </summary>
        public GenerosController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        [HttpGet]
        //IActionResult = Resultado de uma ação
        //Get() = nome generico para a ação
        public IActionResult Get()
        {
            //Retorna uma lista de generos
            //Se conectasr com o epositorio

            // Cria uma lista que recebe os dados
            List<Genero_Domain> listaGenero = _GeneroRepository.Listar_Todos();

            //retorna o status code 200(Ok) com a lista de generos no formao JSON
            return Ok(listaGenero);
        }

        [HttpPost]
        public IActionResult Post(Genero_Domain genero_novo) 
        {
            //Chama o método .Cadastrar()
            _GeneroRepository.Cadastrar(genero_novo);

            //Retorna um Status Code 201 - Created (criado).
            return StatusCode(201);
        }

        [HttpPut ("{id}")]
        public IActionResult PutUrl(int id, Genero_Domain genero)
        {
            Genero_Domain generobuscado = _GeneroRepository.Buscar_Por_Id(id);

            if (generobuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Gênero não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _GeneroRepository.AtualizarIdUrl(id, genero);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody(Genero_Domain genero)
        {
            Genero_Domain generobuscado = _GeneroRepository.Buscar_Por_Id(genero.Id_Genero);

            if (generobuscado != null)
            {
                try
                {
                    _GeneroRepository.AtualizarIdCorpo(genero);

                    return NoContent();
                }
                catch (Exception ex)
                {

                    return BadRequest(ex);
                }
            }

            return NotFound
                   (new
                   {
                       mensagem = "Gênero não encontrado!",
                       erro = true
                   });
        }

        [HttpGet ("{id}")]

        public IActionResult GetById(int id)
        {
            Genero_Domain genero_buscado = _GeneroRepository.Buscar_Por_Id(id);

            if (genero_buscado == null)
            {
                return NotFound("Nenhum gênero encontrado");
            }

            return Ok(genero_buscado);
        }
    }
}
