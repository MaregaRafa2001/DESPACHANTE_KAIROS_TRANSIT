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
                    SQL_.Append("USUARIO, ");
                    SQL_.Append("ULT_ATUAL, ");
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
                    SQL_.Append("@USUARIO, ");
                    SQL_.Append("GETDATE(), ");
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
                    SQL_.Append("DATA = @DATA, ");
                    SQL_.Append("DIA_VENCIMENTO = @DIA_VENCIMENTO, ");
                    SQL_.Append("MOTOBOY_OS = @MOTOBOY_OS, ");
                    SQL_.Append("VALOR_BRUTO = @VALOR_BRUTO, ");
                    SQL_.Append("VALOR_LIQUIDO = @VALOR_LIQUIDO, ");
                    SQL_.Append("USUARIO = @USUARIO, ");
                    SQL_.Append("ULT_ATUAL = @ULT_ATUAL, ");
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
            cmd.Parameters.AddWithValue("@USUARIO", DTO.USUARIO);
            cmd.Parameters.AddWithValue("@ULT_ATUAL", DTO.ULT_ATUAL);
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
                FINANCEIRO_DTO DTO = new FINANCEIRO_DTO();

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM FINANCEIRO Where (Id = " + Id + " );");
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
            _DTO.ID_FASE = dtr["ID_FASE"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_FASE"]);
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
            _DTO.BANCO_OS = dtr["BANCO_OS"].ToString();
            _DTO.USUARIO = dtr["USUARIO"].ToString();
            _DTO.ULT_ATUAL = dtr["ULT_ATUAL"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["ULT_ATUAL"]);

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
                        FINANCEIRO_DTO DTO = new FINANCEIRO_DTO();
                        PopularDados(dtr, DTO);
                        SysDAL.GuardarDTO((IDTO)DTO.Clone());
                        Financeiro.Add(DTO);
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
                    sb.Append(" X.USUARIO,");
                    sb.Append(" X.ULT_ATUAL,");
                    sb.Append(" X.DIA_VENCIMENTO,");
                    sb.Append(" X.INDICACAO,");
                    sb.Append(" A.ID AS ID_CLIENTE,");
                    sb.Append(" A.NOME_COMPLETO,");
                    sb.Append(" A.EMAIL,");
                    sb.Append(" A.PORTARIA, ");
                    sb.Append(" A.CPF, ");
                    sb.Append(" A.TELEFONE, ");
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
                    sb.Append(" ADMINISTRACAO ");
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
                        Financeiro.ADMINISTRACAO = new List<ADMINISTRACAO_DTO>();

                        Financeiro.ID = Convert.ToInt32(dtr["ID_FINANCEIRO"]);
                        Financeiro.FORMA_PAGAMENTO = dtr["FORMA_PAGAMENTO"].ToString();
                        Financeiro.PARCELAS = Convert.ToInt32(dtr["PARCELAS"]);
                        Financeiro.CONSULTOR = dtr["CONSULTOR"].ToString();
                        Financeiro.OBSERVACAO = dtr["OBSERVACAO"].ToString();
                        Financeiro.ID_CLIENTE = dtr["ID_CLIENTE"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_CLIENTE"]);
                        Financeiro.ID_SERVICO = dtr["ID_SERVICO"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_SERVICO"]);
                        Financeiro.ID_FASE = dtr["ID_FASE"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_FASE"]);
                        Financeiro.VALOR = dtr["VALOR"] == DBNull.Value ? 0 : Convert.ToDecimal(dtr["VALOR"]);
                        Financeiro.VALOR_OS = dtr["VALOR_OS"] == DBNull.Value ? 0 : Convert.ToDecimal(dtr["VALOR_OS"]);
                        Financeiro.LOCAL_OS = dtr["LOCAL_OS"].ToString();
                        Financeiro.ID_STATUS = dtr["ID_STATUS"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_STATUS"]);
                        Financeiro.DATA_ALTERACAO = dtr["DATA_ALTERACAO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_ALTERACAO"]);
                        Financeiro.DATA_CRIACAO = dtr["DATA_CRIACAO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_CRIACAO"]);
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
                        //Financeiro.CLIENTE.TELEFONE = dtr["TELEFONE"].ToString();
                        Financeiro.CLIENTE.CNH_PONTUACAO = dtr["CNH_PONTUACAO"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["CNH_PONTUACAO"].ToString());
                        Financeiro.STATUS.ID = dtr["ID_STATUS"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_STATUS"].ToString());
                        Financeiro.STATUS.DESCRICAO = dtr["DESCRICAO_STATUS"].ToString();
                        Financeiro.SERVICO.ID = dtr["ID_SERVICO"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_SERVICO"]);
                        Financeiro.SERVICO.NOME = dtr["NOME_SERVICO"].ToString();
                        Financeiro.USUARIO = dtr["USUARIO"].ToString();
                        Financeiro.ULT_ATUAL = dtr["ULT_ATUAL"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["ULT_ATUAL"]);

                    }

                    if (dtr.NextResult())
                    {
                        while (dtr.Read())
                        {
                            ADMINISTRACAO_DTO ADMINISTRACAO = new ADMINISTRACAO_DTO();
                            ADMINISTRACAO.ID = Convert.ToInt32(dtr["ID"]);
                            ADMINISTRACAO.DATA = dtr["Data"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["Data"]);
                            ADMINISTRACAO.ID_FINANCEIRO = dtr["ID_FINANCEIRO"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_FINANCEIRO"]);
                            ADMINISTRACAO.LAYOUT_TELA = dtr["LAYOUT_TELA"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["LAYOUT_TELA"]);
                            ADMINISTRACAO.FASE = dtr["FASE"].ToString();
                            ADMINISTRACAO.OBSERVACAO = dtr["OBSERVACAO"].ToString();
                            ADMINISTRACAO.DATA_RECEBIMENTO_CONTRATO = dtr["DATA_RECEBIMENTO_CONTRATO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_RECEBIMENTO_CONTRATO"]);
                            ADMINISTRACAO.DATA_ENTREGA_DOCUMENTO = dtr["DATA_ENTREGA_DOCUMENTO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_ENTREGA_DOCUMENTO"]);
                            ADMINISTRACAO.DATA_VENCIMENTO_DOCUMENTO = dtr["DATA_VENCIMENTO_DOCUMENTO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_VENCIMENTO_DOCUMENTO"]);
                            ADMINISTRACAO.DATA_MONTAGEM_PROCESSO = dtr["DATA_MONTAGEM_PROCESSO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_MONTAGEM_PROCESSO"]);
                            ADMINISTRACAO.DATA_IDA_DETRAN = dtr["DATA_IDA_DETRAN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_IDA_DETRAN"]);
                            ADMINISTRACAO.DATA_RETORNO_DETRAN = dtr["DATA_RETORNO_DETRAN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_RETORNO_DETRAN"]);
                            ADMINISTRACAO.PROCURADOR = dtr["PROCURADOR"] == DBNull.Value ? "" : Convert.ToString(dtr["PROCURADOR"]);
                            ADMINISTRACAO.MESES_DETRAN = dtr["MESES_DETRAN"] == DBNull.Value ? (int?)null : Convert.ToInt32(dtr["MESES_DETRAN"]);
                            ADMINISTRACAO.DATA_INICIO = dtr["DATA_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_INICIO"]);
                            ADMINISTRACAO.DATA_TERMINO = dtr["DATA_TERMINO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_TERMINO"]);
                            ADMINISTRACAO.DATA_FECHAMENTO_CURSO = dtr["DATA_FECHAMENTO_CURSO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_FECHAMENTO_CURSO"]);
                            ADMINISTRACAO.RECEBIMENTO_AUTO = dtr["RECEBIMENTO_AUTO"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dtr["RECEBIMENTO_AUTO"]);
                            ADMINISTRACAO.CURSO_FORA = dtr["CURSO_FORA"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dtr["CURSO_FORA"]);
                            ADMINISTRACAO.DATA_DIGITAL_1 = dtr["DATA_DIGITAL_1"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_DIGITAL_1"]);
                            ADMINISTRACAO.DATA_DIGITAL_2 = dtr["DATA_DIGITAL_2"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_DIGITAL_2"]);
                            ADMINISTRACAO.DATA_RECEBIMENTO_CERTIFICADO = dtr["DATA_RECEBIMENTO_CERTIFICADO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_RECEBIMENTO_CERTIFICADO"]);
                            ADMINISTRACAO.AUTO_ESCOLA = dtr["AUTO_ESCOLA"].ToString();
                            ADMINISTRACAO.DATA_FINALIZACAO = dtr["DATA_FINALIZACAO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_FINALIZACAO"]);
                            ADMINISTRACAO.DATA_BAIXA_DE_PONTOS = dtr["DATA_BAIXA_DE_PONTOS"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_BAIXA_DE_PONTOS"]);
                            ADMINISTRACAO.DATA_AGENDAMENTO = dtr["DATA_AGENDAMENTO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_AGENDAMENTO"]);
                            ADMINISTRACAO.DATA_AGENDAMENTO_TEORICODETRAN = dtr["DATA_AGENDAMENTO_TEORICODETRAN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_AGENDAMENTO_TEORICODETRAN"]);
                            ADMINISTRACAO.DATA_CATEGORIA_1 = dtr["DATA_CATEGORIA_1"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_CATEGORIA_1"]);
                            ADMINISTRACAO.DATA_CATEGORIA_2 = dtr["DATA_CATEGORIA_2"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_CATEGORIA_2"]);
                            ADMINISTRACAO.DATA_EMISSAO = dtr["DATA_EMISSAO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_EMISSAO"]);
                            ADMINISTRACAO.DATA_ENTREGA = dtr["DATA_ENTREGA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_ENTREGA"]);
                            ADMINISTRACAO.RETIRADO_POR = dtr["RETIRADO_POR"] == DBNull.Value ? "" : Convert.ToString(dtr["RETIRADO_POR"]);


                            ADMINISTRACAO.OPERACAO = SysDTO.Operacoes.Leitura;
                            Financeiro.ADMINISTRACAO.Add(ADMINISTRACAO);
                        }
                    }
                    Financeiro.Clone();
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


        public int Registrar_FaseFinanceiro(List<ADMINISTRACAO_DTO> lista_fase)
        {
            int result = 0;
            foreach (ADMINISTRACAO_DTO DTO in lista_fase)
            {
                using (SqlConnection cn = new SqlConnection(strConnection))
                {
                    if (DTO.OPERACAO == SysDTO.Operacoes.Inclusao)
                    {
                        try
                        {
                            SqlDataReader dr = null;

                            StringBuilder SQL_ = new StringBuilder();
                            SQL_.Append("INSERT INTO [dbo].[ADMINISTRACAO]        ");
                            SQL_.Append("           ([ID_FINANCEIRO]                    ");
                            SQL_.Append("           ,[LAYOUT_TELA]                      ");
                            SQL_.Append("           ,[FASE]                             ");
                            SQL_.Append("           ,[DATA]                             ");
                            SQL_.Append("           ,[OBSERVACAO]                       ");
                            SQL_.Append("           ,[DATA_RECEBIMENTO_CONTRATO]        ");
                            SQL_.Append("           ,[DATA_ENTREGA_DOCUMENTO]           ");
                            SQL_.Append("           ,[DATA_VENCIMENTO_DOCUMENTO]        ");
                            SQL_.Append("           ,[DATA_MONTAGEM_PROCESSO]           ");
                            SQL_.Append("           ,[DATA_IDA_DETRAN]                  ");
                            SQL_.Append("           ,[DATA_RETORNO_DETRAN]              ");
                            SQL_.Append("           ,[PROCURADOR]                       ");
                            SQL_.Append("           ,[MESES_DETRAN]                     ");
                            SQL_.Append("           ,[DATA_INICIO]                      ");
                            SQL_.Append("           ,[DATA_TERMINO]                     ");
                            SQL_.Append("           ,[DATA_FECHAMENTO_CURSO]            ");
                            SQL_.Append("           ,[RECEBIMENTO_AUTO]                 ");
                            SQL_.Append("           ,[CURSO_FORA]                       ");
                            SQL_.Append("           ,[DATA_DIGITAL_1]                   ");
                            SQL_.Append("           ,[DATA_DIGITAL_2]                   ");
                            SQL_.Append("           ,[DATA_RECEBIMENTO_CERTIFICADO]     ");
                            SQL_.Append("           ,[AUTO_ESCOLA]                      ");
                            SQL_.Append("           ,[DATA_FINALIZACAO]                 ");
                            SQL_.Append("           ,[DATA_BAIXA_DE_PONTOS]             ");
                            SQL_.Append("           ,[DATA_AGENDAMENTO]                 ");
                            SQL_.Append("           ,[DATA_AGENDAMENTO_TEORICODETRAN]   ");
                            SQL_.Append("           ,[DATA_CATEGORIA_1]                 ");
                            SQL_.Append("           ,[DATA_CATEGORIA_2]                 ");
                            SQL_.Append("           ,[DATA_EMISSAO]                     ");
                            SQL_.Append("           ,[DATA_ENTREGA]                     ");
                            SQL_.Append("           ,[RETIRADO_POR]                     ");
                            SQL_.Append("           )                                   ");
                            SQL_.Append("     VALUES                                    ");
                            SQL_.Append("           (@ID_FINANCEIRO                     ");
                            SQL_.Append("           ,@LAYOUT_TELA                       ");
                            SQL_.Append("           ,@FASE                              ");
                            SQL_.Append("           ,@DATA                              ");
                            SQL_.Append("           ,@OBSERVACAO                        ");
                            SQL_.Append("           ,@DATA_RECEBIMENTO_CONTRATO         ");
                            SQL_.Append("           ,@DATA_ENTREGA_DOCUMENTO            ");
                            SQL_.Append("           ,@DATA_VENCIMENTO_DOCUMENTO         ");
                            SQL_.Append("           ,@DATA_MONTAGEM_PROCESSO            ");
                            SQL_.Append("           ,@DATA_IDA_DETRAN                   ");
                            SQL_.Append("           ,@DATA_RETORNO_DETRAN               ");
                            SQL_.Append("           ,@PROCURADOR                        ");
                            SQL_.Append("           ,@MESES_DETRAN                      ");
                            SQL_.Append("           ,@DATA_INICIO                       ");
                            SQL_.Append("           ,@DATA_TERMINO                      ");
                            SQL_.Append("           ,@DATA_FECHAMENTO_CURSO             ");
                            SQL_.Append("           ,@RECEBIMENTO_AUTO                  ");
                            SQL_.Append("           ,@CURSO_FORA                        ");
                            SQL_.Append("           ,@DATA_DIGITAL_1                    ");
                            SQL_.Append("           ,@DATA_DIGITAL_2                    ");
                            SQL_.Append("           ,@DATA_RECEBIMENTO_CERTIFICADO      ");
                            SQL_.Append("           ,@AUTO_ESCOLA                       ");
                            SQL_.Append("           ,@DATA_FINALIZACAO                  ");
                            SQL_.Append("           ,@DATA_BAIXA_DE_PONTOS              ");
                            SQL_.Append("           ,@DATA_AGENDAMENTO                  ");
                            SQL_.Append("           ,@DATA_AGENDAMENTO_TEORICODETRAN    ");
                            SQL_.Append("           ,@DATA_CATEGORIA_1                  ");
                            SQL_.Append("           ,@DATA_CATEGORIA_2                  ");
                            SQL_.Append("           ,@DATA_EMISSAO                      ");
                            SQL_.Append("           ,@DATA_ENTREGA                      ");
                            SQL_.Append("           ,@RETIRADO_POR                      ");
                            SQL_.Append("           )                                   ");
                            SQL_.Append("SELECT SCOPE_IDENTITY();                       ");

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
                    else if (DTO.OPERACAO == SysDTO.Operacoes.Alteracao)
                    {

                        try
                        {
                            SqlDataReader dr = null;

                            StringBuilder SQL_ = new StringBuilder();

                            SQL_.Append("UPDATE ADMINISTRACAO                                                       ");
                            SQL_.Append("   SET                                                                     ");
                            SQL_.Append("       ID_FINANCEIRO = @ID_FINANCEIRO                                      ");
                            SQL_.Append("      ,LAYOUT_TELA = @LAYOUT_TELA                                          ");
                            SQL_.Append("      ,FASE = @FASE                                                        ");
                            SQL_.Append("      ,DATA = @DATA                                                        ");
                            SQL_.Append("      ,OBSERVACAO = @OBSERVACAO                                            ");
                            SQL_.Append("      ,DATA_RECEBIMENTO_CONTRATO = @DATA_RECEBIMENTO_CONTRATO              ");
                            SQL_.Append("      ,DATA_ENTREGA_DOCUMENTO = @DATA_ENTREGA_DOCUMENTO                    ");
                            SQL_.Append("      ,DATA_VENCIMENTO_DOCUMENTO = @DATA_VENCIMENTO_DOCUMENTO              ");
                            SQL_.Append("      ,DATA_MONTAGEM_PROCESSO = @DATA_MONTAGEM_PROCESSO                    ");
                            SQL_.Append("      ,DATA_IDA_DETRAN = @DATA_IDA_DETRAN                                  ");
                            SQL_.Append("      ,DATA_RETORNO_DETRAN = @DATA_RETORNO_DETRAN                          ");
                            SQL_.Append("      ,PROCURADOR = @PROCURADOR                                            ");
                            SQL_.Append("      ,MESES_DETRAN = @MESES_DETRAN                                        ");
                            SQL_.Append("      ,DATA_INICIO = @DATA_INICIO                                          ");
                            SQL_.Append("      ,DATA_TERMINO = @DATA_TERMINO                                        ");
                            SQL_.Append("      ,DATA_FECHAMENTO_CURSO = @DATA_FECHAMENTO_CURSO                      ");
                            SQL_.Append("      ,RECEBIMENTO_AUTO = @RECEBIMENTO_AUTO                                ");
                            SQL_.Append("      ,CURSO_FORA = @CURSO_FORA                                            ");
                            SQL_.Append("      ,DATA_DIGITAL_1 = @DATA_DIGITAL_1                                    ");
                            SQL_.Append("      ,DATA_DIGITAL_2 = @DATA_DIGITAL_2                                    ");
                            SQL_.Append("      ,DATA_RECEBIMENTO_CERTIFICADO = @DATA_RECEBIMENTO_CERTIFICADO        ");
                            SQL_.Append("      ,AUTO_ESCOLA = @AUTO_ESCOLA                                          ");
                            SQL_.Append("      ,DATA_FINALIZACAO = @DATA_FINALIZACAO                                ");
                            SQL_.Append("      ,DATA_BAIXA_DE_PONTOS = @DATA_BAIXA_DE_PONTOS                        ");
                            SQL_.Append("      ,DATA_AGENDAMENTO = @DATA_AGENDAMENTO                                ");
                            SQL_.Append("      ,DATA_AGENDAMENTO_TEORICODETRAN = @DATA_AGENDAMENTO_TEORICODETRAN    ");
                            SQL_.Append("      ,DATA_CATEGORIA_1 = @DATA_CATEGORIA_1                                ");
                            SQL_.Append("      ,DATA_CATEGORIA_2 = @DATA_CATEGORIA_2                                ");
                            SQL_.Append("      ,DATA_EMISSAO = @DATA_EMISSAO                                        ");
                            SQL_.Append("      ,DATA_ENTREGA = @DATA_ENTREGA                                        ");
                            SQL_.Append("      ,RETIRADO_POR = @RETIRADO_POR                                        ");
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
                SqlCommand cmd = new SqlCommand("DELETE FROM ADMINISTRACAO WHERE ID = " + id, conexao);
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

        void PopularParametrosFaseFinanceiro(SqlCommand cmd, ADMINISTRACAO_DTO fase)
        {
            cmd.Parameters.AddWithValue("@ID", fase.ID);
            cmd.Parameters.AddWithValue("@DATA", fase.DATA);
            cmd.Parameters.AddWithValue("@FASE", fase.FASE);
            cmd.Parameters.AddWithValue("@LAYOUT_TELA", fase.LAYOUT_TELA);
            cmd.Parameters.AddWithValue("@ID_FINANCEIRO", fase.ID_FINANCEIRO);
            cmd.Parameters.AddWithValue("@OBSERVACAO", fase.OBSERVACAO);
            cmd.Parameters.AddWithValue("@DATA_RECEBIMENTO_CONTRATO", fase.DATA_RECEBIMENTO_CONTRATO);
            cmd.Parameters.AddWithValue("@DATA_ENTREGA_DOCUMENTO", fase.DATA_ENTREGA_DOCUMENTO);
            cmd.Parameters.AddWithValue("@DATA_VENCIMENTO_DOCUMENTO", fase.DATA_VENCIMENTO_DOCUMENTO);
            cmd.Parameters.AddWithValue("@DATA_MONTAGEM_PROCESSO", fase.DATA_MONTAGEM_PROCESSO);
            cmd.Parameters.AddWithValue("@DATA_IDA_DETRAN", fase.DATA_IDA_DETRAN);
            cmd.Parameters.AddWithValue("@DATA_RETORNO_DETRAN", fase.DATA_RETORNO_DETRAN);
            cmd.Parameters.AddWithValue("@PROCURADOR", fase.PROCURADOR);
            cmd.Parameters.AddWithValue("@MESES_DETRAN", fase.MESES_DETRAN);
            cmd.Parameters.AddWithValue("@DATA_INICIO", fase.DATA_INICIO);
            cmd.Parameters.AddWithValue("@DATA_TERMINO", fase.DATA_TERMINO);
            cmd.Parameters.AddWithValue("@DATA_FECHAMENTO_CURSO", fase.DATA_FECHAMENTO_CURSO);
            cmd.Parameters.AddWithValue("@RECEBIMENTO_AUTO", fase.RECEBIMENTO_AUTO);
            cmd.Parameters.AddWithValue("@CURSO_FORA", fase.CURSO_FORA);
            cmd.Parameters.AddWithValue("@DATA_DIGITAL_1", fase.DATA_DIGITAL_1);
            cmd.Parameters.AddWithValue("@DATA_DIGITAL_2", fase.DATA_DIGITAL_2);
            cmd.Parameters.AddWithValue("@DATA_RECEBIMENTO_CERTIFICADO", fase.DATA_RECEBIMENTO_CERTIFICADO);
            cmd.Parameters.AddWithValue("@AUTO_ESCOLA", fase.AUTO_ESCOLA);
            cmd.Parameters.AddWithValue("@DATA_FINALIZACAO", fase.DATA_FINALIZACAO);
            cmd.Parameters.AddWithValue("@DATA_BAIXA_DE_PONTOS", fase.DATA_BAIXA_DE_PONTOS);
            cmd.Parameters.AddWithValue("DATA_AGENDAMENTO", fase.DATA_AGENDAMENTO);
            cmd.Parameters.AddWithValue("DATA_AGENDAMENTO_TEORICODETRAN", fase.DATA_AGENDAMENTO_TEORICODETRAN);
            cmd.Parameters.AddWithValue("DATA_CATEGORIA_1", fase.DATA_CATEGORIA_1);
            cmd.Parameters.AddWithValue("DATA_CATEGORIA_2", fase.DATA_CATEGORIA_2);
            cmd.Parameters.AddWithValue("DATA_EMISSAO", fase.DATA_EMISSAO);
            cmd.Parameters.AddWithValue("DATA_ENTREGA", fase.DATA_ENTREGA);
            cmd.Parameters.AddWithValue("RETIRADO_POR", fase.RETIRADO_POR);

            //Substitui o null por DBnull
            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

        }
        #endregion

        #region Classe Filha: Fase Juridico

        public FINANCEIRO_DTO Seleciona_Financeiro_By_Id_For_Juridico(int ID)
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
                    sb.Append(" X.USUARIO,");
                    sb.Append(" X.ULT_ATUAL,");
                    sb.Append(" X.DIA_VENCIMENTO,");
                    sb.Append(" X.INDICACAO,");
                    sb.Append(" A.ID AS ID_CLIENTE,");
                    sb.Append(" A.NOME_COMPLETO,");
                    sb.Append(" A.EMAIL,");
                    sb.Append(" A.PORTARIA, ");
                    sb.Append(" A.CPF, ");
                    sb.Append(" A.TELEFONE, ");
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
                    sb.Append(" JURIDICO ");
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
                        Financeiro.ADMINISTRACAO = new List<ADMINISTRACAO_DTO>();

                        Financeiro.ID = Convert.ToInt32(dtr["ID_FINANCEIRO"]);
                        Financeiro.FORMA_PAGAMENTO = dtr["FORMA_PAGAMENTO"].ToString();
                        Financeiro.PARCELAS = Convert.ToInt32(dtr["PARCELAS"]);
                        Financeiro.CONSULTOR = dtr["CONSULTOR"].ToString();
                        Financeiro.OBSERVACAO = dtr["OBSERVACAO"].ToString();
                        Financeiro.ID_CLIENTE = dtr["ID_CLIENTE"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_CLIENTE"]);
                        Financeiro.ID_SERVICO = dtr["ID_SERVICO"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_SERVICO"]);
                        Financeiro.ID_FASE = dtr["ID_FASE"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_FASE"]);
                        Financeiro.VALOR = dtr["VALOR"] == DBNull.Value ? 0 : Convert.ToDecimal(dtr["VALOR"]);
                        Financeiro.VALOR_OS = dtr["VALOR_OS"] == DBNull.Value ? 0 : Convert.ToDecimal(dtr["VALOR_OS"]);
                        Financeiro.LOCAL_OS = dtr["LOCAL_OS"].ToString();
                        Financeiro.ID_STATUS = dtr["ID_STATUS"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_STATUS"]);
                        Financeiro.DATA_ALTERACAO = dtr["DATA_ALTERACAO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_ALTERACAO"]);
                        Financeiro.DATA_CRIACAO = dtr["DATA_CRIACAO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_CRIACAO"]);
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
                        //Financeiro.CLIENTE.TELEFONE = dtr["TELEFONE"].ToString();
                        Financeiro.CLIENTE.CNH_PONTUACAO = dtr["CNH_PONTUACAO"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["CNH_PONTUACAO"].ToString());
                        Financeiro.STATUS.ID = dtr["ID_STATUS"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_STATUS"].ToString());
                        Financeiro.STATUS.DESCRICAO = dtr["DESCRICAO_STATUS"].ToString();
                        Financeiro.SERVICO.ID = dtr["ID_SERVICO"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_SERVICO"]);
                        Financeiro.SERVICO.NOME = dtr["NOME_SERVICO"].ToString();
                        Financeiro.USUARIO = dtr["USUARIO"].ToString();
                        Financeiro.ULT_ATUAL = dtr["ULT_ATUAL"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["ULT_ATUAL"]);

                    }

                    if (dtr.NextResult())
                    {
                        while (dtr.Read())
                        {
                            JURIDICO_DTO JURIDICO_DTO = new JURIDICO_DTO();
                            JURIDICO_DTO.ID = Convert.ToInt32(dtr["ID"]);
                            JURIDICO_DTO.DATA = dtr["Data"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["Data"]);
                            JURIDICO_DTO.ID_FINANCEIRO = dtr["ID_FINANCEIRO"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["ID_FINANCEIRO"]);
                            JURIDICO_DTO.LAYOUT_TELA = dtr["LAYOUT_TELA"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["LAYOUT_TELA"]);
                            JURIDICO_DTO.FASE = dtr["FASE"].ToString();
                            JURIDICO_DTO.OBSERVACAO = dtr["OBSERVACAO"].ToString();

                            JURIDICO_DTO.DataRecebimentoContrato = dtr["DATA_RECEBIMENTO_CONTRATO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_RECEBIMENTO_CONTRATO"]);
                            JURIDICO_DTO.DataClienteContatado = dtr["DATA_CLIENTE_CONTATADO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_CLIENTE_CONTATADO"]);
                            JURIDICO_DTO.DataLimiteDefesa = dtr["DATA_LIMITE_DEFESA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_LIMITE_DEFESA"]);
                            JURIDICO_DTO.Instancia = dtr["INSTANCIA"] == DBNull.Value ? (string)null : Convert.ToString(dtr["INSTANCIA"]);
                            JURIDICO_DTO.SenhaDetran = dtr["SENHA_DETRAN"] == DBNull.Value ? (string)null : Convert.ToString(dtr["SENHA_DETRAN"]);
                            JURIDICO_DTO.DataEntregaCliente = dtr["DATA_ENTREGA_CLIENTE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_ENTREGA_CLIENTE"]);
                            JURIDICO_DTO.DataEntregaAdvogado = dtr["DATA_ENTREGA_ADVOGADO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_ENTREGA_ADVOGADO"]);
                            JURIDICO_DTO.Bloqueio = dtr["BLOQUEIO"] == DBNull.Value ? (string)null : Convert.ToString(dtr["BLOQUEIO"]);
                            JURIDICO_DTO.DataInicio = dtr["DATA_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_INICIO"]);
                            JURIDICO_DTO.DataTermino = dtr["DATA_TERMINO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_TERMINO"]);
                            JURIDICO_DTO.DataProtocolamento = dtr["DATA_PROTOCOLAMENTO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_PROTOCOLAMENTO"]);
                            JURIDICO_DTO.Liminar = dtr["LIMINAR"] == DBNull.Value ? false : Convert.ToBoolean(dtr["LIMINAR"]);
                            JURIDICO_DTO.DataExpedicao = dtr["DATA_EXPEDICAO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_EXPEDICAO"]);
                            JURIDICO_DTO.DataEntregaAdvogadoInterno = dtr["DATA_ENTREGA_ADVOGADO_INTERNO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_ENTREGA_ADVOGADO_INTERNO"]);
                            JURIDICO_DTO.Status = dtr["STATUS"] == DBNull.Value ? (string)null : Convert.ToString(dtr["STATUS"]);
                            JURIDICO_DTO.Resultado = dtr["RESULTADO"] == DBNull.Value ? (string)null : Convert.ToString(dtr["RESULTADO"]);
                            JURIDICO_DTO.DataSentencaProtocolada = dtr["DATA_SENTENCA_PROTOCOLADA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_SENTENCA_PROTOCOLADA"]);
                            JURIDICO_DTO.DataLiberacaoSentenca = dtr["DATA_LIBERACAO_SENTENCA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_LIBERACAO_SENTENCA"]);
                            JURIDICO_DTO.DataFinalizacao = dtr["DATA_FINALIZACAO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["DATA_FINALIZACAO"]);
                            JURIDICO_DTO.OPERACAO = SysDTO.Operacoes.Leitura;
                            Financeiro.JURIDICO.Add(JURIDICO_DTO);
                        }
                    }
                    Financeiro.Clone();
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


        public int Registrar_FaseJuridico(List<JURIDICO_DTO> lista_fase)
        {
            int result = 0;
            foreach (JURIDICO_DTO DTO in lista_fase)
            {
                using (SqlConnection cn = new SqlConnection(strConnection))
                {
                    if (DTO.OPERACAO == SysDTO.Operacoes.Inclusao)
                    {
                        try
                        {
                            SqlDataReader dr = null;

                            StringBuilder SQL_ = new StringBuilder();
                            SQL_.Append("INSERT INTO [dbo].[JURIDICO]");
                            SQL_.Append("           ([ID_FINANCEIRO]");
                            SQL_.Append("           ,[LAYOUT_TELA]");
                            SQL_.Append("           ,[DATA]");
                            SQL_.Append("           ,[FASE]");
                            SQL_.Append("           ,[OBSERVACAO]");
                            SQL_.Append("           ,[DATA_RECEBIMENTO_CONTRATO]");
                            SQL_.Append("           ,[DATA_CLIENTE_CONTATADO]");
                            SQL_.Append("           ,[DATA_LIMITE_DEFESA]");
                            SQL_.Append("           ,[INSTANCIA]");
                            SQL_.Append("           ,[SENHA_DETRAN]");
                            SQL_.Append("           ,[DATA_ENTREGA_CLIENTE]");
                            SQL_.Append("           ,[DATA_ENTREGA_ADVOGADO]");
                            SQL_.Append("           ,[BLOQUEIO]");
                            SQL_.Append("           ,[DATA_INICIO]");
                            SQL_.Append("           ,[DATA_TERMINO]");
                            SQL_.Append("           ,[DATA_PROTOCOLAMENTO]");
                            SQL_.Append("           ,[LIMINAR]");
                            SQL_.Append("           ,[DATA_EXPEDICAO]");
                            SQL_.Append("           ,[DATA_ENTREGA_ADVOGADO_INTERNO]");
                            SQL_.Append("           ,[STATUS]");
                            SQL_.Append("           ,[RESULTADO]");
                            SQL_.Append("           ,[DATA_SENTENCA_PROTOCOLADA]");
                            SQL_.Append("           ,[DATA_LIBERACAO_SENTENCA]");
                            SQL_.Append("           ,[DATA_FINALIZACAO])");
                            SQL_.Append("     VALUES");
                            SQL_.Append("           (@ID_FINANCEIRO");
                            SQL_.Append("           ,@LAYOUT_TELA");
                            SQL_.Append("           ,@DATA");
                            SQL_.Append("           ,@FASE");
                            SQL_.Append("           ,@OBSERVACAO");
                            SQL_.Append("           ,@DATA_RECEBIMENTO_CONTRATO");
                            SQL_.Append("           ,@DATA_CLIENTE_CONTATADO");
                            SQL_.Append("           ,@DATA_LIMITE_DEFESA");
                            SQL_.Append("           ,@INSTANCIA");
                            SQL_.Append("           ,@SENHA_DETRAN");
                            SQL_.Append("           ,@DATA_ENTREGA_CLIENTE");
                            SQL_.Append("           ,@DATA_ENTREGA_ADVOGADO");
                            SQL_.Append("           ,@BLOQUEIO");
                            SQL_.Append("           ,@DATA_INICIO");
                            SQL_.Append("           ,@DATA_TERMINO");
                            SQL_.Append("           ,@DATA_PROTOCOLAMENTO");
                            SQL_.Append("           ,@LIMINAR");
                            SQL_.Append("           ,@DATA_EXPEDICAO");
                            SQL_.Append("           ,@DATA_ENTREGA_ADVOGADO_INTERNO");
                            SQL_.Append("           ,@STATUS");
                            SQL_.Append("           ,@RESULTADO");
                            SQL_.Append("           ,@DATA_SENTENCA_PROTOCOLADA");
                            SQL_.Append("           ,@DATA_LIBERACAO_SENTENCA");
                            SQL_.Append("           ,@DATA_FINALIZACAO)");

                            cn.Open();

                            SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);

                            PopularParametrosFaseJuridico(cmd, DTO);

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
                    else if (DTO.OPERACAO == SysDTO.Operacoes.Alteracao)
                    {

                        try
                        {
                            SqlDataReader dr = null;

                            StringBuilder SQL_ = new StringBuilder();

                            SQL_.Append("UPDATE [dbo].[JURIDICO]");
                            SQL_.Append("   SET [ID_FINANCEIRO] = @ID_FINANCEIRO");
                            SQL_.Append("      ,[LAYOUT_TELA] = @LAYOUT_TELA");
                            SQL_.Append("      ,[DATA] = @DATA");
                            SQL_.Append("      ,[FASE] = @FASE");
                            SQL_.Append("      ,[OBSERVACAO] = @OBSERVACAO");
                            SQL_.Append("      ,[DATA_RECEBIMENTO_CONTRATO] = @DATA_RECEBIMENTO_CONTRATO");
                            SQL_.Append("      ,[DATA_CLIENTE_CONTATADO] = @DATA_CLIENTE_CONTATADO");
                            SQL_.Append("      ,[DATA_LIMITE_DEFESA] = @DATA_LIMITE_DEFESA");
                            SQL_.Append("      ,[INSTANCIA] = @INSTANCIA");
                            SQL_.Append("      ,[SENHA_DETRAN] = @SENHA_DETRAN");
                            SQL_.Append("      ,[DATA_ENTREGA_CLIENTE] = @DATA_ENTREGA_CLIENTE");
                            SQL_.Append("      ,[DATA_ENTREGA_ADVOGADO] = @DATA_ENTREGA_ADVOGADO");
                            SQL_.Append("      ,[BLOQUEIO] = @BLOQUEIO");
                            SQL_.Append("      ,[DATA_INICIO] = @DATA_INICIO");
                            SQL_.Append("      ,[DATA_TERMINO] = @DATA_TERMINO");
                            SQL_.Append("      ,[DATA_PROTOCOLAMENTO] = @DATA_PROTOCOLAMENTO");
                            SQL_.Append("      ,[LIMINAR] = @LIMINAR");
                            SQL_.Append("      ,[DATA_EXPEDICAO] = @DATA_EXPEDICAO");
                            SQL_.Append("      ,[DATA_ENTREGA_ADVOGADO_INTERNO] = @DATA_ENTREGA_ADVOGADO_INTERNO");
                            SQL_.Append("      ,[STATUS] = @STATUS");
                            SQL_.Append("      ,[RESULTADO] = @RESULTADO");
                            SQL_.Append("      ,[DATA_SENTENCA_PROTOCOLADA] = @DATA_SENTENCA_PROTOCOLADA");
                            SQL_.Append("      ,[DATA_LIBERACAO_SENTENCA] = @DATA_LIBERACAO_SENTENCA");
                            SQL_.Append("      ,[DATA_FINALIZACAO] = @DATA_FINALIZACAO");
                            SQL_.Append(" WHERE ");
                            SQL_.Append(" ID = @ID");
                            cn.Open();


                            SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);

                            PopularParametrosFaseJuridico(cmd, DTO);

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

        public bool Excluir_FaseJuridico(int id)
        {
            using (SqlConnection conexao = new SqlConnection(this.strConnection))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM JURIDICO WHERE ID = " + id, conexao);
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

        void PopularParametrosFaseJuridico(SqlCommand cmd, JURIDICO_DTO fase)
        {
            cmd.Parameters.AddWithValue("@ID", fase.ID);
            cmd.Parameters.AddWithValue("@DATA", fase.DATA);
            cmd.Parameters.AddWithValue("@FASE", fase.FASE);
            cmd.Parameters.AddWithValue("@LAYOUT_TELA", fase.LAYOUT_TELA);
            cmd.Parameters.AddWithValue("@ID_FINANCEIRO", fase.ID_FINANCEIRO);
            cmd.Parameters.AddWithValue("@OBSERVACAO", fase.OBSERVACAO);
            cmd.Parameters.AddWithValue("@DATA_RECEBIMENTO_CONTRATO", fase.DataRecebimentoContrato);
            cmd.Parameters.AddWithValue("@DATA_CLIENTE_CONTATADO", fase.DataClienteContatado);
            cmd.Parameters.AddWithValue("@DATA_LIMITE_DEFESA", fase.DataLimiteDefesa);
            cmd.Parameters.AddWithValue("@INSTANCIA", fase.Instancia);
            cmd.Parameters.AddWithValue("@SENHA_DETRAN", fase.SenhaDetran);
            cmd.Parameters.AddWithValue("@DATA_ENTREGA_CLIENTE", fase.DataEntregaCliente);
            cmd.Parameters.AddWithValue("@DATA_ENTREGA_ADVOGADO", fase.DataEntregaAdvogado);
            cmd.Parameters.AddWithValue("@BLOQUEIO", fase.Bloqueio);
            cmd.Parameters.AddWithValue("@DATA_INICIO", fase.DataInicio);
            cmd.Parameters.AddWithValue("@DATA_TERMINO", fase.DataTermino);
            cmd.Parameters.AddWithValue("@DATA_PROTOCOLAMENTO", fase.DataProtocolamento);
            cmd.Parameters.AddWithValue("@LIMINAR", fase.Liminar);
            cmd.Parameters.AddWithValue("@DATA_EXPEDICAO", fase.DataExpedicao);
            cmd.Parameters.AddWithValue("@DATA_ENTREGA_ADVOGADO_INTERNO", fase.DataEntregaAdvogadoInterno);
            cmd.Parameters.AddWithValue("@STATUS", fase.Status);
            cmd.Parameters.AddWithValue("@RESULTADO", fase.Resultado);
            cmd.Parameters.AddWithValue("@DATA_SENTENCA_PROTOCOLADA", fase.DataSentencaProtocolada);
            cmd.Parameters.AddWithValue("@DATA_LIBERACAO_SENTENCA", fase.DataLiberacaoSentenca);
            cmd.Parameters.AddWithValue("@DATA_FINALIZACAO", fase.DataFinalizacao);

            //Substitui o null por DBnull
            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
        }
        #endregion

        public List<ComboItemDTO> Lista_Consultor()
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                List<ComboItemDTO> ComboItemDTO = new List<ComboItemDTO>();

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT TOP 25 CONSULTOR FROM FINANCEIRO GROUP BY CONSULTOR ORDER BY CONSULTOR");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    while (dtr.Read())
                    {
                        ComboItemDTO DTO = new ComboItemDTO();
                        DTO.Value = dtr["CONSULTOR"].ToString();
                        DTO.Text = dtr["CONSULTOR"].ToString();
                        ComboItemDTO.Add(DTO);
                    }
                    return ComboItemDTO;
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
    }
}
