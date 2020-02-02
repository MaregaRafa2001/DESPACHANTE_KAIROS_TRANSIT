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

    public partial class frmFinanceiro : Form
    {
        List<PesquisaGeralDTO> ListaCampos = new List<PesquisaGeralDTO>();
        mdi_principal mdi_Principal = null;

        public frmFinanceiro(mdi_principal mdi)
        {
            InitializeComponent();
            mdi_Principal = mdi;
            this.MdiParent = mdi;
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCad_Financeiro frmCad_Financeiro = new frmCad_Financeiro();
                DialogResult result = frmCad_Financeiro.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PopularGrid();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {

                //Setando o mousepointer para ocupado.
                Cursor.Current = Cursors.WaitCursor;

                //Verifica se existem registros no datagrid
                if (dtgDados.RowCount == 0)
                {
                    return;
                }

                //Visualizando o registro selecionado
                int Id = Convert.ToInt32(dtgDados.CurrentRow.Cells["ID"].Value.ToString());
                if (Id != 0)
                {
                    frmCad_Financeiro frmCad_Financeiro = new frmCad_Financeiro(Id);
                    DialogResult result = frmCad_Financeiro.ShowDialog();
                    if (result == DialogResult.OK)
                        PopularGrid();
                }
                else
                {
                    throw new Exception("O Descricao do registro selecionado está incorreto!");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Nenhum registro válido foi selecionado!", "Não foi possível a visualização do registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não foi possível a visualização do registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void PopularGrid()
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("SELECT X.ID, A.NOME_COMPLETO AS NOME, A.CELULAR, B.NOME AS SERVIÇO, X.CONSULTOR, X.DATA, X.OBSERVACAO FROM FINANCEIRO X  LEFT JOIN CLIENTE A ON X.ID_CLIENTE = A.ID LEFT JOIN SERVICOS B ON X.ID_SERVICO = B.ID ");

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

        private void frmFinanceiro_Load(object sender, EventArgs e)
        {
            PopularGrid();



            if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmFinanceiro.Insert"))
                btnAdicionar.Enabled = false;
            if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmFinanceiro.Delete"))
                btnExcluir.Enabled = false;
            if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmFinanceiro.Update"))
            {
                btnAlterar.Enabled = false;
                dtgDados.DoubleClick -= dtgDados_DoubleClick;
            }
        }


        private void dtgDados_DoubleClick(object sender, EventArgs e)
        {
            btnAlterar_Click(sender, e);
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID_PERFIL = SysBLL.UserLogin.ID_PERFIL;
                frmPesquisar frmPesquisar = new frmPesquisar("SELECT * FROM VW_FINANCEIRO ", dtgDados, this.Name);
                frmPesquisar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dtgDados.CurrentRow.Cells["ID"].Value.ToString());

                bool result = new FINANCEIRO_BLL().Excluir(id);

                if (result)
                {
                    MessageBox.Show("Registro" + id + "excluído com sucesso!");
                    PopularGrid();
                }
                else
                {
                    MessageBox.Show("Nao foi possível excluir este registro!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao deletar o dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}






