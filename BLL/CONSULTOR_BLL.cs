using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CONSULTOR_BLL
    {
        public string strConnection;
        CONSULTOR_DAO DAO = null;

        public CONSULTOR_BLL(string cn)
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new CONSULTOR_DAO(strConnection);
        }

        public int? Set_Consultor(CONSULTOR_DTO DTO)
        {
            return DAO.Set_Consultor(DTO);
        }

        public CONSULTOR_DTO Selecione(int ID)
        {
            return DAO.Seleciona(ID);
        }
    }
}
