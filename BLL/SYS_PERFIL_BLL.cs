using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class SYS_PERFIL_BLL
    {
        public string strConnection;
        SYS_PERFIL_DAL uDAO = null;

        public SYS_PERFIL_BLL(string cn = "")
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            uDAO = new SYS_PERFIL_DAL(strConnection);
        }

        public List<SYS_PERFIL_DTO> Listar()
        {
            return uDAO.Listar();
        }
    }
}
