using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositório de filmes
    /// </summary>
    interface IFilmeRepository
    {
        List<Filme_Domain> Listar_Todos();

        Filme_Domain BuscarPorId(int IdFilme);

        void Cadastrar(Filme_Domain novo_Filme);

        void AtualizarIdUrl(int IdFilme, Filme_Domain filme);

        void Deletar(int IdFilme);
    }
}
