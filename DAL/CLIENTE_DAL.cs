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
                    SQL_.Append("CNH_UF, ");
                    SQL_.Append("CNH_PONTUACAO, ");
                    SQL_.Append("CNH_DATA_VENCIMENTO, ");
                    //ENDERECO
                    SQL_.Append("CEP, ");
                    SQL_.Append("BAIRRO, ");
                    SQL_.Append("LOGRADOURO, ");
                    //SQL_.Append("UF, ");
                    SQL_.Append("MUNICIPIO, ");
                    SQL_.Append("COMPLEMENTO, ");
                    SQL_.Append("NUMERO_RES,    ");
                    //CONTATO
                    SQL_.Append("EMAIL, ");
                    SQL_.Append("EMAIL2, ");
                    SQL_.Append("CELULAR, ");
                    SQL_.Append("TELEFONE, ");
                    SQL_.Append("PORTARIA, ");
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
                    SQL_.Append("@CNH_UF, ");
                    SQL_.Append("@CNH_PONTUACAO, ");
                    SQL_.Append("@CNH_DATA_VENCIMENTO, ");
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
                    SQL_.Append("@CELULAR, ");
                    SQL_.Append("@TELEFONE, ");
                    SQL_.Append("@PORTARIA ");
                    SQL_.Append("@OBSERVACAO ");
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
                    SQL_.Append("CNH_UF = @CNH_UF, ");
                    SQL_.Append("CNH_PONTUACAO = @CNH_PONTUACAO, ");
                    SQL_.Append("CNH_DATA_VENCIMENTO = @CNH_DATA_VENCIMENTO, ");
                    //ENDERECO
                    SQL_.Append("CEP = @CEP, ");
                    SQL_.Append("BAIRRO = @BAIRRO, ");
                    SQL_.Append("LOGRADOURO = @LOGRADOURO, ");
                    //SQL_.Append("UF = @UF, ");
                    SQL_.Append("MUNICIPIO = @MUNICIPIO, ");
                    SQL_.Append("COMPLEMENTO = @COMPLEMENTO, ");
                    SQL_.Append("NUMERO_RES = @NUMERO_RES, ");
                    //CONTATO
                    SQL_.Append("EMAIL = @EMAIL, ");
                    SQL_.Append("EMAIL2 = @EMAIL2, ");
                    SQL_.Append("CELULAR = @CELULAR, ");
                    SQL_.Append("TELEFONE = @TELEFONE, ");
                    SQL_.Append("PORTARIA = @PORTARIA, ");
                    SQL_.Append("OBSERVACAO = @OBSERVACAO ");

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
            cmd.Parameters.AddWithValue("@DATA_NASCIMENTO", DTO.DATA_NASCIMENTO);
            cmd.Parameters.AddWithValue("@CNH", DTO.CNH);
            cmd.Parameters.AddWithValue("@CNH_UF", DTO.CNH_UF);
            cmd.Parameters.AddWithValue("@CNH_PONTUACAO", DTO.CNH_PONTUACAO);
            cmd.Parameters.AddWithValue("@CNH_DATA_VENCIMENTO", DTO.CNH_DATA_VENCIMENTO);
            //ENDEREÇO
            cmd.Parameters.AddWithValue("@CEP", DTO.CEP.Replace("-", ""));
            cmd.Parameters.AddWithValue("@BAIRRO", DTO.BAIRRO);
            cmd.Parameters.AddWithValue("@LOGRADOURO", DTO.LOGRADOURO);
            //cmd.Parameters.AddWithValue("@UF", DTO.UF);
            cmd.Parameters.AddWithValue("@MUNICIPIO", DTO.MUNICIPIO);
            cmd.Parameters.AddWithValue("@COMPLEMENTO", DTO.COMPLEMENTO);
            cmd.Parameters.AddWithValue("@NUMERO_RES", DTO.NUMERO_RES);
            //CONTATO
            cmd.Parameters.AddWithValue("@EMAIL", DTO.EMAIL);
            cmd.Parameters.AddWithValue("@EMAIL2", DTO.EMAIL2);
            cmd.Parameters.AddWithValue("@CELULAR", DTO.CELULAR);
            cmd.Parameters.AddWithValue("@TELEFONE", DTO.TELEFONE);
            cmd.Parameters.AddWithValue("@PORTARIA", DTO.PORTARIA);
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
                CLIENTE_DTO Cliente = new CLIENTE_DTO();

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM CLIENTE Where (Id = " + Id + " );");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    if (dtr.Read())
                    {
                        PopularDados(dtr, Cliente);
                    }

                    return Cliente;
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
            Cliente.NOME_COMPLETO = dtr["NOME_COMPLETO"].ToString();
            Cliente.CPF = dtr["CPF"].ToString();
            Cliente.RG = dtr["RG"].ToString();
            Cliente.DATA_NASCIMENTO = dtr["DATA_NASCIMENTO"].ToString();
            Cliente.CNH = Convert.ToString(dtr["CNH"]);
            Cliente.CNH_UF = dtr["CNH_UF"].ToString();
            Cliente.CNH_PONTUACAO = Convert.ToInt32(dtr["CNH_PONTUACAO"]);
            Cliente.CNH_DATA_VENCIMENTO = Convert.ToDateTime(dtr["CNH_DATA_VENCIMENTO"]);
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
            Cliente.CELULAR = dtr["CELULAR"].ToString();
            Cliente.TELEFONE = dtr["TELEFONE"].ToString();
            Cliente.PORTARIA = dtr["PORTARIA"] == DBNull.Value? false : Convert.ToBoolean(dtr["PORTARIA"]);
            Cliente.OBSERVACAO = dtr["OBSERVACAO"].ToString();
        }

    }
}
