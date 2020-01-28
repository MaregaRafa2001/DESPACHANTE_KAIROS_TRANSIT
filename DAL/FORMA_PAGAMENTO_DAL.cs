using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FORMA_PAGAMENTO_DAL
    {
        public string strConnection;

        public FORMA_PAGAMENTO_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public List<FORMA_PAGAMENTO_DTO> Lista_Forma_Pagamento()
        {
            DataTable dtt = new PesquisaGeralDAL(this.strConnection).Pesquisa("SELECT * FROM FORMA_PAGAMENTO");

            List<FORMA_PAGAMENTO_DTO> List = new List<FORMA_PAGAMENTO_DTO>();

            foreach (DataRow row in dtt.Rows)
            {
                List.Add(new FORMA_PAGAMENTO_DTO() { DESCRICAO = row["DESCRICAO"] == DBNull.Value ? (string)null : row["DESCRICAO"].ToString(), ID = row["ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID"]), GERANUMERO = row["GERANUMERO"] == DBNull.Value ? false : Convert.ToBoolean(row["GERANUMERO"]) });
            }

            List<FORMA_PAGAMENTO_DTO> ListaFiltrada = new List<FORMA_PAGAMENTO_DTO>();

            foreach (FORMA_PAGAMENTO_DTO item in List)
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
                ListaFiltrada.Add(new FORMA_PAGAMENTO_DTO() { DESCRICAO = "Sem formas de pagamentos.", ID = null, GERANUMERO = false });
                return ListaFiltrada;
            }
        }


    }
}
