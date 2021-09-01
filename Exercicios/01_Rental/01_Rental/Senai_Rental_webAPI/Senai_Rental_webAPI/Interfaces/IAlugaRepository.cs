using Senai_Rental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webAPI.Interfaces
{
    interface IAlugaRepository
    {
        List<AlugaDomain> Listar_Todos();

        AlugaDomain BuscarporId(int IdAluga);

        void Cadastrar(AlugaDomain novoAluguel);

        void AtualizarIdUrl(AlugaDomain aluguelatualizado, int IdAluguel);

        void Deletar(int IdAluguel);
    }
}
