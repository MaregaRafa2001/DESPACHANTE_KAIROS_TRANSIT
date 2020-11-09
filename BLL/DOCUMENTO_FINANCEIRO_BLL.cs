using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DOCUMENTO_FINANCEIRO_BLL
    {
        public string strConnection;
        DOCUMENTO_FINANCEIRO_DAL DAO = null;
        public Func<string> get_Connection;

        public DOCUMENTO_FINANCEIRO_BLL(string cn = "")
        {
            try
            {
                if (string.IsNullOrEmpty(cn))
                    cn = SysBLL.strConexao;
                this.strConnection = cn;

                DAO = new DOCUMENTO_FINANCEIRO_DAL(strConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? Set_DOCUMENTO_FINANCEIRO(DOCUMENTO_FINANCEIRO_DTO DTO)
        {
            try
            {
                ValidarDados(DTO);
                SysDAL.Grava_Historico(DTO, strConnection, SysBLL.UserLogin.NOME);
                return DAO.Set_Documento(DTO);
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

        private void ValidarDados(DOCUMENTO_FINANCEIRO_DTO DTO)
        {
            try
            {
                if (DTO.ID_DOCUMENTO == null)
                    throw new CustomException("Favor informe o documento", "Dados incorretos");
                if (DTO.ID_FINANCEIRO == null)
                    throw new CustomException("Erro ao resgatar o id financeiro.\nPor favor, entre em contato com o administrador do sistema", "Erro ao registrar");
                }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public bool Update_DOCUMENTO_FINANCEIRO(DOCUMENTO_FINANCEIRO_DTO DTO)
        {
            try
            {
                ValidarDados(DTO);
                SysDAL.Grava_Historico(DTO, strConnection, SysBLL.UserLogin.NOME);
                return DAO.Update_Documento(DTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DOCUMENTO_FINANCEIRO_DTO Seleciona(int ID)
        {
            try
            {
                return DAO.Seleciona(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
