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
    public partial class frmUsuario : Form
    {
        List<PesquisaGeralDTO> ListaCampos = new List<PesquisaGeralDTO>();

        public frmUsuario(mdi_principal mdi)
        {
            InitializeComponent();
        }

        Dictionary<string, string> campos = new Dictionary<string, string>();


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCad_Usuario frmCad_Usuario = new frmCad_Usuario(0);
                DialogResult result = frmCad_Usuario.ShowDialog();
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
                sbSql.Append("SELECT * FROM VW_LOGIN");

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

        private void BtnAlterar_Click(object sender, EventArgs e)
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
                    frmCad_Usuario frmCad_Usuario = new frmCad_Usuario(Id);
                    DialogResult result = frmCad_Usuario.ShowDialog();
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
                if (dtgDados.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um registro da tabela", "Registro inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int id = Convert.ToInt32(dtgDados.CurrentRow.Cells["ID"].Value.ToString());

                if (id <= 0)
                {
                    MessageBox.Show("Registro não localizado", "Registro inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((MessageBox.Show("Tem certeza de deseja excluir o registro " + id + "?", "Exclusão", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) != DialogResult.Yes)
                {
                    return;
                }
                bool result = new LOGIN_BLL().Excluir(id);

                if (result)
                {
                    MessageBox.Show("Registro " + id + " excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopularGrid();
                }
                else
                {
                    MessageBox.Show("Nao foi possível excluir este registro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        private void BtnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                frmPesquisar frmPesquisar = new frmPesquisar("SELECT * FROM VW_LOGIN ", dtgDados, this.Name);
                frmPesquisar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                campos.Add("ID", "numeric");
                campos.Add("NOME", "string");
                campos.Add("EMAIL", "string");
                campos.Add("PERFIL", "string");
                campos.Add("LOGIN", "string");
                PopularGrid();



                if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmUsuario.Insert"))
                    btnAdicionar.Enabled = false;
                if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmUsuario.Delete"))
                    btnExcluir.Enabled = false;
                if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmUsuario.Update"))
                    btnAlterar.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DtgDados_DoubleClick(object sender, EventArgs e)
        {
            BtnAlterar_Click(sender, e);
        }
    }
}
