using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace APP_UI
{
    public partial class frmCad_Documento : Form
    {
        DOCUMENTO_FINANCEIRO_DTO DOCUMENTO_FINANCEIRO_DTO;
        List<string> lista_erros = new List<string>();
        public frmCad_Documento(int ID = 0, int ID_FINANCEIRO = 0)
        {
            InitializeComponent();
            PopularCombos();

            if (ID == 0)
            {
                cboDocumento.Visible = true;
                txtDocumento.Visible = false;
                DOCUMENTO_FINANCEIRO_DTO = new DOCUMENTO_FINANCEIRO_DTO();
                DOCUMENTO_FINANCEIRO_DTO.ID_FINANCEIRO = ID_FINANCEIRO;
               
            }
            else
            {
                cboDocumento.Visible = false;
                txtDocumento.Visible = true;
                DOCUMENTO_FINANCEIRO_DTO = new DOCUMENTO_FINANCEIRO_BLL().Seleciona(ID);
                PopularDados();
                DOCUMENTO_FINANCEIRO_DTO.OPERACAO = SysDTO.Operacoes.Alteracao;
            }
        }

        void PopularCombos()
        {
            try
            {
                //INDICAÇAO
                cboDocumento.ValueMember = "Value";
                cboDocumento.DisplayMember = "Text";
                cboDocumento.DataSource = new FINANCEIRO_BLL().Lista_Documento();
                cboDocumento.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void PopularDados()
        {
            try
            {
                txtDocumento.Text = DOCUMENTO_FINANCEIRO_DTO.DOCUMENTO;
                mskDataEntrega.Text = DOCUMENTO_FINANCEIRO_DTO.DATA_ENTREGA.ToString();
                mskDataVencimento.Text = DOCUMENTO_FINANCEIRO_DTO.DATA_VENCIMENTO.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lista_erros.Count > 0)
                {
                    MessageBox.Show("Ajuste o(s) erro(s) informado(s) na parte inferior da tela.", "Erro ao registrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AtualizaDTO();

                if (DOCUMENTO_FINANCEIRO_DTO.OPERACAO == SysDTO.Operacoes.Inclusao)
                {
                    int? id = new DOCUMENTO_FINANCEIRO_BLL().Set_DOCUMENTO_FINANCEIRO(DOCUMENTO_FINANCEIRO_DTO);
                    if (id > 0)
                    {
                        MessageBox.Show("Documento incluído com sucesso", "Documento incluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar documento", "Erro ao incluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (DOCUMENTO_FINANCEIRO_DTO.OPERACAO == SysDTO.Operacoes.Alteracao)
                {
                    bool update = new DOCUMENTO_FINANCEIRO_BLL().Update_DOCUMENTO_FINANCEIRO(DOCUMENTO_FINANCEIRO_DTO);
                    if (update)
                    {
                        MessageBox.Show("Documento alterado com sucesso", "Documento alterado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao alterar documento", "Erro ao alterar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao registrar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AtualizaDTO()
        {
            try
            {
                DOCUMENTO_FINANCEIRO_DTO.DATA_ENTREGA = (FormFuncoes.IsDate(mskDataEntrega.Text) ? Convert.ToDateTime(mskDataEntrega.Text) : (DateTime?)null);
                DOCUMENTO_FINANCEIRO_DTO.DATA_VENCIMENTO = (FormFuncoes.IsDate(mskDataVencimento.Text) ? Convert.ToDateTime(mskDataVencimento.Text) : (DateTime?)null);
                DOCUMENTO_FINANCEIRO_DTO.ID_DOCUMENTO = DOCUMENTO_FINANCEIRO_DTO.OPERACAO == SysDTO.Operacoes.Inclusao ? Convert.ToInt32(cboDocumento.SelectedValue) : DOCUMENTO_FINANCEIRO_DTO.ID_DOCUMENTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Validar Dados
        private void ExibeMensagemErro(string Erro = "", bool limparErro = false)
        {
            try
            {
                if (!limparErro && !lista_erros.Exists(erro => erro == Erro))
                {
                    lista_erros.Add(Erro);
                }
                else if (limparErro && lista_erros.Exists(erro => erro == Erro))
                {
                    lista_erros.RemoveAll(erro => erro == Erro);
                }

                if (lista_erros.Count == 0)
                {
                    tslErro.Visible = false;
                    tslErro.Text = "";
                }
                else
                {
                    tslErro.Visible = true;
                    tslErro.Text = lista_erros.LastOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MskDataEntrega_Leave(object sender, EventArgs e)
        {
            try
            {
                if (mskDataEntrega.Text.Replace("_", "").Replace("/", "").Trim().Length > 0 && !FormFuncoes.IsDate(mskDataEntrega.Text))
                {
                    ExibeMensagemErro("Data de entrega inválida");
                }
                else
                {
                    ExibeMensagemErro("Data de entrega inválida", true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao validar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MskDataVencimento_Leave(object sender, EventArgs e)
        {
            try
            {
                if (mskDataVencimento.Text.Replace("_", "").Replace("/", "").Trim().Length > 0 && !FormFuncoes.IsDate(mskDataVencimento.Text))
                {
                    ExibeMensagemErro("Data de vencimento inválida");
                }
                else
                {
                    ExibeMensagemErro("Data de vencimento inválida", true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao validar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
