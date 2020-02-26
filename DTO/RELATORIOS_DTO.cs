using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RELATORIOS_DTO : IDTO
    {
        public RELATORIOS_DTO()
        {
            OPERACAO = SysDTO.Operacoes.Inclusao;
            this.NOME_TABELA = "RELATORIOS";
            this.ID_CLASSE = this.GetHashCode();
        }

        public int ID { get; set; }
        public string NOME { get; set; }
        public string HTML { get; set; }
        public string LISTAHTML1 { get; set; }
        public string LISTAHTML2 { get; set; }
        public string QUERY { get; set; }
        public string SqlChanged { get; set; }
        public bool GERARHTML { get; set; }
        public string COLUNAS_GROUP { get; set; }

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
