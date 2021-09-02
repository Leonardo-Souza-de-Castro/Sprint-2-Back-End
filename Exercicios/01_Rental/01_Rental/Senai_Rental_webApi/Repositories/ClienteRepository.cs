using Senai_Rental_webApi.Domains;
using Senai_Rental_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string stringConexao = "Data Source=NOTE0113E2\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132";

        public void AtualizarIdCorpo(ClienteDomain clienteatualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBody = "Update Cliente Set Nome = @Nome, Sobrenome = @Sobrenome,CPF = @CPF where IdCliente = @Id";

                using (SqlCommand cmd = new SqlCommand(queryBody, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", clienteatualizado.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", clienteatualizado.Sobrenome);
                    cmd.Parameters.AddWithValue("@CPF", clienteatualizado.CPF);
                    cmd.Parameters.AddWithValue("@Id", clienteatualizado.IdCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarporId(int IdCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "Select IdCliente, Nome, Sobrenome, CPF From Cliente Where IdCliente = @id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@id", IdCliente);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        ClienteDomain clientebuscado = new ClienteDomain()
                        {
                            IdCliente = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            CPF = rdr[3].ToString()
                        };

                        return clientebuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "Insert Into Cliente(Nome,Sobrenome,CPF) Values ('@Nome', '@Sobrenome', '@CPF')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoCliente.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", novoCliente.Sobrenome);
                    cmd.Parameters.AddWithValue("@CPF", novoCliente.CPF);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "Delete From Cliente Where IdCliente = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", IdCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> Listar_Todos()
        {
            List<ClienteDomain> Lista_Clientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "Select IdCliente, Nome, Sobrenome, CPF From Cliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            IdCliente = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            CPF = rdr[3].ToString(),
                        };

                        Lista_Clientes.Add(cliente);
                    }
                }
            }

            return Lista_Clientes;
        }
    }
}
