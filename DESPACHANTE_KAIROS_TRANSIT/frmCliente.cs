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
    public partial class frmCliente : Form
    {
        public frmCliente(mdi_principal mdi)
        {
            InitializeComponent();
        }

        Dictionary<string, string> campos = new Dictionary<string, string>();
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCad_Cliente frmCad_Cliente = new frmCad_Cliente();
                DialogResult result = frmCad_Cliente.ShowDialog();
                if (result == DialogResult.OK)
                    PopularGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void PopularGrid()
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("SELECT * FROM VW_CLIENTE ORDER BY ID DESC ");

                //Monta o grid e recupera as colunas utilizadas para pesquisa
                DataTable dtt = new PesquisaGeralBLL().Pesquisa(sbSql.ToString());
                dtgDados.DataSource = dtt; //Vincula o datatable ao datagrid
                dtgDados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); //Redimenciona as colunas de acordo com o conteúdo do campo
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void frmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                PopularGrid();

                if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmCliente.Insert"))
                    btnAdicionar.Enabled = false;
                if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmCliente.Delete"))
                    btnExcluir.Enabled = false;
                if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmCliente.Update"))
                {
                    btnAlterar.Enabled = false;
                    dtgDados.DoubleClick -= dtgDados_DoubleClick;
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
                int Id = Convert.ToInt32(dtgDados.CurrentRow.Cells["Id"].Value.ToString());
                if (Id != 0)
                {
                    frmCad_Cliente frmCad_Cliente = new frmCad_Cliente(Id);
                    DialogResult result = frmCad_Cliente.ShowDialog();
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

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dtgDados.CurrentRow.Cells["ID"].Value.ToString());

                bool result = new CLIENTE_BLL().Excluir(id);

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
                MessageBox.Show(ex.Message, "Nao foi possível excluir este registro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLocalizar_Click(object sender, EventArgs e)
        {
            frmPesquisar frmPesquisar = new frmPesquisar("SELECT * FROM VW_CLIENTE ", dtgDados, this.Name);
            frmPesquisar.ShowDialog();
        }

        private void dtgDados_DoubleClick(object sender, EventArgs e)
        {
            btnAlterar_Click(sender, e);
        }
    }
}
