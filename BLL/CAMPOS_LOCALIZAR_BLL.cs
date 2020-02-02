using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CAMPOS_LOCALIZAR_BLL
    {
        public string strConnection;
        CAMPOS_LOCALIZAR_DAL DAO = null;
        public CAMPOS_LOCALIZAR_BLL(string cn = "")
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new CAMPOS_LOCALIZAR_DAL(strConnection);
        }

        public List<CAMPOS_LOCALIZAR_DTO> Listar(string TELA)
        {
            return DAO.Listar(TELA);
        }
    }
}
