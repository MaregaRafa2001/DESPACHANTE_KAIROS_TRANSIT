using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CONTRATO_DTO
    {
        public int? ID { get; set; }
        public int? ID_CONSULTOR { get; set; }
        public int? ID_CLIENTE { get; set; }
        public int? ID_SERVICO { get; set; }
        public DateTime? DATA_CONTRATO { get; set; }
        public int FORMA_PAG { get; set; }
        public int QTD_PARCELAS { get; set; }
        public string N_BOLETO_CHEQUE { get; set; }
        public string OBS { get; set; }
        public string INDICACAO { get; set; }

    }
}
