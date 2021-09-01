using Senai_Rental_webAPI.Domains;
using Senai_Rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webAPI.Repositories
{
    public class AlugaRepository : IAlugaRepository
    {
        public void AtualizarIdUrl(AlugaDomain aluguelatualizado, int IdAluguel)
        {
            throw new NotImplementedException();
        }

        public AlugaDomain BuscarporId(int IdAluga)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(AlugaDomain novoAluguel)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IdAluguel)
        {
            throw new NotImplementedException();
        }

        public List<AlugaDomain> Listar_Todos()
        {
            throw new NotImplementedException();
        }
    }
}
