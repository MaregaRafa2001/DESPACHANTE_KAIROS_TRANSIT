using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FORMA_PAGAMENTO_BLL
    {
        public string strConnection;
        FORMA_PAGAMENTO_DAO DAO = null;

        public FORMA_PAGAMENTO_BLL(string cn)
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new FORMA_PAGAMENTO_DAO(strConnection);
        }

        public List<FORMA_PAGAMENTO_DTO> Lista_Forma_Pagamento()
        {
            return DAO.Lista_Forma_Pagamento();
        }

    }
}
