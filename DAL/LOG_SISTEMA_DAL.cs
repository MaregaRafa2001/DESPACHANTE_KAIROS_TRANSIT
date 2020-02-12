using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LOG_SISTEMA_DAL
    {
        public string strConnection;

        public LOG_SISTEMA_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public int? Inserir(LOG_SISTEMA_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("INSERT INTO [dbo].[LOG_SISTEMA]    ");
                    SQL_.Append("           ([TABELA]               ");
                    SQL_.Append("           ,[TELA]                 ");
                    SQL_.Append("           ,[OPERACAO]             ");
                    SQL_.Append("           ,[ID_REGISTRO]          ");
                    SQL_.Append("           ,[ITENS_ALTERADOS])     ");
                    SQL_.Append("     VALUES                        ");
                    SQL_.Append("           (                       ");
                    SQL_.Append("		     @TABELA                ");
                    SQL_.Append("           ,@TELA                  ");
                    SQL_.Append("           ,@OPERACAO              ");
                    SQL_.Append("           ,@ID_REGISTRO           ");
                    SQL_.Append("           ,@ITENS_ALTERADOS       ");
                    SQL_.Append("		   )                        ");
                    SQL_.Append("SELECT SCOPE_IDENTITY();           ");
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

        public void PopularParametros(LOG_SISTEMA_DTO DTO, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ID", DTO.ID);
            cmd.Parameters.AddWithValue("@TABELA", DTO.TABELA);
            cmd.Parameters.AddWithValue("@TELA", DTO.TELA);
            cmd.Parameters.AddWithValue("@OPERACAO", DTO.OPERACAO);
            cmd.Parameters.AddWithValue("@ID_REGISTRO", DTO.ID_REGISTRO);
            cmd.Parameters.AddWithValue("@ITENS_ALTERADOS", DTO.ITENS_ALTERADOS);

            //Substitui o null por DBnull
            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

        }

        public List<LOG_SISTEMA_DTO> Seleciona_By_Tabela(string TABELA)
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                List<LOG_SISTEMA_DTO> lista = new List<LOG_SISTEMA_DTO>();
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM LOG_SISTEMA WHERE TABELA = '" + TABELA + "';");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    while (dtr.Read())
                    {
                        LOG_SISTEMA_DTO DTO = new LOG_SISTEMA_DTO();
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

        public LOG_SISTEMA_DTO Seleciona_By_iD(int ID)
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                LOG_SISTEMA_DTO DTO = new LOG_SISTEMA_DTO();
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM LOG_SISTEMA WHERE ID = " + ID + ";");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    if (dtr.Read())
                    {
                        PopularDados(dtr, DTO);
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

        public void PopularDados(SqlDataReader dtr, LOG_SISTEMA_DTO DTO)
        {
            try
            {
                DTO.ID = Convert.ToInt32(dtr["ID"]);
                DTO.TABELA = dtr["TABELA"].ToString();
                DTO.TELA = dtr["TELA"].ToString();
                DTO.OPERACAO = dtr["OPERACAO"].ToString();
                DTO.ID_REGISTRO = dtr["ID_REGISTRO"].ToString();
                DTO.ITENS_ALTERADOS = dtr["ITENS_ALTERADOS"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
