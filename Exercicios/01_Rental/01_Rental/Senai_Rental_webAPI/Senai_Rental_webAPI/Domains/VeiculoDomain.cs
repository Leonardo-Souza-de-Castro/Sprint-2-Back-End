using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webAPI.Domains
{
    public class VeiculoDomain
    {
        public int IdVeiculo { get; set; }
        public string Placa { get; set; }
        public EmpresaDomain Empresa { get; set; }
    }
}
