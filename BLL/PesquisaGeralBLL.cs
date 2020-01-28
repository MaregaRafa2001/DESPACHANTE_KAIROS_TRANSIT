using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BLL
{
    public class PesquisaGeralBLL
    {
        string strConexao = "";

        public PesquisaGeralBLL()
        {
            this.strConexao = SysBLL.strConexao;
        }

        public DataTable Pesquisa(string Query, List<PesquisaGeralDTO> Campos = null)
        {
            try
            {
                DataTable dtt = (new PesquisaGeralDAL(this.strConexao)).Pesquisa(Query);
                string strOculta = "";

                //Lista de campos opcional
                if (Campos != null)
                {
                    Campos.Clear();
                }
                foreach (DataColumn coluna in dtt.Columns)
                {
                    if (Campos != null)
                    {
                        //Lista as propriedades dos campos ("_disable" não permite pesquisa)
                        if (coluna.ColumnName.ToLower().Contains("_disable") != true)
                        {
                            Campos.Add(new PesquisaGeralDTO()
                            {
                                NomeDisplay = coluna.ColumnName.ToUpper().Replace("_INVISIBLE", ""),
                                Nome = coluna.ColumnName,
                                Tamanho = coluna.MaxLength,
                                Tipo = coluna.DataType.ToString()
                            });
                        }
                    }

                    if (coluna.ColumnName.ToLower() == "id_disable")
                    {
                        throw new Exception("A coluna ID não pode conter a propriedade \"_disable\"!");
                    }

                    //listando as colunas ocultas que deverão ser removidas do datatable (caso exista)
                    if (coluna.ColumnName.ToLower().Contains("_invisible") == true && coluna.ColumnName.ToLower() != "id_invisible") //Permite pesquisa mas não lista (Com exceção do id que a vizualização deve ser tratada no evento DataSourceChanged do DataGridView)
                    {
                        strOculta += coluna.ColumnName + ";";
                    }
                    if (coluna.ColumnName.ToLower().Contains("_disable") == true)
                    {
                        coluna.ColumnName = coluna.ColumnName.Replace("_disable", "");
                    }
                }

                //removendo as colunas ocultas do datatable (caso exista)
                if (strOculta.Length > 0)
                {
                    foreach (string oc in strOculta.Split(';'))
                    {
                        if (oc.Length > 0)
                        {
                            dtt.Columns.Remove(oc);
                        }

                    }
                }

                return dtt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Pesquisa(string v, object listaCampos)
        {
            throw new NotImplementedException();
        }

        public PesquisaGeralFiltroDTO SelecionaFiltro(int Id)
        {
            try
            {
                return (new PesquisaGeralDAL(this.strConexao)).SelecionaFiltro(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Registrar(PesquisaGeralFiltroDTO FiltroDTO, bool NewFilter)
        {
            try
            {
                //Registrando os dados
                if (NewFilter == true)
                {
                    //Inclusao
                    new PesquisaGeralDAL(this.strConexao).Incluir(FiltroDTO);
                }
                else
                {
                    //Alteração
                    new PesquisaGeralDAL(this.strConexao).Alterar(FiltroDTO);
                }
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Exclui Registros
        public void Exclui(string Id, string Usuario)
        {
            try
            {
                //Excluindo o registro
                new PesquisaGeralDAL(this.strConexao).Excluir(int.Parse(Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
