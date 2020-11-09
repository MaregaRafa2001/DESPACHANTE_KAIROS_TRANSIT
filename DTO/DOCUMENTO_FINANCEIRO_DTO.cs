using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DOCUMENTO_FINANCEIRO_DTO : IDTO
    {
        public DOCUMENTO_FINANCEIRO_DTO()
        {
            OPERACAO = SysDTO.Operacoes.Inclusao;
            this.NOME_TABELA = "DOCUMENTO_FINANCEIRO";
            this.ID_CLASSE = this.GetHashCode();
        }

        public int ID { get; set; }
        public int? ID_DOCUMENTO { get; set; }
        public int? ID_FINANCEIRO { get; set; }
        public DateTime? DATA_ENTREGA { get; set; }
        public DateTime? DATA_VENCIMENTO { get; set; }

        //ADICIONAIS
        public string DOCUMENTO { get; set; }

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
