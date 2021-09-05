using Senai_Rental_webApi.Domains;
using Senai_Rental_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = "Data Source=DESKTOP-R3SNJAL\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=senai@132";
        public void AtualizarIdUrl(AluguelDomain aluguelatualizado, int IdAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "Update Aluga Set IdCliente = @IdCliente, IdVeiculo = @IdVeiculo, Descricao_Aluguel = @Descricao, Data_Emprestimo = @DE, Data_devolucao = DD ";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", aluguelatualizado.Cliente.IdCliente);
                    cmd.Parameters.AddWithValue("@IdVeiculo", aluguelatualizado.Veiculo.IdVeiculo);
                    cmd.Parameters.AddWithValue("@Descricao", aluguelatualizado.Descricao_Aluguel);
                    cmd.Parameters.AddWithValue("@DE", aluguelatualizado.Data_Emprestimo);
                    cmd.Parameters.AddWithValue("@DD", aluguelatualizado.Data_devolucao);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarporId(int IdAluga)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "Select IdAluguel, Descricao_Aluguel As [Descrição do Aluguel], Data_Emprestimo As [Data de Emprestimo], Data_devolucao As [Data de Devolução], Nome, Sobrenome, Modelo_Veiculo As Modelo" +
                  "From Aluga as A " +
                  "Inner Join Cliente as C on A.IdCliente = C.IdCliente " +
                  "Inner Join Modelo As V on V.IdVeiculo = A.IdVeiculo Where IdAluguel = @id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@id", IdAluga);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelbuscado = new AluguelDomain()
                        {
                            IdAluguel = Convert.ToInt32(rdr[0]),
                            Descricao_Aluguel = rdr[1].ToString(),
                            Data_Emprestimo = rdr[2].ToString(),
                            Data_devolucao = rdr[3].ToString(),
                            Cliente = new ClienteDomain() { Nome = rdr[4].ToString(), Sobrenome = rdr[5].ToString() },
                            Modelo = new ModeloDomain() { Modelo_Veiculo = rdr[6].ToString() }
                        };

                        return aluguelbuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "Inser Into Aluga(IdVeiculo, IdCliente, Descricao_Aluguel, Data_devolucao, Data_Emprestimo) Values(@IdVeiculo, @IdCliente, @Descricao, @DD, @DE)"; //DD = Data devolução e DE = Data Emprestimo
                
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdVeiculo", novoAluguel.Veiculo.IdVeiculo);
                    cmd.Parameters.AddWithValue("@IdCliente", novoAluguel.Cliente.IdCliente);
                    cmd.Parameters.AddWithValue("@Descricao", novoAluguel.Descricao_Aluguel);
                    cmd.Parameters.AddWithValue("@DD", novoAluguel.Data_devolucao);
                    cmd.Parameters.AddWithValue("@DE", novoAluguel.Data_Emprestimo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "Delete From Aluga where IdAluguel = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", IdAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> Listar_Todos()
        {
            List<AluguelDomain> Lista_Alugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "Select IdAluguel, Descricao_Aluguel As [Descrição do Aluguel], Data_Emprestimo As [Data de Emprestimo], Data_devolucao As [Data de Devolução], Nome, Sobrenome, Modelo_Veiculo As Modelo From Aluga as A Inner Join Cliente as C on A.IdCliente = C.IdCliente Inner Join Modelo As V on V.IdVeiculo = A.IdVeiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            IdAluguel = Convert.ToInt32(rdr[0]),
                            Descricao_Aluguel = rdr[1].ToString(),
                            Data_Emprestimo = rdr[2].ToString(),
                            Data_devolucao = rdr[3].ToString(),
                            Cliente = new ClienteDomain() { Nome = rdr[4].ToString(), Sobrenome = rdr[5].ToString()},
                            Modelo = new ModeloDomain() { Modelo_Veiculo = rdr[6].ToString()}
                        };

                        Lista_Alugueis.Add(aluguel);
                    }
                }
            }

            return Lista_Alugueis;
        }
    }
}
