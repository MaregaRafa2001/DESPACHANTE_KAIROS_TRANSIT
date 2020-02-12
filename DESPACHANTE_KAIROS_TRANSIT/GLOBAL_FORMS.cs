﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_UI
{
    public static class GLOBAL_FORMS
    {
        public static void Moeda(ref TextBox textbox)
        {
            String numero = String.Empty;
            Double valor = 0;
            try
            {
                numero = textbox.Text.Replace(",", "").Replace(".", "");
                if (numero.Equals(""))
                    numero = "";
                numero = numero.PadLeft(3, '0');

                if (numero.Length > 3 & numero.Substring(0, 1) == "0") numero = numero.Substring(1, numero.Length - 1);
                valor = Convert.ToDouble(numero) / 100;
                textbox.Text = String.Format("{0:N}", valor);
                textbox.SelectionStart = textbox.Text.Length;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AjustaGrid(DataGridView dtg)
        {
            try
            {
                for (int i = 0; i < dtg.Columns.Count; i++)
                {
                    if (dtg.Columns[i].Name.ToString().ToLower() == "id_invisible")
                    {
                        dtg.Columns[i].Visible = false;
                    }
                    else
                    {
                        dtg.AutoResizeColumn(i);
                    }
                    if (dtg.Columns[i].ValueType == typeof(System.Decimal))
                    {
                        dtg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        //dtg.Columns[i].DefaultCellStyle.Format = "###,##0.##" //n2;
                    }
                    if (dtg.Columns[i].ValueType == typeof(System.Double))
                    {
                        dtg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (dtg.Columns[i].ValueType == typeof(System.Int16))
                    {
                        dtg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (dtg.Columns[i].ValueType == typeof(System.Int32))
                    {
                        dtg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (dtg.Columns[i].ValueType == typeof(System.Int64))
                    {
                        dtg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}