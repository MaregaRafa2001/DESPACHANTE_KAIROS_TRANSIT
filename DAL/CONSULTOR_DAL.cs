using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CONSULTOR_DAL
    {
        public string strConnection;

        public CONSULTOR_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public int? Set_Consultor(CONSULTOR_DTO DTO)
        {

            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("INSERT INTO ");
                    SQL_.Append("CONSULTOR ");
                    SQL_.Append("( ");
                    SQL_.Append("NOME, ");
                    SQL_.Append("TELEFONE, ");
                    SQL_.Append("EMAIL ");
                    SQL_.Append(") ");
                    SQL_.Append("VALUES ");
                    SQL_.Append("( ");
                    SQL_.Append("@NOME, ");
                    SQL_.Append("@TELEFONE, ");
                    SQL_.Append("@EMAIL ");
                    SQL_.Append("); SELECT SCOPE_IDENTITY(); ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    cmd.Parameters.AddWithValue("@NOME", DTO.NOME);
                    cmd.Parameters.AddWithValue("@TELEFONE", DTO.TELEFONE);
                    cmd.Parameters.AddWithValue("@EMAIL", DTO.EMAIL);


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

        public CONSULTOR_DTO Seleciona(int Id)
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                CONSULTOR_DTO Cliente = new CONSULTOR_DTO();

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM CONSULTOR Where (Id = " + Id + ");");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    if (dtr.Read())
                    {
                        Cliente.ID = Convert.ToInt32(dtr["ID"]);
                        Cliente.NOME = dtr["NOME"].ToString();
                        Cliente.TELEFONE = dtr["TELEFONE"].ToString();
                        Cliente.EMAIL = dtr["EMAIL"].ToString();
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


    }
}
