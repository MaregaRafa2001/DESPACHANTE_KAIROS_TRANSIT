using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class FINANCEIRO_DTO : IDTO
    {
        public FINANCEIRO_DTO()
        {
            OPERACAO = SysDTO.Operacoes.Inclusao;
            this.NOME_TABELA = "FINANCEIRO";
            this.ID_CLASSE = this.GetHashCode();
        }
        public int? ID { get; set; }
        public string FORMA_PAGAMENTO { get; set; }
        public int PARCELAS { get; set; }
        public string CONSULTOR { get; set; }
        public string OBSERVACAO { get; set; }
        public int ID_CLIENTE { get; set; }
        public string INDICACAO { get; set; }
        public int ID_SERVICO { get; set; }
        public decimal VALOR { get; set; }
        public string UNIDADE { get; set; }
        public string RECEBIDO_POR { get; set; }

        public decimal? VALOR_OS { get; set; }
        public decimal? VALOR_BRUTO { get; set; }
        public decimal? VALOR_LIQUIDO { get; set; }
        public string LOCAL_OS { get; set; }
        public int ID_STATUS { get; set; }
        public int? ID_FASE { get; set; }

        public DateTime? DATA_ALTERACAO { get; set; }
        public DateTime? DATA_CRIACAO { get; set; }
        public string MOTOBOY_OS { get; set; }
        public string BANCO_OS { get; set; }
        public string NUMBOLCHE { get; set; }
        public DateTime? DATA { get; set; }
        public int DIA_VENCIMENTO { get; set; }

        private SERVICO_DTO S_DTO = new SERVICO_DTO();
        public SERVICO_DTO SERVICO
        {
            get { return S_DTO; }
            set { S_DTO = value; }
        }

        private List<BOLETO_CHEQUE_DTO> B_DTO = new List<BOLETO_CHEQUE_DTO>();
        public List<BOLETO_CHEQUE_DTO> BOLETO_CHEQUE
        {
            get { return B_DTO; }
            set { B_DTO = value; }
        }

        private STATUS_FINANCEIRO_DTO SF_DTO = new STATUS_FINANCEIRO_DTO();
        public STATUS_FINANCEIRO_DTO STATUS
        {
            get { return SF_DTO; }
            set { SF_DTO = value; }
        }

        private CLIENTE_DTO C_DTO = new CLIENTE_DTO();
        public CLIENTE_DTO CLIENTE
        {
            get { return C_DTO; }
            set { C_DTO = value; }
        }

        private List<ADMINISTRACAO_DTO> F_DTO = new List<ADMINISTRACAO_DTO>();
        public List<ADMINISTRACAO_DTO> ADMINISTRACAO
        {
            get { return F_DTO; }
            set { F_DTO = value; }
        }

        private List<JURIDICO_DTO> J_DTO = new List<JURIDICO_DTO>();
        public List<JURIDICO_DTO> JURIDICO
        {
            get { return J_DTO; }
            set { J_DTO = value; }
        }


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
