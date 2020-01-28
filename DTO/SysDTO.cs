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
        SysDTO.Operacoes Operacao { get; set; }
        string Usuario { get; set; }
        DateTime? Ult_Atual { get; set; }
        int IdClasse { get; set; }
        string NomeTabela { get; set; }
        string NomeModulo { get; set; }
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
            this.Operacao = SysDTO.Operacoes.Inclusao;
            this.NomeTabela = "Asp_Sys_Historico";
            this.NomeModulo = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
        }

        public int Id { get; set; }
        public int Id_Registro { get; set; }
        public string Assunto { get; set; }
        public string NomeTabela { get; set; }
        public string Historico { get; set; }
        public string Tabela { get; set; }
        public string NomeModulo { get; set; }
        public SysDTO.Operacoes Operacao { get; set; }
        public int IdClasse { get; set; }
        public string Usuario { get; set; }
        public DateTime? Ult_Atual { get; set; }
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

    public static class ExtractIcon
    {
        // Constants that we need in the function call
        public const int SHGFI_ICON = 0x100;
        public const int SHGFI_SMALLICON = 0x1;
        public const int SHGFI_LARGEICON = 0x0;

        // This structure will contain information about the file
        public struct SHFILEINFO
        {
            // Handle to the icon representing the file
            public IntPtr hIcon;
            // Index of the icon within the image list
            public int iIcon;
            // Various attributes of the file
            public uint dwAttributes;
            // Path to the file
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szDisplayName;
            // File type
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        // The signature of SHGetFileInfo (located in Shell32.dll)
        [DllImport("Shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, uint uFlags);
    }

    
}
