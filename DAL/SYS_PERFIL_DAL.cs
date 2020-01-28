using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SYS_PERFIL_DAL
    {
        public string strConnection;

        public SYS_PERFIL_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public List<SYS_PERFIL_DTO> Listar()
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                List<SYS_PERFIL_DTO> SYS_PERFIL = new List<SYS_PERFIL_DTO>();

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("SELECT ");
                    SQL_.Append("* ");
                    SQL_.Append("FROM ");
                    SQL_.Append("SYS_PERFIL ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        SYS_PERFIL_DTO DTO = new SYS_PERFIL_DTO();
                        DTO.ID = Convert.ToInt32(dr["ID"]);
                        DTO.DESCRICAO = dr["DESCRICAO"].ToString();
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
