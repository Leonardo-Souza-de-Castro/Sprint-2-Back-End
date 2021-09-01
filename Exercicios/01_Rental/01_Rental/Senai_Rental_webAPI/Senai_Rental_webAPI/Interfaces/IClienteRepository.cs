using Senai_Rental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webAPI.Interfaces
{
    interface IClienteRepository
    {
        /// <summary>
        /// Método utilizado para listar todos os Clientes cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de clientes</returns>
        List<ClienteDomain> Listar_Todos();

        /// <summary>
        /// Método utilizado para buscar os clientes por um Id especifico
        /// </summary>
        /// <param name="IdCliente">Id do Cliente buscado</param>
        /// <returns>Retorna o Cliente que tem aquele Id</returns>
        ClienteDomain BuscarporId(int IdCliente);

        /// <summary>
        /// Método utilizado para cadastrar novos clientes
        /// </summary>
        /// <param name="novoCliente">Dados do novo cliente a ser cadastrado</param>
        void Cadastrar(ClienteDomain novoCliente);

        /// <summary>
        /// Método utilizado para atualizar os dados de um cliente
        /// </summary>
        /// <param name="clienteatualizado">Dados que devem ser atualizados</param>
        void AtualizarIdCorpo(ClienteDomain clienteatualizado);

        /// <summary>
        /// Método utilizado para deletar dados de alugueis
        /// </summary>
        /// <param name="IdCliente">Id do aluguel a ser deletado</param>
        void Deletar(int IdCliente);
    }
}
