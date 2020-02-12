using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LOGIN_DTO
    {
        public LOGIN_DTO()
        {
            Operacao = SysDTO.Operacoes.Inclusao;
            LOG_SISTEMA.TABELA = "LOGIN";
        }

        public int ID { get; set; }
        public string NOME { get; set; }
        public string LOGIN { get; set; }
        public string PASS { get; set; }
        public int ID_PERFIL { get; set; }
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
