using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webAPI.Domains
{
    public class AlugaDomain
    {
        public int IdAluguel { get; set; }
        public string Descricao_Aluguel { get; set; }
        public string Data_Emprestimo { get; set; }
        public string Data_devolucao { get; set; }
        public ClienteDomain Cliente { get; set; }
        public VeiculoDomain Veiculo { get; set; }
    }
}
