using Senai_Rental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webAPI.Interfaces
{
    interface IVeiculoRepository
    {
        /// <summary>
        /// Método utilizado para listar todos os Veiculos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de veiculos</returns>
        List<VeiculoDomain> ListarTodos();

        /// <summary>
        /// Método utilizado para buscar os veiculos por um Id especifico
        /// </summary>
        /// <param name="IdVeiculo">Id do Veiculo buscado</param>
        /// <returns>Retorna o Veiculo que tem aquele Id</returns>
        VeiculoDomain BuscarporId(int IdVeiculo);

        /// <summary>
        /// Método utilizado para cadastrar novos veiculos
        /// </summary>
        /// <param name="novoVeiculo">Dados do novo veiculo a ser cadastrado</param>
        void Cadastrar(VeiculoDomain novoVeiculo);

        /// <summary>
        /// Método utilizado para atualizar os dados de um cliente
        /// </summary>
        /// <param name="veiculoatualizado"> Dados que devem ser atualizados</param>
        /// <param name="IdVeiculo">Id do veiculo que sera atualizado</param>
        void AtualizarIdUrl(VeiculoDomain veiculoatualizado, int IdVeiculo);

        /// <summary>
        /// Método utilizado para deletar dados de veiculos
        /// </summary>
        /// <param name="IdVeiculo">Id do veiculo a ser deletado</param>
        void Deletar(int IdVeiculo);
    }
}
