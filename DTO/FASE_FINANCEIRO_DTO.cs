using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FASE_FINANCEIRO_DTO
    {
        public FASE_FINANCEIRO_DTO()
        {
            OPERACAO = SysDTO.Operacoes.Inclusao;
        }

        public int? ID { get; set; }
        public int ID_FINANCEIRO { get; set; }
        public DateTime? DATA { get; set; }
        public string FASE { get; set; }
        public string OBSERVACAO { get; set; }

        //FASE 1
        public DateTime? DATA_RECEBIMENTO_CONTRATO { get; set; }
        //FASE 3
        public DateTime? DATA_ENTREGA_DOCUMENTO { get; set; }
        public DateTime? DATA_VENCIMENTO_DOCUMENTO { get; set; }
        //FASE 4
        public DateTime? DATA_MONTAGEM_PROCESSO { get; set; }
        //FASE 5
        public DateTime? DATA_IDA_DETRAN { get; set; }
        public DateTime? DATA_RETORNO_DETRAN { get; set; }
        public string PROCURADOR { get; set; }
        public string PENALIDADE { get; set; }
        //FASE 6
        public DateTime? DATA_FECHAMENTO_CURSO { get; set; }
        public bool? RECEBIMENTO_AUTO { get; set; }
        public bool? CURSO_FORA { get; set; }
        //FASE 7
        public DateTime? DATA_DIGITAL_1 { get; set; }
        public DateTime? DATA_DIGITAL_2 { get; set; }
        public DateTime? DATA_RECEBIMENTO_CERTIFICADO { get; set; }

        //EXTRAS
        public SysDTO.Operacoes OPERACAO { get; set; }
    }
}
