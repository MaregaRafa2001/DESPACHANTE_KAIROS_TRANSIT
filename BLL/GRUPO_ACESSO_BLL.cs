using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class GRUPO_ACESSO_BLL
    {
        public string strConnection;
        GRUPO_ACESSO_DAL DAO = null;

        public GRUPO_ACESSO_BLL(string cn = "")
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new GRUPO_ACESSO_DAL(strConnection);
        }

        public GRUPO_ACESSO_DTO Listar(int ID_PERFIL)
        {
            return DAO.Listar(ID_PERFIL);
        }

        public int? Inserir(GRUPO_ACESSO_DTO DTO)
        {
            try
            {
                return DAO.Inserir(DTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                return DAO.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
