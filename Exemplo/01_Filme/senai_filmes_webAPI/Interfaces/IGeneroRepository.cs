using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interfce responsavel pelo repositorio GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        // Estrutura de métodos da Interface
        // Tipo_Retorno Nome_Metodo (Tipo_Parametro Nome_Parametro)
        
        /// <summary>
        /// Método que retorna todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<Genero_Domain> Listar_Todos();

        /// <summary>
        /// Método que busca um genero com base no Id
        /// </summary>
        /// <param name="Id_Genero"> Id do genero que será buscado</param>
        /// <returns>Retorna um unico genero, que foi buscado</returns>
        Genero_Domain Buscar_Por_Id(int Id_Genero);

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="genero_novo"> Objeto novo com os dados que serão cadastrados</param>
        void Cadastrar(Genero_Domain genero_novo);

        /// <summary>
        /// Atualiza um genero passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero"> Objeto geenero com novos dados</param>
        void AtualizarIdCorpo(Genero_Domain genero);

        /// <summary>
        /// Atualiza um genero existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="Id_genero"> Id do genero que sera atualizado</param>
        /// <param name="genero">Objeto genero com novos dados</param>
        void AtualizarIdUrl(int Id_genero, Genero_Domain genero);

        /// <summary>
        /// Deleta um genero
        /// </summary>
        /// <param name="IdGenero">Id do genero que sera deletado</param>
        void Deletar(int IdGenero);
    }
}
