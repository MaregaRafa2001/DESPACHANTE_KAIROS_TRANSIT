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
                cboForma_Pagamento.ValueMember = "ID";
                cboForma_Pagamento.DisplayMember = "DESCRICAO";
                cboForma_Pagamento.DataSource = new FORMA_PAGAMENTO_BLL().Lista_Forma_Pagamento();
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
            if (cboStatusPagamento.Text.ToLower() == "pago")
                cboStatusPagamento.Enabled = false;
            txtNumBolChe.Text = boleto_cheque.NUMERO;
            txtValor.Text = boleto_cheque.VALOR.ToString();
            if (boleto_cheque.ID_FORMA_PAGAMENTO != null)
                cboForma_Pagamento.SelectedValue = boleto_cheque.ID_FORMA_PAGAMENTO;
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
            boleto_cheque.STATUS_PAGAMENTO = Convert.ToString(cboStatusPagamento.Text);
            boleto_cheque.NUMERO = txtNumBolChe.Text;
            boleto_cheque.VALOR = Convert.ToDecimal(txtValor.Text);
            boleto_cheque.ID_FORMA_PAGAMENTO = Convert.ToInt32(cboForma_Pagamento.SelectedValue);
            boleto_cheque.FORMA_PAGAMENTO = cboForma_Pagamento.Text;
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
    }
}
