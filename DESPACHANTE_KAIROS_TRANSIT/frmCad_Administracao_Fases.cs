using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace APP_UI
{
    public partial class frmCad_Administracao_Fases : Form
    {
        public FASE_FINANCEIRO_DTO fase_financeiro_dto;
        string ObservacaoClone = "";
        public frmCad_Administracao_Fases(FASE_FINANCEIRO_DTO fase_financeiro_dto)
        {
            InitializeComponent();
            PopularCombos();
            this.fase_financeiro_dto = fase_financeiro_dto;
            if (this.fase_financeiro_dto.ID != null)
            {
                PopularDados();
            }
            else
            {
                Random random = new Random();
                this.fase_financeiro_dto.ID = random.Next();
                tabControl1.TabPages.Remove(tabDetalhe);
            }
        }

        void PopularCombos()
        {
            try
            {
                List<FASE_FINANCEIRO_DTO> Lista_fases = new List<FASE_FINANCEIRO_DTO>();
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { FASE = "FASE 1 - DEVENDO DOCUMENTOS" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { FASE = "FASE 2 - AGUARDANDO RESULTADOS" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { FASE = "FASE 3 - DEVENDO CFC" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { FASE = "FASE 4 - AGUARDANDO CHEGAR O CERTIFICADO CFC" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { FASE = "FASE 5 - AGUARDANDO DAR A DATA DE FINALIZARMOS" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { FASE = "FASE 6 - PROCESSOS FINALIZADOS" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { FASE = "SETOR DE COBRANÇA" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { FASE = "ABRIRAM CHAMADO SAC" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { FASE = "PEDIRAM DEVOLUÇÃO" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { FASE = "CHEGAR CERTIFICADO CFC" });
                cboFase.ValueMember = "FASE";
                cboFase.DisplayMember = "FASE";
                cboFase.DataSource = Lista_fases;
                cboFase.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void PopularDados()
        {
            mskData.Text = fase_financeiro_dto.DATA.Value.ToString();
            cboFase.SelectedValue = fase_financeiro_dto.FASE;
            lblDescricao.Text = fase_financeiro_dto.OBSERVACAO;
            ObservacaoClone = fase_financeiro_dto.OBSERVACAO;
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (AtualizaDTO())
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool AtualizaDTO()
        {
            try
            {
                if (!ValidarDados())
                    return false;

                fase_financeiro_dto.DATA = Convert.ToDateTime(mskData.Text);
                fase_financeiro_dto.FASE = cboFase.SelectedValue.ToString();
                if (txtObservacao.Text.Trim().Length > 0)
                    fase_financeiro_dto.OBSERVACAO = lblDescricao.Text + "\r\n" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " - " + txtObservacao.Text;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        bool ValidarDados()
        {
            try
            {
                if (!GLOBAL_BLL.IsDate(mskData.Text))
                {
                    MessageBox.Show("Preencha a data corretamente", "Data inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (cboFase.SelectedValue == null)
                {
                    MessageBox.Show("Selecione a fase", "Fase inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }

        private void TxtObservacao_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void TxtObservacao_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnConfirmar;
        }

        private void FrmCad_Financeiro_Fases_Load(object sender, EventArgs e)
        {
            if (fase_financeiro_dto.DATA == null)
                mskData.Text = DateTime.Now.ToShortDateString();
        }

        private void cboFase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
