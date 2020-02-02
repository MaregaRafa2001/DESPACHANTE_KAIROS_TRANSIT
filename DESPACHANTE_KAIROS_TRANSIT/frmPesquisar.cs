using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_UI
{
    public partial class frmPesquisar : Form
    {
        string strQuery = "";
        List<CAMPOS_LOCALIZAR_DTO> campos;
        DataGridView dataGridView;
        string Tela = "";
        public frmPesquisar(string Query, DataGridView dataGridView, string Tela)
        {
            InitializeComponent();
            strQuery = Query;
            this.dataGridView = dataGridView;
            this.Tela = Tela;
        }

        private void frmPesquisar_Load(object sender, EventArgs e)
        {
            try
            {

                campos = new CAMPOS_LOCALIZAR_BLL().Listar(Tela);
                campos.Insert(0, new CAMPOS_LOCALIZAR_DTO { DISPLAY = "<TODOS>", VALUE = "todos", TIPO = "todos" });
                List<ComboItemDTO> itemDTOs = new List<ComboItemDTO>();

                foreach (var item in campos)
                {
                    itemDTOs.Add(new ComboItemDTO() { Text = item.DISPLAY, Value = item.VALUE });
                }
                cboCampos.DisplayMember = "text";
                cboCampos.ValueMember = "value";
                cboCampos.DataSource = itemDTOs;
                cboCampos.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cboCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCampos.SelectedValue != null)
            {
                string Tipo = campos.Find(x => x.DISPLAY == cboCampos.Text).TIPO;
                switch (Tipo)
                {
                    case "string":
                        txtValor.Visible = true;
                        lblValor.Visible = true;
                        cboValor.Visible = false;
                        dtpMax.Visible = false;
                        dtpMin.Visible = false;
                        lblData.Visible = false;
                        break;
                    case "numeric":
                        txtValor.Visible = true;
                        lblValor.Visible = true;
                        cboValor.Visible = false;
                        dtpMax.Visible = false;
                        dtpMin.Visible = false;
                        lblData.Visible = false;
                        break;
                    case "datetime":
                        txtValor.Visible = false;
                        lblValor.Visible = true;
                        cboValor.Visible = false;
                        dtpMax.Visible = true;
                        dtpMin.Visible = true;
                        lblData.Visible = true;
                        break;
                    case "bool":
                        txtValor.Visible = false;
                        lblValor.Visible = true;
                        cboValor.Visible = true;
                        dtpMax.Visible = false;
                        dtpMin.Visible = false;
                        lblData.Visible = false;
                        break;
                    case "todos":
                        txtValor.Visible = false;
                        cboValor.Visible = false;
                        lblValor.Visible = false;
                        dtpMax.Visible = false;
                        dtpMin.Visible = false;
                        lblData.Visible = false;
                        break;
                    default:
                        txtValor.Visible = true;
                        lblValor.Visible = true;
                        cboValor.Visible = false;
                        dtpMax.Visible = false;
                        dtpMin.Visible = false;
                        lblData.Visible = false;
                        break;
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboCampos.SelectedValue != null)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append(strQuery);
                    string Tipo = campos.Find(x => x.DISPLAY == cboCampos.Text).TIPO;
                    switch (Tipo)
                    {
                        case "string":
                            str.Append(" WHERE " + cboCampos.Text + " LIKE '" + txtValor.Text + "%'");
                            break;
                        case "datetime":
                            str.Append(" WHERE " + cboCampos.Text + " BETWEEN '" + dtpMin.Value.ToShortDateString() + "' AND '" + dtpMax.Value.ToShortDateString() + "'");
                            break;
                        case "numeric":
                            str.Append(" WHERE " + cboCampos.Text + " = " + txtValor.Text);
                            break;
                        case "bool":
                            str.Append(" WHERE " + cboCampos.Text + " = " + cboValor.SelectedValue);
                            break;
                        case "todos":
                            str.Append(" WHERE 1=1");
                            break;
                        default:
                            str.Append(" WHERE " + cboCampos.Text + " = '" + txtValor.Text + "'");
                            break;
                    }

                    DataTable dtt = new PesquisaGeralBLL().Pesquisa(str.ToString());

                    dataGridView.DataSource = dtt;

                    this.DialogResult = DialogResult.OK;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
