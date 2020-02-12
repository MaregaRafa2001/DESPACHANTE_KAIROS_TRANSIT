using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class STATUS_FINANCEIRO_DTO
    {
        public STATUS_FINANCEIRO_DTO()
        {
            LOG_SISTEMA.TABELA = "STATUS_FINANCEIRO";
        }
        public int ID { get; set; }
        public string DESCRICAO { get; set; }
        public string COR { get; set; }

        //LOG DO SISTEMA
        private LOG_SISTEMA_DTO L_DTO = new LOG_SISTEMA_DTO();
        public LOG_SISTEMA_DTO LOG_SISTEMA
        {
            get { return L_DTO; }
            set { L_DTO = value; }
        }
    }
}