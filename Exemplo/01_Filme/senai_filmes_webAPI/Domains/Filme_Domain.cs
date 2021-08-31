using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    /// <summary>
    /// Essa classe representa a entidade Filme
    /// </summary>
    public class Filme_Domain
    {
        public int Id_Filme { get; set; }

        public int Id_Genero { get; set; }

        public string Nome_Filme { get; set; }
        
        public Genero_Domain genero { get; set; }
    }
}
