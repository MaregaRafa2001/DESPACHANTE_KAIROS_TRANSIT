using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SysDTO
    {

        public enum Enum_Historico_Atributos
        {
            //Usada para marcar os campos que não serão gravados no histórico
            Gravavel,
            //Usada para marcar os campos que forem do tipo imagem
            Imagem,
            //Usado para marcar os campos que são Chave Estrangeira nas tabelas filhas
            Chave_Estrangeira
        }

        public enum Operacoes
        {
            Leitura,
            Inclusao,
            Alteracao,
            Exclusao
        }

        //Uma lista estática que será usada para gravar uma copia dos dados de uma classe DTO.
        //Somente classes que implementam a interface IDTO serão aceitas.
        //Só pode ser guardada uma única classe DTO do mesmo objeto,a chave definida é o nome do Módulo em que a classe foi criada e o Id(Código Hash) da classe.
        public static List<IDTO> BackupsDTO = new List<IDTO>();
    }

    public interface IDTO : ICloneable
    {
        SysDTO.Operacoes OPERACAO { get; set; }
        string USUARIO { get; set; }
        DateTime? ULT_ATUAL { get; set; }
        int ID_CLASSE { get; set; }
        string NOME_TABELA { get; set; }
    }


    public class CustomException : Exception
    {
        public string Value { get; set; }
        public string Title { get; set; }
        public CustomException(string Message, string Value, string Title = "")
            : base(Message)
        {
            this.Value = Value;
            this.Title = Title;
        }
    }

    public class InfoModuloDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Produto { get; set; }
        public string Modulo { get; set; }
        public string Versao { get; set; }
        public string Copyright { get; set; }
        public string Company { get; set; }
        public string Data { get; set; }
    }

    public class ComboItemDTO
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return this.Text; ;
        }
    }
    public class HistoricoDTO : IDTO
    {
        public HistoricoDTO()
        {
            this.OPERACAO = SysDTO.Operacoes.Inclusao;
            this.NOME_TABELA = "LOG_SISTEMA";
        }

        public int ID { get; set; }
        public int ID_REGISTRO { get; set; }
        public string ASSUNTO { get; set; }
        public string NOME_TABELA { get; set; }
        public string HISTORICO { get; set; }
        public string TABELA { get; set; }
        public SysDTO.Operacoes OPERACAO { get; set; }
        public int ID_CLASSE { get; set; }
        public string USUARIO { get; set; }
        public DateTime? ULT_ATUAL { get; set; }
        public string Rep { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }

    public class Sys_DicionarioDTO
    {
        public int Id { get; set; }
        public string Nome_Tabela { get; set; }
        public string Nome_Coluna { get; set; }
        public string Descricao_Coluna { get; set; }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class Historico_AtributosDTO : System.Attribute
    {
        public SysDTO.Enum_Historico_Atributos Atributo;
        public object Valor;

        public Historico_AtributosDTO(SysDTO.Enum_Historico_Atributos Atributo, object Valor)
        {
            this.Atributo = Atributo;
            this.Valor = Valor;
        }
    }

    public enum Operacoes
    {
        Inclusao,
        Alteracao,
        Exclusao,
        Leitura,
        ReInclusao
    }

    public enum Campos
    {
        TextBox,
        MaskedBox,
        ComboBox,
        NumericUpDown,
    }

    public enum TipoCampo
    {
        SemFormatacao,
        DateTime,
        CPF,
        CEP,
        Int,
    }
}
