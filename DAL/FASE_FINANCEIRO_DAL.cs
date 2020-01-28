using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FASE_FINANCEIRO_DAL
    {
        public string strConnection;

        public FASE_FINANCEIRO_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public List<FASE_FINANCEIRO_DTO> Listar()
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                List<FASE_FINANCEIRO_DTO> SYS_PERFIL = new List<FASE_FINANCEIRO_DTO>();

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("SELECT ");
                    SQL_.Append("* ");
                    SQL_.Append("FROM ");
                    SQL_.Append("FASE_FINANCEIRO ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        FASE_FINANCEIRO_DTO DTO = new FASE_FINANCEIRO_DTO();
                        DTO.ID = Convert.ToInt32(dr["ID"]);
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

    }
}
