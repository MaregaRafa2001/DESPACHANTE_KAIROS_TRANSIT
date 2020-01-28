using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RELATORIOS_DTO
    {
        public RELATORIOS_DTO()
        {
            Operacao = SysDTO.Operacoes.Inclusao;
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

        public SysDTO.Operacoes Operacao { get; set; }

    }
}
