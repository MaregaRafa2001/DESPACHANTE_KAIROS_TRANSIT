using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LOGIN_DTO : IDTO
    {
        public LOGIN_DTO()
        {
            OPERACAO = SysDTO.Operacoes.Inclusao;
            this.NOME_TABELA = "LOGIN";
            this.ID_CLASSE = this.GetHashCode();
        }

        public int ID { get; set; }
        public string NOME { get; set; }
        public string LOGIN { get; set; }
        public string PASS { get; set; }
        public int ID_PERFIL { get; set; }

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
