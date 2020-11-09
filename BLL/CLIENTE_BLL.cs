using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Correios.Net;
using DAL;
using DTO;

namespace BLL
{
    public class CLIENTE_BLL
    {
        public string strConnection;
        CLIENTE_DAL DAO = null;

        public CLIENTE_BLL(string cn = "")
        {
            if (string.IsNullOrEmpty(cn))
                cn = SysBLL.strConexao;
            this.strConnection = cn;
            DAO = new CLIENTE_DAL(strConnection);
        }

        public int? Set_Cliente(CLIENTE_DTO DTO)
        {
            SysDAL.Grava_Historico(DTO, strConnection, SysBLL.UserLogin.NOME);
            return DAO.Set_Cliente(DTO);
        }

        public bool Update_Cliente(CLIENTE_DTO DTO)
        {
            SysDAL.Grava_Historico(DTO, strConnection, SysBLL.UserLogin.NOME);
            return DAO.Update_Cliente(DTO);
        }

        public bool Excluir(int id)
        {
            return DAO.Excluir(id);
        }
       

        public CLIENTE_DTO Selecione(int ID)
        {
            return DAO.Seleciona(ID);
        }

        private List<string> ValidarDados(CLIENTE_DTO DTO)
        {
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(DTO.NOME_COMPLETO))
                result.Add("NOME_COMPLETO");
            if (string.IsNullOrEmpty(DTO.DATA_NASCIMENTO))
                result.Add("NASCIMENTO");
            if (string.IsNullOrEmpty(DTO.BAIRRO))
                result.Add("BAIRRO");
            if (string.IsNullOrEmpty(DTO.CEP))
                result.Add("CEP");
            if (string.IsNullOrEmpty(DTO.CPF))
                result.Add("CPF");
            //if (string.IsNullOrEmpty(DTO.UF))
            //    result.Add("UF");
            if (string.IsNullOrEmpty(DTO.MUNICIPIO))
                result.Add("MUNICIPIO");
            //if (string.IsNullOrEmpty(DTO.CELULAR))
            //    result.Add("CELULAR");
            if (string.IsNullOrEmpty(DTO.RG))
                result.Add("RG");
            if (string.IsNullOrEmpty(DTO.LOGRADOURO))
                result.Add("LOGRADOURO");
            return result;
        }

        public Dictionary<string, string> LocalizarCEP(string CEP)
        {
            try
            {
                Dictionary<string, string> Retorno = new Dictionary<string, string>();
                Retorno["STATUS"] = "False";
                if (!string.IsNullOrWhiteSpace(CEP))
                {
                    Address endereco = SearchZip.GetAddress(CEP);
                    if (endereco.Zip != null)
                    {
                        Retorno["STATUS"] = "True";
                        Retorno["UF"] = endereco.State;
                        Retorno["CIDADE"] = endereco.City;
                        Retorno["BAIRRO"] = endereco.District;
                        Retorno["LOGRADOURO"] = endereco.Street;
                    }
                    else
                    {
                        Retorno["ERRO"] = "Cep não localizado...";
                    }
                }
                else
                {
                    Retorno["ERRO"] = "Informe um CEP válido";
                }
                return Retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, string> Localizar(string CEP)
        {
            try
            {
                Dictionary<string, string> Retorno = new Dictionary<string, string>();
                Retorno["STATUS"] = "False";

                DataSet ds = new DataSet();
                ds.ReadXml("https://viacep.com.br/ws/" + CEP.Replace("-", "").Trim() + "/xml/");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            Retorno.Add("UF", ds.Tables[0].Rows[0]["uf"].ToString().Trim());
                        }
                        catch
                        {
                            Retorno["ERRO"] = "Cep não encontrado!";
                            return Retorno;
                        }
                        Retorno.Add("LOGRADOURO", ds.Tables[0].Rows[0]["logradouro"].ToString().Trim());
                        Retorno.Add("COMPLEMENTO", ds.Tables[0].Rows[0]["complemento"].ToString().Trim());
                        Retorno.Add("BAIRRO", ds.Tables[0].Rows[0]["bairro"].ToString().Trim());
                        Retorno.Add("CIDADE", ds.Tables[0].Rows[0]["localidade"].ToString().Trim());
                        Retorno.Add("Uf", ds.Tables[0].Rows[0]["uf"].ToString().Trim());
                        Retorno["STATUS"] = "True";
                    }
                    else
                        Retorno["ERRO"] = "Cep não encontrado!";
                }
                else
                    Retorno["ERRO"] = "Erro no WebService!";
                return Retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
