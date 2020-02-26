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
    public partial class frmCad_Administracao : Form
    {
        List<FASE_FINANCEIRO_DTO> list_fase_financeiro_dto = new List<FASE_FINANCEIRO_DTO>();
        FINANCEIRO_DTO financeiro_dto;
        mdi_principal mdi_Principal;
        public frmCad_Administracao(int ID, mdi_principal mdi_Principal)
        {
            InitializeComponent();
            this.mdi_Principal = mdi_Principal;
            this.financeiro_dto = new FINANCEIRO_BLL().Seleciona_Financeiro_By_Id(ID);
            PopularDadosCliente();
            PopularDadosFinanceiro();
        }

        void PopularDadosFinanceiro()
        {
            try
            {
                mskData.Text = financeiro_dto.DATA.ToString();
                txtStatus.Text = financeiro_dto.STATUS.DESCRICAO;
                txtServico.Text = financeiro_dto.SERVICO.NOME;
                txtValor.Text = financeiro_dto.VALOR.ToString();
                txtFormaPagamento.Text = financeiro_dto.FORMA_PAGAMENTO;
                txtNParcelas.Text = financeiro_dto.PARCELAS.ToString();
                list_fase_financeiro_dto = financeiro_dto.FASE_FINANCEIRO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void PopularDadosCliente()
        {
            txtCliente.Text = financeiro_dto.CLIENTE.NOME_COMPLETO;
            txtEmail.Text = financeiro_dto.CLIENTE.EMAIL;
            txtTelefone.Text = financeiro_dto.CLIENTE.TELEFONE;
            txtPontuacaoCNH.Text = financeiro_dto.CLIENTE.CNH_PONTUACAO == 1 ? financeiro_dto.CLIENTE.CNH_PONTUACAO + " ponto" : financeiro_dto.CLIENTE.CNH_PONTUACAO + " pontos";
            txtPortaria.Text = financeiro_dto.CLIENTE.PORTARIA == true ? "Sim" : "Não";
        }

        void PopularGrid()
        {
            try
            {
                List<FASE_FINANCEIRO_DTO> new_list_ = new List<FASE_FINANCEIRO_DTO>();
                var list_fase_financeiro = list_fase_financeiro_dto.OrderByDescending(x => x.DATA);
                foreach (var item in list_fase_financeiro)
                {
                    new_list_.Add(item);
                }
                DataTable dtt = ConvertToDataTable(new_list_);
                dtgDados.DataSource = null;
                dtgDados.DataSource = dtt;
                dtgDados.ClearSelection();
                foreach (DataGridViewColumn column in dtgDados.Columns)
                {
                    column.Visible = false;
                }
                dtgDados.Columns["DATA"].Visible = true;
                dtgDados.Columns["FASE"].Visible = true;
                GLOBAL_FORMS.AjustaGrid(dtgDados);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                FASE_FINANCEIRO_DTO fase_financeiro = new FASE_FINANCEIRO_DTO();
                frmCad_Administracao_Fases frmCad_Financeiro_Fases = new frmCad_Administracao_Fases(fase_financeiro);
                DialogResult result = frmCad_Financeiro_Fases.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fase_financeiro = frmCad_Financeiro_Fases.fase_financeiro_dto;
                    fase_financeiro.ID_FINANCEIRO = financeiro_dto.ID == null ? 0 : (int)financeiro_dto.ID;
                    fase_financeiro.OPERACAO = SysDTO.Operacoes.Inclusao;
                    list_fase_financeiro_dto.Add(fase_financeiro);
                    PopularGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDados.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um registro na linha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string Id = dtgDados.CurrentRow.Cells["Id"].Value.ToString();

                if (list_fase_financeiro_dto.Exists(x => x.ID.ToString() == Id))
                {
                    FASE_FINANCEIRO_DTO fase = list_fase_financeiro_dto.First(x => x.ID.ToString() == Id);
                    frmCad_Administracao_Fases frmCad_Financeiro_Fases = new frmCad_Administracao_Fases(fase);
                    DialogResult result = frmCad_Financeiro_Fases.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        foreach (FASE_FINANCEIRO_DTO fASE_FINANCEIRO in list_fase_financeiro_dto.FindAll(x => x.ID.ToString() == Id))
                        {
                            fASE_FINANCEIRO.DATA = fase.DATA;
                            fASE_FINANCEIRO.FASE = fase.FASE;
                            fASE_FINANCEIRO.OBSERVACAO = fASE_FINANCEIRO.OBSERVACAO;
                            fASE_FINANCEIRO.ID_FINANCEIRO = financeiro_dto.ID == null ? 0 : (int)financeiro_dto.ID;
                            if (fASE_FINANCEIRO.OPERACAO != SysDTO.Operacoes.Inclusao)
                                fASE_FINANCEIRO.OPERACAO = SysDTO.Operacoes.Alteracao;
                        }
                        PopularGrid();
                    }
                }
                else
                {
                    MessageBox.Show("Registro não encontrado. Por favor, reinicie o programa.\nCaso o erro insista, entre em contato com o administrador do sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDados.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um registro na linha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string Id = dtgDados.CurrentRow.Cells["Id"].Value.ToString();

                if (list_fase_financeiro_dto.Exists(x => x.ID.ToString() == Id))
                {
                    FASE_FINANCEIRO_DTO fase_financeiro = list_fase_financeiro_dto.Find(x => x.ID.ToString() == Id);
                    if (fase_financeiro.OPERACAO != SysDTO.Operacoes.Inclusao)
                        new FINANCEIRO_BLL().Excluir_FaseFinanceiro((int)fase_financeiro.ID);
                    list_fase_financeiro_dto.Remove(fase_financeiro);
                    PopularGrid();
                }
                else
                {
                    MessageBox.Show("Registro não encontrado. Por favor, reinicie o programa.\nCaso o erro insista, entre em contato com o administrador do sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                int result = new FINANCEIRO_BLL().Registrar_FaseFinanceiro(financeiro_dto.FASE_FINANCEIRO);
                if (result > 1)
                    MessageBox.Show("Foram incluídos/alterados " + result + " fases", "Registro concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Foi incluído/alterado " + result + " fase", "Registro concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCad_FinanceiroV2_Load(object sender, EventArgs e)
        {
            PopularGrid();

            if (financeiro_dto.ID != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT TOP (100) PERCENT ID, DATAHORA AS 'Data', USUARIO AS Usuário, ASSUNTO, HISTORICO,ID_REGISTRO ");
                sb.Append(" FROM LOG_SISTEMA WHERE (TABELA = N'FINANCEIRO') ");
                sb.Append(" and (id_registro = " + financeiro_dto.ID + ")");
                //Carregando o Histórico
                if (financeiro_dto.ID != 0)
                {
                    DataTable dtt = new PesquisaGeralBLL().Pesquisa(sb.ToString());

                    dtt.DefaultView.Sort = "Data Desc";
                    dtgHistorico.DataSource = dtt;
                    dtgHistorico.Columns["Historico"].Visible = false;
                    dtgHistorico.RowHeadersVisible = false;
                    dtgHistorico.Columns["id_registro"].Visible = false;
                    dtgHistorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
            }
            else
            {
                tabControl1.TabPages.Remove(tabHistórico);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            {
                DialogResult escolha = MessageBox.Show("Tem a certeza que deseja sair?", "Mensagem do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (escolha == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (financeiro_dto.ID_CLIENTE == 0)
                {
                    MessageBox.Show("Cliente não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmCad_Cliente frmCad_Cliente = new frmCad_Cliente(financeiro_dto.ID_CLIENTE);
                frmCad_Cliente.ShowDialog();
                financeiro_dto.CLIENTE = frmCad_Cliente.CLIENTE_DTO;
                PopularDadosCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFinanceiro_Click(object sender, EventArgs e)
        {
            try
            {
                if (financeiro_dto.ID == null || financeiro_dto.ID == 0)
                {
                    MessageBox.Show("Financeiro não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmCad_Financeiro frmCad_Financeiro = new frmCad_Financeiro((int)financeiro_dto.ID);
                frmCad_Financeiro.ShowDialog();
                financeiro_dto = frmCad_Financeiro.FINANCEIRO_DTO;
                financeiro_dto.CLIENTE = new CLIENTE_BLL().Selecione(financeiro_dto.ID_CLIENTE);
                PopularDadosCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtgHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgHistorico.Rows.Count != 0)
                {
                    string strAssunto = dtgHistorico.CurrentRow.Cells["Assunto"].Value.ToString();
                    StringBuilder stbDetalhes = new StringBuilder();
                    stbDetalhes.Append(strAssunto + "\r\n");
                    stbDetalhes.Append(string.Join("", Enumerable.Repeat("-", strAssunto.Length)) + "\r\n");
                    stbDetalhes.Append("Id do Registro: " + dtgHistorico.CurrentRow.Cells["ID_REGISTRO"].Value.ToString() + "\r\n");
                    stbDetalhes.Append("Usuário: " + dtgHistorico.CurrentRow.Cells["Usuário"].Value.ToString() + "\r\n");
                    stbDetalhes.Append("Data: " + dtgHistorico.CurrentRow.Cells["Data"].Value.ToString() + "\r\n");
                    stbDetalhes.Append("\r\n");
                    stbDetalhes.Append("---------- Dados" + (dtgHistorico.CurrentRow.Cells["Assunto"].Value.ToString() != "Criação" ? " Anteriores" : "") + ": ----------\r\n");
                    stbDetalhes.Append(dtgHistorico.CurrentRow.Cells["historico"].Value.ToString().Replace("|", "\r\n"));
                    stbDetalhes.Append("---------------------------------------\r\n");
                    stbDetalhes.Append("---------------------------------------\r\n");
                    stbDetalhes.Append("---------------------------------------\r\n");
                    txtMaisDetalhes.Text = stbDetalhes.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao mostrar detalhes do Histórico!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DtgDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnAlterar_Click(sender, e);
        }
    }
}
