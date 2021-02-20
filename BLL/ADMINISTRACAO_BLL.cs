using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ADMINISTRACAO_BLL
    {
        public string strConnection;
        ADMINISTRACAO_DAL uDAO = null;

        public ADMINISTRACAO_BLL(string cn = "")
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            uDAO = new ADMINISTRACAO_DAL(strConnection);
        }

        public List<ADMINISTRACAO_DTO> Listar()
        {
            return uDAO.Listar();
        }
        public List<FASE_FINANCEIRO_DTO> Listar_FaseFinanceiro(int ID_SERVICO)
        {
            return uDAO.Listar_FaseFinanceiro(ID_SERVICO);
        }
        public List<STATUS_ADMINISTRACAO_FASES> Listar_Status_administracao_Fases()
        {
            return uDAO.Listar_Status_administracao_Fases();
        }
    }
}
