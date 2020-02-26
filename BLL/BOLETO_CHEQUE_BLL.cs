using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BOLETO_CHEQUE_BLL
    {
        public string strConnection;
        BOLETO_CHEQUE_DAL DAO = null;

        public BOLETO_CHEQUE_BLL(string cn = "")
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new BOLETO_CHEQUE_DAL(strConnection);
        }

        public int? Inserir(BOLETO_CHEQUE_DTO DTO)
        {
            return DAO.Inserir(DTO);
        }

        public bool Excluir(int id)
        {
            return DAO.Excluir(id);
        }
        public bool Alterar(BOLETO_CHEQUE_DTO DTO)
        {
            SysDAL.Grava_Historico(DTO, strConnection, SysBLL.UserLogin.NOME);
            return DAO.Alterar(DTO);
        }

        public List<BOLETO_CHEQUE_DTO> Seleciona_by_Id_Financeiro(int ID_FINANCEIRO)
        {
            return DAO.Seleciona_by_Id_Financeiro(ID_FINANCEIRO);
        }
    }
}
