using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;
using System.Reflection;

namespace DAL
{
    public class SysDAL
    {
        //Uma lista que será populada com um objeto Sys_DicionarioDTO que contém um dicionário das colunas da tabela na classe DTO.
        public static List<Sys_DicionarioDTO> ListaSysDicionario = new List<Sys_DicionarioDTO>();
        /// <summary>
        /// Método para gravar o histórico de alterações realizadas pelos usuários do sistema nas tabelas do banco de dados.
        /// </summary>
        /// <param name="ClasseDTO">Uma classe DTO que representa a tabela que foi alterada.</param>
        /// <param name="Conexao">Uma string de conexão com o bando de dados</param>
        /// <returns>Retorna true caso o histórico seja gravado com sucesso,e false caso ocorra algum problema durante a gravação do histórico.</returns>
        /// <remarks>Este método só aceita classes que implementaram a Interface IDTO.</remarks>
        public static bool Grava_Historico(IDTO ClasseDTO, string Conexao, string Usuario, string CamposAdcionais = null, bool Backup = false, SqlCommand scm = null)
        {
            try
            {
                //String que será populada com os campos e valores alterados.
                StringBuilder sbHistorico = new StringBuilder();

                bool GravaCampo = false;
                bool Alterou_Filha = false;

                //Adciona no Histórico campos adcionais se houver algum
                if (Backup == false & CamposAdcionais != null && CamposAdcionais.Trim() != "") { sbHistorico.Append(CamposAdcionais + "|"); }

                Object backupDTO = null;

                if (SysDTO.BackupsDTO.Exists(s => s.IdClasse == ClasseDTO.IdClasse & s.NomeModulo == ClasseDTO.NomeModulo) == true)
                {
                    //Recupera a classe DTO que foi copiada,essa classe contém os dados originais da tabela antes de serem alterados.
                    backupDTO = SysDTO.BackupsDTO.Single(s => s.IdClasse == ClasseDTO.IdClasse & s.NomeModulo == ClasseDTO.NomeModulo);
                }
                else
                {
                    return false;
                }

                SysDTO.BackupsDTO.Remove((IDTO)backupDTO);

                //Cria um objeto HistoricoDTO que será populado com os dados da classe DTO copiada.
                HistoricoDTO dtoHistorico = new HistoricoDTO();

                dtoHistorico.Tabela = ClasseDTO.NomeTabela;

                //Lista o dicionário de campos,se já existir na lista não faz consulta no banco de dados.
                Listar_Dicionario(Conexao, ClasseDTO.NomeTabela);

                string strUsuarioAnterior = "";
                DateTime dtDataAnterior = DateTime.Today;

                //Esta variável será usada para guardar o número de campos da tabela que foram alterados pelo Usuário do Sistema.
                int intContagem = 0;

                //Pecorre todas as propriedade da Classe DTO para fazer verificação e comparação entre os dados da classe copiada e a classe atual.
                foreach (PropertyInfo propinfo in backupDTO.GetType().GetProperties())
                {
                    //Recupera o Id referente ao campo chave primária definido na tabela.
                    if (propinfo.Name.ToUpper() == "ID")
                    {
                        dtoHistorico.Id_Registro = Convert.ToInt32(propinfo.GetValue(backupDTO, null));
                    }

                    //Data da última alteração realizada na tabela antes de ser alterada.
                    if (propinfo.Name.ToUpper() == "ULT_ATUAL")
                    {
                        dtDataAnterior = Convert.ToDateTime(propinfo.GetValue(backupDTO, null));
                    }
                    //Recupera o Usuário anterior e o Usuário Atual que alteraram dados na tabela.
                    if (propinfo.Name.ToUpper() == "USUARIO")
                    {

                        dtoHistorico.Usuario = Usuario;
                        //Usuário Anterior.
                        strUsuarioAnterior = propinfo.GetValue(backupDTO, null).ToString().Trim();
                    }

                    //***********************
                    //Faz histórico das classes filhas dentro de uma lista.
                    try
                    {
                        if (propinfo.PropertyType.GetGenericArguments().Count() > 0)
                        {
                            if (propinfo.PropertyType.GetGenericArguments()[0].GetInterfaces().ToList().Exists(s => s.Name == "IDTO"))
                            {
                                System.Collections.IList lista = (System.Collections.IList)propinfo.GetValue(ClasseDTO, null);

                                foreach (object obj in lista)
                                {
                                    PropertyInfo[] lista_prop = obj.GetType().GetProperties();
                                    string strAdcional = "";

                                    foreach (PropertyInfo prop in lista_prop)
                                    {
                                        if (prop.GetCustomAttributes(typeof(Historico_AtributosDTO), true).Length > 0)
                                        {
                                            strAdcional += prop.Name + "=" + (prop.GetValue(obj, null) == null ? "[Nulo]" : prop.GetValue(obj, null).ToString()) + "|";
                                        }
                                    }

                                    if (strAdcional.Length > 0)
                                    {
                                        Grava_Historico((IDTO)obj, Conexao, strAdcional.Substring(0, strAdcional.Length - 1));
                                    }
                                    else
                                    {
                                        Grava_Historico((IDTO)obj, Conexao, Usuario);
                                    }
                                    if (((IDTO)obj).Operacao != SysDTO.Operacoes.Leitura)
                                    {
                                        Alterou_Filha = true;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    //***********************

                    //Recupera o valor anterior do campo na classe DTO que foi copiada.
                    string strValorAnterior = (propinfo.GetValue(backupDTO, null) == null ? "[Nulo]" : propinfo.GetValue(backupDTO, null).ToString());
                    //Recupera o valor na classe DTO atual.
                    string strValorAtual = (propinfo.GetValue(ClasseDTO, null) == null ? "[Nulo]" : propinfo.GetValue(ClasseDTO, null).ToString());

                    if (strValorAnterior.Trim() == "") { strValorAnterior = "[vazio]"; }
                    if (strValorAtual.Trim() == "") { strValorAtual = "[vazio]"; }

                    //Verifica se há alteração no campo
                    if (propinfo.GetValue(backupDTO, null) != null && (propinfo.GetValue(backupDTO, null).GetType() == typeof(decimal) | propinfo.GetValue(backupDTO, null).GetType() == typeof(double)))
                    {
                        decimal? valor1 = Convert.ToDecimal((strValorAnterior == "[Nulo]" ? null : strValorAnterior));
                        decimal? valor2 = Convert.ToDecimal((strValorAtual == "[Nulo]" ? null : strValorAtual));

                        if (valor1 != valor2)
                        {
                            GravaCampo = true;
                        }
                        else
                        {
                            GravaCampo = false;
                        }
                    }
                    else
                    {
                        if (strValorAnterior != strValorAtual)
                        {
                            GravaCampo = true;
                        }
                        else
                        {
                            GravaCampo = false;
                        }
                    }

                    //Se Backup = true irá fazer histórico de todos os campos exceto os que foram marcados com o atributo Historico_AtributosDTO.Gravavel = false
                    if (Backup == true) { GravaCampo = true; }

                    //Verifica se o campo foi marcado com algum atributo personalizado
                    object[] atributos = propinfo.GetCustomAttributes(typeof(Historico_AtributosDTO), true);

                    foreach (Historico_AtributosDTO atrib in atributos)
                    {
                        //Verifica se o campo foi marcado como não gravável.
                        if (atrib.Atributo == SysDTO.Enum_Historico_Atributos.Gravavel)
                        {
                            GravaCampo = (bool)atrib.Valor;
                        }
                        if (atrib.Atributo == SysDTO.Enum_Historico_Atributos.Imagem)
                        {
                            GravaCampo = false;
                        }
                    }

                    //Recupera o valor anterior se o valor atual e o valor anterior forem diferentes,ou seja,se houve alteração nos dados.
                    if (GravaCampo == true)
                    {
                        //Recupera o dicionário do campo na lista de dicionários: ListaSysDicionario.                            
                        //Linq to Object: Usado para localizar o dicionário do campo dentro da lista: ListaSysDicionario.
                        //Se existir dicionário para o campo será gravado a descrição da coluna,caso contrário será usado o própio nome da propriedade na Classe DTO.
                        //Os campos da classe DTO: OPERACAO,ULT_ATUAL e USUARIO não serão gravados no histórico.
                        if (propinfo.Name.ToUpper() != "OPERACAO" & propinfo.Name.ToUpper() != "ULT_ATUAL" & propinfo.Name.ToUpper() != "USUARIO")
                        {
                            if (ListaSysDicionario.Exists(s => s.Nome_Tabela == ClasseDTO.NomeTabela & s.Nome_Coluna.ToUpper() == propinfo.Name.ToUpper()))
                            {
                                //Recupera a descrição da coluna no dicionário.
                                Sys_DicionarioDTO sysdicionarioDTO = ListaSysDicionario.Single(s => s.Nome_Tabela == ClasseDTO.NomeTabela & s.Nome_Coluna.ToUpper() == propinfo.Name.ToUpper());
                                //Adciona na StringBuilder a descrição da coluna e o valor anterior do campo alterado.
                                sbHistorico.Append(sysdicionarioDTO.Descricao_Coluna + " = " + strValorAnterior.Replace("|", ":") + "|");
                            }
                            else
                            {
                                //Adciona na StringBuilder o nome da propriedade da Classe DTO e o valor anterior do campo alterado.
                                sbHistorico.Append(propinfo.Name + "=" + strValorAnterior.Replace("|", ":") + "|");
                            }

                            //Adiciona +1 na contagem de campos que foram alterados.
                            intContagem++;
                        }
                    }
                }

                //Se não houve alteração nos dados
                if (intContagem == 0)
                {
                    dtoHistorico.Assunto = "Dados registrados sem alteração.";

                    //Não grava histórico das classes filhas que não foram alteradas
                    if (ClasseDTO.Operacao == SysDTO.Operacoes.Leitura)
                    {
                        return false;
                    }
                    //Se não alterou filha não faz nada
                    if (Alterou_Filha == true)
                    {
                        return false;
                    }
                }
                else //Se houve alteração nos dados informa o número de campos que foram alterados
                {
                    if (Backup == true)
                    {
                        dtoHistorico.Assunto = CamposAdcionais;
                    }
                    else
                    {
                        if (intContagem == 1)
                        {
                            dtoHistorico.Assunto = intContagem + " registro alterado.";
                        }
                        else
                        {
                            dtoHistorico.Assunto = intContagem + " registros alterados.";
                        }
                    }
                }

                //Grava o usuário e a data anterior às alterações.
                sbHistorico.Append("Usuario Anterior=" + strUsuarioAnterior + "|");
                sbHistorico.Append("Data Anterior=" + dtDataAnterior.ToString("dd/MM/yyyy HH:mm:ss") + "|");

                //Seta os campos que foram alterados.
                dtoHistorico.Historico = sbHistorico.ToString();

                //Grava no banco de dados o histórico dos campos que foram alterados.
                using (SqlConnection scn = new SqlConnection(Conexao))
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [Asp_Sys_Historico]([ID_REGISTRO],[ASSUNTO],[HISTORICO],[USUARIO],[DATAHORA],[REP],[TABELA],[MODULO])");
                        sb.Append(" VALUES (@ID_REGISTRO,@ASSUNTO,@HISTORICO,@USUARIO,GETDATE(), @REP, @TABELA, @MODULO);SELECT SCOPE_IDENTITY();");

                        //No caso de um comando não fazer parte de uma begin transaction abre uma nova conexão
                        if (scm == null)
                        {
                            scm = new SqlCommand(sb.ToString(), scn);
                            scn.Open();
                        }

                        scm.Parameters.AddWithValue("@ID_REGISTRO", dtoHistorico.Id_Registro);
                        scm.Parameters.AddWithValue("@ASSUNTO", dtoHistorico.Assunto);
                        scm.Parameters.AddWithValue("@HISTORICO", dtoHistorico.Historico);
                        scm.Parameters.AddWithValue("@USUARIO", dtoHistorico.Usuario);
                        scm.Parameters.AddWithValue("@REP", "N");
                        scm.Parameters.AddWithValue("@TABELA", dtoHistorico.Tabela);
                        scm.Parameters.AddWithValue("@MODULO", dtoHistorico.NomeModulo);

                        dtoHistorico.Id = Convert.ToInt32(scm.ExecuteScalar());
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        scn.Close();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public static void GuardarDTO(IDTO ClasseDTO)
        {
            try
            {
                //Adciona no backup de classes DTO a nova classe criada.
                SysDTO.BackupsDTO.Add(ClasseDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Listar_Dicionario(string Conexao, string Tabela)
        {
            try
            {
                if (SysDAL.ListaSysDicionario.Exists(s => s.Nome_Tabela == Tabela))
                {
                    return;
                }
                else
                {
                    SqlDataReader dtr = null;
                    //Recupera as informações do dicionário das colunas referente a tabela da classe DTO,popula o objeto ListaSysDicionario e o adciona na lista ListaSysDicionario.
                    using (SqlConnection scn = new SqlConnection(Conexao))
                    {
                        try
                        {
                            scn.Open();
                            string sql = "SELECT id, nome_tabela, nome_coluna, descricao_coluna FROM Asp_Sys_Dicionario WHERE  (nome_tabela = '" + Tabela + "')";
                            SqlCommand scm = new SqlCommand(sql, scn);
                            dtr = scm.ExecuteReader();

                            while (dtr.Read())
                            {
                                Sys_DicionarioDTO sysdicionarioDTO = new Sys_DicionarioDTO();
                                sysdicionarioDTO.Descricao_Coluna = dtr["Descricao_Coluna"].ToString();
                                sysdicionarioDTO.Nome_Coluna = dtr["Nome_Coluna"].ToString();
                                sysdicionarioDTO.Nome_Tabela = dtr["Nome_Tabela"].ToString();
                                sysdicionarioDTO.Id = Convert.ToInt32(dtr["id"]);

                                SysDAL.ListaSysDicionario.Add(sysdicionarioDTO);
                            }

                        }
                        catch (SqlException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            if (dtr != null) { dtr.Close(); }
                            scn.Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}