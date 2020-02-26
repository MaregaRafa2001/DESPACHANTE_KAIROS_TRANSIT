using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace APP_UI
{
    public partial class frmCad_Financeiro : Form
    {

        List<FORMA_PAGAMENTO_DTO> lista_forma_pagamento = new List<FORMA_PAGAMENTO_DTO>();
        List<SERVICO_DTO> lista_servico = new List<SERVICO_DTO>();//VARIAVEL PARA SALVAR A LISTA DE SERVICOS TRAZIDAS DO BANCO

        public FINANCEIRO_DTO FINANCEIRO_DTO = null;
        bool SetWithNewCliente = false;
        FINANCEIRO_BLL FINANCEIRO_BLL = new FINANCEIRO_BLL();
        CLIENTE_DTO CLIENTE_DTO = null;
        List<BOLETO_CHEQUE_DTO> lista_boleto_cheque = new List<BOLETO_CHEQUE_DTO>();
        BOLETO_CHEQUE_DTO BOLETO_CHEQUE_SELECIONADO = new BOLETO_CHEQUE_DTO();
        int DIA_VENCTO_PADRAO = 1;

        public frmCad_Financeiro(int ID = 0, int ID_CLIENTE = 0)
        {
            try
            {
                InitializeComponent();
                lista_forma_pagamento = new FORMA_PAGAMENTO_BLL().Lista_Forma_Pagamento();
                PopularCombos();

                if (ID_CLIENTE > 0)
                {
                    CLIENTE_DTO = new CLIENTE_BLL().Selecione(ID_CLIENTE);
                    txtCliente.Text = CLIENTE_DTO.NOME_COMPLETO;
                    mskData.Text = DateTime.Now.ToShortDateString();
                }
                else if (ID_CLIENTE == -1)
                {
                    SetWithNewCliente = true;
                    txtCliente.Visible = false;
                    btnPesquisarAdvogado.Visible = false;
                    lblCliente.Visible = false;
                    CLIENTE_DTO = new CLIENTE_DTO();
                }

                if (ID == 0)
                {
                    FINANCEIRO_DTO = new FINANCEIRO_DTO();
                }

                else
                {
                    FINANCEIRO_DTO = FINANCEIRO_BLL.Seleciona(ID);
                    lista_boleto_cheque = new BOLETO_CHEQUE_BLL().Seleciona_by_Id_Financeiro(ID);

                    foreach (BOLETO_CHEQUE_DTO boleto_cheque in lista_boleto_cheque)
                        boleto_cheque.OPERACAO = SysDTO.Operacoes.Leitura;
                    PopularGrid();
                    PopularDados();
                    txtValor.ReadOnly = true;
                    FINANCEIRO_DTO.OPERACAO = SysDTO.Operacoes.Alteracao;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void PopularCombos()
        {
            try
            {
                //Forma pagamento
                cboForma_Pagamento.SelectedIndexChanged -= CboForma_Pagamento_SelectedIndexChanged;
                cboForma_Pagamento.ValueMember = "ID";
                cboForma_Pagamento.DisplayMember = "DESCRICAO";
                cboForma_Pagamento.DataSource = lista_forma_pagamento;
                cboForma_Pagamento.SelectedIndex = -1;
                cboForma_Pagamento.SelectedIndexChanged += CboForma_Pagamento_SelectedIndexChanged;

                //INDICAÇAO
                cboIndicacao.ValueMember = "ID";
                cboIndicacao.DisplayMember = "DESCRICAO";
                cboIndicacao.DataSource = new INDICACAO_BLL().Lista_indicacao();
                cboIndicacao.SelectedIndex = 0;

                //SERVICO
                cboServico.ValueMember = "ID";
                cboServico.DisplayMember = "NOME";
                lista_servico = new SERVICO_BLL().ListaServico(false);
                cboServico.DataSource = lista_servico;
                cboServico.SelectedIndex = -1;

                //STATUS
                cboStatus.ValueMember = "value";
                cboStatus.DisplayMember = "text";
                cboStatus.DataSource = new STATUS_FINANCEIRO_BLL().Lista_Status();
                cboStatus.SelectedIndex = -1;
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
                txtValor.Text = FINANCEIRO_DTO.VALOR.ToString();

                numQtdParcela.ValueChanged -= numQtdParcela_ValueChanged;
                numQtdParcela.Value = FINANCEIRO_DTO.PARCELAS;
                numQtdParcela.ValueChanged += numQtdParcela_ValueChanged;

                cboForma_Pagamento.SelectedIndexChanged -= CboForma_Pagamento_SelectedIndexChanged;
                cboForma_Pagamento.Text = FINANCEIRO_DTO.FORMA_PAGAMENTO;
                cboForma_Pagamento.SelectedIndexChanged += CboForma_Pagamento_SelectedIndexChanged;

                cboConsultor.Text = FINANCEIRO_DTO.CONSULTOR;

                txtObservacao.Text = FINANCEIRO_DTO.OBSERVACAO;

                CLIENTE_DTO = new CLIENTE_BLL().Selecione(FINANCEIRO_DTO.ID_CLIENTE);

                txtCliente.Text = CLIENTE_DTO.NOME_COMPLETO;

                cboIndicacao.Text = FINANCEIRO_DTO.INDICACAO;

                cboServico.SelectedValue = FINANCEIRO_DTO.ID_SERVICO;

                cboStatus.SelectedValue = FINANCEIRO_DTO.ID_STATUS;

                txtBanco.Text = FINANCEIRO_DTO.BANCO_OS;

                txtMotoboy_os.Text = FINANCEIRO_DTO.MOTOBOY_OS;

                txtLocal_os.Text = FINANCEIRO_DTO.LOCAL_OS;

                nudDiaVencimento.Value = FINANCEIRO_DTO.DIA_VENCIMENTO;

                txtValorOS.Text = FINANCEIRO_DTO.VALOR_OS.ToString();

                mskData.Text = FINANCEIRO_DTO.DATA.Value.ToShortDateString();

                txtValorLi.Text = FINANCEIRO_DTO.VALOR_LIQUIDO.ToString();

                txtValorB.Text = FINANCEIRO_DTO.VALOR_BRUTO.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmCad_Financeiro_Load(object sender, EventArgs e)
        {
            try
            {
                if (FINANCEIRO_DTO.ID != null && FINANCEIRO_DTO.ID > 0)
                {
                    if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmFinanceiro.Update.Valor"))
                    {
                        txtValor.ReadOnly = true;
                        BloquearNumeric(nudDiaVencimento);
                        BloquearNumeric(numQtdParcela);
                        cboForma_Pagamento.Enabled = false;
                        cboServico.Enabled = false;
                        txtValorB.ReadOnly = true;
                        txtValorLi.ReadOnly = true;
                        txtValorOS.ReadOnly = true;
                        btnAplicar.Enabled = false;
                        btnAlterarValor.Visible = false;
                    }
                }
                else
                {
                    btnAlterarValor.Visible = false;
                }

                if (FINANCEIRO_DTO.ID != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT TOP (100) PERCENT ID, DATAHORA AS 'Data', USUARIO AS Usuário, ASSUNTO, HISTORICO,ID_REGISTRO ");
                    sb.Append(" FROM LOG_SISTEMA WHERE (TABELA = N'FINANCEIRO') ");
                    sb.Append(" and (id_registro = " + FINANCEIRO_DTO.ID + ")");
                    //Carregando o Histórico
                    if (FINANCEIRO_DTO.ID != 0)
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
                    tabControl2.TabPages.Remove(tabHistórico);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void BloquearNumeric(NumericUpDown numeric)
        {
            numeric.ReadOnly = true;
            numeric.Minimum = numeric.Value;
            numeric.Maximum = numeric.Value;
        }

        public bool AtualizaDTO()
        {
            try
            {

                FINANCEIRO_DTO.INDICACAO = cboIndicacao.Text;
                FINANCEIRO_DTO.ID_STATUS = Convert.ToInt32(cboStatus.SelectedValue);
                FINANCEIRO_DTO.ID_SERVICO = Convert.ToInt32(cboServico.SelectedValue);
                FINANCEIRO_DTO.DIA_VENCIMENTO = Convert.ToInt32(nudDiaVencimento.Value);
                FINANCEIRO_DTO.SERVICO.NOME = cboServico.Text;
                FINANCEIRO_DTO.SERVICO.VALOR = Convert.ToDecimal(txtValor.Text);
                FINANCEIRO_DTO.VALOR = Convert.ToDecimal(txtValor.Text);
                FINANCEIRO_DTO.FORMA_PAGAMENTO = cboForma_Pagamento.Text;
                FINANCEIRO_DTO.PARCELAS = Convert.ToInt32(numQtdParcela.Value.ToString());
                FINANCEIRO_DTO.BANCO_OS = txtBanco.Text;
                FINANCEIRO_DTO.CONSULTOR = cboConsultor.Text;
                FINANCEIRO_DTO.MOTOBOY_OS = txtMotoboy_os.Text;
                FINANCEIRO_DTO.LOCAL_OS = txtLocal_os.Text;
                FINANCEIRO_DTO.VALOR_OS = Convert.ToDecimal(txtValorOS.Text);
                FINANCEIRO_DTO.OBSERVACAO = txtObservacao.Text;
                FINANCEIRO_DTO.ULT_ATUAL = DateTime.Now;
                FINANCEIRO_DTO.USUARIO = SysBLL.UserLogin.NOME;

                FINANCEIRO_DTO.VALOR_LIQUIDO = Convert.ToDecimal(txtValorLi.Text);
                FINANCEIRO_DTO.VALOR_BRUTO = Convert.ToDecimal(txtValorB.Text);
                try
                {
                    FINANCEIRO_DTO.DATA = Convert.ToDateTime(mskData.Text);
                }
                catch
                {
                    MessageBox.Show("Preencha a data", "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                try
                {
                    FINANCEIRO_DTO.ID_CLIENTE = CLIENTE_DTO.ID == null ? 0 : Convert.ToInt32(CLIENTE_DTO.ID);
                }
                catch (Exception)
                {

                    MessageBox.Show("Selecione um Cliente", "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
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

        void PopularGrid()
        {
            try
            {
                if (lista_boleto_cheque.Count() == 0)
                {
                    return;
                }

                foreach (BOLETO_CHEQUE_DTO DTO in lista_boleto_cheque)
                {
                    if (DTO.OPERACAO == SysDTO.Operacoes.Exclusao)
                        new BOLETO_CHEQUE_BLL().Excluir(DTO.ID);
                }

                DataTable dtt = ConvertToDataTable(lista_boleto_cheque);

                //DataColumn clnValorParcela = new DataColumn();
                //clnValorParcela.ColumnName = "Valor da parcela";
                //dtt.Columns.Add(clnValorParcela);

                dtgBoletosCheques.DataSource = null;
                dtgBoletosCheques.DataSource = dtt;
                dtgBoletosCheques.ClearSelection();


                //string ValorParcelas = "";
                //if (txtValor.Text != "")
                //{
                //    try
                //    {
                //        decimal valor = Convert.ToDecimal(txtValor.Text);
                //        if (numQtdParcela.Value > 0)
                //        {
                //            ValorParcelas = (valor / numQtdParcela.Value).ToString("C");
                //        }
                //        else
                //            ValorParcelas = txtValor.Text;
                //    }
                //    catch
                //    {
                //    }
                //}

                foreach (DataGridViewRow row in dtgBoletosCheques.Rows)
                {
                    row.Cells["VALOR"].Value = Convert.ToDecimal(row.Cells["VALOR"].Value.ToString()).ToString("#0.00");
                    if (row.Cells["OPERACAO"].Value.ToString() == "3")
                    {
                        dtgBoletosCheques.Rows.Remove(row);
                    }
                }
                foreach (DataGridViewColumn column in dtgBoletosCheques.Columns)
                {
                    column.Visible = false;
                }

                dtgBoletosCheques.Columns["NUMERO"].Visible = true;
                dtgBoletosCheques.Columns["PARCELA"].Visible = true;
                dtgBoletosCheques.Columns["FORMA_PAGAMENTO"].Visible = true;
                dtgBoletosCheques.Columns["VALOR"].Visible = true;
                dtgBoletosCheques.Columns["DATA_VENCTO"].Visible = true;
                dtgBoletosCheques.Columns["STATUS_PAGAMENTO"].Visible = true;
                dtgBoletosCheques.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader); //Redimenciona as colunas de acordo com o conteúdo do campo
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void ValidarDados(FINANCEIRO_DTO DTO)
        {
            try
            {
                if (string.IsNullOrEmpty(DTO.CONSULTOR))
                    throw new CustomException("Favor informe o consultor", "Dados incorretos");
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
                if (!AtualizaDTO())
                {
                    return;
                }

                if (SetWithNewCliente)
                {
                    ValidarDados(FINANCEIRO_DTO);
                    this.DialogResult = DialogResult.OK;
                    return;
                }

                if (FINANCEIRO_DTO.OPERACAO == SysDTO.Operacoes.Inclusao)
                {
                    int? id = FINANCEIRO_BLL.Set_Financeiro(FINANCEIRO_DTO);
                    if (id > 0)
                    {
                        foreach (BOLETO_CHEQUE_DTO bOLETO_CHEQUE in lista_boleto_cheque)
                        {
                            bOLETO_CHEQUE.USUARIO = SysBLL.UserLogin.NOME;
                            bOLETO_CHEQUE.ULT_ATUAL = DateTime.Now;
                            bOLETO_CHEQUE.ID_FINANCEIRO = (int)id;
                            if (bOLETO_CHEQUE.OPERACAO == SysDTO.Operacoes.Inclusao)
                                new BOLETO_CHEQUE_BLL().Inserir(bOLETO_CHEQUE);
                            else if (bOLETO_CHEQUE.OPERACAO == SysDTO.Operacoes.Alteracao)
                                new BOLETO_CHEQUE_BLL().Alterar(bOLETO_CHEQUE);
                        }

                        MessageBox.Show("Registro incluído com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (FINANCEIRO_DTO.OPERACAO == SysDTO.Operacoes.Alteracao)
                {
                    if (FINANCEIRO_BLL.Update_Financeiro(FINANCEIRO_DTO))
                    {
                        foreach (BOLETO_CHEQUE_DTO bOLETO_CHEQUE in lista_boleto_cheque)
                        {
                            bOLETO_CHEQUE.USUARIO = SysBLL.UserLogin.NOME;
                            bOLETO_CHEQUE.ULT_ATUAL = DateTime.Now;
                            bOLETO_CHEQUE.ID_FINANCEIRO = (int)FINANCEIRO_DTO.ID;
                            if (bOLETO_CHEQUE.OPERACAO == SysDTO.Operacoes.Inclusao)
                                new BOLETO_CHEQUE_BLL().Inserir(bOLETO_CHEQUE);
                            else if (bOLETO_CHEQUE.OPERACAO == SysDTO.Operacoes.Alteracao)
                                new BOLETO_CHEQUE_BLL().Alterar(bOLETO_CHEQUE);
                            else if (bOLETO_CHEQUE.OPERACAO == SysDTO.Operacoes.Exclusao)
                                new BOLETO_CHEQUE_BLL().Excluir(bOLETO_CHEQUE.ID);
                        }
                        MessageBox.Show("Registro incluído com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboForma_Pagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboForma_Pagamento.SelectedValue != null)
                {
                    if (lista_forma_pagamento.First(x => x.ID == Convert.ToInt32(cboForma_Pagamento.SelectedValue)).GERANUMERO)
                    {
                        if (dtgBoletosCheques.Rows.Count == 0)
                        {
                            Random random = new Random();
                            for (int i = dtgBoletosCheques.Rows.Count; i < numQtdParcela.Value; i++)
                            {
                                DateTime data = DateTime.Now.AddMonths(i);
                                BOLETO_CHEQUE_DTO DTO = new BOLETO_CHEQUE_DTO();
                                DTO.ID = random.Next();
                                DTO.FORMA_PAGAMENTO = cboForma_Pagamento.Text;
                                DTO.DATA_VENCTO = new DateTime(data.Year, data.Month, (int)nudDiaVencimento.Value);
                                DTO.ATIVO = true;
                                DTO.OPERACAO = SysDTO.Operacoes.Inclusao;
                                DTO.ID_FINANCEIRO = FINANCEIRO_DTO.ID == null ? 0 : (int)FINANCEIRO_DTO.ID;
                                DTO.PARCELA = i + 1;
                                DTO.VALOR = 0;
                                DTO.STATUS_PAGAMENTO = "Pendente";
                                lista_boleto_cheque.Add(DTO);
                            }
                        }
                        foreach (BOLETO_CHEQUE_DTO BOLETO_CHEQUE in lista_boleto_cheque)
                        {
                            BOLETO_CHEQUE.FORMA_PAGAMENTO = cboForma_Pagamento.Text;
                            if (BOLETO_CHEQUE.OPERACAO == SysDTO.Operacoes.Leitura)
                                BOLETO_CHEQUE.OPERACAO = SysDTO.Operacoes.Alteracao;
                        }

                    }
                    else
                    {
                        foreach (BOLETO_CHEQUE_DTO bOLETO in lista_boleto_cheque)
                        {
                            if (bOLETO.OPERACAO == SysDTO.Operacoes.Alteracao || bOLETO.OPERACAO == SysDTO.Operacoes.Leitura)
                                bOLETO.OPERACAO = SysDTO.Operacoes.Exclusao;
                        }

                        lista_boleto_cheque.RemoveAll(x => x.OPERACAO == SysDTO.Operacoes.Inclusao);
                        dtgBoletosCheques.DataSource = null;
                    }

                }
                UpdateValor();
                PopularGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Moeda(ref txtValor);
                PopularGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Moeda(ref TextBox textbox)
        {
            String numero = String.Empty;
            Double valor = 0;
            try
            {
                numero = textbox.Text.Replace(",", "").Replace(".", "");
                if (numero.Equals(""))
                    numero = "";
                numero = numero.PadLeft(3, '0');

                if (numero.Length > 3 & numero.Substring(0, 1) == "0") numero = numero.Substring(1, numero.Length - 1);
                valor = Convert.ToDouble(numero) / 100;
                textbox.Text = String.Format("{0:N}", valor);
                textbox.SelectionStart = textbox.Text.Length;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnPesquisarAdvogado_Click(object sender, EventArgs e)
        {
            frmLocalizar frmLocalizar = new frmLocalizar("CLIENTE");
            DialogResult result = frmLocalizar.ShowDialog();
            if (result == DialogResult.OK)
            {
                CLIENTE_DTO DTO = new CLIENTE_DTO();
                DTO = new CLIENTE_BLL().Selecione(Convert.ToInt32(frmLocalizar.ID_REGISTRO));
                txtCliente.Text = DTO.NOME_COMPLETO;
                CLIENTE_DTO = DTO;
            }
        }

        private void txtValorOS_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorOS);
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgBoletosCheques.CurrentRow == null)
                {
                    return;
                }


                int ID = (int)(dtgBoletosCheques.CurrentRow.Cells["ID"].Value);
                if (lista_boleto_cheque.Exists(x => x.ID == ID))
                {

                    BOLETO_CHEQUE_SELECIONADO = lista_boleto_cheque.First(x => x.ID == ID);
                    BOLETO_CHEQUE_SELECIONADO.VALOR = Convert.ToDecimal(BOLETO_CHEQUE_SELECIONADO.VALOR.Value.ToString("#0.00"));
                    decimal valorParcelasAnteriores = 0;
                    decimal valorDisponivel = 0;
                    if (BOLETO_CHEQUE_SELECIONADO.PARCELA == 1)
                    {
                        valorDisponivel += Convert.ToDecimal(txtValor.Text);
                    }
                    else
                    {
                        foreach (BOLETO_CHEQUE_DTO DTO in lista_boleto_cheque.FindAll(x => x.PARCELA < BOLETO_CHEQUE_SELECIONADO.PARCELA))
                        {
                            valorParcelasAnteriores += Convert.ToDecimal(DTO.VALOR);
                        }
                    }

                    valorDisponivel = Convert.ToDecimal(txtValor.Text) - valorParcelasAnteriores;

                    bool LastParcela = (lista_boleto_cheque.Max(x => x.PARCELA) == BOLETO_CHEQUE_SELECIONADO.PARCELA);

                    frmBoletoCheque frmBoletoCheque = new frmBoletoCheque(BOLETO_CHEQUE_SELECIONADO, valorDisponivel, LastParcela);
                    DialogResult result = frmBoletoCheque.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        UpdateValorPrestacao(BOLETO_CHEQUE_SELECIONADO);
                        if (BOLETO_CHEQUE_SELECIONADO.OPERACAO == SysDTO.Operacoes.Leitura)
                        {
                            BOLETO_CHEQUE_SELECIONADO.OPERACAO = SysDTO.Operacoes.Alteracao;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao carregar registro. Reinicie o programa, caso o erro persista, entre em contato com o suporte.", "Erro ao carregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                PopularGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void numQtdParcela_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lista_forma_pagamento.Exists(x => x.ID == Convert.ToInt32(cboForma_Pagamento.SelectedValue)))
                {
                    FORMA_PAGAMENTO_DTO forma_pagamento = lista_forma_pagamento.First(x => x.ID == Convert.ToInt32(cboForma_Pagamento.SelectedValue));
                    if (forma_pagamento.GERANUMERO == false)
                    {
                        foreach (BOLETO_CHEQUE_DTO bOLETO in lista_boleto_cheque)
                        {
                            if (bOLETO.OPERACAO == SysDTO.Operacoes.Alteracao || bOLETO.OPERACAO == SysDTO.Operacoes.Leitura)
                                bOLETO.OPERACAO = SysDTO.Operacoes.Exclusao;
                        }

                        lista_boleto_cheque.RemoveAll(x => x.OPERACAO == SysDTO.Operacoes.Inclusao);
                        dtgBoletosCheques.DataSource = null;
                        return;
                    }
                }
                if (lista_boleto_cheque.Count <= numQtdParcela.Value)
                {
                    int count = lista_boleto_cheque.Count;
                    for (int i = count; i < numQtdParcela.Value; i++)
                    {
                        BOLETO_CHEQUE_DTO _DTO = new BOLETO_CHEQUE_DTO();
                        Random random = new Random();
                        _DTO.ID = random.Next();
                        _DTO.FORMA_PAGAMENTO = string.IsNullOrEmpty(cboForma_Pagamento.Text) ? "" : cboForma_Pagamento.Text;
                        _DTO.STATUS_PAGAMENTO = "Pendente";
                        _DTO.NUMERO = "";
                        DateTime data = DateTime.Now.AddMonths(i);
                        _DTO.DATA_VENCTO = new DateTime(data.Year, data.Month, (int)nudDiaVencimento.Value);
                        _DTO.PARCELA = i + 1;
                        //  _DTO.PRECO = Convert.toDecimal;
                        _DTO.OPERACAO = SysDTO.Operacoes.Inclusao;
                        lista_boleto_cheque.Add(_DTO);
                    }
                }
                else
                {
                    if (lista_boleto_cheque.Count == 1 && Convert.ToInt32(numQtdParcela.Value) == 0)
                    {
                        lista_boleto_cheque.Clear();
                        PopularGrid();

                        return;
                    }
                    DialogResult result = MessageBox.Show("Ao diminuir a quantidade de parcelas, você irá excluir a última. Deseja continuar?", "Excluir parcela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {

                        for (int i = Convert.ToInt32(numQtdParcela.Value); i < lista_boleto_cheque.Count;)
                        {

                            lista_boleto_cheque.Last(x => x.PARCELA != null).OPERACAO = SysDTO.Operacoes.Exclusao;
                            foreach (BOLETO_CHEQUE_DTO DTO in lista_boleto_cheque.FindAll(x => x.OPERACAO == SysDTO.Operacoes.Exclusao))
                            {
                                new BOLETO_CHEQUE_BLL().Excluir(DTO.ID);
                            }
                            lista_boleto_cheque.RemoveAll(x => x.OPERACAO == SysDTO.Operacoes.Exclusao);

                        }

                    }


                }

                UpdateValor();
                PopularGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgBoletosCheques_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                BtnAplicar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboConsultor_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(new FINANCEIRO_BLL().Verifica_Consultor(cboConsultor.Text)))
                {
                    picConsultor.Visible = true;
                    toolTip.Show("Consultor não encontrado em registros anteriores. \nAo inserir, será considerado como novo consultor.", picConsultor);
                }
                else
                {
                    picConsultor.Visible = false;
                    toolTip.Hide(picConsultor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void TxtObservacao_Enter(object sender, EventArgs e)
        {
            try
            {
                this.AcceptButton = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtObservacao_Leave(object sender, EventArgs e)
        {
            try
            {
                this.AcceptButton = btnRegistrar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NudDiaVencimento_ValueChanged(object sender, EventArgs e)
        {
            foreach (BOLETO_CHEQUE_DTO boleto_cheque in lista_boleto_cheque)
            {
                if (boleto_cheque.DATA_VENCTO != null)
                {
                    if (boleto_cheque.DATA_VENCTO.Value.Day == DIA_VENCTO_PADRAO)
                    {
                        DateTime data = new DateTime(boleto_cheque.DATA_VENCTO.Value.Year, boleto_cheque.DATA_VENCTO.Value.Month, (int)nudDiaVencimento.Value);
                        boleto_cheque.DATA_VENCTO = data;
                    }
                }
                else
                {

                }
            }
            DIA_VENCTO_PADRAO = (int)nudDiaVencimento.Value;
            PopularGrid();
        }
        private void txtValorB_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorB);
            PopularGrid();
        }

        private void txtValorLi_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorLi);
            PopularGrid();
        }

        private void BtnAlterarValor_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Ao alterar o valor total, será alterado todas as parcelas em aberto. Deseja Continuar?", "Alteração de valor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    txtValor.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtValor_Leave(object sender, EventArgs e)
        {
            try
            {

                int Qtd = lista_boleto_cheque.Count(x => x.STATUS_PAGAMENTO.ToUpper() != "PAGO");
                decimal valorDescontado = 0;
                foreach (BOLETO_CHEQUE_DTO DTO in lista_boleto_cheque.FindAll(x => x.STATUS_PAGAMENTO.ToUpper() == "PAGO"))
                {
                    valorDescontado += Convert.ToDecimal(DTO.VALOR);
                }

                if (Convert.ToDecimal(txtValor.Text) < valorDescontado)
                {
                    txtValor.Text = valorDescontado.ToString();
                    MessageBox.Show("O valor total deve ser maior do que a soma de todas as parcelas já pagas.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal valorTotal = Convert.ToDecimal(txtValor.Text) - valorDescontado;
                foreach (BOLETO_CHEQUE_DTO DTO in lista_boleto_cheque.FindAll(x => x.STATUS_PAGAMENTO.ToUpper() != "PAGO"))
                {
                    DTO.VALOR = Convert.ToDecimal(valorTotal / Qtd);
                    if (DTO.OPERACAO == SysDTO.Operacoes.Leitura)
                        DTO.OPERACAO = SysDTO.Operacoes.Alteracao;
                }

                if (FINANCEIRO_DTO.OPERACAO != SysDTO.Operacoes.Inclusao)
                    txtValor.ReadOnly = true;

                PopularGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateValor()
        {
            try
            {

                int Qtd = 0;
                if (lista_boleto_cheque.Exists(x => x.STATUS_PAGAMENTO.ToUpper() != "PAGO"))
                    Qtd = lista_boleto_cheque.Count(x => x.STATUS_PAGAMENTO.ToUpper() != "PAGO");
                decimal valorDescontado = 0;
                foreach (BOLETO_CHEQUE_DTO DTO in lista_boleto_cheque.FindAll(x => x.STATUS_PAGAMENTO.ToUpper() == "PAGO"))
                {
                    valorDescontado += Convert.ToDecimal(DTO.VALOR);
                }

                if (Convert.ToDecimal(txtValor.Text) < valorDescontado)
                {
                    txtValor.Text = valorDescontado.ToString();
                    MessageBox.Show("O valor total deve ser maior do que a soma de todas as parcelas já pagas.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal valorTotal = Convert.ToDecimal(txtValor.Text) - valorDescontado;
                foreach (BOLETO_CHEQUE_DTO DTO in lista_boleto_cheque.FindAll(x => x.STATUS_PAGAMENTO.ToUpper() != "PAGO"))
                {
                    DTO.VALOR = Convert.ToDecimal(Convert.ToDecimal(valorTotal / Qtd).ToString("#0.00"));
                    if (DTO.OPERACAO == SysDTO.Operacoes.Leitura)
                        DTO.OPERACAO = SysDTO.Operacoes.Alteracao;
                }

                if (FINANCEIRO_DTO.OPERACAO != SysDTO.Operacoes.Inclusao)
                    txtValor.ReadOnly = true;

                PopularGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateValorPrestacao(BOLETO_CHEQUE_DTO DTO)
        {
            try
            {
                decimal valoresPassados = 0;
                foreach (BOLETO_CHEQUE_DTO boleto_cheque_ in lista_boleto_cheque.FindAll(x => x.PARCELA <= DTO.PARCELA))
                {
                    valoresPassados += Convert.ToDecimal(boleto_cheque_.VALOR);
                }
                int qtdPrestacao = lista_boleto_cheque.Count(x => x.PARCELA > DTO.PARCELA);
                decimal valorTotal = Convert.ToDecimal(txtValor.Text) - valoresPassados;
                if (qtdPrestacao > 0)
                {
                    decimal valorParaParcela = valorTotal / qtdPrestacao;

                    foreach (BOLETO_CHEQUE_DTO boleto_cheque_ in lista_boleto_cheque.FindAll(x => x.PARCELA > DTO.PARCELA))
                    {
                        boleto_cheque_.VALOR = valorParaParcela;
                        if (boleto_cheque_.OPERACAO == SysDTO.Operacoes.Leitura)
                            boleto_cheque_.OPERACAO = SysDTO.Operacoes.Alteracao;
                    }

                }
                //else
                //    decimal valorParaParcela = valorTotal / qtdPrestacao;

            }
            catch (Exception ex)
            {
                throw ex;
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
    }
}