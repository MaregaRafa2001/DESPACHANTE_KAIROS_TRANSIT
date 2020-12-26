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
        public ADMINISTRACAO_DTO administracao_dto;
        int ID_SERVICO;

        string ObservacaoClone = "";
        public frmCad_Administracao_Fases(ADMINISTRACAO_DTO administracao_dto, int ID_SERVICO)
        {
            InitializeComponent();
            this.ID_SERVICO = ID_SERVICO;
            PopularCombos();
            this.administracao_dto = administracao_dto;
            if (this.administracao_dto.ID != null)
            {
                PopularDados();
                cboFase.Enabled = false;
            }
            else
            {
                Random random = new Random();
                this.administracao_dto.ID = random.Next();
                tabControl1.TabPages.Remove(tabDetalhe);
            }
        }

        void PopularCombos()
        {
            try
            {
                cboFase.SelectedIndexChanged -= cboFase_SelectedIndexChanged;
                List<FASE_FINANCEIRO_DTO> Lista_fases = new ADMINISTRACAO_BLL().Listar_FaseFinanceiro(ID_SERVICO);
                if (Lista_fases.Count() == 0)
                {
                    throw new CustomException("Não foi identificado nenhuma fase para este serviço. Entre em contato com o suporte do sistema." + (administracao_dto == null ? "" : "\nID do registro: " + administracao_dto.ID), "Erro ao carregar fases");
                }
                cboFase.ValueMember = "LAYOUT_TELA";
                cboFase.DisplayMember = "DESCRICAO";
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
            cboFase.SelectedValue = administracao_dto.LAYOUT_TELA;
            lblDescricao.Text = administracao_dto.OBSERVACAO;
            ObservacaoClone = administracao_dto.OBSERVACAO;

            if (cboFase.SelectedValue == null)
            {
                throw new Exception("Não foi possível localizar a fase selecionada. Entre em contato com o suporte do sistema. \r\nID do registro: " + administracao_dto.ID);
            }

            loadTela(Convert.ToInt32(cboFase.SelectedValue));
            //POPULA A TELA COM O LAYOUT DA FASE
            switch (Convert.ToInt32(cboFase.SelectedValue))
            {
                case 1://BEM VINDO
                    Layout1_mskDataRecebimento.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_RECEBIMENTO_CONTRATO);
                    break;
                case 2://DOCUMENTAÇÃO
                    break;
                case 3://CORRESPÔNDENCIA
                    break;
                case 4://MONTAGEM
                    Layout4_mskDataMontagemProcesso.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_MONTAGEM_PROCESSO);
                    break;
                case 5://PROCURADORIA DETRAN
                    Layout5_mskIda.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_IDA_DETRAN);
                    Layout5_mskRetorno.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_RETORNO_DETRAN);
                    Layout5_mskProcurador.Text = administracao_dto.PROCURADOR;
                    Layout5_mskInicio.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_INICIO);
                    Layout5_mskTermino.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_TERMINO);
                    Layout5_txtMesesDetran.Text = administracao_dto.MESES_DETRAN == (int?)null ? "0" : administracao_dto.MESES_DETRAN.ToString();

                    if (administracao_dto.RECONHECER_FIRMA == null || administracao_dto.RECONHECER_FIRMA == 'N')
                        radNenhum.Checked = true;
                    else if (administracao_dto.RECONHECER_FIRMA == 'S')
                        radSemelhanca.Checked = true;
                    else
                        radAutenticidade.Checked = true;

                    break;
                case 6://PÓS VENDA \ CURSO DE CFC
                    Layout6_mskFechamentoCurso.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_FECHAMENTO_CURSO);
                    Fase6_cbRecebimentoAuto.Checked = administracao_dto.RECEBIMENTO_AUTO == null ? false : Convert.ToBoolean(administracao_dto.RECEBIMENTO_AUTO);
                    Fase6_cbCursoFora.Checked = administracao_dto.CURSO_FORA == null ? false : Convert.ToBoolean(administracao_dto.CURSO_FORA);
                    break;
                case 7://AUTO ESCOLA
                    Layout7_mskDigital1.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_DIGITAL_1);
                    Fase7_mskDigital2.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_DIGITAL_2);
                    Fase7_mskRecebimentoCertificado.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_RECEBIMENTO_CERTIFICADO);
                    Layout7_txtAutoEscola.Text = administracao_dto.AUTO_ESCOLA;
                    break;
                case 8://FINALIZAÇÃO
                    Layout8_mskDataFinalizacao.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_FINALIZACAO);
                    Layout8_mskDataBaixaDePontos.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_BAIXA_DE_PONTOS);
                    break;
                case 9://CADASTRO DETRAN
                    Layout9_mskDataAgendamento.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_AGENDAMENTO);
                    break;
                //case 10://CURSO DE CFC
                //    break;
                case 11://TEÓRICO DETRAN
                    Layout11_mskDataRecebimento.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_AGENDAMENTO_TEORICODETRAN);
                    break;
                case 12://PRÁTICO AUTO-ESCOLA
                    Layout12_mskDataAgendamento.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_AGENDAMENTO);
                    Layout12_mskDataCategoria1.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_CATEGORIA_1);
                    Layout12_mskDataCategoria2.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_CATEGORIA_2);
                    break;
                case 13://FINALIZAÇÃO ENTREGA CNH
                    Layout13_mskDataEmissao.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_EMISSAO);
                    Layout13_mskDataEntrega.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_ENTREGA);
                    Layout13_RetiradoPor.Text = administracao_dto.RETIRADO_POR;
                    break;

                case 14://PROCURADORIA DETRAN
                    Layout14_mskIda.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_IDA_DETRAN);
                    Layout14_mskRetorno.Text = FormFuncoes.PopularMskData(administracao_dto.DATA_RETORNO_DETRAN);
                    Layout14_mskProcurador.Text = administracao_dto.PROCURADOR;
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

                administracao_dto.DATA = Convert.ToDateTime(DateTime.Now);
                administracao_dto.FASE = cboFase.Text.ToString();
                administracao_dto.LAYOUT_TELA = Convert.ToInt32(cboFase.SelectedValue);
                if (txtObservacao.Text.Trim().Length > 0)
                    administracao_dto.OBSERVACAO = lblDescricao.Text + "\r\n" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " (" + SysBLL.UserLogin.NOME + ") - " + txtObservacao.Text;

                switch (Convert.ToInt32(cboFase.SelectedValue))
                {
                    case 1://BEM VINDO
                        administracao_dto.DATA_RECEBIMENTO_CONTRATO = FormFuncoes.GetMskDate(Layout1_mskDataRecebimento);
                        break;
                    case 2://DOCUMENTAÇÃO
                        break;
                    case 3://CORRESPÔNDENCIA
                        break;
                    case 4://MONTAGEM
                        administracao_dto.DATA_MONTAGEM_PROCESSO = FormFuncoes.GetMskDate(Layout4_mskDataMontagemProcesso);
                        break;
                    case 5://PROCURADORIA DETRAN
                        administracao_dto.DATA_IDA_DETRAN = FormFuncoes.GetMskDate(Layout5_mskIda);
                        administracao_dto.DATA_RETORNO_DETRAN = FormFuncoes.GetMskDate(Layout5_mskRetorno);
                        administracao_dto.PROCURADOR = Layout5_mskProcurador.Text;
                        administracao_dto.DATA_INICIO = FormFuncoes.GetMskDate(Layout5_mskInicio);
                        administracao_dto.DATA_TERMINO = FormFuncoes.GetMskDate(Layout5_mskTermino);
                        administracao_dto.MESES_DETRAN = string.IsNullOrEmpty(Layout5_txtMesesDetran.Text) ? (int?)null : Convert.ToInt32(Layout5_txtMesesDetran.Text);
                        administracao_dto.RECONHECER_FIRMA = radNenhum.Checked ? 'N' : radAutenticidade.Checked ? 'A' : 'S';

                        break;
                    case 6://PÓS VENDA \ CURSO DE CFC
                        administracao_dto.DATA_FECHAMENTO_CURSO = FormFuncoes.GetMskDate(Layout6_mskFechamentoCurso);
                        administracao_dto.RECEBIMENTO_AUTO = Fase6_cbRecebimentoAuto.Checked;
                        administracao_dto.CURSO_FORA = Fase6_cbCursoFora.Checked;
                        break;
                    case 7://AUTO ESCOLA
                        administracao_dto.DATA_DIGITAL_1 = FormFuncoes.GetMskDate(Layout7_mskDigital1);
                        administracao_dto.DATA_DIGITAL_2 = FormFuncoes.GetMskDate(Fase7_mskDigital2);
                        administracao_dto.DATA_RECEBIMENTO_CERTIFICADO = FormFuncoes.GetMskDate(Fase7_mskRecebimentoCertificado);
                        administracao_dto.AUTO_ESCOLA = Layout7_txtAutoEscola.Text;
                        break;
                    case 8://FINALIZAÇÃO
                        administracao_dto.DATA_FINALIZACAO = FormFuncoes.GetMskDate(Layout8_mskDataFinalizacao);
                        administracao_dto.DATA_BAIXA_DE_PONTOS = FormFuncoes.GetMskDate(Layout8_mskDataBaixaDePontos);
                        break;
                    case 9://CADASTRO DETRAN
                        administracao_dto.DATA_AGENDAMENTO = FormFuncoes.GetMskDate(Layout9_mskDataAgendamento);
                        break;
                    //case 10://CURSO DE CFC
                    //    break;
                    case 11://TEÓRICO DETRAN
                        administracao_dto.DATA_AGENDAMENTO_TEORICODETRAN = FormFuncoes.GetMskDate(Layout11_mskDataRecebimento);
                        break;
                    case 12://PRÁTICO AUTO-ESCOLA
                        administracao_dto.DATA_AGENDAMENTO = FormFuncoes.GetMskDate(Layout12_mskDataAgendamento);
                        administracao_dto.DATA_CATEGORIA_1 = FormFuncoes.GetMskDate(Layout12_mskDataCategoria1);
                        administracao_dto.DATA_CATEGORIA_2 = FormFuncoes.GetMskDate(Layout12_mskDataCategoria2);
                        break;
                    case 13://FINALIZAÇÃO ENTREGA CNH
                        administracao_dto.DATA_EMISSAO = FormFuncoes.GetMskDate(Layout13_mskDataEmissao);
                        administracao_dto.DATA_ENTREGA = FormFuncoes.GetMskDate(Layout13_mskDataEntrega);
                        administracao_dto.RETIRADO_POR = Layout13_RetiradoPor.Text;
                        break;
                    default:
                        break;
                    case 14://PROCURADORIA DETRAN
                        administracao_dto.DATA_IDA_DETRAN = FormFuncoes.GetMskDate(Layout14_mskIda);
                        administracao_dto.DATA_RETORNO_DETRAN = FormFuncoes.GetMskDate(Layout14_mskRetorno);
                        administracao_dto.PROCURADOR = Layout14_mskProcurador.Text;
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

        private void TxtObservacao_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnConfirmar;
        }

        private void FrmCad_Financeiro_Fases_Load(object sender, EventArgs e)
        {
            if (cboFase.Enabled)
                loadTela(Convert.ToInt32(cboFase.SelectedValue));
            PopularGrid();
        }

        void PopularGrid()
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("SELECT * FROM VW_DOCUMENTO WHERE ID_FINANCEIRO_INVISIBLE = " + administracao_dto.ID_FINANCEIRO + " ORDER BY DOCUMENTO DESC");

                //Monta o grid e recupera as colunas utilizadas para pesquisa
                DataTable dtt = new PesquisaGeralBLL().Pesquisa(sbSql.ToString());
                dtgDadosDocumento.DataSource = dtt; //Vincula o datatable ao datagrid
                dtgDadosDocumento.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); //Redimenciona as colunas de acordo com o conteúdo do campo
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFase_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTela(Convert.ToInt32(cboFase.SelectedValue));
        }

        public void loadTela(int Fase)
        {
            switch (Fase)
            {

                case 1: //BEM VINDO
                    pnlFase1.Visible = true;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase8.Visible = false;
                    pnlLayout9.Visible = false;
                    pnlLayout11.Visible = false;
                    pnlLayout12.Visible = false;
                    pnlLayout13.Visible = false;
                    pnlFase14.Visible = false;
                    pnlFase1.Location = new System.Drawing.Point(6, 50);
                    gpbObservacao.Location = new System.Drawing.Point(13, 132);
                    this.Size = new System.Drawing.Size(402, 397);
                    break;

                case 2:  //DOCUMENTAÇÃO
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = true;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase8.Visible = false;
                    pnlLayout9.Visible = false;
                    pnlLayout11.Visible = false;
                    pnlLayout12.Visible = false;
                    pnlLayout13.Visible = false;
                    pnlFase14.Visible = false;
                    pnlFase2.Location = new System.Drawing.Point(6, 50);
                    this.Size = new System.Drawing.Size(402, 314);
                    gpbObservacao.Location = new System.Drawing.Point(13, 50);
                    break;
                case 3:  //CORRESPÔNDENCIA
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = true;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase8.Visible = false;
                    pnlLayout9.Visible = false;
                    pnlLayout11.Visible = false;
                    pnlLayout12.Visible = false;
                    pnlLayout13.Visible = false;
                    pnlFase14.Visible = false;
                    pnlFase3.Location = new System.Drawing.Point(6, 50);
                    this.Size = new System.Drawing.Size(402, 487);
                    gpbObservacao.Location = new System.Drawing.Point(13, 222);
                    break;
                case 4: //MONTAGEM
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = true;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase8.Visible = false;
                    pnlLayout9.Visible = false;
                    pnlLayout11.Visible = false;
                    pnlLayout12.Visible = false;
                    pnlLayout13.Visible = false;
                    pnlFase14.Visible = false;
                    pnlFase4.Location = new System.Drawing.Point(6, 50);
                    this.Size = new System.Drawing.Size(402, 397);
                    gpbObservacao.Location = new System.Drawing.Point(13, 132);
                    break;
                case 5: //PROCURADORIA DETRAN
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = true;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase8.Visible = false;
                    pnlLayout9.Visible = false;
                    pnlLayout11.Visible = false;
                    pnlLayout12.Visible = false;
                    pnlLayout13.Visible = false;
                    pnlFase14.Visible = false;
                    pnlFase5.Location = new System.Drawing.Point(6, 50);
                    this.Size = new System.Drawing.Size(402, 503);
                    gpbObservacao.Location = new System.Drawing.Point(13, 232);
                    break;
                case 6: //PÓS VENDA  / CURSO DE CFC
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = true;
                    pnlFase7.Visible = false;
                    pnlFase8.Visible = false;
                    pnlLayout9.Visible = false;
                    pnlLayout11.Visible = false;
                    pnlLayout12.Visible = false;
                    pnlLayout13.Visible = false;
                    pnlFase14.Visible = false;
                    pnlFase6.Location = new System.Drawing.Point(6, 50);
                    this.Size = new System.Drawing.Size(402, 397);
                    gpbObservacao.Location = new System.Drawing.Point(13, 132);
                    break;
                case 7: //AUTO ESCOLA
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = true;
                    pnlFase8.Visible = false;
                    pnlLayout9.Visible = false;
                    pnlLayout11.Visible = false;
                    pnlLayout12.Visible = false;
                    pnlLayout13.Visible = false;
                    pnlFase14.Visible = false;
                    pnlFase7.Location = new System.Drawing.Point(6, 50);
                    this.Size = new System.Drawing.Size(402, 455);
                    gpbObservacao.Location = new System.Drawing.Point(13, 184);
                    break;
                case 8: //FINALIZAÇÃO
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase8.Visible = true;
                    pnlLayout9.Visible = false;
                    pnlLayout11.Visible = false;
                    pnlLayout12.Visible = false;
                    pnlLayout13.Visible = false;
                    pnlFase14.Visible = false;
                    pnlFase8.Location = new System.Drawing.Point(6, 50);
                    this.Size = new System.Drawing.Size(402, 395);
                    gpbObservacao.Location = new System.Drawing.Point(13, 125);
                    break;
                case 9: //CADASTRO DETRAN
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase8.Visible = false;
                    pnlLayout9.Visible = true;
                    pnlLayout11.Visible = false;
                    pnlLayout12.Visible = false;
                    pnlLayout13.Visible = false;
                    pnlFase14.Visible = false;

                    pnlLayout9.Location = new System.Drawing.Point(6, 50);
                    this.Size = new System.Drawing.Size(402, 397);
                    gpbObservacao.Location = new System.Drawing.Point(13, 132);
                    break;
                case 11: //TEÓRICO DETRAN
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase8.Visible = false;
                    pnlLayout9.Visible = false;
                    pnlLayout11.Visible = true;
                    pnlLayout12.Visible = false;
                    pnlLayout13.Visible = false;
                    pnlFase14.Visible = false;

                    pnlLayout11.Location = new System.Drawing.Point(6, 50);
                    this.Size = new System.Drawing.Size(402, 397);
                    gpbObservacao.Location = new System.Drawing.Point(13, 132);
                    break;
                case 12: //PRÁTICO AUTO-ESCOLA
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase8.Visible = false;
                    pnlLayout9.Visible = false;
                    pnlLayout11.Visible = false;
                    pnlLayout12.Visible = true;
                    pnlLayout13.Visible = false;
                    pnlFase14.Visible = false;

                    pnlLayout12.Location = new System.Drawing.Point(6, 50);
                    this.Size = new System.Drawing.Size(402, 455);
                    gpbObservacao.Location = new System.Drawing.Point(13, 184);
                    break;
                case 13: //FINALIZAÇÃO ENTREGA CNH
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase8.Visible = false;
                    pnlLayout9.Visible = false;
                    pnlLayout11.Visible = false;
                    pnlLayout12.Visible = false;
                    pnlLayout13.Visible = true;
                    pnlFase14.Visible = false;

                    pnlLayout13.Location = new System.Drawing.Point(6, 50);
                    this.Size = new System.Drawing.Size(402, 455);
                    gpbObservacao.Location = new System.Drawing.Point(13, 184);
                    break;

                case 14: //FINALIZAÇÃO ENTREGA CNH
                    pnlFase1.Visible = false;
                    pnlFase2.Visible = false;
                    pnlFase3.Visible = false;
                    pnlFase4.Visible = false;
                    pnlFase5.Visible = false;
                    pnlFase6.Visible = false;
                    pnlFase7.Visible = false;
                    pnlFase8.Visible = false;
                    pnlLayout9.Visible = false;
                    pnlLayout11.Visible = false;
                    pnlLayout12.Visible = false;
                    pnlLayout13.Visible = false;
                    pnlFase14.Visible = true;

                    pnlFase14.Location = new System.Drawing.Point(6, 50);
                    gpbObservacao.Location = new System.Drawing.Point(13, 132);
                    this.Size = new System.Drawing.Size(402, 397);
                    break;
            }
        }

        private void PicVisualizarObservacao_Click(object sender, EventArgs e)
        {
            try
            {
                frmObservacoes frmObservacoes = new frmObservacoes(administracao_dto.OBSERVACAO);
                frmObservacoes.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtgDadosDocumento_DoubleClick(object sender, EventArgs e)
        {
            TsbDocEdit_Click(sender, e);
        }

        private void TsbDocAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmCad_Documento frmCad_Documento = new frmCad_Documento(0, administracao_dto.ID_FINANCEIRO);
                DialogResult result = frmCad_Documento.ShowDialog();
                if (result == DialogResult.OK)
                    PopularGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não foi possível incluir o registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbDocEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //Setando o mousepointer para ocupado.
                Cursor.Current = Cursors.WaitCursor;

                //Verifica se existem registros no datagrid
                if (dtgDadosDocumento.RowCount == 0)
                {
                    return;
                }

                //Visualizando o registro selecionado
                int Id = Convert.ToInt32(dtgDadosDocumento.CurrentRow.Cells["ID"].Value.ToString());
                if (Id != 0)
                {
                    frmCad_Documento frmCad_Documento = new frmCad_Documento(Id, administracao_dto.ID_FINANCEIRO);
                    DialogResult result = frmCad_Documento.ShowDialog();
                    if (result == DialogResult.OK)
                        PopularGrid();
                }
                else
                {
                    throw new Exception("O Id do registro selecionado está incorreto!");
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
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void TsbDocDel_Click(object sender, EventArgs e)
        {
            try
            {
                //Setando o mousepointer para ocupado.
                Cursor.Current = Cursors.WaitCursor;

                //Verifica se existem registros no datagrid
                if (dtgDadosDocumento.RowCount == 0)
                {
                    return;
                }

                //Visualizando o registro selecionado
                int Id = Convert.ToInt32(dtgDadosDocumento.CurrentRow.Cells["ID"].Value.ToString());
                if (Id != 0)
                {
                    DialogResult messageResult = MessageBox.Show("Tem certeza que deseja excluir o registro " + Id + "?", "Exclusão", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (messageResult != DialogResult.Yes)
                        return;
                    bool result = new DOCUMENTO_FINANCEIRO_BLL().Excluir(Id);
                    if (result)
                    {
                        MessageBox.Show("Registro excluído com sucesso", "Registro excluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PopularGrid();
                    }
                }
                else
                {
                    throw new Exception("O Id do registro selecionado está incorreto!");
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
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

      
    }
}
