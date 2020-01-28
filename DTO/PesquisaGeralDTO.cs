using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PesquisaGeralDTO
    {
        public string NomeDisplay { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int Tamanho { get; set; }

        public PesquisaGeralDTO()
        { }

        public PesquisaGeralDTO(string NomeDisplay, string Nome, string Tipo, int Tamanho)
        {
            this.NomeDisplay = NomeDisplay;
            this.Nome = Nome;
            this.Tamanho = Tamanho;
            this.Tipo = Tipo;
        }

        public override string ToString()
        {
            return NomeDisplay;
        }
    }

    public class PesquisaGeralFiltroDTO
    {
        public int Id { get; set; }
        public string App { get; set; }
        public int Img { get; set; }
        public string Opcao { get; set; }
        public string Nome { get; set; }
        public string Sql { get; set; }
        public string UserType { get; set; }
        public string SqlChanged { get; set; }
        public string Rep { get; set; }

        public PesquisaGeralFiltroDTO()
        {
            //Valores Default
            this.Id = 0;
            this.Nome = "";
            this.Opcao = "";
            this.Img = 3;
            this.Rep = "N";
        }

        public override string ToString()
        {
            return Nome;
        }
    }

    public class RelPesquisaGeralCamposDTO
    {
        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
        public string Campo3 { get; set; }
        public string Campo4 { get; set; }
        public string Campo5 { get; set; }
        public string Campo6 { get; set; }
        public string Campo7 { get; set; }
        public string Campo8 { get; set; }
        public string Campo9 { get; set; }
        public string Campo10 { get; set; }
        public string Campo11 { get; set; }
        public string Campo12 { get; set; }
        public string Campo13 { get; set; }
        public string Campo14 { get; set; }
        public string Campo15 { get; set; }
        public string Campo16 { get; set; }
        public string Campo17 { get; set; }
        public string Campo18 { get; set; }
        public string Campo19 { get; set; }
        public string Campo20 { get; set; }
        public string Campo21 { get; set; }
        public string Campo22 { get; set; }
        public string Campo23 { get; set; }
        public string Campo24 { get; set; }
        public string Campo25 { get; set; }
        public string Campo26 { get; set; }
        public string Campo27 { get; set; }
        public string Campo28 { get; set; }
        public string Campo29 { get; set; }
        public string Campo30 { get; set; }
        public string Campo31 { get; set; }
        public string Campo32 { get; set; }
        public string Campo33 { get; set; }
        public string Campo34 { get; set; }
        public string Campo35 { get; set; }
        public string Campo36 { get; set; }
        public string Campo37 { get; set; }
        public string Campo38 { get; set; }
        public string Campo39 { get; set; }
        public string Campo40 { get; set; }
        public string Campo41 { get; set; }
        public string Campo42 { get; set; }
        public string Campo43 { get; set; }
        public string Campo44 { get; set; }
        public string Campo45 { get; set; }
        public string Campo46 { get; set; }
        public string Campo47 { get; set; }
        public string Campo48 { get; set; }
        public string Campo49 { get; set; }
        public string Campo50 { get; set; }
        public string Campo51 { get; set; }
        public string Campo52 { get; set; }
        public string Campo53 { get; set; }
        public string Campo54 { get; set; }
        public string Campo55 { get; set; }
        public string Campo56 { get; set; }
        public string Campo57 { get; set; }
        public string Campo58 { get; set; }
        public string Campo59 { get; set; }
        public string Campo60 { get; set; }
    }

    public class RelPesquisaGeralDTO
    {
        public string Titulo { get; set; }
        public string SubTitulo1 { get; set; }
        public string SubTitulo2 { get; set; }
        public string Obs1 { get; set; }
        public string Obs2 { get; set; }
        public string Obs3 { get; set; }
        public int Count { get { return this.Campos.Count; } }
        public List<RelPesquisaGeralCamposDTO> Campos { get; set; }
    }

}
