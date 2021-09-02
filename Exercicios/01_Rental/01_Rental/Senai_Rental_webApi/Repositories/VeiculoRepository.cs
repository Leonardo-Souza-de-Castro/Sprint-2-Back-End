using Senai_Rental_webApi.Domains;
using Senai_Rental_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string stringConexao = "Data Source=NOTE0113E2\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132";
        public void AtualizarIdUrl(VeiculoDomain veiculoatualizado, int IdVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "Update Veiculo Set IdEmpresa = @idempresa Where IdVeiculo = @id";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@idempresa", veiculoatualizado.Empresa.IdEmpresa);
                    cmd.Parameters.AddWithValue("@id", IdVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarporId(int IdVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "Select IdVeiculo,Placa,IdEmpresa From Veiculo Where IdVeiculo = @id";


                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@id", IdVeiculo);
                    
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain veiculobuscado = new VeiculoDomain()
                        {
                            IdVeiculo = Convert.ToInt32(rdr[0]),
                            Placa = rdr[1].ToString(),
                            Empresa = new EmpresaDomain { IdEmpresa = Convert.ToInt32(rdr[2]) }
                        };

                        return veiculobuscado;
                    }

                    return null;
                }
            }
        }
        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "Insert Into Veiculo(Placa, IdEmpresa) Values(@Placa, @IdEmpresa)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Placa", novoVeiculo.Placa);
                    cmd.Parameters.AddWithValue("@IdEmpresa", novoVeiculo.Empresa.IdEmpresa);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "Delete From Veiculo where IdVeiculo = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", IdVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> Lista_Veiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "Select IdVeiculo, Placa, IdEmpresa From Veiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            IdVeiculo = Convert.ToInt32(rdr[0]),
                            Placa = rdr[1].ToString(),
                            Empresa = new EmpresaDomain() { IdEmpresa = Convert.ToInt32(rdr[2]) }
                        };

                        Lista_Veiculos.Add(veiculo);
                    }
                }
            }

            return Lista_Veiculos;
        }
    }
}