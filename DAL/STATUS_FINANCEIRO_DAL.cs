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
    public class STATUS_FINANCEIRO_DAL
    {
        public string strConnection;

        public STATUS_FINANCEIRO_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public List<ComboItemDTO> Lista_Status(bool addTodos = false)
        {
            DataTable dtt = new PesquisaGeralDAL(this.strConnection).Pesquisa("SELECT * FROM STATUS_FINANCEIRO ORDER BY DESCRICAO ");

            List<ComboItemDTO> List = new List<ComboItemDTO>();

            if (addTodos)
            {
                List.Add(new ComboItemDTO() { Text = "Todos", Value = 0 });
            }

            foreach (DataRow row in dtt.Rows)
            {
                List.Add(new ComboItemDTO() { Text = row["DESCRICAO"] == DBNull.Value ? (string)null : char.ToUpper(row["DESCRICAO"].ToString()[0]) + row["DESCRICAO"].ToString().Substring(1), Value = row["ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID"]) });
            }

            if (List.Count > 0)
            {
                return List;
            }
            else
            {
                List.Add(new ComboItemDTO() { Text = "Sem status.", Value = null });
                return List;
            }
        }

    }
}
