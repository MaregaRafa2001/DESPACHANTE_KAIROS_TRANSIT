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
                List<ComboItemDTO> Lista_Status = new STATUS_FINANCEIRO_BLL().Lista_Status();

                cboStatusPagamento.ValueMember = "value";
                cboStatusPagamento.DisplayMember = "text";
                cboStatusPagamento.DataSource = Lista_Status;
                cboStatusPagamento.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        void PopularDados()
        {
            txtParcela.Text = boleto_cheque.PARCELA.ToString();
            //if (boleto_cheque.DATA_VENCTO != null)
            mskDataVencimento.Text = DateTime.Now.ToShortDateString();
            cboStatusPagamento.SelectedValue = boleto_cheque.ID_STATUS_PAGAMENTO == null? 0 : boleto_cheque.ID_STATUS_PAGAMENTO;
            txtNumBolChe.Text = boleto_cheque.NUMERO;

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
            boleto_cheque.ID_STATUS_PAGAMENTO = Convert.ToInt32(cboStatusPagamento.SelectedValue);
            boleto_cheque.NUMERO = txtNumBolChe.Text;
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


    }
}
