using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_UI
{
    public class FormFuncoes
    {
        public static string SomenteNumeros(string Texto)
        {
            //Usando Expressões Regulares
            Regex re = new Regex("[0-9]");
            StringBuilder s = new StringBuilder();
            foreach (Match m in re.Matches(Texto))
            {
                s.Append(m.Value);
            }

            return s.ToString();
        }

        public static List<ComboItemDTO> ListaEstados()
        {
            List<ComboItemDTO> retorno = new List<ComboItemDTO>();
            retorno.Add(new ComboItemDTO() { Text = "AC", Value = "AC" });
            retorno.Add(new ComboItemDTO() { Text = "AL", Value = "AL" });
            retorno.Add(new ComboItemDTO() { Text = "AP", Value = "AP" });
            retorno.Add(new ComboItemDTO() { Text = "AM", Value = "AM" });
            retorno.Add(new ComboItemDTO() { Text = "BA", Value = "BA" });
            retorno.Add(new ComboItemDTO() { Text = "CE", Value = "CE" });
            retorno.Add(new ComboItemDTO() { Text = "DF", Value = "DF" });
            retorno.Add(new ComboItemDTO() { Text = "ES", Value = "ES" });
            retorno.Add(new ComboItemDTO() { Text = "GO", Value = "GO" });
            retorno.Add(new ComboItemDTO() { Text = "MA", Value = "MA" });
            retorno.Add(new ComboItemDTO() { Text = "MT", Value = "MT" });
            retorno.Add(new ComboItemDTO() { Text = "MS", Value = "MS" });
            retorno.Add(new ComboItemDTO() { Text = "MG", Value = "MG" });
            retorno.Add(new ComboItemDTO() { Text = "PA", Value = "PA" });
            retorno.Add(new ComboItemDTO() { Text = "PB", Value = "PB" });
            retorno.Add(new ComboItemDTO() { Text = "PR", Value = "PR" });
            retorno.Add(new ComboItemDTO() { Text = "PE", Value = "PE" });
            retorno.Add(new ComboItemDTO() { Text = "PI", Value = "PI" });
            retorno.Add(new ComboItemDTO() { Text = "RJ", Value = "RJ" });
            retorno.Add(new ComboItemDTO() { Text = "RN", Value = "RN" });
            retorno.Add(new ComboItemDTO() { Text = "RS", Value = "RS" });
            retorno.Add(new ComboItemDTO() { Text = "RO", Value = "RO" });
            retorno.Add(new ComboItemDTO() { Text = "RR", Value = "RR" });
            retorno.Add(new ComboItemDTO() { Text = "SC", Value = "SC" });
            retorno.Add(new ComboItemDTO() { Text = "SP", Value = "SP" });
            retorno.Add(new ComboItemDTO() { Text = "SE", Value = "SE" });
            retorno.Add(new ComboItemDTO() { Text = "TO", Value = "TO" });
            return retorno;
        }

        public static string PopularMskData(DateTime? data)
        {
            try
            {
                return (data == null ? "" : data.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DateTime? GetMskDate(MaskedTextBox txt)
        {
            try
            {
                if (FormFuncoes.IsDate(txt.Text))
                {
                    return Convert.ToDateTime(txt.Text);
                }
                return (DateTime?)null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsDate(string date)
        {
            try
            {
                DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNumber(string number)
        {
            try
            {
                Int64.Parse(number);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GerarComprovante(List<BOLETO_CHEQUE_DTO> Lista_Boleto_Cheque)
        {
            try
            {

                if (!Lista_Boleto_Cheque.Exists(boleto_cheque => boleto_cheque.GeraComprovante))
                    return false;


                using (StreamWriter writer = new StreamWriter("recibo.html", false))
                {
                    foreach (BOLETO_CHEQUE_DTO DTO in Lista_Boleto_Cheque.FindAll(boleto_cheque => boleto_cheque.GeraComprovante))
                    {
                        writer.WriteLine(MontaComprovante(DTO));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string MontaComprovante(BOLETO_CHEQUE_DTO DTO)
        {
            try
            {

                string mesExtenso = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month);
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append("<html>                                                    ");
                stringBuilder.Append("<head>                                                    ");
                stringBuilder.Append("  <style>                                                 ");
                stringBuilder.Append("                                                          ");
                stringBuilder.Append("   body {                                                 ");
                stringBuilder.Append("  margin: 10px;                                           ");
                stringBuilder.Append("}                                                         ");
                stringBuilder.Append("                                                          ");
                stringBuilder.Append("  .break { page-break-before: always; }                   ");
                stringBuilder.Append("                                                          ");
                stringBuilder.Append(".header                                                   ");
                stringBuilder.Append("{                                                         ");
                stringBuilder.Append("  width: 100%;                                            ");
                stringBuilder.Append("  height: 20%;                                            ");
                stringBuilder.Append("  border: 1px solid black;                                ");
                stringBuilder.Append("  padding: 10px;                                          ");
                stringBuilder.Append("  margin-top: 10px;                                       ");
                stringBuilder.Append("}                                                         ");
                stringBuilder.Append("                                                          ");
                stringBuilder.Append("  .header td {                                            ");
                stringBuilder.Append("    width: 50%;                                           ");
                stringBuilder.Append("  }                                                       ");
                stringBuilder.Append("                                                          ");
                stringBuilder.Append("  .header h1 {                                            ");
                stringBuilder.Append("    font-size: 22px;                                      ");
                stringBuilder.Append("  }                                                       ");
                stringBuilder.Append("                                                          ");
                stringBuilder.Append(".conteudo {                                               ");
                stringBuilder.Append("  padding: 20px;                                          ");
                stringBuilder.Append("}                                                         ");
                stringBuilder.Append("                                                          ");
                stringBuilder.Append(".assinatura {                                             ");
                stringBuilder.Append("  margin-top: 50px;                                       ");
                stringBuilder.Append("  text-align: center;                                     ");
                stringBuilder.Append("  margin-bottom: 20px;                                    ");
                stringBuilder.Append("}                                                         ");
                stringBuilder.Append("                                                          ");
                stringBuilder.Append(".assinatura hr {                                          ");
                stringBuilder.Append("  width: 40%;                                             ");
                stringBuilder.Append("  margin-top: 40px;                                       ");
                stringBuilder.Append("  margin-bottom: 1px;                                     ");
                stringBuilder.Append("}                                                         ");
                stringBuilder.Append("  </style>                                                ");
                stringBuilder.Append("</head>                                                   ");
                stringBuilder.Append("<body>                                                    ");
                stringBuilder.Append("  <div class='break'>                                     ");
                stringBuilder.Append("    <table class='header'>                                ");
                stringBuilder.Append("    <tr>                                                  ");
                stringBuilder.Append("      <td>                                                ");
                stringBuilder.Append("        <h1>                                              ");
                stringBuilder.Append("          Kairós Transit                                  ");
                stringBuilder.Append("        </h1>                                             ");
                stringBuilder.Append("      </td>                                               ");
                stringBuilder.Append("      <td>                                                ");
                stringBuilder.Append("        <p>                                               ");
                stringBuilder.Append("          Nº do registro: " + DTO.ID_FINANCEIRO);
                stringBuilder.Append("        </p>                                              ");
                stringBuilder.Append("        <p>                                               ");
                stringBuilder.Append("          Valor: R$ " + DTO.VALOR.ToString().Replace(".", ","));
                stringBuilder.Append("        </p>                                              ");
                stringBuilder.Append("      </td>                                               ");
                stringBuilder.Append("    </tr>                                                 ");
                stringBuilder.Append("    </table>                                              ");
                stringBuilder.Append("    <div class='conteudo'>                                ");
                stringBuilder.Append("      <p>                                                 ");
                stringBuilder.Append("      Eu, <b>" + SysBLL.UserLogin.NOME + "</b>, declaro ter recebido na data <b>" + DateTime.Now.ToString("dd/MM/yyyy") + "</b> a quantia de: <b>R$ " + DTO.VALOR.ToString().Replace(".", ",") + " (" + EscreverExtenso(Convert.ToDecimal(DTO.VALOR)) + ")</b> na forma de pagamento <b>" + DTO.FORMA_PAGAMENTO + "</b>, referente ao serviço <b>" + DTO.SERVICO + "</b>");
                stringBuilder.Append("      </p>                                                ");
                stringBuilder.Append("      <div class='assinatura'>                            ");
                stringBuilder.Append("        <p>                                               ");
                stringBuilder.Append("          São Paulo, " + DateTime.Now.Day + " de " + mesExtenso + " de " + DateTime.Now.Year);
                stringBuilder.Append("        </p>                                              ");
                stringBuilder.Append("        <hr />                                            ");
                stringBuilder.Append("        assinatura do cliente                             ");
                stringBuilder.Append("      </div>                                              ");
                stringBuilder.Append("    </div>                                                ");
                stringBuilder.Append("                                                          ");
                stringBuilder.Append("  </div>                                                  ");
                stringBuilder.Append("</body>                                                   ");
                stringBuilder.Append("</html>                                                   ");


                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string EscreverExtenso(decimal valor)
        {
            if (valor <= 0 | valor >= 1000000000000000)
                return "Valor não suportado pelo sistema.";
            else
            {
                string strValor = valor.ToString("000000000000000.00");
                string valor_por_extenso = string.Empty;
                for (int i = 0; i <= 15; i += 3)
                {
                    valor_por_extenso += Escrever_Valor_Extenso(Convert.ToDecimal(strValor.Substring(i, 3)));
                    if (i == 0 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                            valor_por_extenso += " TRILHÃO" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                            valor_por_extenso += " TRILHÕES" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 3 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                            valor_por_extenso += " BILHÃO" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                            valor_por_extenso += " BILHÕES" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 6 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                            valor_por_extenso += " MILHÃO" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                            valor_por_extenso += " MILHÕES" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 9 & valor_por_extenso != string.Empty)
                        if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                            valor_por_extenso += " MIL" + ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0) ? " E " : string.Empty);
                    if (i == 12)
                    {
                        if (valor_por_extenso.Length > 8)
                            if (valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "BILHÃO" | valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "MILHÃO")
                                valor_por_extenso += " DE";
                            else
                                if (valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "BILHÕES" | valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "MILHÕES"
| valor_por_extenso.Substring(valor_por_extenso.Length - 8, 7) == "TRILHÕES")
                                valor_por_extenso += " DE";
                            else
                                    if (valor_por_extenso.Substring(valor_por_extenso.Length - 8, 8) == "TRILHÕES")
                                valor_por_extenso += " DE";
                        if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                            valor_por_extenso += " REAL";
                        else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                            valor_por_extenso += " REAIS";
                        if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valor_por_extenso != string.Empty)
                            valor_por_extenso += " E ";
                    }
                    if (i == 15)
                        if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                            valor_por_extenso += " CENTAVO";
                        else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                            valor_por_extenso += " CENTAVOS";
                }
                return valor_por_extenso;
            }
        }

        static string Escrever_Valor_Extenso(decimal valor)
        {
            if (valor <= 0)
                return string.Empty;
            else
            {
                string montagem = string.Empty;
                if (valor > 0 & valor < 1)
                {
                    valor *= 100;
                }
                string strValor = valor.ToString("000");
                int a = Convert.ToInt32(strValor.Substring(0, 1));
                int b = Convert.ToInt32(strValor.Substring(1, 1));
                int c = Convert.ToInt32(strValor.Substring(2, 1));
                if (a == 1) montagem += (b + c == 0) ? "CEM" : "CENTO";
                else if (a == 2) montagem += "DUZENTOS";
                else if (a == 3) montagem += "TREZENTOS";
                else if (a == 4) montagem += "QUATROCENTOS";
                else if (a == 5) montagem += "QUINHENTOS";
                else if (a == 6) montagem += "SEISCENTOS";
                else if (a == 7) montagem += "SETECENTOS";
                else if (a == 8) montagem += "OITOCENTOS";
                else if (a == 9) montagem += "NOVECENTOS";
                if (b == 1)
                {
                    if (c == 0) montagem += ((a > 0) ? " E " : string.Empty) + "DEZ";
                    else if (c == 1) montagem += ((a > 0) ? " E " : string.Empty) + "ONZE";
                    else if (c == 2) montagem += ((a > 0) ? " E " : string.Empty) + "DOZE";
                    else if (c == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TREZE";
                    else if (c == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUATORZE";
                    else if (c == 5) montagem += ((a > 0) ? " E " : string.Empty) + "QUINZE";
                    else if (c == 6) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSEIS";
                    else if (c == 7) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSETE";
                    else if (c == 8) montagem += ((a > 0) ? " E " : string.Empty) + "DEZOITO";
                    else if (c == 9) montagem += ((a > 0) ? " E " : string.Empty) + "DEZENOVE";
                }
                else if (b == 2) montagem += ((a > 0) ? " E " : string.Empty) + "VINTE";
                else if (b == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TRINTA";
                else if (b == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUARENTA";
                else if (b == 5) montagem += ((a > 0) ? " E " : string.Empty) + "CINQUENTA";
                else if (b == 6) montagem += ((a > 0) ? " E " : string.Empty) + "SESSENTA";
                else if (b == 7) montagem += ((a > 0) ? " E " : string.Empty) + "SETENTA";
                else if (b == 8) montagem += ((a > 0) ? " E " : string.Empty) + "OITENTA";
                else if (b == 9) montagem += ((a > 0) ? " E " : string.Empty) + "NOVENTA";
                if (strValor.Substring(1, 1) != "1" & c != 0 & montagem != string.Empty) montagem += " E ";
                if (strValor.Substring(1, 1) != "1")
                    if (c == 1) montagem += "UM";
                    else if (c == 2) montagem += "DOIS";
                    else if (c == 3) montagem += "TRÊS";
                    else if (c == 4) montagem += "QUATRO";
                    else if (c == 5) montagem += "CINCO";
                    else if (c == 6) montagem += "SEIS";
                    else if (c == 7) montagem += "SETE";
                    else if (c == 8) montagem += "OITO";
                    else if (c == 9) montagem += "NOVE";
                return montagem;
            }
        }
    }
}
