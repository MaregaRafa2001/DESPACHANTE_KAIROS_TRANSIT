using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SYS_MENU_DAL
    {
        public string strConnection;

        public SYS_MENU_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public List<SYS_MENU_DTO> Listar()
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                List<SYS_MENU_DTO> SYS_PERFIL = new List<SYS_MENU_DTO>();

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("SELECT ");
                    SQL_.Append("* ");
                    SQL_.Append("FROM ");
                    SQL_.Append("SYS_MENU ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        SYS_MENU_DTO DTO = new SYS_MENU_DTO();
                        DTO.ID = Convert.ToInt32(dr["ID"]);
                        DTO.DESCRICAO = dr["DESCRICAO"].ToString();
                        DTO.NAME = dr["NAME"].ToString();
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
