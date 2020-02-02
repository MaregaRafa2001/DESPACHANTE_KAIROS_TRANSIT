using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APP_UI
{
    public partial class frmInputBox : Form
    {

        public string Valor = "";
        string Tipo = "";
        string TipoRetornoCBO = "text";
        public frmInputBox(string Mensagem, string WindowCaption, string Tipo = "string")
        {
            InitializeComponent();
            this.txtMsg.Text = Mensagem.Replace(Tipo, "");
            this.Text = WindowCaption;
            this.Tipo = Tipo;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Tipo.ToUpper() == "TIPODATETIME")
            {
                this.Valor = dtpDataInicio.Value.ToShortDateString() + "' AND '" + dtpDataFim.Value.ToShortDateString();
            }
            else if (Tipo.ToUpper() == "TIPODATETIME2")
            {
                this.Valor = dtpDataInicio.Value.ToShortDateString() + " AND " + dtpDataFim.Value.ToShortDateString();
            }
            else if (Tipo.ToUpper() == "BOOLEAN")
            {
                this.Valor = cboBoolean.SelectedValue.ToString();
            }
            else if (Tipo.Split(' ')[0].ToLower().Trim() == "search")
            {
                this.Valor = txtValor.Text;
            }
            else if (Tipo.ToUpper().Contains("SELECT"))
            {
                if (TipoRetornoCBO == "value")
                    this.Valor = cboConsulta.SelectedValue.ToString();
                else
                    this.Valor = cboConsulta.Text;
            }
            else
            {
                this.Valor = this.txtValor.Text;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmInputBox_Load(object sender, EventArgs e)
        {
            if (Tipo.ToLower() == "tipodatetime" || Tipo.ToLower() == "tipodatetime2")
            {
                txtValor.Visible = false;
                cboBoolean.Visible = false;
                dtpDataInicio.Visible = true;
                dtpDataFim.Visible = true;
                lblDe.Visible = true;
                lblAte.Visible = true;
            }
            else if (Tipo.ToLower() == "boolean")
            {
                txtValor.Visible = false;
                cboBoolean.Visible = true;
                cboBoolean.ValueMember = "value";
                cboBoolean.DisplayMember = "Text";
                cboBoolean.DataSource = new List<ComboItemDTO>() { new ComboItemDTO() { Text = "Sim", Value = 1 }, new ComboItemDTO() { Text = "Não", Value = 0 } };
                cboBoolean.SelectedIndex = 0;
            }
            else if (Tipo.Split(' ')[0].ToLower().Trim() == "search")
            {
                string strSQL = Tipo.Replace("Search", "");

                frmPesquisarConsultor pesquisarConsultor = new frmPesquisarConsultor(strSQL);
                DialogResult result = pesquisarConsultor.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtValor.Text = pesquisarConsultor.Resultado;
                    btnOK_Click(sender, e);
                }
                else
                {
                    btnOK_Click(sender, e);
                }
                return;
            }
            else if (Tipo.ToLower().Contains("select"))
            {
                cboConsulta.Visible = true;
                txtValor.Visible = false;
                cboConsulta.DataSource = null;
                cboConsulta.DisplayMember = "Text";
                cboConsulta.ValueMember = "Value";

                string[] parametros = Tipo.ToLower().Split(' ');
                bool Todos = true;
                if (parametros.Length > 2)
                    TipoRetornoCBO = parametros[2];
                if (parametros.Length > 3)
                    Todos = Convert.ToBoolean(parametros[3]);
                switch (parametros[1].ToLower().Trim())
                {
                    case "servico":
                        cboConsulta.DataSource = new SERVICO_BLL().ListaServicoComboItemDTO(Todos);
                        break;
                    case "status":
                        cboConsulta.DataSource = new STATUS_FINANCEIRO_BLL().Lista_Status(Todos);
                        break;
                }
            }
            else
            {
                this.txtValor.Text = Valor;
                cboBoolean.Visible = false;
            }
        }
    }
}
