using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FORMA_PAGAMENTO_DTO
    {
        public FORMA_PAGAMENTO_DTO()
        {
            LOG_SISTEMA.TABELA = "FORMA_PAGAMENTO";
        }
        public int? ID { get; set; }
        public string DESCRICAO { get; set; }
        public bool GERANUMERO { get; set; }


        //LOG DO SISTEMA
        private LOG_SISTEMA_DTO L_DTO = new LOG_SISTEMA_DTO();
        public LOG_SISTEMA_DTO LOG_SISTEMA
        {
            get { return L_DTO; }
            set { L_DTO = value; }
        }
    }
}
