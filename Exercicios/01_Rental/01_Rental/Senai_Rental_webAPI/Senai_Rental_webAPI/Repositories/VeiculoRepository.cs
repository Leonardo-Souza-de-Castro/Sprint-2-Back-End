using Senai_Rental_webAPI.Domains;
using Senai_Rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webAPI.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        public void AtualizarIdUrl(VeiculoDomain veiculoatualizado, int IdVeiculo)
        {
            throw new NotImplementedException();
        }

        public VeiculoDomain BuscarporId(int IdVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IdVeiculo)
        {
            throw new NotImplementedException();
        }

        public List<VeiculoDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
