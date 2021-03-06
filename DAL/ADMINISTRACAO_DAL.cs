using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ADMINISTRACAO_DAL
    {
        public string strConnection;

        public ADMINISTRACAO_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public List<ADMINISTRACAO_DTO> Listar()
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                List<ADMINISTRACAO_DTO> SYS_PERFIL = new List<ADMINISTRACAO_DTO>();

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("SELECT ");
                    SQL_.Append("* ");
                    SQL_.Append("FROM ");
                    SQL_.Append("ADMINISTRACAO ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ADMINISTRACAO_DTO DTO = new ADMINISTRACAO_DTO();
                        DTO.ID = Convert.ToInt32(dr["ID"]);
                        DTO.ID_STATUS_ADMINISTRACAO_FASES = dr["ID_STATUS_ADMINISTRACAO_FASES"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID_STATUS_ADMINISTRACAO_FASES"]);
                        DTO.FASE = Convert.ToString(dr["FASE"]);
                        DTO.OBSERVACAO = dr["OBSERVACAO"].ToString();
                        DTO.DATA = dr["COR"] == DBNull.Value? (DateTime?)null : Convert.ToDateTime(dr["COR"].ToString());
                        SYS_PERFIL.Add(DTO);
                    }

                    return SYS_PERFIL;
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

        public List<FASE_FINANCEIRO_DTO> Listar_FaseFinanceiro(int ID_SERVICO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                List<FASE_FINANCEIRO_DTO> LISTA_FASE_FINANCEIRO = new List<FASE_FINANCEIRO_DTO>();

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("SELECT  ");
                    SQL_.Append("FASE.ID, ");
                    SQL_.Append("CONCAT('FASE ', SER_FASE.NUMERO_FASE, ' - ', FASE.DESCRICAO) AS DESCRICAO, ");
                    SQL_.Append("FASE.LAYOUT_TELA ");
                    SQL_.Append("FROM  ");
                    SQL_.Append("SERVICOS_FASE_FINANCEIRO SER_FASE ");
                    SQL_.Append("LEFT JOIN  ");
                    SQL_.Append("FASE_FINANCEIRO FASE ");
                    SQL_.Append("ON  ");
                    SQL_.Append("SER_FASE.ID_FASE_FINANCEIRO = FASE.ID ");
                    SQL_.Append("WHERE  ");
                    SQL_.Append("SER_FASE.ID_SERVICO = @ID_SERVICO ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    cmd.Parameters.AddWithValue("@ID_SERVICO", ID_SERVICO);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        FASE_FINANCEIRO_DTO DTO = new FASE_FINANCEIRO_DTO();
                        DTO.ID = Convert.ToInt32(dr["ID"]);
                        DTO.DESCRICAO = Convert.ToString(dr["DESCRICAO"]);
                        DTO.LAYOUT_TELA = dr["LAYOUT_TELA"] == DBNull.Value? 0 : Convert.ToInt32(dr["LAYOUT_TELA"]);
                        LISTA_FASE_FINANCEIRO.Add(DTO);
                    }

                    return LISTA_FASE_FINANCEIRO;
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



        public List<STATUS_ADMINISTRACAO_FASES> Listar_Status_administracao_Fases()
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                List<STATUS_ADMINISTRACAO_FASES> STATUS_ADMINISTRACAO_FASES = new List<STATUS_ADMINISTRACAO_FASES>();

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("SELECT * FROM STATUS_ADMINISTRACAO_FASES   ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        STATUS_ADMINISTRACAO_FASES DTO = new STATUS_ADMINISTRACAO_FASES();
                        DTO.ID = Convert.ToInt32(dr["ID"]);
                        DTO.DESCRICAO = Convert.ToString(dr["DESCRICAO"]);
                        STATUS_ADMINISTRACAO_FASES.Add(DTO);
                    }

                    return STATUS_ADMINISTRACAO_FASES;
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
}
