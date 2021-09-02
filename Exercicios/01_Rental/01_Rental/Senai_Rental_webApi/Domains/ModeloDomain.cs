using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webApi.Domains
{
    public class ModeloDomain
    {
        public int IdModelo { get; set; }
        public string Modelo_Veiculo { get; set; }
        public VeiculoDomain Veiculo { get; set; }
    }
}
