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
            Operacao = SysDTO.Operacoes.Inclusao;
        }

        public int? ID { get; set; }
        public int ID_FINANCEIRO { get; set; }
        public DateTime? DATA { get; set; }
        public string FASE { get; set; }
        public string OBSERVACAO { get; set; }

        public SysDTO.Operacoes Operacao { get; set; }
    }
}
