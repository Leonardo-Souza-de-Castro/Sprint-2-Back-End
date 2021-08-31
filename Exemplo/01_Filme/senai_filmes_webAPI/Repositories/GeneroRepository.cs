using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco que recebe os parametros
        /// Data Source = nome do servidor que o banco esta hospedado
        /// initial catalog = Nome do banco
        /// user id = sa;] pwd=senai@132 == Faz a autenticação no com o SQl Server passando Login e Senha
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-R3SNJAL\\SQLEXPRESS; initial catalog=Catalogo; user id=sa; pwd=senai@132";

        //Essa tipo de autenticaçãose refere a autenticação do Windols
        // private string StringConexao = Data Source=DESKTOP-R3SNJAL\\SQLEXPRESS; initial catalog=Catalogo; integrated segurity=true

        public void AtualizarIdCorpo(Genero_Domain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBody = "Update Genero Set nomeGenero = @novo_nome where Id_Genero = @id";

                using (SqlCommand cmd = new SqlCommand(queryBody, con))
                {
                    cmd.Parameters.AddWithValue("@novo_nome", genero.Nome_Genero);

                    cmd.Parameters.AddWithValue("@id", genero.Id_Genero);
                }
            }
        }

        public void AtualizarIdUrl(int Id_genero, Genero_Domain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateURL = "Update Genero Set nomeGenero = @novo_nome where Id_Genero = @id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateURL, con))
                {
                    cmd.Parameters.AddWithValue("@novo_nome", genero.Nome_Genero);

                    cmd.Parameters.AddWithValue("@id", Id_genero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Genero_Domain Buscar_Por_Id(int Id_Genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "Select Id_Genero, NomeGenero From Genero Where = @id";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@id", Id_Genero);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Genero_Domain genero_buscado = new Genero_Domain();
                        {
                            genero_buscado.Id_Genero = Convert.ToInt32(reader[0]);

                            genero_buscado.Nome_Genero = reader[1].ToString();
                        };

                        return genero_buscado;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Ele vai cadastrar um novo genero
        /// </summary>
        /// <param name="genero_novo"> Objeto do tipo genero que sera cadastrado</param>
        public void Cadastrar(Genero_Domain genero_novo)
        {
            //Esse using faz uma conexão com o servidor e quando acabar essa ação ele encerra essa conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrução que vai ser executada no Banco
                string queryInsert = "Insert Into Genero (nome_Genero) Values('"+ @genero_novo.Nome_Genero +"')";
                
                //Abre a conexão
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Ele vai executar nossa ação sem nos devolver nenhum resposta
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Deletar(int IdGenero)
        {
            throw new NotImplementedException();
        }

        public List<Genero_Domain> Listar_Todos()
        {
            List<Genero_Domain> Lista_Generos = new List<Genero_Domain>();

            //O using dentro do método serve para executar uma ação e dps encerrala quando acabar o método por exmplo com as conexões do sql ele conecta loga e dps desconecta
            using (SqlConnection con = new SqlConnection(stringConexao)) 
            {
                //Declara a instrução a ser executada no banco
                string querySelectALL = "Select IdGenero,NomeGenero From Genero";

                //Abre a conexão com o banco
                con.Open();

                SqlDataReader rdr;

                //Manda o banco executar aquela instrução declarada anteriormente, então informamos a string com o comando e a string com o banco
                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    //Ele executa a query e armazena no rdr
                    rdr = cmd.ExecuteReader();

                    //Enqunto houver registros para serem lidos no rdr o while se repete
                    while (rdr.Read())
                    {
                        Genero_Domain genero = new Genero_Domain()
                        {
                            Id_Genero = Convert.ToInt32(rdr[0]),
                            Nome_Genero = rdr[1].ToString(),

                        };

                        Lista_Generos.Add(genero);
                    }
                }
            }

            return Lista_Generos;
        }
    }
}