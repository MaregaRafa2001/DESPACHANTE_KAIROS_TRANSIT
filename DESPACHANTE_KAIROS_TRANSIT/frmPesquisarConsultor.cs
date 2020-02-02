using BLL;
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
    public partial class frmPesquisarConsultor : Form
    {
        string SQL;
        int ColumnIndex;
        public string Resultado;
        public frmPesquisarConsultor(string SQL, int ColumnIndex = 0)
        {
            InitializeComponent();
            this.SQL = SQL;
            this.ColumnIndex = ColumnIndex;
        }



        private void BtnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Valor = txtValor.Text;
                if (string.IsNullOrEmpty(Valor))
                {
                    MessageBox.Show("Insira um parâmetro de busca!", "Parâmetro inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (radInicio.Checked)
                    Valor = Valor + "%";
                else if (radQualquerParte.Checked)
                    Valor = "%" + Valor + "%";

                string strSql = SQL.Replace("@@VALORBUSCAPARAMETRO", Valor);
                DataTable dtt = new PesquisaGeralBLL().Pesquisa(strSql);
                dtgDados.DataSource = dtt; //Vincula o datatable ao datagrid
                dtgDados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao pesquisar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSelecionar_Click(object sender, EventArgs e)
        {
            if (dtgDados.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro da tabela", "Selecione um registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string Resultado = dtgDados.CurrentRow.Cells[ColumnIndex].Value.ToString();
            this.Resultado = Resultado;
            this.DialogResult = DialogResult.OK;
        }

        private void DtgDados_DoubleClick(object sender, EventArgs e)
        {
            BtnSelecionar_Click(sender, e);
        }

        private void FrmPesquisarConsultor_Load(object sender, EventArgs e)
        {

        }
    }
}
