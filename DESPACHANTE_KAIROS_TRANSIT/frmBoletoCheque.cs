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

        public frmBoletoCheque(BOLETO_CHEQUE_DTO boleto_cheque)
        {
            InitializeComponent();

            this.boleto_cheque = boleto_cheque;
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
            mskDataVencimento.Text = DateTime.Now.ToShortDateString();
            cboStatusPagamento.Text = boleto_cheque.STATUS_PAGAMENTO;
            txtNumBolChe.Text = boleto_cheque.NUMERO;
            txtValor.Text = boleto_cheque.VALOR.ToString();
        }


        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
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

            boleto_cheque.DATA_VENCTO = FormFuncoes.IsDate(mskDataVencimento.Text) ? Convert.ToDateTime(mskDataVencimento.Text) : (DateTime?)null;
            boleto_cheque.STATUS_PAGAMENTO = Convert.ToString(cboStatusPagamento.Text);
            boleto_cheque.NUMERO = txtNumBolChe.Text;
            boleto_cheque.VALOR = Convert.ToDecimal(txtValor.Text);
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
    }
}
