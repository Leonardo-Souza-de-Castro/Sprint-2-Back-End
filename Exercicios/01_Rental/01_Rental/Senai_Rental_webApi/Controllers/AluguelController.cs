using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Rental_webApi.Domains;
using Senai_Rental_webApi.Interfaces;
using Senai_Rental_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }

        public AluguelController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> lista_Alugueis = _AluguelRepository.Listar_Todos();

            return Ok(lista_Alugueis);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarporId(id);

            if (aluguelBuscado == null)
            {
                return NotFound("nenhum Aluguel encontrado");
            }

            return Ok(aluguelBuscado);
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain aluguel_novo)
        {
            _AluguelRepository.Cadastrar(aluguel_novo);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutURL(AluguelDomain aluguel, int id)
        {
            AluguelDomain aluguel_Buscado = _AluguelRepository.BuscarporId(id);

            if (aluguel_Buscado != null)
            {
                try
                {
                    _AluguelRepository.AtualizarIdUrl(aluguel, id);

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
                        mensagem = "Aluguel não encontrado!",
                        erro = true
                    });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _AluguelRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
