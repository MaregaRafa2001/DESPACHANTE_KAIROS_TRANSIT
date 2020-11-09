using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_UI
{
    public partial class frmCad_FormaPagamento : Form
    {
        public FORMA_PAGAMENTO_DTO FORMA_PAGAMENTO_DTO = null;
        FORMA_PAGAMENTO_BLL FORMA_PAGAMENTO_BLL = new FORMA_PAGAMENTO_BLL();
        List<PesquisaGeralDTO> ListaCampos = new List<PesquisaGeralDTO>();
        public frmCad_FormaPagamento(int ID)
        {
            InitializeComponent();
            if (ID == 0)
            {
                FORMA_PAGAMENTO_DTO = new FORMA_PAGAMENTO_DTO();
               
            }
            else
            {
                FORMA_PAGAMENTO_DTO = FORMA_PAGAMENTO_BLL.Selecione(ID);
                PopularDados();
                FORMA_PAGAMENTO_DTO.OPERACAO = SysDTO.Operacoes.Alteracao; 
            }
        }

        public void PopularDados()
        {
            //ENDEREÇO
            txtDescricao.Text = FORMA_PAGAMENTO_DTO.DESCRICAO;
        
        }


        public void AtualizaDTO()
        {
            try
            {
                //DADOS
                FORMA_PAGAMENTO_DTO.DESCRICAO = txtDescricao.Text;
               
            }
            catch (Exception EX)
            {

                throw EX;
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (ValidarDados())
                {
                    AtualizaDTO();

                    if (FORMA_PAGAMENTO_DTO.OPERACAO == SysDTO.Operacoes.Inclusao)
                    {
                        int? id = FORMA_PAGAMENTO_BLL.Set_FormaPagamento(FORMA_PAGAMENTO_DTO);
                        if (id > 0)
                        {
                           
                            MessageBox.Show("Forma de Pagamento inserida com sucesso!", "Forma de Pagamento inserida ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (FORMA_PAGAMENTO_DTO.OPERACAO == SysDTO.Operacoes.Alteracao)
                    {
                        if (FORMA_PAGAMENTO_BLL.Update_FormaPagamento(FORMA_PAGAMENTO_DTO))
                            MessageBox.Show("Forma de Pagamento Alterada com sucesso!", "Forma de Pagamento Alterada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao localizar o Cep", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidarDados()
        {
            try
            {
                if (txtDescricao.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Campo Descrição é Obrigatório!", "Descrição Obrigatória", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult escolha = MessageBox.Show("Tem a certeza que deseja sair?", "Mensagem do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (escolha == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
