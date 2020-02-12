using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BOLETO_CHEQUE_DAL
    {
        public string strConnection;

        public BOLETO_CHEQUE_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public int? Inserir(BOLETO_CHEQUE_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("INSERT INTO ");
                    SQL_.Append("BOLETO_CHEQUE ");
                    SQL_.Append("( ");

                    SQL_.Append("ID_FINANCEIRO, ");
                    SQL_.Append("NUMERO, ");
                    SQL_.Append("PARCELA, ");
                    SQL_.Append("FORMA_PAGAMENTO, ");
                    SQL_.Append("VALOR, ");
                    SQL_.Append("DATA_VENCTO, ");
                    SQL_.Append("STATUS_PAGAMENTO, ");
                    SQL_.Append("ATIVO ");

                    SQL_.Append(") ");
                    SQL_.Append("VALUES ");
                    SQL_.Append("( ");

                    SQL_.Append("@ID_FINANCEIRO, ");
                    SQL_.Append("@NUMERO, ");
                    SQL_.Append("@PARCELA, ");
                    SQL_.Append("@FORMA_PAGAMENTO, ");
                    SQL_.Append("@VALOR, ");
                    SQL_.Append("@DATA_VENCTO, ");
                    SQL_.Append("@STATUS_PAGAMENTO, ");
                    SQL_.Append("1 ");
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

        public bool Alterar(BOLETO_CHEQUE_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("UPDATE ");
                    SQL_.Append("BOLETO_CHEQUE ");
                    SQL_.Append("SET ");

                    SQL_.Append("ID_FINANCEIRO = @ID_FINANCEIRO, ");
                    SQL_.Append("NUMERO = @NUMERO, ");
                    SQL_.Append("PARCELA = @PARCELA, ");
                    SQL_.Append("FORMA_PAGAMENTO = @FORMA_PAGAMENTO, ");
                    SQL_.Append("VALOR = @VALOR, ");
                    SQL_.Append("DATA_VENCTO = @DATA_VENCTO, ");
                    SQL_.Append("STATUS_PAGAMENTO = @STATUS_PAGAMENTO, ");
                    SQL_.Append("ATIVO = @ATIVO ");

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
                SqlCommand cmd = new SqlCommand("DELETE FROM BOLETO_CHEQUE WHERE ID = " + id, conexao);
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

        public void PopularParametros(BOLETO_CHEQUE_DTO DTO, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ID", DTO.ID);
            cmd.Parameters.AddWithValue("@ID_FINANCEIRO", DTO.ID_FINANCEIRO);
            cmd.Parameters.AddWithValue("@NUMERO", DTO.NUMERO);
            cmd.Parameters.AddWithValue("@PARCELA", DTO.PARCELA);
            cmd.Parameters.AddWithValue("@FORMA_PAGAMENTO", DTO.FORMA_PAGAMENTO);
            cmd.Parameters.AddWithValue("@VALOR", DTO.VALOR);
            cmd.Parameters.AddWithValue("@DATA_VENCTO", DTO.DATA_VENCTO);
            cmd.Parameters.AddWithValue("@STATUS_PAGAMENTO", DTO.STATUS_PAGAMENTO);
            cmd.Parameters.AddWithValue("@VALOR", DTO.VALOR);
            cmd.Parameters.AddWithValue("@DATA_VENCTO", DTO.DATA_VENCTO);
            cmd.Parameters.AddWithValue("@STATUS_PAGAMENTO", DTO.STATUS_PAGAMENTO);
            cmd.Parameters.AddWithValue("@ATIVO", DTO.ATIVO);


            //Substitui o null por DBnull
            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

        }

        public List<BOLETO_CHEQUE_DTO> Seleciona_by_Id_Financeiro(int ID_FINANCEIRO)
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                List<BOLETO_CHEQUE_DTO> lista = new List<BOLETO_CHEQUE_DTO>();
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM BOLETO_CHEQUE WHERE ID_FINANCEIRO = " + ID_FINANCEIRO + ";");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    while (dtr.Read())
                    {
                        BOLETO_CHEQUE_DTO DTO = new BOLETO_CHEQUE_DTO();
                        PopularDados(dtr, DTO);
                        lista.Add(DTO);
                    }

                    return lista;
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

        public void PopularDados(SqlDataReader dtr, BOLETO_CHEQUE_DTO DTO)
        {
            try
            {
                DTO.ID = Convert.ToInt32(dtr["ID"]);
                DTO.ID_FINANCEIRO = Convert.ToInt32(dtr["ID_FINANCEIRO"]);
                DTO.NUMERO = dtr["NUMERO"].ToString();
                DTO.FORMA_PAGAMENTO = dtr["FORMA_PAGAMENTO"].ToString();
                DTO.PARCELA = Convert.ToInt32(dtr["PARCELA"]);
                DTO.VALOR = dtr["VALOR"] == DBNull.Value? (decimal?)null : Convert.ToDecimal(dtr["VALOR"]);
                DTO.DATA_VENCTO = dtr["DATA_VENCTO"] == DBNull.Value? (DateTime?)null : Convert.ToDateTime(dtr["DATA_VENCTO"]);
                DTO.STATUS_PAGAMENTO = dtr["STATUS_PAGAMENTO"] == DBNull.Value? "" : Convert.ToString(dtr["STATUS_PAGAMENTO"]);
                DTO.ATIVO = Convert.ToBoolean(dtr["ATIVO"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
