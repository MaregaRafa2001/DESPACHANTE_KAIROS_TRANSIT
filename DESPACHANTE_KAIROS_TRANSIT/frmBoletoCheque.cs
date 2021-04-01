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
    public partial class frmBoletoCheque : Form
    {


        public BOLETO_CHEQUE_DTO boleto_cheque = new BOLETO_CHEQUE_DTO();
        decimal ValorDisponivel;

        public frmBoletoCheque(BOLETO_CHEQUE_DTO boleto_cheque, decimal ValorDisponivel, bool LastParcela)
        {
            InitializeComponent();
            this.ValorDisponivel = ValorDisponivel;
            this.boleto_cheque = boleto_cheque;
            if (LastParcela)
                txtValor.ReadOnly = true;
            if (this.boleto_cheque.OPERACAO != SysDTO.Operacoes.Inclusao)
            {
                txtValor.ReadOnly = true;
                cboForma_Pagamento.Enabled = false;
                mskDataVencimento.ReadOnly = true;
            }
            PopularCombos();
            PopularDados();
        }



        void PopularCombos()
        {
            try
            {
                List<ComboItemDTO> Lista_Status = new List<ComboItemDTO>();
                Lista_Status.Add(new ComboItemDTO() { Text = "Pendente", Value = "Pendente" });
                Lista_Status.Add(new ComboItemDTO() { Text = "Atrasado", Value = "Atrasado" });
                Lista_Status.Add(new ComboItemDTO() { Text = "Pago", Value = "Pago" });

                cboStatusPagamento.ValueMember = "value";
                cboStatusPagamento.DisplayMember = "text";
                cboStatusPagamento.DataSource = Lista_Status;
                cboStatusPagamento.SelectedIndex = 0;

                //Forma pagamento
                List<FORMA_PAGAMENTO_DTO> Lista_FormaPagamento = new FORMA_PAGAMENTO_BLL().Lista_Forma_Pagamento();

                cboForma_Pagamento.ValueMember = "ID";
                cboForma_Pagamento.DisplayMember = "DESCRICAO";
                cboForma_Pagamento.DataSource = Lista_FormaPagamento;
                cboForma_Pagamento.SelectedIndex = -1;

                //Forma pagamento juros
                List<FORMA_PAGAMENTO_DTO> NewLista_FormaPagamento = new List<FORMA_PAGAMENTO_DTO>();
                NewLista_FormaPagamento.AddRange(Lista_FormaPagamento);
                NewLista_FormaPagamento.Insert(0, new FORMA_PAGAMENTO_DTO() { DESCRICAO = "Nenhum", ID = null });
                cboFormaPagamentoJuros.ValueMember = "ID";
                cboFormaPagamentoJuros.DisplayMember = "DESCRICAO";
                cboFormaPagamentoJuros.DataSource = NewLista_FormaPagamento;
                cboForma_Pagamento.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        void PopularDados()
        {
            txtParcela.Text = boleto_cheque.PARCELA.ToString();
            mskDataVencimento.Text = (boleto_cheque.DATA_VENCTO == null ? "" : boleto_cheque.DATA_VENCTO.Value.ToShortDateString());
            cboStatusPagamento.Text = boleto_cheque.STATUS_PAGAMENTO;
            txtCobranca.Text = boleto_cheque.COBRANCA == null ? "" : boleto_cheque.COBRANCA.ToString();
            mskDataProtesto.Text = (boleto_cheque.DATA_PROTESTO == null ? "" : boleto_cheque.DATA_PROTESTO.Value.ToShortDateString());
            mskCartaAnuencia.Text = (boleto_cheque.CARTA_ANUENCIA == null ? "" : boleto_cheque.CARTA_ANUENCIA.Value.ToShortDateString());
            txtCartorio.Text = boleto_cheque.CARTORIO == null ? "" : boleto_cheque.CARTORIO.ToString();
            if (cboStatusPagamento.Text.ToLower() == "pago")
            {
                cboStatusPagamento.Enabled = false;
                txtValor.ReadOnly = true;
            }
            txtNumBolChe.Text = boleto_cheque.NUMERO;
            txtValor.Text = boleto_cheque.VALOR.ToString();
            txtValorJuros.Text = boleto_cheque.VALOR_JUROS.ToString();
            mskDataPagamento.Text = boleto_cheque.DATA_PAGAMENTO.ToString();
            
            if (boleto_cheque.ID_FORMA_PAGAMENTO != null)
                cboForma_Pagamento.SelectedValue = boleto_cheque.ID_FORMA_PAGAMENTO;

            if (boleto_cheque.ID_FORMA_PAGAMENTO_JUROS != null)
                cboFormaPagamentoJuros.SelectedValue = boleto_cheque.ID_FORMA_PAGAMENTO_JUROS;
        }


        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtValor.Text) > ValorDisponivel)
                {
                    MessageBox.Show("O valor da parcela não pode ser maior do que o valor total disponível", "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValor.Focus();
                    return;
                }

                AtualizaDTO();
                ValidarDados();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Campos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        void AtualizaDTO()
        {
            if (boleto_cheque.STATUS_PAGAMENTO.ToLower() != "pago" && cboStatusPagamento.Text.ToLower() == "pago")
                boleto_cheque.GeraComprovante = true;
            boleto_cheque.DATA_VENCTO = FormFuncoes.IsDate(mskDataVencimento.Text) ? Convert.ToDateTime(mskDataVencimento.Text) : (DateTime?)null;
            boleto_cheque.DATA_PAGAMENTO = FormFuncoes.IsDate(mskDataPagamento.Text) ? Convert.ToDateTime(mskDataPagamento.Text) : (DateTime?)null;
            boleto_cheque.STATUS_PAGAMENTO = Convert.ToString(cboStatusPagamento.Text);
            boleto_cheque.NUMERO = txtNumBolChe.Text;
            boleto_cheque.VALOR = Convert.ToDecimal(txtValor.Text);
            boleto_cheque.VALOR_JUROS = Convert.ToDecimal(txtValorJuros.Text);
            boleto_cheque.ID_FORMA_PAGAMENTO = Convert.ToInt32(cboForma_Pagamento.SelectedValue);
            boleto_cheque.FORMA_PAGAMENTO = cboForma_Pagamento.Text;
            boleto_cheque.ID_FORMA_PAGAMENTO_JUROS = Convert.ToInt32(cboFormaPagamentoJuros.SelectedValue);
            boleto_cheque.FORMA_PAGAMENTO_JUROS = cboFormaPagamentoJuros.Text;
            boleto_cheque.COBRANCA = Convert.ToString(txtCobranca.Text);
            boleto_cheque.DATA_PROTESTO = FormFuncoes.IsDate(mskDataProtesto.Text) ? Convert.ToDateTime(mskDataProtesto.Text) : (DateTime?)null;
            boleto_cheque.CARTA_ANUENCIA = FormFuncoes.IsDate(mskCartaAnuencia.Text) ? Convert.ToDateTime(mskCartaAnuencia.Text) : (DateTime?)null;
            boleto_cheque.CARTORIO = Convert.ToString(txtCobranca.Text);
        }

        void ValidarDados()
        {
            if (boleto_cheque.PARCELA == null || boleto_cheque.PARCELA == 0)
                throw new CustomException("Parcela não preenchida. Tente recarregar a tela", "Dados incorretos");
            if (boleto_cheque.STATUS_PAGAMENTO == null || boleto_cheque.PARCELA == 0)
                throw new CustomException("Favor informe o status do pagamento", "Dados incorretos");
            if (!FormFuncoes.IsDate(boleto_cheque.DATA_VENCTO.ToString()))
                throw new CustomException("Favor informe a data de vencimento", "Dados incorretos");
            if (string.IsNullOrEmpty(boleto_cheque.STATUS_PAGAMENTO.ToString()) || boleto_cheque.STATUS_PAGAMENTO.ToString() == "0")
                throw new CustomException("Favor informe o status de pagamento", "Dados incorretos");
            if (boleto_cheque.ID_FORMA_PAGAMENTO == null || boleto_cheque.ID_FORMA_PAGAMENTO == 0)
                throw new CustomException("Favor informe a forma de pagamento", "Dados incorretos");
        }

        private void TxtValor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GLOBAL_FORMS.Moeda(ref txtValor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtValorJuros_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GLOBAL_FORMS.Moeda(ref txtValorJuros);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblBoletoCheque_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
