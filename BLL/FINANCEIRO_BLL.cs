using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class FINANCEIRO_BLL
    {
        public string strConnection;
        FINANCEIRO_DAL DAO = null;
        public Func<string> get_Connection;

        public FINANCEIRO_BLL(string cn = "")
        {
            try
            {
                if (string.IsNullOrEmpty(cn))
                    cn = SysBLL.strConexao;
                this.strConnection = cn;

                DAO = new FINANCEIRO_DAL(strConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? Set_Financeiro(FINANCEIRO_DTO DTO)
        {
            try
            {
                ValidarDados(DTO);
                SysDAL.Grava_Historico(DTO, strConnection, SysBLL.UserLogin.NOME);
                return DAO.Set_Financeiro(DTO);
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

        public bool Update_Financeiro(FINANCEIRO_DTO DTO)
        {
            try
            {
                ValidarDados(DTO);
                SysDAL.Grava_Historico(DTO, strConnection, SysBLL.UserLogin.NOME);
                return DAO.Update_Financeiro(DTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FINANCEIRO_DTO Seleciona(int ID)
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
        public FINANCEIRO_DTO Seleciona_Financeiro_By_Id(int ID)
        {
            try
            {
                return DAO.Seleciona_Financeiro_By_Id(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Registrar_FaseFinanceiro(List<FASE_FINANCEIRO_DTO> lista_fase)
        {
            try
            {
                return DAO.Registrar_FaseFinanceiro(lista_fase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir_FaseFinanceiro(int id)
        {
            try
            {
                return DAO.Excluir_FaseFinanceiro(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Verifica_Consultor(string Consultor)
        {
            try
            {
                return DAO.Verifica_Consultor(Consultor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FINANCEIRO_DTO> Seleciona_By_Cliente(int ID)
        {
            try
            {
                return DAO.Seleciona_By_Cliente(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        private void ValidarDados(FINANCEIRO_DTO DTO)
        {
            try
            {
                if (string.IsNullOrEmpty(DTO.INDICACAO))
                    throw new CustomException("Favor informe a Indicação", "Dados incorretos");
                if (string.IsNullOrEmpty(DTO.FORMA_PAGAMENTO))
                    throw new CustomException("Favor informe a forma de pagamento", "Dados incorretos");
                if (string.IsNullOrEmpty(DTO.CONSULTOR))
                    throw new CustomException("Favor informe o consultor", "Dados incorretos");
                if (DTO.ID_CLIENTE == 0)
                    throw new CustomException("Favor informe o cliente", "Dados incorretos");
                if (DTO.ID_SERVICO == 0)
                    throw new CustomException("Favor informe o serviço", "Dados incorretos");
                if (DTO.DIA_VENCIMENTO <= 0)
                    throw new CustomException("Favor informe o dia de vencimento", "Dados incorretos");
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}