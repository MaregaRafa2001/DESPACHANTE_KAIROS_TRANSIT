using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DOCUMENTO_FINANCEIRO_DAL
    {
        public string strConnection;

        public DOCUMENTO_FINANCEIRO_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public int? Set_Documento(DOCUMENTO_FINANCEIRO_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("INSERT INTO ");
                    SQL_.Append("DOCUMENTO_FINANCEIRO ");
                    SQL_.Append("( ");
                    //DADOS
                    SQL_.Append("ID_DOCUMENTO,  ");
                    SQL_.Append("ID_FINANCEIRO,  ");
                    SQL_.Append("DATA_ENTREGA,  ");
                    SQL_.Append("DATA_VENCIMENTO ");

                    SQL_.Append(") ");
                    SQL_.Append("VALUES ");
                    SQL_.Append("( ");

                    //DADOS
                    SQL_.Append("@ID_DOCUMENTO,  ");
                    SQL_.Append("@ID_FINANCEIRO,  ");
                    SQL_.Append("@DATA_ENTREGA,  ");
                    SQL_.Append("@DATA_VENCIMENTO ");

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

        public bool Update_Documento(DOCUMENTO_FINANCEIRO_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("UPDATE ");
                    SQL_.Append("DOCUMENTO_FINANCEIRO ");
                    SQL_.Append("SET ");
                    //DADOS
                    SQL_.Append("ID_DOCUMENTO = @ID_DOCUMENTO,  ");
                    SQL_.Append("ID_FINANCEIRO = @ID_FINANCEIRO,  ");
                    SQL_.Append("DATA_ENTREGA = @DATA_ENTREGA,  ");
                    SQL_.Append("DATA_VENCIMENTO = @DATA_VENCIMENTO ");

                    SQL_.Append("WHERE ID = @ID ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    PopularParametros(DTO, cmd);


                    cmd.ExecuteNonQuery();

                    return true;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM DOCUMENTO_FINANCEIRO WHERE ID = " + id, conexao);
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

        public void PopularParametros(DOCUMENTO_FINANCEIRO_DTO DTO, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ID", DTO.ID);
            //DADOS
            cmd.Parameters.AddWithValue("@ID_DOCUMENTO", DTO.ID_DOCUMENTO);
            cmd.Parameters.AddWithValue("@ID_FINANCEIRO", DTO.ID_FINANCEIRO);
            cmd.Parameters.AddWithValue("@DATA_ENTREGA", DTO.DATA_ENTREGA);
            cmd.Parameters.AddWithValue("@DATA_VENCIMENTO", DTO.DATA_VENCIMENTO);

            //Substitui o null por DBnull
            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

        }

        public DOCUMENTO_FINANCEIRO_DTO Seleciona(int Id)
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                DOCUMENTO_FINANCEIRO_DTO DTO = new DOCUMENTO_FINANCEIRO_DTO();

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT ");
                    sb.Append("DOCUMENTO_FINANCEIRO.ID, ");
                    sb.Append("DOCUMENTO_FINANCEIRO.ID_DOCUMENTO, ");
                    sb.Append("DOCUMENTO_FINANCEIRO.ID_FINANCEIRO, ");
                    sb.Append("DOCUMENTO_FINANCEIRO.DATA_ENTREGA, ");
                    sb.Append("DOCUMENTO_FINANCEIRO.DATA_VENCIMENTO, ");
                    sb.Append("DOCUMENTO_FINANCEIRO.USUARIO, ");
                    sb.Append("DOCUMENTO_FINANCEIRO.ULT_ATUAL, ");
                    sb.Append("DOCUMENTO.DOCUMENTO ");
                    sb.Append("FROM ");
                    sb.Append("DOCUMENTO_FINANCEIRO ");
                    sb.Append("LEFT JOIN DOCUMENTO ");
                    sb.Append("ON ");
                    sb.Append("DOCUMENTO_FINANCEIRO.ID_DOCUMENTO = DOCUMENTO.ID ");
                    sb.Append("WHERE  ");
                    sb.Append("(DOCUMENTO_FINANCEIRO.ID = "+ Id + ") ");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    if (dtr.Read())
                    {
                        PopularDados(dtr, DTO);
                        SysDAL.GuardarDTO((IDTO)DTO.Clone());
                    }

                    return DTO;
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

        public void PopularDados(SqlDataReader dtr, DOCUMENTO_FINANCEIRO_DTO DTO)
        {
            DTO.ID = Convert.ToInt32(dtr["ID"]);
            //DADOS
            DTO.ID_DOCUMENTO = dtr["ID_DOCUMENTO"] == DBNull.Value ? (int?)null : Convert.ToInt32(dtr["ID_DOCUMENTO"]);
            DTO.ID_FINANCEIRO = dtr["ID_FINANCEIRO"] == DBNull.Value ? (int?)null : Convert.ToInt32(dtr["ID_FINANCEIRO"]);
            DTO.DATA_ENTREGA = dtr["DATA_ENTREGA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_ENTREGA"]);
            DTO.DATA_VENCIMENTO = dtr["DATA_VENCIMENTO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_VENCIMENTO"]);
            DTO.DOCUMENTO = dtr["DOCUMENTO"] == DBNull.Value ? "" : Convert.ToString(dtr["DOCUMENTO"]);
            DTO.USUARIO = dtr["USUARIO"].ToString();
            DTO.ULT_ATUAL = dtr["ULT_ATUAL"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["ULT_ATUAL"]);
        }


    }
}
