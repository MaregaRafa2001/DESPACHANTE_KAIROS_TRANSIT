using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BOLETO_CHEQUE_DTO
    {
        public BOLETO_CHEQUE_DTO()
        {
            Operacao = SysDTO.Operacoes.Inclusao;
        }

        public int ID { get; set; }
        public int? ID_FINANCEIRO { get; set; }
        public string NUMERO { get; set; }
        public int? PARCELA { get; set; }
        public DateTime? DATA_VENCTO { get; set; }
        public string FORMA_PAGAMENTO { get; set; }
        public int? STATUS_PAGAMENTO { get; set; }
        public bool? ATIVO { get; set; }
        public SysDTO.Operacoes Operacao { get; set; }

    }
}
