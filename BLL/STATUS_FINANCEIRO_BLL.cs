using System;
using DTO;
using DAO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class STATUS_FINANCEIRO_BLL
    {
        public string strConnection;
        STATUS_FINANCEIRO_DAO DAO = null;
        public Func<string> get_Connection;

        public STATUS_FINANCEIRO_BLL(string cn)
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new STATUS_FINANCEIRO_DAO(strConnection);
        }

        public List<ComboItemDTO> Lista_Status(bool addTodos = false)
        {
            return DAO.Lista_Status(addTodos);
        }
    }
}
