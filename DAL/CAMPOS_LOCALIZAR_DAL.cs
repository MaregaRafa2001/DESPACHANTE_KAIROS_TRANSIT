using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CAMPOS_LOCALIZAR_DAL
    {
        public string strConnection;

        public CAMPOS_LOCALIZAR_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public List<CAMPOS_LOCALIZAR_DTO> Listar(string Tela)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                List<CAMPOS_LOCALIZAR_DTO> CAMPOS_TELA = new List<CAMPOS_LOCALIZAR_DTO>();

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("SELECT ");
                    SQL_.Append("* ");
                    SQL_.Append("FROM ");
                    SQL_.Append("CAMPOS_LOCALIZAR ");
                    SQL_.Append("WHERE ");
                    SQL_.Append("TELA ='" + Tela + "' ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        CAMPOS_LOCALIZAR_DTO DTO = new CAMPOS_LOCALIZAR_DTO();
                        DTO.ID = Convert.ToInt32(dr["ID"]);
                        DTO.TELA = Convert.ToString(dr["TELA"]);
                        DTO.DISPLAY = Convert.ToString(dr["DISPLAY"]);
                        DTO.VALUE = Convert.ToString(dr["VALUE"]);
                        DTO.TIPO = Convert.ToString(dr["TIPO"]);
                        CAMPOS_TELA.Add(DTO);
                    }

                    return CAMPOS_TELA;
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
