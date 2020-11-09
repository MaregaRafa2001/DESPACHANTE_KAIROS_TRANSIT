using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FORMA_PAGAMENTO_BLL
    {
        public string strConnection;
        FORMA_PAGAMENTO_DAL DAO = null;

        public FORMA_PAGAMENTO_BLL(string cn = "")
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new FORMA_PAGAMENTO_DAL(strConnection);
        }

        public int? Set_FormaPagamento(FORMA_PAGAMENTO_DTO DTO)
        {
            SysDAL.Grava_Historico(DTO, strConnection, SysBLL.UserLogin.NOME);
            return DAO.Set_FormaPagamento(DTO);
        }

        public bool Update_FormaPagamento(FORMA_PAGAMENTO_DTO DTO)
        {
            SysDAL.Grava_Historico(DTO, strConnection, SysBLL.UserLogin.NOME);
            return DAO.Update_FormaPagamento(DTO);
        }

        public bool Excluir(int id)
        {
            return DAO.Excluir(id);
        }

        public FORMA_PAGAMENTO_DTO Selecione(int ID)
        {
            return DAO.Seleciona(ID);
        }

        public List<FORMA_PAGAMENTO_DTO> Lista_Forma_Pagamento()
        {
            return DAO.Lista_Forma_Pagamento();
        }

    }
}
