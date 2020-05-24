using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ADMINISTRACAO_DTO
    {
        public ADMINISTRACAO_DTO()
        {
            OPERACAO = SysDTO.Operacoes.Inclusao;
        }

        public int? ID { get; set; }
        public int LAYOUT_TELA { get; set; }
        public int ID_FINANCEIRO { get; set; }
        public DateTime? DATA { get; set; }
        public string FASE { get; set; }
        public string OBSERVACAO { get; set; }

        //LAYOUT TELA 1
        public DateTime? DATA_RECEBIMENTO_CONTRATO { get; set; }

        //LAYOUT TELA 3
        public DateTime? DATA_ENTREGA_DOCUMENTO { get; set; }
        public DateTime? DATA_VENCIMENTO_DOCUMENTO { get; set; }

        //LAYOUT TELA 4
        public DateTime? DATA_MONTAGEM_PROCESSO { get; set; }

        //LAYOUT TELA 5
        public DateTime? DATA_IDA_DETRAN { get; set; }
        public DateTime? DATA_RETORNO_DETRAN { get; set; }
        public string PROCURADOR { get; set; }
        public int? MESES_DETRAN { get; set; }
        public DateTime? DATA_INICIO { get; set; }
        public DateTime? DATA_TERMINO { get; set; }

        //LAYOUT TELA 6
        public DateTime? DATA_FECHAMENTO_CURSO { get; set; }
        public bool? RECEBIMENTO_AUTO { get; set; }
        public bool? CURSO_FORA { get; set; }

        //LAYOUT TELA 7
        public DateTime? DATA_DIGITAL_1 { get; set; }
        public DateTime? DATA_DIGITAL_2 { get; set; }
        public DateTime? DATA_RECEBIMENTO_CERTIFICADO { get; set; }
        public string AUTO_ESCOLA { get; set; }

        //LAYOUT TELA 8
        public DateTime? DATA_FINALIZACAO { get; set; }
        public DateTime? DATA_BAIXA_DE_PONTOS { get; set; }

        //LAYOUT TELA 9
        public DateTime? DATA_AGENDAMENTO { get; set; }

        //LAYOUT TELA 10
        //Layout 10 não utiliza nenhum campo

        //LAYOUT TELA 11
        public DateTime? DATA_AGENDAMENTO_TEORICODETRAN { get; set; }

        //LAYOUT TELA 12
        //public DateTime? DATA_AGENDAMENTO { get; set; } É Utilizado o mesmo campo da fase 9 para ocupar menos espaço na memória
        public DateTime? DATA_CATEGORIA_1 { get; set; }
        public DateTime? DATA_CATEGORIA_2 { get; set; }

        //LAYOUT TELA 13
        public DateTime? DATA_EMISSAO { get; set; }
        public DateTime? DATA_ENTREGA { get; set; }
        public string RETIRADO_POR { get; set; }

        //EXTRAS
        public SysDTO.Operacoes OPERACAO { get; set; }
    }
}
