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
                    SQL_.Append("ID_FORMA_PAGAMENTO, ");
                    SQL_.Append("FORMA_PAGAMENTO, ");
                    SQL_.Append("ID_FORMA_PAGAMENTO_JUROS, ");
                    SQL_.Append("FORMA_PAGAMENTO_JUROS, ");
                    SQL_.Append("VALOR, ");
                    SQL_.Append("VALOR_JUROS, ");
                    SQL_.Append("DATA_VENCTO, ");
                    SQL_.Append("DATA_PAGAMENTO, ");
                    SQL_.Append("STATUS_PAGAMENTO, ");
                    SQL_.Append("USUARIO, ");
                    SQL_.Append("ULT_ATUAL, ");
                    SQL_.Append("ATIVO, ");
                    SQL_.Append("COBRANCA, ");
                    SQL_.Append("DATA_PROTESTO, ");
                    SQL_.Append("CARTA_ANUENCIA, ");
                    SQL_.Append("CARTORIO ");

                    SQL_.Append(") ");
                    SQL_.Append("VALUES ");
                    SQL_.Append("( ");

                    SQL_.Append("@ID_FINANCEIRO, ");
                    SQL_.Append("@NUMERO, ");
                    SQL_.Append("@PARCELA, ");
                    SQL_.Append("@ID_FORMA_PAGAMENTO, ");
                    SQL_.Append("@FORMA_PAGAMENTO, ");
                    SQL_.Append("@ID_FORMA_PAGAMENTO_JUROS, ");
                    SQL_.Append("@FORMA_PAGAMENTO_JUROS, ");
                    SQL_.Append("@VALOR, ");
                    SQL_.Append("@VALOR_JUROS, ");
                    SQL_.Append("@DATA_VENCTO, ");
                    SQL_.Append("@DATA_PAGAMENTO, ");
                    SQL_.Append("@STATUS_PAGAMENTO, ");
                    SQL_.Append("@USUARIO, ");
                    SQL_.Append("@ULT_ATUAL, ");
                    SQL_.Append("1, ");
                    SQL_.Append("@COBRANCA, ");
                    SQL_.Append("@DATA_PROTESTO, ");
                    SQL_.Append("@CARTA_ANUENCIA, ");
                    SQL_.Append("@CARTORIO ");
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
                    SQL_.Append("ID_FORMA_PAGAMENTO = @ID_FORMA_PAGAMENTO, ");
                    SQL_.Append("FORMA_PAGAMENTO = @FORMA_PAGAMENTO, ");
                    SQL_.Append("ID_FORMA_PAGAMENTO_JUROS = @ID_FORMA_PAGAMENTO_JUROS, ");
                    SQL_.Append("FORMA_PAGAMENTO_JUROS = @FORMA_PAGAMENTO_JUROS, ");
                    SQL_.Append("VALOR = @VALOR, ");
                    SQL_.Append("VALOR_JUROS = @VALOR_JUROS, ");
                    SQL_.Append("DATA_VENCTO = @DATA_VENCTO, ");
                    SQL_.Append("DATA_PAGAMENTO = @DATA_PAGAMENTO, ");
                    SQL_.Append("STATUS_PAGAMENTO = @STATUS_PAGAMENTO, ");
                    SQL_.Append("USUARIO = @USUARIO, ");
                    SQL_.Append("ULT_ATUAL = @ULT_ATUAL, ");
                    SQL_.Append("ATIVO = @ATIVO, ");
                    SQL_.Append("COBRANCA = @COBRANCA, ");
                    SQL_.Append("DATA_PROTESTO = @DATA_PROTESTO, ");
                    SQL_.Append("CARTA_ANUENCIA = @CARTA_ANUENCIA, ");
                    SQL_.Append("CARTORIO = @CARTORIO ");

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
            cmd.Parameters.AddWithValue("@ID_FORMA_PAGAMENTO", DTO.ID_FORMA_PAGAMENTO);
            cmd.Parameters.AddWithValue("@FORMA_PAGAMENTO", DTO.FORMA_PAGAMENTO);
            cmd.Parameters.AddWithValue("@ID_FORMA_PAGAMENTO_JUROS", DTO.ID_FORMA_PAGAMENTO_JUROS);
            cmd.Parameters.AddWithValue("@FORMA_PAGAMENTO_JUROS", DTO.FORMA_PAGAMENTO_JUROS);
            cmd.Parameters.AddWithValue("@VALOR", DTO.VALOR);
            cmd.Parameters.AddWithValue("@VALOR_JUROS", DTO.VALOR_JUROS);
            cmd.Parameters.AddWithValue("@DATA_VENCTO", DTO.DATA_VENCTO);
            cmd.Parameters.AddWithValue("@DATA_PAGAMENTO", DTO.DATA_PAGAMENTO);
            cmd.Parameters.AddWithValue("@STATUS_PAGAMENTO", DTO.STATUS_PAGAMENTO);
            cmd.Parameters.AddWithValue("@USUARIO", DTO.USUARIO);
            cmd.Parameters.AddWithValue("@ULT_ATUAL", DTO.ULT_ATUAL);
            cmd.Parameters.AddWithValue("@ATIVO", DTO.ATIVO);
            cmd.Parameters.AddWithValue("@COBRANCA", DTO.COBRANCA);
            cmd.Parameters.AddWithValue("@DATA_PROTESTO", DTO.DATA_PROTESTO);
            cmd.Parameters.AddWithValue("@CARTA_ANUENCIA", DTO.CARTA_ANUENCIA);
            cmd.Parameters.AddWithValue("@CARTORIO", DTO.CARTORIO);


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
                        SysDAL.GuardarDTO((IDTO)DTO.Clone());

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
                DTO.ID_FORMA_PAGAMENTO = dtr["ID_FORMA_PAGAMENTO"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_FORMA_PAGAMENTO"]);
                DTO.FORMA_PAGAMENTO = dtr["FORMA_PAGAMENTO"].ToString();
                DTO.ID_FORMA_PAGAMENTO_JUROS = dtr["ID_FORMA_PAGAMENTO_JUROS"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_FORMA_PAGAMENTO_JUROS"]);
                DTO.FORMA_PAGAMENTO_JUROS = dtr["FORMA_PAGAMENTO_JUROS"].ToString();
                DTO.PARCELA = Convert.ToInt32(dtr["PARCELA"]);
                DTO.VALOR = dtr["VALOR"] == DBNull.Value? (decimal?)null : Convert.ToDecimal(dtr["VALOR"]);
                DTO.VALOR_JUROS = dtr["VALOR_JUROS"] == DBNull.Value? (decimal?)null : Convert.ToDecimal(dtr["VALOR_JUROS"]);
                DTO.DATA_VENCTO = dtr["DATA_VENCTO"] == DBNull.Value? (DateTime?)null : Convert.ToDateTime(dtr["DATA_VENCTO"]);
                DTO.DATA_PAGAMENTO = dtr["DATA_PAGAMENTO"] == DBNull.Value? (DateTime?)null : Convert.ToDateTime(dtr["DATA_PAGAMENTO"]);
                DTO.STATUS_PAGAMENTO = dtr["STATUS_PAGAMENTO"] == DBNull.Value? "" : Convert.ToString(dtr["STATUS_PAGAMENTO"]);
                DTO.USUARIO = dtr["USUARIO"].ToString();
                DTO.ULT_ATUAL = dtr["ULT_ATUAL"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["ULT_ATUAL"]);
                DTO.ATIVO = Convert.ToBoolean(dtr["ATIVO"]);
                DTO.COBRANCA = dtr["NUMERO"].ToString();
                DTO.DATA_PROTESTO = dtr["DATA_PROTESTO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_PROTESTO"]);
                DTO.CARTA_ANUENCIA = dtr["CARTA_ANUENCIA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["CARTA_ANUENCIA"]);
                DTO.CARTORIO = dtr["NUMERO"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
