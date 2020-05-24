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
using APP_UI;

namespace APP_UI
{
    public partial class frmCad_Juridico_Fases : Form
    {
        public JURIDICO_DTO juridico_dto;
        int ID_SERVICO;
        string ObservacaoClone = "";

        public frmCad_Juridico_Fases(JURIDICO_DTO juridico_dto, int ID_SERVICO)
        {
            InitializeComponent();
            this.ID_SERVICO = ID_SERVICO;
            PopularCombos();
            this.juridico_dto = juridico_dto;
            if (this.juridico_dto.ID != null)
            {
                PopularDados();
                cboFase.Enabled = false;
            }
            else
            {
                Random random = new Random();
                this.juridico_dto.ID = random.Next();
                tabControl1.TabPages.Remove(tabDetalhe);
            }
        }

        void PopularCombos()
        {
            try
            {
                cboFase.SelectedIndexChanged -= CboFase_SelectedIndexChanged;
                List<FASE_FINANCEIRO_DTO> Lista_fases = new List<FASE_FINANCEIRO_DTO>();
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 1, LAYOUT_TELA = 1, DESCRICAO = "Fase 1 - Bem-Vindo" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 2, LAYOUT_TELA = 2, DESCRICAO = "Fase 2 - Documentação" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 3, LAYOUT_TELA = 3, DESCRICAO = "Fase 3 - Encaminhamento ao advogado" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 4, LAYOUT_TELA = 4, DESCRICAO = "Fase 4 (Judicial) - Julgamento" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 5, LAYOUT_TELA = 5, DESCRICAO = "Fase 5 (Recurso) - Julgamento" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 6, LAYOUT_TELA = 6, DESCRICAO = "Fase 6 (Judicial) - Sentença" });
                Lista_fases.Add(new FASE_FINANCEIRO_DTO() { ID = 7, LAYOUT_TELA = 7, DESCRICAO = "Fase 7 (Recurso) - Finalização" });
                if (Lista_fases.Count() == 0)
                {
                    throw new CustomException("Não foi identificado nenhuma fase para este serviço. Entre em contato com o suporte do sistema." + (juridico_dto == null ? "" : "\nID do registro: " + juridico_dto.ID), "Erro ao carregar fases");
                }
                cboFase.ValueMember = "LAYOUT_TELA";
                cboFase.DisplayMember = "DESCRICAO";
                cboFase.DataSource = Lista_fases;
                cboFase.SelectedIndex = 0;
                cboFase.SelectedIndexChanged += CboFase_SelectedIndexChanged;


                #region Popular Combos de fases
                //FASE 1
                List<ComboItemDTO> lista_Instancia = new List<ComboItemDTO>();
                lista_Instancia.Add(new ComboItemDTO() { Text = "DETRAN", Value = "DETRAN" });
                lista_Instancia.Add(new ComboItemDTO() { Text = "JARI", Value = "JARI" });
                lista_Instancia.Add(new ComboItemDTO() { Text = "CETRAN", Value = "CETRAN" });
                pnlFase1_cboInstancia.ValueMember = "Value";
                pnlFase1_cboInstancia.DisplayMember = "Text";
                pnlFase1_cboInstancia.DataSource = lista_Instancia;
                pnlFase1_cboInstancia.SelectedIndex = -1;

                //FASE 4 
                List<ComboItemDTO> lista_Bloqueio = new List<ComboItemDTO>();
                lista_Bloqueio.Add(new ComboItemDTO() { Text = "Suspensão", Value = "Suspensão" });
                lista_Bloqueio.Add(new ComboItemDTO() { Text = "Cassação", Value = "Cassação" });
                pnlFase4_cboBloqueio.ValueMember = "Value";
                pnlFase4_cboBloqueio.DisplayMember= "Text";
                pnlFase4_cboBloqueio.DataSource = lista_Bloqueio;
                pnlFase4_cboBloqueio.SelectedIndex = -1;


                //FASE 5
                pnlFase5_cboBloqueio.ValueMember = "Value";
                pnlFase5_cboBloqueio.DisplayMember = "Text";
                pnlFase5_cboBloqueio.DataSource = lista_Bloqueio;
                pnlFase5_cboBloqueio.SelectedIndex = -1;

                pnlFase5_cboInstancia.ValueMember = "Value";
                pnlFase5_cboInstancia.DisplayMember = "Text";
                pnlFase5_cboInstancia.DataSource = lista_Instancia;
                pnlFase5_cboInstancia.SelectedIndex = -1;

                List<ComboItemDTO> lista_Status = new List<ComboItemDTO>();
                lista_Status.Add(new ComboItemDTO() { Text = "Prazo expirado", Value = "Prazo expirado" });
                lista_Status.Add(new ComboItemDTO() { Text = "Expirada", Value = "Expirada" });
                lista_Status.Add(new ComboItemDTO() { Text = "Ativo", Value = "Ativo" });
                pnlFase5_cboStatus.ValueMember = "Value";
                pnlFase5_cboStatus.DisplayMember = "Text";
                pnlFase5_cboStatus.DataSource = lista_Status;
                pnlFase5_cboStatus.SelectedIndex = -1;

                //FASE 6
                List<ComboItemDTO> lista_Resultado = new List<ComboItemDTO>();
                lista_Resultado.Add(new ComboItemDTO() { Text = "Defirido", Value = "Defirido" });
                lista_Resultado.Add(new ComboItemDTO() { Text = "Indefirido", Value = "Indefirido" });
                pnlFase6_cboResultado.ValueMember = "Value";
                pnlFase6_cboResultado.DisplayMember = "Text";
                pnlFase6_cboResultado.DataSource = lista_Resultado;
                pnlFase6_cboResultado.SelectedIndex = -1;

                //FASE 7 
                pnlFase7_cboResultado.ValueMember = "Value";
                pnlFase7_cboResultado.DisplayMember = "Text";
                pnlFase7_cboResultado.DataSource = lista_Resultado;
                pnlFase7_cboResultado.SelectedIndex = -1;

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void PopularDados()
        {
            cboFase.SelectedValue = juridico_dto.LAYOUT_TELA;
            lblDescricao.Text = juridico_dto.OBSERVACAO;
            ObservacaoClone = juridico_dto.OBSERVACAO;

            if (cboFase.SelectedValue == null)
            {
                throw new Exception("Não foi possível localizar a fase selecionada. Entre em contato com o suporte do sistema. \r\nID do registro: " + juridico_dto.ID);
            }

            loadTela(Convert.ToInt32(cboFase.SelectedValue));
            //POPULA A TELA COM O LAYOUT DA FASE
            switch (Convert.ToInt32(cboFase.SelectedValue))
            {
                case 1:
                    pnlFase1_cboInstancia.Text = juridico_dto.Instancia != null ? juridico_dto.Instancia : "";
                    pnlFase1_mskDataClienteContatado.Text = FormFuncoes.PopularMskData(juridico_dto.DataClienteContatado);
                    pnlFase1_mskDataLimiteDefesa.Text = FormFuncoes.PopularMskData(juridico_dto.DataLimiteDefesa);
                    pnlFase1_mskDataRecebimentoContrato.Text = FormFuncoes.PopularMskData(juridico_dto.DataRecebimentoContrato);
                    pnlFase1_txtSenhaDetran.Text = juridico_dto.SenhaDetran;
                    break;
                case 2:
                    break;
                case 3:
                    pnlFase3_DataEntregaCliente.Text = FormFuncoes.PopularMskData(juridico_dto.DataEntregaCliente);
                    pnlFase3_mskDataEntregaAdvogado.Text = FormFuncoes.PopularMskData(juridico_dto.DataEntregaAdvogado);
                    break;
                case 4:
                    pnlFase4_cboBloqueio.Text = juridico_dto.Bloqueio != null ? juridico_dto.Bloqueio : "";
                    pnlFase4_mskDataEntregaAdvogado.Text = FormFuncoes.PopularMskData(juridico_dto.DataEntregaAdvogado);
                    pnlFase4_mskDataExpedicao.Text = FormFuncoes.PopularMskData(juridico_dto.DataExpedicao);
                    pnlFase4_mskDataInicio.Text = FormFuncoes.PopularMskData(juridico_dto.DataInicio);
                    pnlFase4_mskDataProtocolamento.Text = FormFuncoes.PopularMskData(juridico_dto.DataProtocolamento);
                    pnlFase4_mskDataTermino.Text = FormFuncoes.PopularMskData(juridico_dto.DataTermino);
                    pnlFase4_radImpedimentoSim.Checked = juridico_dto.Liminar;
                    break;
                case 5:
                    pnlFase5_cboBloqueio.Text = juridico_dto.Bloqueio != null ? juridico_dto.Bloqueio : "";
                    pnlFase5_cboInstancia.Text = juridico_dto.Instancia != null ? juridico_dto.Instancia : "";
                    pnlFase5_cboStatus.Text = juridico_dto.Status != null ? juridico_dto.Status : "";
                    pnlFase5_mskDataEntregaAdvogado.Text = FormFuncoes.PopularMskData(juridico_dto.DataEntregaAdvogado);
                    pnlFase5_mskDataProtocolamento.Text = FormFuncoes.PopularMskData(juridico_dto.DataProtocolamento);
                    break;
                case 6:
                    pnlFase6_cboResultado.Text = juridico_dto.Resultado != null ? juridico_dto.Resultado : "";
                    pnlFase6_mskDataFinalizacao.Text = FormFuncoes.PopularMskData(juridico_dto.DataFinalizacao);
                    pnlFase6_mskDataLiberacaoSentenca.Text = FormFuncoes.PopularMskData(juridico_dto.DataLiberacaoSentenca);
                    pnlFase6_mskSentencaProtocolada.Text = FormFuncoes.PopularMskData(juridico_dto.DataSentencaProtocolada);
                    break;
                case 7:
                    pnlFase7_cboResultado.Text = juridico_dto.Resultado != null ? juridico_dto.Resultado : "";
                    pnlFase7_mskDataFinalizacao.Text = FormFuncoes.PopularMskData(juridico_dto.DataFinalizacao);
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

                juridico_dto.DATA = Convert.ToDateTime(DateTime.Now);
                juridico_dto.FASE = cboFase.Text.ToString();
                juridico_dto.LAYOUT_TELA = Convert.ToInt32(cboFase.SelectedValue);
                if (txtObservacao.Text.Trim().Length > 0)
                    juridico_dto.OBSERVACAO = lblDescricao.Text + "\r\n" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " - " + txtObservacao.Text;

                switch (Convert.ToInt32(cboFase.SelectedValue))
                {
                    case 1:
                        juridico_dto.Instancia = pnlFase1_cboInstancia.Text;
                        juridico_dto.DataClienteContatado = FormFuncoes.GetMskDate(pnlFase1_mskDataClienteContatado);
                        juridico_dto.DataLimiteDefesa = FormFuncoes.GetMskDate(pnlFase1_mskDataLimiteDefesa);
                        juridico_dto.DataRecebimentoContrato = FormFuncoes.GetMskDate(pnlFase1_mskDataRecebimentoContrato);
                        juridico_dto.SenhaDetran = pnlFase1_txtSenhaDetran.Text;
                        break;
                    case 2:
                        break;
                    case 3:
                        juridico_dto.DataEntregaCliente = FormFuncoes.GetMskDate(pnlFase3_DataEntregaCliente);
                        juridico_dto.DataEntregaAdvogado = FormFuncoes.GetMskDate(pnlFase3_mskDataEntregaAdvogado);
                        break;
                    case 4:
                        juridico_dto.Bloqueio = pnlFase4_cboBloqueio.Text;
                        juridico_dto.DataEntregaAdvogado = FormFuncoes.GetMskDate(pnlFase4_mskDataEntregaAdvogado);
                        juridico_dto.DataExpedicao = FormFuncoes.GetMskDate(pnlFase4_mskDataExpedicao);
                        juridico_dto.DataInicio = FormFuncoes.GetMskDate(pnlFase4_mskDataInicio);
                        juridico_dto.DataProtocolamento = FormFuncoes.GetMskDate(pnlFase4_mskDataProtocolamento);
                        juridico_dto.DataTermino = FormFuncoes.GetMskDate(pnlFase4_mskDataTermino);
                        juridico_dto.Liminar = pnlFase4_radImpedimentoSim.Checked;
                        break;
                    case 5:
                        juridico_dto.Bloqueio = pnlFase5_cboBloqueio.Text;
                        juridico_dto.Instancia = pnlFase5_cboInstancia.Text;
                        juridico_dto.Status = pnlFase5_cboStatus.Text;
                        juridico_dto.DataEntregaAdvogado = FormFuncoes.GetMskDate(pnlFase5_mskDataEntregaAdvogado);
                        juridico_dto.DataProtocolamento = FormFuncoes.GetMskDate(pnlFase5_mskDataProtocolamento);
                        break;
                    case 6:
                        juridico_dto.Resultado = pnlFase6_cboResultado.Text;
                        juridico_dto.DataFinalizacao = FormFuncoes.GetMskDate(pnlFase6_mskDataFinalizacao);
                        juridico_dto.DataLiberacaoSentenca = FormFuncoes.GetMskDate(pnlFase6_mskDataLiberacaoSentenca);
                        juridico_dto.DataSentencaProtocolada = FormFuncoes.GetMskDate(pnlFase6_mskSentencaProtocolada);
                        break;
                    case 7:
                        juridico_dto.Resultado = pnlFase7_cboResultado.Text;
                        juridico_dto.DataFinalizacao = FormFuncoes.GetMskDate(pnlFase7_mskDataFinalizacao);
                        break;
                }
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

        private void FrmCad_Juridico_Fases_Load(object sender, EventArgs e)
        {
            if (cboFase.Enabled)
                loadTela(Convert.ToInt32(cboFase.SelectedValue));
        }

        private void CboFase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboFase.SelectedValue != null)
                    loadTela(Convert.ToInt32(cboFase.SelectedValue));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadTela(int Fase)
        {
            switch (Fase)
            {
                case 1:
                    pnlFase1.Visible = true;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase1.Location = new System.Drawing.Point(12, 60);
                    gpbObservacao.Location = new System.Drawing.Point(13, 176);
                    this.Size = new Size(363, 454);
                    break;
                case 2:
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = true;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase2.Location = new System.Drawing.Point(12, 60);
                    gpbObservacao.Location = new System.Drawing.Point(13, 55);
                    this.Size = new Size(363, 315);
                    break;
                case 3:
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = true;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase3.Location = new System.Drawing.Point(12, 60);
                    gpbObservacao.Location = new System.Drawing.Point(13, 124);
                    this.Size = new Size(363, 396);
                    break;
                case 4:
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = true;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase4.Location = new System.Drawing.Point(12, 60);
                    gpbObservacao.Location = new System.Drawing.Point(13, 199);
                    this.Size = new Size(363, 466);
                    break;
                case 5:
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = true;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase5.Location = new System.Drawing.Point(12, 60);
                    gpbObservacao.Location = new System.Drawing.Point(13, 175);
                    this.Size = new Size(363, 446);

                    break;
                case 6:
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = true;
                    pnlFase7.Visible = false;
                    pnlFase6.Location = new System.Drawing.Point(12, 60);
                    gpbObservacao.Location = new System.Drawing.Point(13, 175);
                    this.Size = new Size(363, 446);

                    break;
                case 7:
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = true;
                    pnlFase7.Location = new System.Drawing.Point(12, 60);
                    gpbObservacao.Location = new System.Drawing.Point(13, 110);
                    this.Size = new Size(363, 386);

                    break;
                default:
                    break;
            }
        }

        private void TxtObservacao_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnConfirmar;
        }

        private void TxtObservacao_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void FrmCad_Juridico_Fases_SizeChanged(object sender, EventArgs e)
        {
            textBox1.Text = "Largura: " + this.Size.Width.ToString() + " - Altura: " + this.Size.Height.ToString();
        }

        private void GpbObservacao_LocationChanged(object sender, EventArgs e)
        {
            textBox2.Text = gpbObservacao.Location.Y.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            gpbObservacao.Location = new Point(gpbObservacao.Location.X, gpbObservacao.Location.Y - 1);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            gpbObservacao.Location = new Point(gpbObservacao.Location.X, gpbObservacao.Location.Y + 1);
        }
    }
}
