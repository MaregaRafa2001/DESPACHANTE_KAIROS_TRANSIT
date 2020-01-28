using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FINANCEIRO_DAL
    {
        public string strConnection;



        public FINANCEIRO_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public int? Set_Financeiro(FINANCEIRO_DTO DTO)
        {

            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("INSERT INTO ");
                    SQL_.Append("FINANCEIRO ");
                    SQL_.Append("( ");
                    SQL_.Append("FORMA_PAGAMENTO, ");
                    SQL_.Append("PARCELAS, ");
                    SQL_.Append("CONSULTOR, ");
                    SQL_.Append("VALOR, ");
                    SQL_.Append("OBSERVACAO, ");
                    SQL_.Append("ID_CLIENTE, ");
                    SQL_.Append("ID_SERVICO, ");
                    SQL_.Append("ID_FASE, ");
                    SQL_.Append("VALOR_OS , ");
                    SQL_.Append("LOCAL_OS, ");
                    SQL_.Append("ID_STATUS, ");
                    SQL_.Append("INDICACAO, ");
                    SQL_.Append("DATA_ALTERACAO, ");
                    SQL_.Append("DATA_CRIACAO, ");
                    SQL_.Append("DATA, ");
                    SQL_.Append("DIA_VENCIMENTO, ");
                    SQL_.Append("MOTOBOY_OS, ");
                    SQL_.Append("VALOR_BRUTO, ");
                    SQL_.Append("VALOR_LIQUIDO, ");
                    
                    SQL_.Append("BANCO_OS ");
                    SQL_.Append(") ");
                    SQL_.Append("VALUES ");
                    SQL_.Append("( ");
                    SQL_.Append("@FORMA_PAGAMENTO, ");
                    SQL_.Append("@PARCELAS, ");
                    SQL_.Append("@CONSULTOR, ");
                    SQL_.Append("@VALOR, ");
                    SQL_.Append("@OBSERVACAO, ");
                    SQL_.Append("@ID_CLIENTE, ");
                    SQL_.Append("@ID_SERVICO, ");
                    SQL_.Append("@ID_FASE, ");
                    SQL_.Append("@VALOR_OS , ");
                    SQL_.Append("@LOCAL_OS, ");
                    SQL_.Append("@ID_STATUS, ");
                    SQL_.Append("@INDICACAO, ");
                    SQL_.Append("GETDATE(), ");
                    SQL_.Append("GETDATE(), ");
                    SQL_.Append("@DATA, ");
                    SQL_.Append("@DIA_VENCIMENTO, ");
                    SQL_.Append("@MOTOBOY_OS, ");
                    SQL_.Append("@VALOR_BRUTO, ");
                    SQL_.Append("@VALOR_LIQUIDO, ");
                    SQL_.Append("@BANCO_OS ");
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


        public bool Excluir(int id)
        {
            using (SqlConnection conexao = new SqlConnection(this.strConnection))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM FINANCEIRO WHERE ID = " + id, conexao);
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

        public bool Update_Financeiro(FINANCEIRO_DTO dTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("UPDATE ");
                    SQL_.Append("FINANCEIRO ");
                    SQL_.Append("SET ");
                    SQL_.Append("FORMA_PAGAMENTO = @FORMA_PAGAMENTO, ");
                    SQL_.Append("PARCELAS = @PARCELAS, ");
                    SQL_.Append("CONSULTOR = @CONSULTOR, ");
                    SQL_.Append("VALOR = @VALOR, ");
                    SQL_.Append("OBSERVACAO = @OBSERVACAO, ");
                    SQL_.Append("ID_CLIENTE = @ID_CLIENTE, ");
                    SQL_.Append("ID_SERVICO = @ID_SERVICO, ");
                    SQL_.Append("ID_FASE = @ID_FASE, ");
                    SQL_.Append("VALOR_OS = @VALOR_OS , ");
                    SQL_.Append("LOCAL_OS = @LOCAL_OS , ");
                    SQL_.Append("ID_STATUS = @ID_STATUS, ");
                    SQL_.Append("INDICACAO = @INDICACAO, ");
                    SQL_.Append("DATA_ALTERACAO = GETDATE(), ");
                    SQL_.Append("DATA = DATA, ");
                    SQL_.Append("DIA_VENCIMENTO = @DIA_VENCIMENTO, ");
                    SQL_.Append("MOTOBOY_OS = @MOTOBOY_OS, ");
                    SQL_.Append("VALOR_BRUTO = @VALOR_BRUTO, ");
                    SQL_.Append("VALOR_LIQUIDO = @VALOR_LIQUIDO, ");
                    SQL_.Append("BANCO_OS = @BANCO_OS ");
                    SQL_.Append("WHERE ID = @ID ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);

                    PopularParametros(dTO, cmd);


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


        public void PopularParametros(FINANCEIRO_DTO DTO, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ID", DTO.ID);
            cmd.Parameters.AddWithValue("@FORMA_PAGAMENTO", DTO.FORMA_PAGAMENTO);
            cmd.Parameters.AddWithValue("@PARCELAS", DTO.PARCELAS);
            cmd.Parameters.AddWithValue("@CONSULTOR", DTO.CONSULTOR);
            cmd.Parameters.AddWithValue("@VALOR", DTO.VALOR);
            cmd.Parameters.AddWithValue("@OBSERVACAO", DTO.OBSERVACAO);
            cmd.Parameters.AddWithValue("@ID_CLIENTE", DTO.ID_CLIENTE);
            cmd.Parameters.AddWithValue("@ID_SERVICO", DTO.ID_SERVICO);
            cmd.Parameters.AddWithValue("@ID_FASE", DTO.ID_FASE);
            cmd.Parameters.AddWithValue("@VALOR_OS", DTO.VALOR_OS);
            cmd.Parameters.AddWithValue("@LOCAL_OS", DTO.LOCAL_OS);
            cmd.Parameters.AddWithValue("@DATA", DTO.DATA);
            cmd.Parameters.AddWithValue("@ID_STATUS", DTO.ID_STATUS);
            cmd.Parameters.AddWithValue("@INDICACAO", DTO.INDICACAO);
            cmd.Parameters.AddWithValue("@DIA_VENCIMENTO", DTO.DIA_VENCIMENTO);
            cmd.Parameters.AddWithValue("@MOTOBOY_OS", DTO.MOTOBOY_OS);
            cmd.Parameters.AddWithValue("@BANCO_OS", DTO.BANCO_OS);
            cmd.Parameters.AddWithValue("@VALOR_BRUTO", DTO.VALOR_BRUTO);
            cmd.Parameters.AddWithValue("@VALOR_LIQUIDO", DTO.VALOR_LIQUIDO);
            //cmd.Parameters.AddWithValue("@DATA_ALTERACAO", DTO.DATA_ALTERACAO);

            //Substitui o null por DBnull
            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

        }

        public FINANCEIRO_DTO Seleciona(int Id)
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                FINANCEIRO_DTO Financeiro = new FINANCEIRO_DTO();

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM FINANCEIRO Where (Id = " + Id + " );");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    if (dtr.Read())
                    {
                        PopularDados(dtr, Financeiro);
                    }

                    return Financeiro;
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

        public bool Verifica_Consultor(string Consultor)
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                FINANCEIRO_DTO Financeiro = new FINANCEIRO_DTO();

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT TOP 1 CONSULTOR FROM FINANCEIRO WHERE CONSULTOR = '" + Consultor + "'");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    if (dtr.Read())
                    {
                        return true;
                    }

                    return false;
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

        void PopularDados(SqlDataReader dtr, FINANCEIRO_DTO _DTO)
        {
            _DTO.ID = Convert.ToInt32(dtr["ID"]);
            //DADOS
            _DTO.FORMA_PAGAMENTO = dtr["FORMA_PAGAMENTO"].ToString();
            _DTO.PARCELAS = Convert.ToInt32(dtr["PARCELAS"]);
            _DTO.DIA_VENCIMENTO = Convert.ToInt32(dtr["DIA_VENCIMENTO"]);
            _DTO.CONSULTOR = dtr["CONSULTOR"].ToString();
            _DTO.OBSERVACAO = dtr["OBSERVACAO"].ToString();
            _DTO.ID_CLIENTE = Convert.ToInt32(dtr["ID_CLIENTE"]);
            _DTO.ID_SERVICO = Convert.ToInt32(dtr["ID_SERVICO"]);
            _DTO.ID_FASE = dtr["ID_FASE"] == DBNull.Value? 0 : Convert.ToInt32(dtr["ID_FASE"]);
            _DTO.VALOR = Convert.ToDecimal(dtr["VALOR"]);
            _DTO.VALOR_OS = Convert.ToDecimal(dtr["VALOR_OS"]);
            _DTO.LOCAL_OS = dtr["LOCAL_OS"].ToString();
            _DTO.ID_STATUS = Convert.ToInt32(dtr["ID_STATUS"]);
            _DTO.INDICACAO = dtr["INDICACAO"].ToString();
            _DTO.DATA_ALTERACAO = Convert.ToDateTime(dtr["DATA_ALTERACAO"]);
            _DTO.DATA_CRIACAO = Convert.ToDateTime(dtr["DATA_CRIACAO"]);
            _DTO.DATA = Convert.ToDateTime(dtr["DATA"]);
            _DTO.MOTOBOY_OS = dtr["MOTOBOY_OS"].ToString();
            _DTO.BANCO_OS = dtr["BANCO_OS"].ToString();
            _DTO.VALOR_BRUTO = dtr["VALOR_BRUTO"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(dtr["VALOR_BRUTO"]);
            _DTO.VALOR_LIQUIDO = dtr["VALOR_LIQUIDO"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(dtr["VALOR_LIQUIDO"]);
        }

        public List<FINANCEIRO_DTO> Seleciona_By_Cliente(int ID_CLIENTE)
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                List<FINANCEIRO_DTO> Financeiro = new List<FINANCEIRO_DTO>();

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM FINANCEIRO X Where ID_CLIENTE = " + ID_CLIENTE + " ORDER BY DATA_ALTERACAO  DESC;");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    while (dtr.Read())
                    {
                        FINANCEIRO_DTO dTO = new FINANCEIRO_DTO();
                        PopularDados(dtr, dTO);
                        Financeiro.Add(dTO);
                    }
                    return Financeiro;
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

        public FINANCEIRO_DTO Seleciona_Financeiro_By_Id(int ID)
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                FINANCEIRO_DTO Financeiro = new FINANCEIRO_DTO();

                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append(" SELECT ");
                    sb.Append(" X.ID AS ID_FINANCEIRO, ");
                    sb.Append(" X.FORMA_PAGAMENTO, ");
                    sb.Append(" X.PARCELAS, ");
                    sb.Append(" X.CONSULTOR, ");
                    sb.Append(" X.OBSERVACAO, ");
                    sb.Append(" X.ID_CLIENTE, ");
                    sb.Append(" X.ID_SERVICO, ");
                    sb.Append(" X.ID_FASE, ");
                    sb.Append(" X.VALOR,  ");
                    sb.Append(" X.VALOR_OS, ");
                    sb.Append(" X.LOCAL_OS, ");
                    sb.Append(" X.ID_STATUS, ");
                    sb.Append(" X.DATA_ALTERACAO, ");
                    sb.Append(" X.DATA_CRIACAO, ");
                    sb.Append(" X.MOTOBOY_OS, ");
                    sb.Append(" X.BANCO_OS,");
                    sb.Append(" X.DATA,");
                    sb.Append(" X.DIA_VENCIMENTO,");
                    sb.Append(" X.INDICACAO,");
                    sb.Append(" A.ID AS ID_CLIENTE,");
                    sb.Append(" A.NOME_COMPLETO,");
                    sb.Append(" A.EMAIL,");
                    sb.Append(" A.CPF, ");
                    sb.Append(" A.RG,");
                    sb.Append(" A.CNH,");
                    sb.Append(" A.CNH_PONTUACAO,");
                    sb.Append(" B.ID AS ID_STATUS,");
                    sb.Append(" B.DESCRICAO AS DESCRICAO_STATUS,");
                    sb.Append(" S.ID AS ID_SERVICO,");
                    sb.Append(" S.NOME AS NOME_SERVICO");
                    sb.Append(" FROM FINANCEIRO X");
                    sb.Append(" LEFT JOIN CLIENTE A");
                    sb.Append(" ON X.ID_CLIENTE = A.ID");
                    sb.Append(" LEFT JOIN STATUS_FINANCEIRO B");
                    sb.Append(" ON X.ID_STATUS = B.ID");
                    sb.Append(" LEFT JOIN SERVICOS S");
                    sb.Append(" ON X.ID_SERVICO = S.ID");
                    sb.Append(" WHERE X.ID = " + ID + ";");


                    sb.Append(" SELECT ");
                    sb.Append(" * ");
                    sb.Append(" FROM ");
                    sb.Append(" FASE_FINANCEIRO ");
                    sb.Append(" WHERE ");
                    sb.Append(" ID_FINANCEIRO = " + ID);
                    sb.Append(" ORDER BY DATA DESC");

                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    if (dtr.Read())
                    {
                        Financeiro.CLIENTE = new CLIENTE_DTO();
                        Financeiro.SERVICO = new SERVICO_DTO();
                        Financeiro.STATUS = new STATUS_FINANCEIRO_DTO();
                        Financeiro.FASE_FINANCEIRO = new List<FASE_FINANCEIRO_DTO>();

                        Financeiro.ID = Convert.ToInt32(dtr["ID_FINANCEIRO"]);
                        Financeiro.FORMA_PAGAMENTO = dtr["FORMA_PAGAMENTO"].ToString();
                        Financeiro.PARCELAS = Convert.ToInt32(dtr["PARCELAS"]);
                        Financeiro.CONSULTOR = dtr["CONSULTOR"].ToString();
                        Financeiro.OBSERVACAO = dtr["OBSERVACAO"].ToString();
                        Financeiro.ID_CLIENTE = dtr["ID_CLIENTE"] == DBNull.Value? 0 : Convert.ToInt32(dtr["ID_CLIENTE"]);
                        Financeiro.ID_SERVICO = dtr["ID_SERVICO"] == DBNull.Value? 0 : Convert.ToInt32(dtr["ID_SERVICO"]);
                        Financeiro.ID_FASE = dtr["ID_FASE"] == DBNull.Value? 0 : Convert.ToInt32(dtr["ID_FASE"]);
                        Financeiro.VALOR = dtr["VALOR"] == DBNull.Value? 0 : Convert.ToDecimal(dtr["VALOR"]);
                        Financeiro.VALOR_OS = dtr["VALOR_OS"] == DBNull.Value? 0 : Convert.ToDecimal(dtr["VALOR_OS"]);
                        Financeiro.LOCAL_OS = dtr["LOCAL_OS"].ToString();
                        Financeiro.ID_STATUS = dtr["ID_STATUS"] == DBNull.Value? 0 : Convert.ToInt32(dtr["ID_STATUS"]);
                        Financeiro.DATA_ALTERACAO = dtr["DATA_ALTERACAO"] ==  DBNull.Value? (DateTime?)null : Convert.ToDateTime(dtr["DATA_ALTERACAO"]);
                        Financeiro.DATA_CRIACAO = dtr["DATA_CRIACAO"] ==  DBNull.Value? (DateTime?)null : Convert.ToDateTime(dtr["DATA_CRIACAO"]);
                        Financeiro.MOTOBOY_OS = dtr["MOTOBOY_OS"].ToString();
                        Financeiro.BANCO_OS = dtr["BANCO_OS"].ToString();
                        Financeiro.DATA = dtr["DATA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA"]);
                        Financeiro.DIA_VENCIMENTO = dtr["DIA_VENCIMENTO"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["DIA_VENCIMENTO"]);
                        Financeiro.INDICACAO = dtr["INDICACAO"].ToString();
                        Financeiro.CLIENTE.ID = dtr["ID_CLIENTE"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_CLIENTE"]);
                        Financeiro.CLIENTE.NOME_COMPLETO = dtr["NOME_COMPLETO"].ToString();
                        Financeiro.CLIENTE.EMAIL = dtr["EMAIL"].ToString();
                        Financeiro.CLIENTE.CPF = dtr["CPF"].ToString();
                        Financeiro.CLIENTE.RG = dtr["RG"].ToString();
                        Financeiro.CLIENTE.CNH = dtr["CNH"].ToString();
                        Financeiro.CLIENTE.CNH_PONTUACAO = dtr["CNH_PONTUACAO"] == DBNull.Value? 0 : Convert.ToInt32(dtr["CNH_PONTUACAO"].ToString());
                        Financeiro.STATUS.ID = dtr["ID_STATUS"] == DBNull.Value? 0 : Convert.ToInt32(dtr["ID_STATUS"].ToString());
                        Financeiro.STATUS.DESCRICAO = dtr["DESCRICAO_STATUS"].ToString();
                        Financeiro.SERVICO.ID = dtr["ID_SERVICO"] == DBNull.Value ? 0 :  Convert.ToInt32(dtr["ID_SERVICO"]);
                        Financeiro.SERVICO.NOME = dtr["NOME_SERVICO"].ToString();
                    }

                    if (dtr.NextResult())
                    {
                        while (dtr.Read())
                        {
                            FASE_FINANCEIRO_DTO fase_financeiro = new FASE_FINANCEIRO_DTO();
                            fase_financeiro.ID = Convert.ToInt32(dtr["ID"]);
                            fase_financeiro.DATA = dtr["Data"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["Data"]);
                            fase_financeiro.ID_FINANCEIRO = dtr["ID_FINANCEIRO"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_FINANCEIRO"]);
                            fase_financeiro.FASE = dtr["FASE"].ToString();
                            fase_financeiro.OBSERVACAO = dtr["OBSERVACAO"].ToString();
                            fase_financeiro.Operacao = SysDTO.Operacoes.Leitura;
                            Financeiro.FASE_FINANCEIRO.Add(fase_financeiro);
                        }
                    }
                    return Financeiro;
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

        #region Classe Filha: Fase Financeiro


        public int Registrar_FaseFinanceiro(List<FASE_FINANCEIRO_DTO> lista_fase)
        {
            int result = 0;
            foreach (FASE_FINANCEIRO_DTO DTO in lista_fase)
            {
                using (SqlConnection cn = new SqlConnection(strConnection))
                {
                    if (DTO.Operacao == SysDTO.Operacoes.Inclusao)
                    {
                        try
                        {
                            SqlDataReader dr = null;

                            StringBuilder SQL_ = new StringBuilder();
                            SQL_.Append("INSERT INTO [dbo].[FASE_FINANCEIRO]   ");
                            SQL_.Append("           ([ID_FINANCEIRO]           ");
                            SQL_.Append("           ,[FASE]                    ");
                            SQL_.Append("           ,[DATA]                    ");
                            SQL_.Append("           ,[OBSERVACAO])             ");
                            SQL_.Append("     VALUES                           ");
                            SQL_.Append("           (@ID_FINANCEIRO            ");
                            SQL_.Append("           ,@FASE                     ");
                            SQL_.Append("           ,@DATA                     ");
                            SQL_.Append("           ,@OBSERVACAO)              ");
                            SQL_.Append("SELECT SCOPE_IDENTITY();              ");

                            cn.Open();

                            SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);

                            PopularParametrosFaseFinanceiro(cmd, DTO);

                            if ((DTO.ID = Convert.ToInt32(cmd.ExecuteScalar())) > 0)
                            {
                                result++;
                            }
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
                    else if (DTO.Operacao == SysDTO.Operacoes.Alteracao)
                    {

                        try
                        {
                            SqlDataReader dr = null;

                            StringBuilder SQL_ = new StringBuilder();

                            SQL_.Append("UPDATE [dbo].[FASE_FINANCEIRO]           ");
                            SQL_.Append("   SET [ID_FINANCEIRO] = @ID_FINANCEIRO  ");
                            SQL_.Append("      ,[FASE] = @FASE                    ");
                            SQL_.Append("      ,[DATA] = @DATA                    ");
                            SQL_.Append("      ,[OBSERVACAO] = @OBSERVACAO        ");
                            SQL_.Append(" WHERE ID = @ID                          ");
                            cn.Open();

                            SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);

                            PopularParametrosFaseFinanceiro(cmd, DTO);

                            cmd.ExecuteNonQuery();

                            result++;
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
            }
            return result;
        }

        public bool Excluir_FaseFinanceiro(int id)
        {
            using (SqlConnection conexao = new SqlConnection(this.strConnection))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM FASE_FINANCEIRO WHERE ID = " + id, conexao);
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

        void PopularParametrosFaseFinanceiro(SqlCommand cmd, FASE_FINANCEIRO_DTO fase)
        {
            cmd.Parameters.AddWithValue("@ID", fase.ID);
            cmd.Parameters.AddWithValue("@DATA", fase.DATA);
            cmd.Parameters.AddWithValue("@FASE", fase.FASE);
            cmd.Parameters.AddWithValue("@ID_FINANCEIRO", fase.ID_FINANCEIRO);
            cmd.Parameters.AddWithValue("@OBSERVACAO", fase.OBSERVACAO);

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


    #endregion

}
