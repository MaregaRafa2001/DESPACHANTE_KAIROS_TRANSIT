using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SYS_MENU_BLL
    {
        public string strConnection;
        SYS_MENU_DAO uDAO = null;

        public SYS_MENU_BLL(string cn = "")
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            uDAO = new SYS_MENU_DAO(strConnection);
        }

        public List<SYS_MENU_DTO> Listar()
        {
            return uDAO.Listar();
        }
    }
}
