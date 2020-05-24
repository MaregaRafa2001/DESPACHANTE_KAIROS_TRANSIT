using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class JURIDICO_DTO
    {
        public JURIDICO_DTO()
        {
            OPERACAO = SysDTO.Operacoes.Inclusao;
            this.NOME_TABELA = "JURIDICO";
            this.ID_CLASSE = this.GetHashCode();
        }
        public int? ID { get; set; }
        public int ID_FINANCEIRO { get; set; }
        public int LAYOUT_TELA { get; set; }
        public DateTime? DATA { get; set; }
        public string FASE { get; set; }
        public string OBSERVACAO { get; set; }

        //FASE 1
        public DateTime? DataRecebimentoContrato { get; set; }
        public DateTime? DataClienteContatado { get; set; }
        public DateTime? DataLimiteDefesa { get; set; }
        public string Instancia { get; set; }
        public string SenhaDetran { get; set; }
        //FASE 2

        //FASE 3
        public DateTime? DataEntregaCliente { get; set; }
        public DateTime? DataEntregaAdvogado { get; set; }
        //FASE 4
        public string Bloqueio { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public DateTime? DataProtocolamento { get; set; }
        public bool Liminar { get; set; }
        public DateTime? DataExpedicao { get; set; }
        //FASE 5 
        public DateTime? DataEntregaAdvogadoInterno { get; set; }
        public string Status { get; set; }
        //FASE 6 
        public string Resultado { get; set; }
        public DateTime? DataSentencaProtocolada { get; set; }
        public DateTime? DataLiberacaoSentenca { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        //FASE 7

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
