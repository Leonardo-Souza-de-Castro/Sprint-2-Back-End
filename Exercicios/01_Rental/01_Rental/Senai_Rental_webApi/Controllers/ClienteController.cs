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
        public class ClienteController : ControllerBase
        {
            private IClienteRepository _ClienteRepository { get; set; }

            public ClienteController()
            {
                _ClienteRepository = new ClienteRepository();
            }

            [HttpGet]
            public IActionResult Get()
            {
                List<ClienteDomain> listaCliente = _ClienteRepository.Listar_Todos();

                return Ok(listaCliente);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int Id)
            {
                ClienteDomain cliente_buscado = _ClienteRepository.BuscarporId(Id);

                if (cliente_buscado == null)
                {
                    return NotFound("Nenhum gênero encontrado");
                }

                return Ok(cliente_buscado);
            }

            [HttpPost]
            public IActionResult Post(ClienteDomain cliente_novo)
            {
                _ClienteRepository.Cadastrar(cliente_novo);

                return StatusCode(201);
            }

            [HttpPut]
            public IActionResult PutBody(ClienteDomain cliente)
            {
                ClienteDomain cliente_buscado = _ClienteRepository.BuscarporId(cliente.IdCliente);

                if (cliente_buscado != null)
                {
                    try
                    {
                        _ClienteRepository.AtualizarIdCorpo(cliente);

                        return NoContent();
                    }
                    catch (Exception ex)
                    {

                        return BadRequest(ex);
                    }
                }

                return NotFound(new
                {
                    mensagem = "Cliente não encontrado",
                    erro = true
                });
            }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            _ClienteRepository.Deletar(Id);

            return StatusCode(204);
        }
    }
}

