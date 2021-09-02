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
    public class VeiculoController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }

        public VeiculoController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculo = _VeiculoRepository.ListarTodos();

            return Ok(listaVeiculo);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain veiculobuscado = _VeiculoRepository.BuscarporId(id);

            if (veiculobuscado == null)
            {
                return NotFound("Nenhum gênero encontrado");
            }

            return Ok(veiculobuscado);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain veiculo_novo)
        {
            _VeiculoRepository.Cadastrar(veiculo_novo);

            return StatusCode(201);
        }

        [HttpPut ("{id}")]
        public IActionResult PutURL(VeiculoDomain veiculo, int id)
        {
            VeiculoDomain veiculo_buscadao = _VeiculoRepository.BuscarporId(id);

            if (veiculo_buscadao != null)
            {
                try
                {
                    _VeiculoRepository.AtualizarIdUrl(veiculo, id);

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
                        mensagem = "Veiculo não encontrado!",
                        erro = true
                    });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _VeiculoRepository.Deletar(id);

            return StatusCode(204);
        }

    }
}
