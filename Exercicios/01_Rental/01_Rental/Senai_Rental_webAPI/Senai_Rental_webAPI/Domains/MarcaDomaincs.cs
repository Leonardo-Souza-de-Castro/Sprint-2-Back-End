using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webAPI.Domains
{
    public class MarcaDomaincs
    {
        public int IdMarca { get; set; }
        public int Marca_Veiculo { get; set; }
        public ModeloDomain Modelo { get; set; }
    }
}
