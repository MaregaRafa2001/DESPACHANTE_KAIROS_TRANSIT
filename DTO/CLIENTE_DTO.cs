using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CLIENTE_DTO
    {
        public CLIENTE_DTO()
        {
            Operacao = SysDTO.Operacoes.Inclusao;
            LOG_SISTEMA.TABELA = "CLIENTE";
        }

        public int? ID { get; set; }
        public string NOME_COMPLETO { get; set; }
        public string DATA_NASCIMENTO { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public DateTime CNH_DATA_VENCIMENTO { get; set; }
        public int CNH_PONTUACAO { get; set; }
        public string CNH_UF { get; set; }

        //ENDEREÇO
        public string LOGRADOURO { get; set; }
        public string CEP { get; set; }
        public string COMPLEMENTO { get; set; }
        public string BAIRRO { get; set; }
        public string UF { get; set; }
        public string MUNICIPIO { get; set; }
        public string NUMERO_RES { get; set; }
        //CONTATO
        public string EMAIL { get; set; }
        public string EMAIL2 { get; set; }
        public string TELEFONE { get; set; }
        public string CELULAR { get; set; }
        public string FONE_LIVRE { get; set; }
        public string OBSERVACAO { get; set; }
        public bool PORTARIA { get; set; }

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
