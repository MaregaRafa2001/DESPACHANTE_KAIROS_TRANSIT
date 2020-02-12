using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LOG_SISTEMA_BLL
    {
        public string strConnection;
        LOG_SISTEMA_DAL DAO = null;

        public LOG_SISTEMA_BLL(string cn = "")
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new LOG_SISTEMA_DAL(strConnection);
        }

        public int? Inserir(LOG_SISTEMA_DTO DTO)
        {
            return DAO.Inserir(DTO);
        }

        public List<LOG_SISTEMA_DTO> Seleciona_By_Tabela(string TABELA)
        {
            return DAO.Seleciona_By_Tabela(TABELA);
        }

        public LOG_SISTEMA_DTO Seleciona_By_iD(int ID)
        {
            return DAO.Seleciona_By_iD(ID);
        }
    }
}
