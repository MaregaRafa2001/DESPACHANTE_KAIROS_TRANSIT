using APP_UI;
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
    public partial class frmJuridico : Form
    {
        List<PesquisaGeralDTO> ListaCampos = new List<PesquisaGeralDTO>();
        mdi_principal mdi_Principal = null;

        public frmJuridico(mdi_principal mdi)
        {
            InitializeComponent();
            mdi_Principal = mdi;
        }


        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDados.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um registro na tabela", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int ID = Convert.ToInt32(dtgDados.CurrentRow.Cells["ID"].Value);
                frmCad_Juridico frmCad_Juridico = new frmCad_Juridico(ID, mdi_Principal);
                DialogResult result = frmCad_Juridico.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PopularGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void BtnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID_PERFIL = SysBLL.UserLogin.ID_PERFIL;
                frmPesquisar frmPesquisar = new frmPesquisar("SELECT * FROM VW_ADMINISTRACAO", dtgDados, this.Name);
                frmPesquisar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmJuridico_Load(object sender, EventArgs e)
        {
            try
            {
                PopularGrid();

                if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmJuridico.Update"))
                {
                    btnAlterar.Enabled = false;
                    dtgDados.DoubleClick -= DtgDados_DoubleClick;
                }
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
