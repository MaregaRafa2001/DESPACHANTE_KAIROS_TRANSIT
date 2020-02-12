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
                cboFase.Enabled = false;
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
                cboFase.SelectedIndexChanged -= cboFase_SelectedIndexChanged;
                List<FASE_FINANCEIRO_DTO> Lista_fases = new List<FASE_FINANCEIRO_DTO>();
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 1, FASE = "FASE 1 - BEM-VINDO" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 2, FASE = "FASE 2 - DOCUMENTAÇÃO" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 3, FASE = "FASE 3 - CORRESPONDÊNCIA" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 4, FASE = "FASE 4 - MONTAGEM DE PROCESSO" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 5, FASE = "FASE 5 - PROCURADORIA DETRAN" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 6, FASE = "FASE 6 - PÓS-VENDA" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 7, FASE = "FASE 7 - AUTO-ESCOLA" });
                //Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = , FASE = "SETOR DE COBRANÇA" });
                //Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = , FASE = "ABRIRAM CHAMADO SAC" });
                //Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = , FASE = "PEDIRAM DEVOLUÇÃO" });
                //Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = , FASE = "CHEGAR CERTIFICADO CFC" });
                cboFase.ValueMember = "ID";
                cboFase.DisplayMember = "FASE";
                cboFase.DataSource = Lista_fases;
                cboFase.SelectedIndex = 0;
                cboFase.SelectedIndexChanged += cboFase_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void PopularDados()
        {
            cboFase.Text = fase_financeiro_dto.FASE;
            lblDescricao.Text = fase_financeiro_dto.OBSERVACAO;
            ObservacaoClone = fase_financeiro_dto.OBSERVACAO;

            if (cboFase.SelectedValue == null)
            {
                throw new Exception("Não foi possível localizar a fase selecionada. Entre em contato com o suporte do sistema. \r\nID do registro: " + fase_financeiro_dto.ID);
            }

            loadTela(Convert.ToInt32(cboFase.SelectedValue));

            switch (Convert.ToInt32(cboFase.SelectedValue))
            {
                case 1:
                    Fase1_mskDataRecebimento.Text = fase_financeiro_dto.DATA_RECEBIMENTO_CONTRATO.ToString();
                    break;
                case 2:
                    break;
                case 3:
                    Fase3_mskDataEntrega.Text = fase_financeiro_dto.DATA_ENTREGA_DOCUMENTO.ToString();
                    Fase3_mskDataVencimento.Text = fase_financeiro_dto.DATA_VENCIMENTO_DOCUMENTO.ToString();
                    break;
                case 4:
                    Fase4_mskDataMontagemProcesso.Text = fase_financeiro_dto.DATA_MONTAGEM_PROCESSO.ToString();
                    break;
                case 5:
                    Fase5_mskIda.Text = fase_financeiro_dto.DATA_IDA_DETRAN.ToString();
                    Fase5_mskRetorno.Text = fase_financeiro_dto.DATA_RETORNO_DETRAN.ToString();
                    Fase5_mskProcurador.Text = fase_financeiro_dto.PROCURADOR.ToString();
                    Fase5_txtPenalidade.Text = fase_financeiro_dto.PENALIDADE.ToString();
                    break;
                case 6:
                    Fase6_mskFechamentoCurso.Text = fase_financeiro_dto.DATA_FECHAMENTO_CURSO.ToString();
                    Fase6_cbRecebimentoAuto.Checked = fase_financeiro_dto.RECEBIMENTO_AUTO == null ? false : Convert.ToBoolean(fase_financeiro_dto.RECEBIMENTO_AUTO);
                    Fase6_cbCursoFora.Checked = fase_financeiro_dto.CURSO_FORA == null ? false : Convert.ToBoolean(fase_financeiro_dto.CURSO_FORA);
                    break;
                case 7:
                    Fase7_mskDigital1.Text = fase_financeiro_dto.DATA_DIGITAL_1.ToString();
                    Fase7_mskDigital2.Text = fase_financeiro_dto.DATA_DIGITAL_2.ToString();
                    Fase7_mskRecebimentoCertificado.Text = fase_financeiro_dto.DATA_RECEBIMENTO_CERTIFICADO.ToString();
                    break;
            }
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

                fase_financeiro_dto.DATA = Convert.ToDateTime(DateTime.Now);
                fase_financeiro_dto.FASE = cboFase.Text.ToString();
                if (txtObservacao.Text.Trim().Length > 0)
                    fase_financeiro_dto.OBSERVACAO = lblDescricao.Text + "\r\n" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " - " + txtObservacao.Text;

                switch (Convert.ToInt32(cboFase.SelectedValue))
                {
                    case 1:
                        fase_financeiro_dto.DATA_RECEBIMENTO_CONTRATO = GetMskDate(Fase1_mskDataRecebimento);
                        break;
                    case 2:
                        break;
                    case 3:
                        fase_financeiro_dto.DATA_ENTREGA_DOCUMENTO = GetMskDate(Fase3_mskDataEntrega);
                        fase_financeiro_dto.DATA_VENCIMENTO_DOCUMENTO = GetMskDate(Fase3_mskDataVencimento);
                        break;
                    case 4:
                        fase_financeiro_dto.DATA_MONTAGEM_PROCESSO = GetMskDate(Fase4_mskDataMontagemProcesso);
                        break;
                    case 5:
                        fase_financeiro_dto.DATA_IDA_DETRAN = GetMskDate(Fase5_mskIda);
                        fase_financeiro_dto.DATA_RETORNO_DETRAN = GetMskDate(Fase5_mskRetorno);
                        fase_financeiro_dto.PENALIDADE = Fase5_txtPenalidade.Text;
                        fase_financeiro_dto.PROCURADOR = Fase5_mskProcurador.Text;
                        break;
                    case 6:
                        fase_financeiro_dto.DATA_FECHAMENTO_CURSO = GetMskDate(Fase6_mskFechamentoCurso);
                        fase_financeiro_dto.RECEBIMENTO_AUTO = Fase6_cbRecebimentoAuto.Checked;
                        fase_financeiro_dto.CURSO_FORA = Fase6_cbCursoFora.Checked;
                        break;
                    case 7:
                        fase_financeiro_dto.DATA_DIGITAL_1 = GetMskDate(Fase7_mskDigital1);
                        fase_financeiro_dto.DATA_DIGITAL_2 = GetMskDate(Fase7_mskDigital2);
                        fase_financeiro_dto.DATA_RECEBIMENTO_CERTIFICADO = GetMskDate(Fase7_mskRecebimentoCertificado);
                        break;
                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime? GetMskDate(MaskedTextBox txt)
        {
            try
            {
                if (FormFuncoes.IsDate(txt.Text))
                {
                    return Convert.ToDateTime(txt.Text);
                }
                return (DateTime?)null;
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
                if (!GLOBAL_BLL.IsDate(DateTime.Now.ToShortDateString()))
                {
                    MessageBox.Show("Preencha a data corretamente", "Data inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (cboFase.Text == null)
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

        private void TxtObservacao_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnConfirmar;
        }

        private void FrmCad_Financeiro_Fases_Load(object sender, EventArgs e)
        {
            if (cboFase.Enabled)
                loadTela(Convert.ToInt32(cboFase.SelectedValue));
        }

        private void cboFase_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTela(Convert.ToInt32(cboFase.SelectedValue));
        }

        public void loadTela(int Fase)
        {
            switch (Fase)
            {
                case 1:
                    this.Size = new System.Drawing.Size(402, 397);
                    gpbObservacao.Location = new System.Drawing.Point(13, 132);
                    pnlFase1.Visible = true;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    break;
                case 2:
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = true;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    this.Size = new System.Drawing.Size(402, 314);
                    gpbObservacao.Location = new System.Drawing.Point(13, 50);
                    break;
                case 3:
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = true;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    this.Size = new System.Drawing.Size(402, 397);
                    gpbObservacao.Location = new System.Drawing.Point(13, 132);
                    break;
                case 4:
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = true;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    this.Size = new System.Drawing.Size(402, 397);
                    gpbObservacao.Location = new System.Drawing.Point(13, 132);
                    break;
                case 5:
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = true;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    this.Size = new System.Drawing.Size(402, 455);
                    gpbObservacao.Location = new System.Drawing.Point(13, 184);
                    break;
                case 6:
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = true;
                    pnlFase7.Visible = false;
                    this.Size = new System.Drawing.Size(402, 397);
                    gpbObservacao.Location = new System.Drawing.Point(13, 132);
                    break;
                case 7:
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = true;
                    this.Size = new System.Drawing.Size(402, 397);
                    gpbObservacao.Location = new System.Drawing.Point(13, 132);
                    break;
            }
        }
    }
}
