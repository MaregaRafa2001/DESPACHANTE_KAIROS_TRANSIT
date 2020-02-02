using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    }
}
