﻿using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        /// <summary>
        /// SETA O CURSOR NO INICIO DO CAMPO
        /// </summary>
        /// <param name="obj">Campo que será setado o cursor</param>
        public static void InicioIndex(object obj)
        {
            try
            {
                MaskedTextBox msk = (MaskedTextBox)obj;
                string removido = Regex.Replace(msk.Text, "[^0-9]", "");

                if (removido.Length == 0)
                    msk.SelectionStart = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DateTime? GetDate(string text)
        {
            try
            {
                return DateTime.Parse(text);
            }
            catch
            {
                return (DateTime?)null;
            }
        }

        public static bool ValidarCampo(List<string> CamposInvalidos, string nome, string valor, Campos campo, TipoCampo tipoCampo = TipoCampo.SemFormatacao, bool obrigatorio = true)
        {
            switch (campo)
            {
                case Campos.TextBox:
                    if (obrigatorio && string.IsNullOrEmpty(valor))
                    {
                        CamposInvalidos.Add(nome);
                        return false;
                    }
                    break;
                case Campos.MaskedBox:
                    string valorFormatado = valor.Replace("/", "").Replace("_", "").Replace("-", "").Replace(" ", "").Replace(",", "").Replace(".", "");
                    switch (tipoCampo)
                    {
                        case TipoCampo.SemFormatacao:
                            break;
                        case TipoCampo.DateTime:
                            if ((obrigatorio && string.IsNullOrEmpty(valorFormatado)) || (!string.IsNullOrEmpty(valorFormatado) && !GLOBAL_BLL.IsDate(valor)))
                            {
                                CamposInvalidos.Add(nome);
                                return false;
                            }
                            break;
                        case TipoCampo.CPF:
                            if ((obrigatorio && string.IsNullOrEmpty(valorFormatado)) || (!string.IsNullOrEmpty(valorFormatado) && !GLOBAL_BLL.IsCpf(valor.Replace(",", "."))))
                            {
                                CamposInvalidos.Add(nome);
                                return false;
                            }
                            break;
                        case TipoCampo.CEP:
                            if ((obrigatorio && string.IsNullOrEmpty(valorFormatado)) || (!string.IsNullOrEmpty(valorFormatado) && !GLOBAL_BLL.IsCep(valor)))
                            {
                                CamposInvalidos.Add(nome);
                                return false;
                            }
                            break;
                        case TipoCampo.Int:
                            if (!GLOBAL_BLL.IsNumeric(valor))
                                return false;
                            break;
                        default:
                            break;
                    }

                    break;
                case Campos.ComboBox:
                    if (string.IsNullOrEmpty(valor))
                    {
                        CamposInvalidos.Add(nome);
                        return false;
                    }
                    break;
                case Campos.NumericUpDown:
                    if (string.IsNullOrEmpty(valor))
                    {
                        CamposInvalidos.Add(nome);
                        return false;
                    }
                    break;
                default:
                    CamposInvalidos.Add(nome);
                    return false;
            }
            return true;
        }
    }
}
