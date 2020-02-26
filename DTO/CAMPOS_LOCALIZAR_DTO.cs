using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CAMPOS_LOCALIZAR_DTO
    {
        public CAMPOS_LOCALIZAR_DTO()
        {
            OPERACAO = SysDTO.Operacoes.Inclusao;
        }

        public int ID { get; set; }
        public string TELA { get; set; }
        public string DISPLAY { get; set; }
        public string VALUE { get; set; }
        public string TIPO { get; set; }

        public SysDTO.Operacoes OPERACAO { get; set; }
    }
}
