using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GRUPO_ACESSO_DTO
    {
        public GRUPO_ACESSO_DTO()
        {
            this.OPERACAO = SysDTO.Operacoes.Inclusao;
            this.NOME_TABELA = "GRUPO_ACESSO";
            this.ID_CLASSE = this.GetHashCode();
        }
        public int ID { get; set; }
        public int ID_PERFIL { get; set; }
        public int ID_SYS_MENU { get; set; }

        List<SYS_MENU_DTO> SYS_MENU_ = new List<SYS_MENU_DTO>();
        public List<SYS_MENU_DTO> SYS_MENU
        {
            get { return SYS_MENU_; }
            set { SYS_MENU_ = value; }
        }

        public SysDTO.Operacoes OPERACAO { get; set; }
        public string USUARIO { get; set; }
        public DateTime? ULT_ATUAL { get; set; }
        public int ID_CLASSE { get; set; }
        public string NOME_TABELA { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
