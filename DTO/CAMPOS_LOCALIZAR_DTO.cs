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
            Operacao = SysDTO.Operacoes.Inclusao;
            LOG_SISTEMA.TABELA = "CAMPOS_LOCALIZAR";
        }

        public int ID { get; set; }
        public string TELA { get; set; }
        public string DISPLAY { get; set; }
        public string VALUE { get; set; }
        public string TIPO { get; set; }

        public SysDTO.Operacoes Operacao { get; set; }

        //LOG DO SISTEMA
        private LOG_SISTEMA_DTO L_DTO = new LOG_SISTEMA_DTO();
        public LOG_SISTEMA_DTO LOG_SISTEMA
        {
            get { return L_DTO; }
            set { L_DTO = value; }
        }

    }
}
