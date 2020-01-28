using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class PesquisaGeralDAL
    {
        string strConexao;

        public PesquisaGeralDAL(string ConnectionString)
        {
            this.strConexao = ConnectionString;
        }

        public DataTable Pesquisa(string Query)
        {
            using (SqlConnection scn = new SqlConnection(this.strConexao))
            {
                try
                {
                    scn.Open();

                    SqlCommand scm = scn.CreateCommand();
                    scm.CommandText = Query;
                    scm.CommandTimeout = 120;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = scm;

                    DataTable dtt = new DataTable();
                    sda.Fill(dtt);
                    sda.Dispose();
                    return dtt;

                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                finally
                {
                    scn.Close();
                }
            }
        }

        //Selecionar Filtro
        public PesquisaGeralFiltroDTO SelecionaFiltro(int Id)
        {
            using (SqlConnection scn = new SqlConnection(this.strConexao))
            {
                SqlDataReader dtr = null;
                PesquisaGeralFiltroDTO FiltroDTO = new PesquisaGeralFiltroDTO();

                try
                {
                    string sql = "SELECT * FROM Filtros WHERE (ID = " + Id + ")";
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sql, scn);
                    dtr = scm.ExecuteReader();

                    if (dtr.Read())
                    {
                        FiltroDTO.Id = Convert.ToInt32(dtr["id"]);
                        FiltroDTO.App = dtr["app"].ToString();
                        FiltroDTO.Img = Convert.ToInt32(dtr["img"]);
                        FiltroDTO.Nome = dtr["nome"].ToString();
                        FiltroDTO.Opcao = dtr["opcao"].ToString();
                        FiltroDTO.Sql = dtr["sql"].ToString();
                        FiltroDTO.Rep = dtr["rep"].ToString();
                        FiltroDTO.UserType = dtr["usertype"].ToString();
                        FiltroDTO.SqlChanged = "";
                    }
                    else
                    {
                        throw new Exception("Não foi possível localizar o filtro Id nº " + Id + "!");
                    }
                    return FiltroDTO;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (dtr != null) { dtr.Close(); }
                    scn.Close();
                }
            }
        }

        //Incluir Dados
        public void Incluir(PesquisaGeralFiltroDTO FiltroDTO)
        {
            using (SqlConnection scn = new SqlConnection(this.strConexao))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO [Filtros] ");
                    sb.Append("([App]");
                    sb.Append(",[img]");
                    sb.Append(",[Nome]");
                    sb.Append(",[Opcao]");
                    sb.Append(",[SQL]");
                    sb.Append(",[usertype]");
                    sb.Append(",[Rep])");
                    sb.Append(" VALUES ");
                    sb.Append("(@App");
                    sb.Append(",@img");
                    sb.Append(",@Nome");
                    sb.Append(",@Opcao");
                    sb.Append(",@SQL");
                    sb.Append(",@usertype");
                    sb.Append(",@Rep)");
                    sb.Append(";SELECT SCOPE_IDENTITY();");
                    scn.Open();

                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    //Popula os parametros com os seus respectivos valores
                    Popular_Parametros(scm, FiltroDTO);

                    //Retorna o id do insert
                    FiltroDTO.Id = Convert.ToInt32(scm.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    scn.Close();
                }
            }
        }

        //Alterar Dados
        public void Alterar(PesquisaGeralFiltroDTO FiltroDTO)
        {
            using (SqlConnection scn = new SqlConnection(this.strConexao))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE [Filtros] SET [App] = @App");
                    sb.Append(",[img] = @img");
                    sb.Append(",[Nome] = @Nome");
                    sb.Append(",[Opcao] = @Opcao");
                    sb.Append(",[SQL] = @SQL");
                    sb.Append(",[Rep] = @Rep");
                    sb.Append(",[usertype] = @usertype");
                    sb.Append(" WHERE (id = @Id)");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    Popular_Parametros(scm, FiltroDTO);

                    if (scm.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("O registro Id nº " + FiltroDTO.Id + " não foi localizado.\nNão foi possível registrar as alterações!");
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    scn.Close();
                }
            }
        }

        //Excluir Dados
        public int Excluir(int Id)
        {
            using (SqlConnection scn = new SqlConnection(this.strConexao))
            {
                try
                {
                    string sql = "DELETE FROM Filtros WHERE (Id = " + Id.ToString() + ")";
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sql, scn);
                    return (int)scm.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    scn.Close();
                }
            }
        }

        //Popular Parametros
        private void Popular_Parametros(SqlCommand scm, PesquisaGeralFiltroDTO FiltroDTO)
        {
            try
            {
                scm.Parameters.AddWithValue("@id", FiltroDTO.Id); //Utilizado no where no caso de alteração

                scm.Parameters.AddWithValue("@App", FiltroDTO.App);
                scm.Parameters.AddWithValue("@img", FiltroDTO.Img);
                scm.Parameters.AddWithValue("@nome", FiltroDTO.Nome);
                scm.Parameters.AddWithValue("@Opcao", FiltroDTO.Opcao);
                scm.Parameters.AddWithValue("@SQL", FiltroDTO.Sql);
                scm.Parameters.AddWithValue("@UserType", FiltroDTO.UserType);
                scm.Parameters.AddWithValue("@Rep", "N");
                //Substitui o null por DBnull
                foreach (SqlParameter Parameter in scm.Parameters)
                {
                    if (Parameter.Value == null)
                    {
                        Parameter.Value = DBNull.Value;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
