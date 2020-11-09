using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FORMA_PAGAMENTO_DTO : IDTO
    {
        public FORMA_PAGAMENTO_DTO()
        {
            OPERACAO = SysDTO.Operacoes.Inclusao;
            this.NOME_TABELA = "FORMA_PAGAMENTO";
            this.ID_CLASSE = this.GetHashCode();
        }
        public int? ID { get; set; }
        public string DESCRICAO { get; set; }
        public bool GERANUMERO { get; set; }


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
