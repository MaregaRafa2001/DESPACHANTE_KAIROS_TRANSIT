using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CONTRATO_BLL
    {
        public string strConnection;
        CONTRATO_DAL DAO = null;

        public CONTRATO_BLL(string cn)
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new CONTRATO_DAL(strConnection);
        }

        public int? Set_Contrato(CONTRATO_DTO DTO)
        {
            return DAO.Set_Contrato(DTO);
        }

    }
}
