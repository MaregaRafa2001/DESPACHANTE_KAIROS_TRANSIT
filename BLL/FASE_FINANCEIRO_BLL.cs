using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FASE_FINANCEIRO_BLL
    {
        public string strConnection;
        FASE_FINANCEIRO_DAL uDAO = null;

        public FASE_FINANCEIRO_BLL(string cn = "")
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            uDAO = new FASE_FINANCEIRO_DAL(strConnection);
        }

        public List<FASE_FINANCEIRO_DTO> Listar()
        {
            return uDAO.Listar();
        }
    }
}
