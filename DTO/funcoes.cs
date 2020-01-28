using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DTO
{
   public class funcoes
   {
      public bool ValidarCPF(string cpf_)
      {
         string valor;
         valor = "";
         valor = cpf_.Replace(".", "");
         valor = valor.Replace(",", "");
         valor = valor.Replace("-", "");

         if (valor.Length != 11)

            return false;

         bool igual = true;

         for (int i = 1; i < 11 && igual; i++)
            if (valor[i] != valor[0])
               igual = false;

         if (igual || valor == "12345678909")
            return false;

         int[] numeros = new int[11];

         for (int i = 0; i < 11; i++)
            numeros[i] = int.Parse(valor[i].ToString());

         int soma = 0;
         for (int i = 0; i < 9; i++)
            soma += (10 - i) * numeros[i];

         int resultado = soma % 11;

         if (resultado == 1 || resultado == 0)
         {
            if (numeros[9] != 0)

               return false;
         }

         else if (numeros[9] != 11 - resultado)
            return false;

         soma = 0;

         for (int i = 0; i < 10; i++)
            soma += (11 - i) * numeros[i];

         resultado = soma % 11;

         if (resultado == 1 || resultado == 0)
         {
            if (numeros[10] != 0)
               return false;
         }
         else
             if (numeros[10] != 11 - resultado)
            return false;

         return true;

      }

      public bool ValidarEmail(string email_)
      {
         try
         {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (rg.IsMatch(email_))
               return true;

            else
               return false;

         }
         catch(Exception ex)
         {
            throw new Exception(ex.ToString());
         }
      }

      public bool ValidarData(string data_)
      {
         try
         {
            DateTime dt = DateTime.MinValue;
            if (data_.Length < 10)
            {
               return false;
            }
            else if (DateTime.TryParse(data_.Trim(), out dt))
            {
               return true;
            }
            else
            {
               return false;
            }
         }
         catch(Exception ex)
         {
            throw new Exception(ex.ToString());
         }
      }

   }
}
