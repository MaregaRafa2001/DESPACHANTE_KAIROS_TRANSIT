using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RELATORIOS_DAL
    {
        public string strConnection;

        public RELATORIOS_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public List<RELATORIOS_DTO> Listar()
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                List<RELATORIOS_DTO> list = new List<RELATORIOS_DTO>();

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("SELECT ");
                    SQL_.Append("*  ");
                    SQL_.Append("FROM  ");
                    SQL_.Append("RELATORIOS ");
                    SQL_.Append("WHERE ");
                    SQL_.Append("ATIVO = 1 ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        RELATORIOS_DTO relatorios = new RELATORIOS_DTO();
                        PopularDados(dr, relatorios);
                        list.Add(relatorios);
                    }

                    return list;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.ToString());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());

                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public RELATORIOS_DTO Get_Relatorio_By_Id(int ID)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                RELATORIOS_DTO relatorios = new RELATORIOS_DTO();

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("SELECT ");
                    SQL_.Append("*  ");
                    SQL_.Append("FROM  ");
                    SQL_.Append("RELATORIOS ");
                    SQL_.Append("WHERE ");
                    SQL_.Append("ID = @ID ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        PopularDados(dr, relatorios);
                    }

                    return relatorios;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.ToString());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());

                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public int Inserir(RELATORIOS_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("INSERT INTO ");
                    SQL_.Append("RELATORIOS ");
                    SQL_.Append("( ");

                    SQL_.Append("NOME, ");
                    SQL_.Append("HTML, ");
                    SQL_.Append("LISTAHTML1, ");
                    SQL_.Append("LISTAHTML2, ");
                    SQL_.Append("COLUNAS_GROUP, ");
                    SQL_.Append("QUERY ");

                    SQL_.Append(") ");
                    SQL_.Append("VALUES ");
                    SQL_.Append("( ");

                    SQL_.Append("@NOME, ");
                    SQL_.Append("@HTML, ");
                    SQL_.Append("@LISTAHTML1, ");
                    SQL_.Append("@LISTAHTML2, ");
                    SQL_.Append("@COLUNAS_GROUP, ");
                    SQL_.Append("@QUERY ");
                    SQL_.Append("); SELECT SCOPE_IDENTITY(); ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    PopularParametros(DTO, cmd);

                    if ((DTO.ID = Convert.ToInt32(cmd.ExecuteScalar())) > 0)
                    {
                        return DTO.ID;
                    }

                    return 0;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.ToString());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());

                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public int Alterar(RELATORIOS_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("UPDATE ");
                    SQL_.Append("RELATORIOS ");
                    SQL_.Append("SET ");

                    SQL_.Append("NOME = @NOME, ");
                    SQL_.Append("HTML = @HTML, ");
                    SQL_.Append("LISTAHTML1 = @LISTAHTML1, ");
                    SQL_.Append("LISTAHTML2 = @LISTAHTML2, ");
                    SQL_.Append("COLUNAS_GROUP = @COLUNAS_GROUP, ");
                    SQL_.Append("QUERY = @QUERY ");

                    SQL_.Append("WHERE ID = @ID ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    PopularParametros(DTO, cmd);


                    cmd.ExecuteNonQuery();

                    return DTO.ID;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.ToString());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());

                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public bool Excluir(int id)
        {
            using (SqlConnection conexao = new SqlConnection(this.strConnection))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM RELATORIOS WHERE ID = " + id, conexao);
                try
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    conexao.Close();
                }
            }
        }

        public void PopularDados(SqlDataReader dtr, RELATORIOS_DTO DTO)
        {
            try
            {
                DTO.ID = Convert.ToInt32(dtr["ID"]);
                DTO.NOME = dtr["NOME"].ToString();
                DTO.HTML = dtr["HTML"].ToString();
                DTO.LISTAHTML1 = dtr["LISTAHTML1"].ToString();
                DTO.LISTAHTML2 = dtr["LISTAHTML2"].ToString();
                DTO.QUERY = dtr["QUERY"].ToString();
                DTO.COLUNAS_GROUP = dtr["COLUNAS_GROUP"].ToString();
                DTO.GERARHTML = Convert.ToBoolean(dtr["GERARHTML"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void PopularParametros(RELATORIOS_DTO DTO, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ID", DTO.ID);
            cmd.Parameters.AddWithValue("@NOME", DTO.NOME);
            cmd.Parameters.AddWithValue("@HTML", DTO.HTML);
            cmd.Parameters.AddWithValue("@LISTAHTML1", DTO.LISTAHTML1);
            cmd.Parameters.AddWithValue("@LISTAHTML2", DTO.LISTAHTML2);
            cmd.Parameters.AddWithValue("@COLUNAS_GROUP", DTO.COLUNAS_GROUP);
            cmd.Parameters.AddWithValue("@QUERY", DTO.QUERY);
            cmd.Parameters.AddWithValue("@GERARHTML", DTO.GERARHTML);


            //Substitui o null por DBnull
            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

        }



    }
}
