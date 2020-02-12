using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LOG_SISTEMA_DTO
    {
        public LOG_SISTEMA_DTO()
        {
        }

        public int ID { get; set; }
        public string TABELA { get; set; }
        public string TELA { get; set; }
        public string OPERACAO { get; set; }
        public string ID_REGISTRO { get; set; }
        public string ITENS_ALTERADOS { get; set; }
    }
}
