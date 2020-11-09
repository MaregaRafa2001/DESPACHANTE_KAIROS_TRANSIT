using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class CLIENTE_DAL
    {
        public string strConnection;

        public CLIENTE_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public int? Set_Cliente(CLIENTE_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("INSERT INTO ");
                    SQL_.Append("CLIENTE ");
                    SQL_.Append("( ");
                    //DADOS
                    SQL_.Append("NOME_COMPLETO, ");
                    SQL_.Append("CPF, ");
                    SQL_.Append("RG, ");
                    SQL_.Append("DATA_NASCIMENTO, ");
                    SQL_.Append("CNH, ");
                    SQL_.Append("CNH_CATEGORIA, ");
                    SQL_.Append("CNH_ID_TIPO, ");
                    SQL_.Append("CNH_UF, ");
                    SQL_.Append("CNH_MUNICIPIO, ");
                    SQL_.Append("CNH_PONTUACAO, ");
                    SQL_.Append("CNH_DATA_VENCIMENTO, ");
                    SQL_.Append("CNH_DATA_EMISSAO, ");
                    SQL_.Append("CNH_VENCIDA, ");
                    SQL_.Append("ATIV_REMUNERADA, ");
                    SQL_.Append("SIGLA_PCD, ");
                    //ENDERECO
                    SQL_.Append("CEP, ");
                    SQL_.Append("BAIRRO, ");
                    SQL_.Append("LOGRADOURO, ");
                    SQL_.Append("MUNICIPIO, ");
                    SQL_.Append("COMPLEMENTO, ");
                    SQL_.Append("NUMERO_RES,    ");
                    //CONTATO
                    SQL_.Append("EMAIL, ");
                    SQL_.Append("EMAIL2, ");
                    //SQL_.Append("CELULAR, ");
                    //SQL_.Append("TELEFONE, ");
                    SQL_.Append("PORTARIA, ");
                    SQL_.Append("IMPEDIMENTO, ");
                    SQL_.Append("USUARIO, ");
                    SQL_.Append("ULT_ATUAL, ");
                    SQL_.Append("OBSERVACAO ");

                    SQL_.Append(") ");
                    SQL_.Append("VALUES ");
                    SQL_.Append("( ");

                    //DADOS
                    SQL_.Append("@NOME_COMPLETO, ");
                    SQL_.Append("@CPF, ");
                    SQL_.Append("@RG, ");
                    SQL_.Append("@DATA_NASCIMENTO, ");
                    SQL_.Append("@CNH, ");
                    SQL_.Append("@CNH_CATEGORIA, ");
                    SQL_.Append("@CNH_ID_TIPO, ");
                    SQL_.Append("@CNH_UF, ");
                    SQL_.Append("@CNH_MUNICIPIO, ");
                    SQL_.Append("@CNH_PONTUACAO, ");
                    SQL_.Append("@CNH_DATA_VENCIMENTO, ");
                    SQL_.Append("@CNH_DATA_EMISSAO, ");
                    SQL_.Append("@CNH_VENCIDA, ");
                    SQL_.Append("@ATIV_REMUNERADA, ");
                    SQL_.Append("@SIGLA_PCD, ");
                    //ENDERECO
                    SQL_.Append("@CEP, ");
                    SQL_.Append("@BAIRRO, ");
                    SQL_.Append("@LOGRADOURO, ");
                    //SQL_.Append("@UF, ");
                    SQL_.Append("@MUNICIPIO, ");
                    SQL_.Append("@COMPLEMENTO, ");
                    SQL_.Append("@NUMERO_RES, ");
                    //CONTATO
                    SQL_.Append("@EMAIL, ");
                    SQL_.Append("@EMAIL2, ");
                    //SQL_.Append("@CELULAR, ");
                    //SQL_.Append("@TELEFONE, ");
                    SQL_.Append("@PORTARIA, ");
                    SQL_.Append("@IMPEDIMENTO, ");
                    SQL_.Append("@USUARIO, ");
                    SQL_.Append("@ULT_ATUAL, ");
                    SQL_.Append("@OBSERVACAO ");
                    SQL_.Append("); SELECT SCOPE_IDENTITY(); ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    PopularParametros(DTO, cmd);

                    if ((DTO.ID = Convert.ToInt32(cmd.ExecuteScalar())) > 0)
                    {
                        try
                        {
                            Set_Cliente_Celular(DTO);
                            Set_Cliente_Telefone(DTO);
                        }
                        catch
                        {
                        }
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

        public bool Update_Cliente(CLIENTE_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("UPDATE ");
                    SQL_.Append("CLIENTE ");
                    SQL_.Append("SET ");
                    //DADOS
                    SQL_.Append("NOME_COMPLETO = @NOME_COMPLETO, ");
                    SQL_.Append("CPF = @CPF, ");
                    SQL_.Append("RG = @RG, ");
                    SQL_.Append("DATA_NASCIMENTO = @DATA_NASCIMENTO, ");
                    SQL_.Append("CNH = @CNH, ");
                    SQL_.Append("CNH_CATEGORIA = @CNH_CATEGORIA, ");
                    SQL_.Append("CNH_ID_TIPO = @CNH_ID_TIPO, ");
                    SQL_.Append("CNH_UF = @CNH_UF, ");
                    SQL_.Append("CNH_MUNICIPIO = @CNH_MUNICIPIO, ");
                    SQL_.Append("CNH_PONTUACAO = @CNH_PONTUACAO, ");
                    SQL_.Append("CNH_DATA_VENCIMENTO = @CNH_DATA_VENCIMENTO, ");
                    SQL_.Append("CNH_DATA_EMISSAO = @CNH_DATA_EMISSAO, ");
                    SQL_.Append("CNH_VENCIDA = @CNH_VENCIDA, ");
                    SQL_.Append("ATIV_REMUNERADA = @ATIV_REMUNERADA, ");
                    SQL_.Append("SIGLA_PCD = @SIGLA_PCD, ");
                    //ENDERECO
                    SQL_.Append("CEP = @CEP, ");
                    SQL_.Append("BAIRRO = @BAIRRO, ");
                    SQL_.Append("LOGRADOURO = @LOGRADOURO, ");
                    SQL_.Append("MUNICIPIO = @MUNICIPIO, ");
                    SQL_.Append("COMPLEMENTO = @COMPLEMENTO, ");
                    SQL_.Append("NUMERO_RES = @NUMERO_RES, ");
                    //CONTATO
                    SQL_.Append("EMAIL = @EMAIL, ");
                    SQL_.Append("EMAIL2 = @EMAIL2, ");
                    //SQL_.Append("CELULAR = @CELULAR, ");
                    //SQL_.Append("TELEFONE = @TELEFONE, ");
                    SQL_.Append("PORTARIA = @PORTARIA, ");
                    SQL_.Append("IMPEDIMENTO = @IMPEDIMENTO, ");
                    SQL_.Append("USUARIO = @USUARIO, ");
                    SQL_.Append("ULT_ATUAL = @ULT_ATUAL, ");
                    SQL_.Append("OBSERVACAO = @OBSERVACAO ");

                    SQL_.Append("WHERE ID = @ID ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    PopularParametros(DTO, cmd);


                    cmd.ExecuteNonQuery();

                    try
                    {
                        Set_Cliente_Celular(DTO);
                        Set_Cliente_Telefone(DTO);
                    }
                    catch
                    {
                    }

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
                SqlCommand cmd = new SqlCommand("DELETE FROM CLIENTE WHERE ID = " + id, conexao);
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

        public void PopularParametros(CLIENTE_DTO DTO, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ID", DTO.ID);
            //DADOS
            cmd.Parameters.AddWithValue("@NOME_COMPLETO", DTO.NOME_COMPLETO);
            cmd.Parameters.AddWithValue("@CPF", DTO.CPF);
            cmd.Parameters.AddWithValue("@RG", DTO.RG);
            try
            {
                Convert.ToDateTime(DTO.DATA_NASCIMENTO);
            }
            catch
            {
                DTO.DATA_NASCIMENTO = null;
            }
            cmd.Parameters.AddWithValue("@DATA_NASCIMENTO", DTO.DATA_NASCIMENTO);
            cmd.Parameters.AddWithValue("@CNH", DTO.CNH);
            cmd.Parameters.AddWithValue("@CNH_CATEGORIA", DTO.CNH_CATEGORIA);
            cmd.Parameters.AddWithValue("@CNH_ID_TIPO", DTO.CNH_ID_TIPO);
            cmd.Parameters.AddWithValue("@CNH_UF", DTO.CNH_UF);
            cmd.Parameters.AddWithValue("@CNH_MUNICIPIO", DTO.CNH_MUNICIPIO);
            cmd.Parameters.AddWithValue("@CNH_PONTUACAO", DTO.CNH_PONTUACAO);
            cmd.Parameters.AddWithValue("@CNH_DATA_VENCIMENTO", DTO.CNH_DATA_VENCIMENTO);
            cmd.Parameters.AddWithValue("@CNH_DATA_EMISSAO", DTO.CNH_DATA_EMISSAO);
            cmd.Parameters.AddWithValue("@CNH_VENCIDA", DTO.CNH_VENCIDA);
            cmd.Parameters.AddWithValue("@ATIV_REMUNERADA", DTO.ATIV_REMUNERADA);
            cmd.Parameters.AddWithValue("@SIGLA_PCD", DTO.SIGLA_PCD);
            //ENDEREÇO
            cmd.Parameters.AddWithValue("@CEP", DTO.CEP.Replace("-", ""));
            cmd.Parameters.AddWithValue("@BAIRRO", DTO.BAIRRO);
            cmd.Parameters.AddWithValue("@LOGRADOURO", DTO.LOGRADOURO);
            cmd.Parameters.AddWithValue("@MUNICIPIO", DTO.MUNICIPIO);
            cmd.Parameters.AddWithValue("@COMPLEMENTO", DTO.COMPLEMENTO);
            cmd.Parameters.AddWithValue("@NUMERO_RES", DTO.NUMERO_RES);
            //CONTATO
            cmd.Parameters.AddWithValue("@EMAIL", DTO.EMAIL);
            cmd.Parameters.AddWithValue("@EMAIL2", DTO.EMAIL2);
            //cmd.Parameters.AddWithValue("@CELULAR", DTO.CELULAR);
            //cmd.Parameters.AddWithValue("@TELEFONE", DTO.TELEFONE);
            cmd.Parameters.AddWithValue("@PORTARIA", DTO.PORTARIA);
            cmd.Parameters.AddWithValue("@IMPEDIMENTO", DTO.IMPEDIMENTO);
            cmd.Parameters.AddWithValue("@USUARIO", DTO.USUARIO);
            cmd.Parameters.AddWithValue("@ULT_ATUAL", DTO.ULT_ATUAL);
            cmd.Parameters.AddWithValue("@OBSERVACAO", DTO.OBSERVACAO);

            //Substitui o null por DBnull
            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

        }

        public CLIENTE_DTO Seleciona(int Id)
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                CLIENTE_DTO DTO = new CLIENTE_DTO();

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM CLIENTE Where (Id = " + Id + " );");

                    sb.Append("SELECT * FROM CELULAR Where (ID_CLIENTE = " + Id + " );");
                    sb.Append("SELECT * FROM TELEFONE Where (ID_CLIENTE = " + Id + " );");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    if (dtr.Read())
                    {
                        PopularDados(dtr, DTO);

                        if (dtr.NextResult())
                        {
                            while (dtr.Read())
                            {
                                CELULAR_DTO CELULAR = new CELULAR_DTO();
                                PopularDadosCelular(dtr, CELULAR);
                                DTO.CELULAR.Add(CELULAR);
                            }
                        }

                        if (dtr.NextResult())
                        {
                            while (dtr.Read())
                            {
                                TELEFONE_DTO TELEFONE = new TELEFONE_DTO();
                                PopularDadosTelefone(dtr, TELEFONE);
                                DTO.TELEFONE.Add(TELEFONE);
                            }
                        }
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

        public void PopularDados(SqlDataReader dtr, CLIENTE_DTO Cliente)
        {
            Cliente.ID = Convert.ToInt32(dtr["ID"]);
            //DADOS
            Cliente.NOME_COMPLETO = dtr["NOME_COMPLETO"] == DBNull.Value ? "" : dtr["NOME_COMPLETO"].ToString();
            Cliente.CPF = dtr["CPF"].ToString();
            Cliente.RG = dtr["RG"].ToString();
            Cliente.DATA_NASCIMENTO = dtr["DATA_NASCIMENTO"] == DBNull.Value ? "" : dtr["DATA_NASCIMENTO"].ToString();
            if (!string.IsNullOrEmpty(Cliente.DATA_NASCIMENTO) && Cliente.DATA_NASCIMENTO.Length > 10)
                Cliente.DATA_NASCIMENTO = Cliente.DATA_NASCIMENTO.Substring(0, 10);
            Cliente.CNH_CATEGORIA = dtr["CNH_CATEGORIA"].ToString();
            Cliente.CNH_ID_TIPO = dtr["CNH_ID_TIPO"] == DBNull.Value ? (int?)null : Convert.ToInt32(dtr["CNH_ID_TIPO"]);
            Cliente.CNH = Convert.ToString(dtr["CNH"]);
            Cliente.CNH_UF = dtr["CNH_UF"].ToString();
            Cliente.CNH_MUNICIPIO = dtr["CNH_MUNICIPIO"].ToString();
            Cliente.CNH_PONTUACAO = dtr["CNH_PONTUACAO"] == DBNull.Value ? (int?)null : Convert.ToInt32(dtr["CNH_PONTUACAO"]);
            Cliente.CNH_DATA_VENCIMENTO = dtr["CNH_DATA_VENCIMENTO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["CNH_DATA_VENCIMENTO"]);
            Cliente.CNH_DATA_EMISSAO = dtr["CNH_DATA_EMISSAO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["CNH_DATA_EMISSAO"]);
            Cliente.CNH_VENCIDA = dtr["CNH_VENCIDA"] == DBNull.Value ? false : Convert.ToBoolean(dtr["CNH_VENCIDA"]);
            Cliente.ATIV_REMUNERADA = dtr["ATIV_REMUNERADA"] == DBNull.Value ? false : Convert.ToBoolean(dtr["ATIV_REMUNERADA"]);
            Cliente.SIGLA_PCD = dtr["SIGLA_PCD"] == DBNull.Value ? "" : dtr["SIGLA_PCD"].ToString();
            //ENDERECO
            Cliente.CEP = dtr["CEP"].ToString();
            Cliente.BAIRRO = dtr["BAIRRO"].ToString();
            Cliente.LOGRADOURO = dtr["LOGRADOURO"].ToString();
            //Cliente.UF = dtr["UF"].ToString();
            Cliente.MUNICIPIO = dtr["MUNICIPIO"].ToString();
            Cliente.COMPLEMENTO = dtr["COMPLEMENTO"].ToString();
            Cliente.NUMERO_RES = dtr["NUMERO_RES"].ToString();
            //CONTATO
            Cliente.EMAIL = dtr["EMAIL"].ToString();
            Cliente.EMAIL2 = dtr["EMAIL2"].ToString();
            //Cliente.CELULAR = dtr["CELULAR"].ToString();
            //Cliente.TELEFONE = dtr["TELEFONE"].ToString();
            Cliente.USUARIO = dtr["USUARIO"].ToString();
            Cliente.ULT_ATUAL = dtr["ULT_ATUAL"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["ULT_ATUAL"]);
            Cliente.PORTARIA = dtr["PORTARIA"] == DBNull.Value ? false : Convert.ToBoolean(dtr["PORTARIA"]);
            Cliente.IMPEDIMENTO = dtr["IMPEDIMENTO"] == DBNull.Value ? false : Convert.ToBoolean(dtr["IMPEDIMENTO"]);
            Cliente.OBSERVACAO = dtr["OBSERVACAO"].ToString();
        }

        #region CELULAR
        public int? Set_Cliente_Celular(CLIENTE_DTO CLIENTE)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                try
                {
                    if (CLIENTE.CELULAR == null)
                        return 0;
                    if (!CLIENTE.CELULAR.Exists(x => x.OPERACAO != SysDTO.Operacoes.Leitura))
                        return 0;
                    int qtdUpdIns = 0;

                    foreach (CELULAR_DTO DTO in CLIENTE.CELULAR.Where(x => x.OPERACAO != SysDTO.Operacoes.Leitura))
                    {
                        DTO.ID_CLIENTE = Convert.ToInt32(CLIENTE.ID);

                        StringBuilder SQL_ = new StringBuilder();
                        if (DTO.OPERACAO == SysDTO.Operacoes.Inclusao)
                        {
                            SQL_.Append("INSERT INTO [dbo].[CELULAR] ");
                            SQL_.Append("           ([ID_CLIENTE] ");
                            SQL_.Append("           ,[NUMERO]) ");
                            SQL_.Append("     VALUES ");
                            SQL_.Append("           ( ");
                            SQL_.Append("		     @ID_CLIENTE ");
                            SQL_.Append("           ,@NUMERO ");
                            SQL_.Append("           ); ");
                            SQL_.Append("SELECT SCOPE_IDENTITY(); ");
                        }
                        else if (DTO.OPERACAO == SysDTO.Operacoes.Alteracao)
                        {
                            SQL_.Append("UPDATE [dbo].[CELULAR] ");
                            SQL_.Append("   SET [ID_CLIENTE] = @ID_CLIENTE ");
                            SQL_.Append("      ,[NUMERO] = @NUMERO ");
                            SQL_.Append(" WHERE ID = @ID ");
                        }
                        else if (DTO.OPERACAO == SysDTO.Operacoes.Exclusao)
                        {
                            SQL_.Append("DELETE FROM [CELULAR] WHERE ID = @ID");
                        }
                        cn.Open();

                        SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                        PopularParametrosCelular(DTO, cmd);

                        cmd.ExecuteNonQuery();
                        cn.Close();
                        qtdUpdIns++;
                    }
                    return qtdUpdIns;
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

        public void PopularParametrosCelular(CELULAR_DTO DTO, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ID", DTO.ID);
            //DADOS
            cmd.Parameters.AddWithValue("@ID_CLIENTE", DTO.ID_CLIENTE);
            cmd.Parameters.AddWithValue("@NUMERO", DTO.NUMERO);

            //Substitui o null por DBnull
            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

        }

        public void PopularDadosCelular(SqlDataReader dtr, CELULAR_DTO DTO)
        {
            DTO.ID = Convert.ToInt32(dtr["ID"]);
            DTO.ID_CLIENTE = Convert.ToInt32(dtr["ID_CLIENTE"]);
            DTO.NUMERO = dtr["NUMERO"].ToString();
        }

        #endregion

        #region TELEFONE
        public int? Set_Cliente_Telefone(CLIENTE_DTO CLIENTE)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                try
                {
                    if (CLIENTE.TELEFONE == null)
                        return 0;
                    if (!CLIENTE.TELEFONE.Exists(x => x.OPERACAO != SysDTO.Operacoes.Leitura))
                        return 0;
                    int qtdUpdIns = 0;

                    foreach (TELEFONE_DTO DTO in CLIENTE.TELEFONE.Where(x => x.OPERACAO != SysDTO.Operacoes.Leitura))
                    {
                        DTO.ID_CLIENTE = Convert.ToInt32(CLIENTE.ID);
                        StringBuilder SQL_ = new StringBuilder();
                        if (DTO.OPERACAO == SysDTO.Operacoes.Inclusao)
                        {
                            SQL_.Append("INSERT INTO [dbo].[TELEFONE] ");
                            SQL_.Append("           ([ID_CLIENTE] ");
                            SQL_.Append("           ,[NUMERO]) ");
                            SQL_.Append("     VALUES ");
                            SQL_.Append("           ( ");
                            SQL_.Append("		     @ID_CLIENTE ");
                            SQL_.Append("           ,@NUMERO ");
                            SQL_.Append("           ); ");
                            SQL_.Append("SELECT SCOPE_IDENTITY(); ");
                        }
                        else if (DTO.OPERACAO == SysDTO.Operacoes.Alteracao)
                        {
                            SQL_.Append("UPDATE [dbo].[TELEFONE] ");
                            SQL_.Append("   SET [ID_CLIENTE] = @ID_CLIENTE ");
                            SQL_.Append("      ,[NUMERO] = @NUMERO ");
                            SQL_.Append(" WHERE ID = @ID ");
                        }
                        else if (DTO.OPERACAO == SysDTO.Operacoes.Exclusao)
                        {
                            SQL_.Append("DELETE FROM [TELEFONE] WHERE ID = @ID");
                        }
                        cn.Open();

                        SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                        PopularParametrosTelefone(DTO, cmd);

                        cmd.ExecuteNonQuery();
                        cn.Close();
                        qtdUpdIns++;
                    }
                    return qtdUpdIns;
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

        public void PopularParametrosTelefone(TELEFONE_DTO DTO, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ID", DTO.ID);
            //DADOS
            cmd.Parameters.AddWithValue("@ID_CLIENTE", DTO.ID_CLIENTE);
            cmd.Parameters.AddWithValue("@NUMERO", DTO.NUMERO);

            //Substitui o null por DBnull
            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

        }

        public void PopularDadosTelefone(SqlDataReader dtr, TELEFONE_DTO DTO)
        {
            DTO.ID = Convert.ToInt32(dtr["ID"]);
            DTO.ID_CLIENTE = Convert.ToInt32(dtr["ID_CLIENTE"]);
            DTO.NUMERO = dtr["NUMERO"].ToString();
        }
        #endregion

    }
}
