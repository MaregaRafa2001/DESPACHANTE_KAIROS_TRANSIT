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
    public class SERVICO_DAL
    {
        public string strConnection;

        public SERVICO_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public int? Set_Servico(SERVICO_DTO DTO)
        {

            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("INSERT INTO ");
                    SQL_.Append("SERVICOS ");
                    SQL_.Append("( ");
                    SQL_.Append("NOME, ");
                    SQL_.Append("VALOR ");
                    SQL_.Append(") ");
                    SQL_.Append("VALUES ");
                    SQL_.Append("( ");
                    SQL_.Append("@NOME, ");
                    SQL_.Append("@VALOR ");
                    SQL_.Append("); SELECT SCOPE_IDENTITY(); ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    cmd.Parameters.AddWithValue("@NOME", DTO.NOME);
                    cmd.Parameters.AddWithValue("@VALOR", DTO.VALOR);



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

        public List<SERVICO_DTO> Lista_Servico(bool ContainsTodos = false)
        {
            DataTable dtt = new PesquisaGeralDAL(this.strConnection).Pesquisa("SELECT * FROM SERVICOS WHERE ATIVO = 1 ORDER BY NOME ");

            List<SERVICO_DTO> List = new List<SERVICO_DTO>();

            if (ContainsTodos)
            {
                List.Add(new SERVICO_DTO() { NOME = "Todos", ID = 0, VALOR = Convert.ToDecimal("0.00") });
            }

            foreach (DataRow row in dtt.Rows)
            {
                List.Add(new SERVICO_DTO() { NOME = row["NOME"] == DBNull.Value ? (string)null : char.ToUpper(row["NOME"].ToString()[0]) + row["NOME"].ToString().Substring(1), ID = row["ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID"]), VALOR = row["VALOR"] == DBNull.Value? 0 : Convert.ToDecimal(row["VALOR"].ToString()) });
            }

            if (List.Count > 0)
            {
                return List;
            }
            else
            {
                List.Add(new SERVICO_DTO() { NOME = "Sem serviços.", ID = null, VALOR = Convert.ToDecimal("0.00") });
                return List;
            }
        }
        public List<ComboItemDTO> ListaServicoComboItemDTO(bool ContainsTodos = false)
        {
            DataTable dtt = new PesquisaGeralDAL(this.strConnection).Pesquisa("SELECT * FROM SERVICOS ORDER BY NOME ");

            List<ComboItemDTO> List = new List<ComboItemDTO>();

            if (ContainsTodos)
            {
                List.Add(new ComboItemDTO() { Text = "Todos", Value = "" });
            }

            foreach (DataRow row in dtt.Rows)
            {
                List.Add(new ComboItemDTO() { Text = row["NOME"] == DBNull.Value ? (string)null : char.ToUpper(row["NOME"].ToString()[0]) + row["NOME"].ToString().Substring(1), Value = row["ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID"]) });
            }

            if (List.Count > 0)
            {
                return List;
            }
            else
            {
                List.Add(new ComboItemDTO() { Text = "Sem serviços.", Value = null });
                return List;
            }
        }

    }
}
