using Senai_Rental_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webApi.Interfaces
{
    interface IAluguelRepository
    {
        List<AluguelDomain> Listar_Todos();

        AluguelDomain BuscarporId(int IdAluga);

        void Cadastrar(AluguelDomain novoAluguel);

        void AtualizarIdUrl(AluguelDomain aluguelatualizado, int IdAluguel);

        void Deletar(int IdAluguel);
    }
}
