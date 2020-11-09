using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BOLETO_CHEQUE_DTO : IDTO
    {
        public BOLETO_CHEQUE_DTO()
        {
            OPERACAO = SysDTO.Operacoes.Inclusao;
            this.NOME_TABELA = "BOLETO_CHEQUE";
            this.ID_CLASSE = this.GetHashCode();
            this.GeraComprovante = false;
        }

        public int ID { get; set; }
        public int? ID_FINANCEIRO { get; set; }
        public string NUMERO { get; set; }
        public int? PARCELA { get; set; }
        public int? ID_FORMA_PAGAMENTO { get; set; }
        public string FORMA_PAGAMENTO { get; set; }
        public bool? ATIVO { get; set; }
        public decimal? VALOR { get; set; }
        public DateTime? DATA_VENCTO { get; set; }
        public string STATUS_PAGAMENTO { get; set; }


        //CAMPOS PARA GERAR COMPROVANTE
        public bool GeraComprovante { get; set; }
        public string SERVICO { get; set; }

        public SysDTO.Operacoes OPERACAO { get; set; }
        public string USUARIO { get; set; }
        public DateTime? ULT_ATUAL { get; set; }
        public int ID_CLASSE { get; set; }
        public string NOME_TABELA { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
