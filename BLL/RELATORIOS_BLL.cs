using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RELATORIOS_BLL
    {
        public string strConnection;
        RELATORIOS_DAO DAO = null;

        public RELATORIOS_BLL(string cn)
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new RELATORIOS_DAO(strConnection);
        }

        public int Registrar(RELATORIOS_DTO DTO)
        {
            try
            {
                if (DTO.Operacao == SysDTO.Operacoes.Inclusao)
                {
                    return DAO.Inserir(DTO);
                }
                else if (DTO.Operacao == SysDTO.Operacoes.Alteracao)
                {
                    return DAO.Alterar(DTO);
                }
                else
                    return 0;
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

        public List<RELATORIOS_DTO> Listar()
        {
            try
            {
                return DAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RELATORIOS_DTO Get_Relatorio_By_Id(int ID)
        {
            try
            {
                return DAO.Get_Relatorio_By_Id(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
