using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class LOGIN_BLL
    {
        public string strConnection;
        LOGIN_DAL DAO = null;

        public LOGIN_BLL(string cn = "")
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new LOGIN_DAL(strConnection);
        }

        public LOGIN_DTO Get_User_By_Login(LOGIN_DTO DTO)
        {
            return DAO.Get_User_By_Login(DTO);
        }

        public int? Set_Login(LOGIN_DTO DTO)
        {
            return DAO.Set_Login(DTO);
        }

        public bool Excluir(int id)
        {
            return DAO.Excluir(id);
        }
        public bool Update_Login(LOGIN_DTO DTO)
        {
            return DAO.Update_Login(DTO);
        }

        public LOGIN_DTO Selecione(int ID)
        {
            return DAO.Seleciona(ID);
        }
    }
}
