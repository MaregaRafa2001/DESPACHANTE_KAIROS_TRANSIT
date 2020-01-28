using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class INDICACAO_BLL
    {
        public string strConnection;
        INDICACAO_DAO DAO = null;

        public INDICACAO_BLL(string cn)
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new INDICACAO_DAO(strConnection);
        }

        public List<INDICACAO_DTO> Lista_indicacao()
        {
            return DAO.Lista_indicacao();
        }

    }
}