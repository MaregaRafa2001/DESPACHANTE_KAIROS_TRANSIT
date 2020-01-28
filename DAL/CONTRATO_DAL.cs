using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CONTRATO_DAL
    {
        public string strConnection;

        public CONTRATO_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public int? Set_Contrato(CONTRATO_DTO DTO)
        {

            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("INSERT INTO ");
                    SQL_.Append("CONTRATO ");
                    SQL_.Append("( ");
                    SQL_.Append("ID_CONSULTOR, ");
                    SQL_.Append("INDICACAO, ");
                    SQL_.Append("ID_SERVICO, ");
                    SQL_.Append("FORMA_PAG, ");
                    SQL_.Append("ID_CLIENTE, ");
                    SQL_.Append("QTD_PARCELAS, ");
                    SQL_.Append("N_BOLETO_CHEQUE, ");
                    SQL_.Append("OBS ");
                    SQL_.Append(") ");
                    SQL_.Append("VALUES ");
                    SQL_.Append("( ");
                    SQL_.Append("@ID_CONSULTOR, ");
                    SQL_.Append("@INDICACAO, ");
                    SQL_.Append("@ID_SERVICO, ");
                    SQL_.Append("@FORMA_PAG, ");
                    SQL_.Append("@ID_CLIENTE, ");
                    SQL_.Append("@QTD_PARCELAS, ");
                    SQL_.Append("@N_BOLETO_CHEQUE, ");
                    SQL_.Append("@OBS ");
                    SQL_.Append("); SELECT SCOPE_IDENTITY(); ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    cmd.Parameters.AddWithValue("@ID_CONSULTOR", DTO.ID_CONSULTOR);
                    cmd.Parameters.AddWithValue("@INDICACAO", DTO.INDICACAO);
                    cmd.Parameters.AddWithValue("@ID_SERVICO", DTO.ID_SERVICO);
                    cmd.Parameters.AddWithValue("@FORMA_PAG", DTO.FORMA_PAG);
                    cmd.Parameters.AddWithValue("@ID_CLIENTE", DTO.ID_CLIENTE);
                    cmd.Parameters.AddWithValue("@QTD_PARCELAS", DTO.QTD_PARCELAS);
                    cmd.Parameters.AddWithValue("@N_BOLETO_CHEQUE", DTO.N_BOLETO_CHEQUE);
                    cmd.Parameters.AddWithValue("@OBS", DTO.OBS);





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


    }
}
