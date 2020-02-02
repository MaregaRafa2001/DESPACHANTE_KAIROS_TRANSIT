using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SERVICO_BLL
    {
        public string strConnection;
        SERVICO_DAL DAO = null;

        public SERVICO_BLL(string cn = "")
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new SERVICO_DAL(strConnection);
        }

        public int? Set_Servico(SERVICO_DTO DTO)
        {
            return DAO.Set_Servico(DTO);
        }
        public List<SERVICO_DTO> ListaServico(bool ContainsTodos = false)
        {
            return DAO.Lista_Servico(ContainsTodos);
        }
        public List<ComboItemDTO> ListaServicoComboItemDTO(bool ContainsTodos = false)
        {
            return DAO.ListaServicoComboItemDTO(ContainsTodos);
        }
    }
}
