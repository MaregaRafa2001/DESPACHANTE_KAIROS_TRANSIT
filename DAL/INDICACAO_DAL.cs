using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class INDICACAO_DAL
    {
        public string strConnection;

        public INDICACAO_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public List<INDICACAO_DTO> Lista_indicacao()
        {
            DataTable dtt = new PesquisaGeralDAL(this.strConnection).Pesquisa("SELECT * FROM INDICACAO");

            List<INDICACAO_DTO> List = new List<INDICACAO_DTO>();

            foreach (DataRow row in dtt.Rows)
            {
                List.Add(new INDICACAO_DTO() { DESCRICAO = row["DESCRICAO"] == DBNull.Value ? (string)null : row["DESCRICAO"].ToString(), ID = row["ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID"])});
            }



            List<INDICACAO_DTO> ListaFiltrada = new List<INDICACAO_DTO>();

            foreach (INDICACAO_DTO item in List)
            {
                if (item.DESCRICAO != null)
                {
                    ListaFiltrada.Add(item);
                }
            }

            if (ListaFiltrada.Count > 0)
            {
                return ListaFiltrada;
            }
            else
            {
                ListaFiltrada.Add(new INDICACAO_DTO() { DESCRICAO = "Sem Indicação.", ID = (int?)null });
                return ListaFiltrada;
            }
        }


    }
}