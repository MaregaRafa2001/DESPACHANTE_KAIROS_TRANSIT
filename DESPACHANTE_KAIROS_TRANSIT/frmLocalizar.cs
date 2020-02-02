using DTO;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_UI
{
    public partial class frmLocalizar : Form
    {
        List<PesquisaGeralDTO> ListaCampos = new List<PesquisaGeralDTO>();
        List<ComboItemDTO> Campos = new List<ComboItemDTO>();
        public string ID_REGISTRO = "";
        string Tabela;
        public frmLocalizar(string Tabela)
        {
            InitializeComponent();
            this.Tabela = Tabela;
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCampo.SelectedValue.ToString().ToUpper() != "TODOS")
            {
                txtValor.Visible = true;
            }
            else
            {
                txtValor.Visible = false;
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            string strSearch = "";
            string campo = "";
            foreach (var item in Campos)
            {
                campo += item + ",";
            }
            strSearch = "SELECT "+ campo.Substring(0, campo.Length - 1) + " FROM " + Tabela + " WHERE " + cboCampo.SelectedValue + " like '" + txtValor.Text + "%'";
            PopularGrid(strSearch);
        }

        void PopularGrid(string sql)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append(sql);

                //Monta o grid e recupera as colunas utilizadas para pesquisa
                DataTable dtt = new PesquisaGeralBLL().Pesquisa(sbSql.ToString(), ListaCampos);
                dtgDados.DataSource = dtt; //Vincula o datatable ao datagrid
                dtgDados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); //Redimenciona as colunas de acordo com o conteúdo do campo
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLocalizar_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLocalizar;
            switch (Tabela)
            {
                case "CLIENTE":
                    Campos.Add(new ComboItemDTO() { Text = "ID", Value = "ID" });
                    Campos.Add(new ComboItemDTO() { Text = "NOME_COMPLETO", Value = "NOME_COMPLETO" });
                    Campos.Add(new ComboItemDTO() { Text = "CPF", Value = "CPF" });
                    break;
                case "CONSULTOR":
                    Campos.Add(new ComboItemDTO() { Text = "ID", Value = "ID" });
                    Campos.Add(new ComboItemDTO() { Text = "NOME", Value = "NOME" });
                    Campos.Add(new ComboItemDTO() { Text = "EMAIL", Value = "EMAIL" });
                    break;
            }

            cboCampo.DataSource = null;
            cboCampo.ValueMember = "Value";
            cboCampo.DisplayMember = "Text";
            cboCampo.DataSource = Campos;

        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            ID_REGISTRO = dtgDados.CurrentRow.Cells["ID"].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void dtgDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelecionar_Click(sender, e);
        }
    }
}
