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
                        boleto_cheque.Operacao = SysDTO.Operacoes.Leitura;
                    PopularGrid();
                    PopularDados();
                    FINANCEIRO_DTO.Operacao = SysDTO.Operacoes.Alteracao;
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
                cboIndicacao.SelectedIndex = -1;

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
                cboForma_Pagamento.Text = FINANCEIRO_DTO.FORMA_PAGAMENTO;
                numQtdParcela.Value = FINANCEIRO_DTO.PARCELAS;
                numQtdParcela.ValueChanged += numQtdParcela_ValueChanged;
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

                    }

                    if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmFinanceiro.Update.Boleto"))
                    {
                        btnAplicar.Enabled = false;
                    }
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

                DataTable dtt = ConvertToDataTable(lista_boleto_cheque);

                DataColumn clnValorParcela = new DataColumn();
                clnValorParcela.ColumnName = "Valor da parcela";
                dtt.Columns.Add(clnValorParcela);

                dtgBoletosCheques.DataSource = null;
                dtgBoletosCheques.DataSource = dtt;
                dtgBoletosCheques.ClearSelection();


                string ValorParcelas = "";
                if (txtValor.Text != "")
                {
                    try
                    {
                        decimal valor = Convert.ToDecimal(txtValor.Text);
                        if (numQtdParcela.Value > 0)
                        {
                            ValorParcelas = (valor / numQtdParcela.Value).ToString("C");
                        }
                        else
                            ValorParcelas = txtValor.Text;
                    }
                    catch
                    {
                    }
                }

                foreach (DataGridViewRow row in dtgBoletosCheques.Rows)
                {
                    row.Cells["Valor da parcela"].Value = ValorParcelas;


                    if (row.Cells["Operacao"].Value.ToString() == "3")
                    {
                        dtgBoletosCheques.Rows.Remove(row);
                    }


                }
                dtgBoletosCheques.Columns["ID"].Visible = false;
                dtgBoletosCheques.Columns["ATIVO"].Visible = false;
                dtgBoletosCheques.Columns["ID_FINANCEIRO"].Visible = false;
                dtgBoletosCheques.Columns["ID_STATUS_PAGAMENTO"].Visible = false;
                dtgBoletosCheques.Columns["Operacao"].Visible = false;
                dtgBoletosCheques.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); //Redimenciona as colunas de acordo com o conteúdo do campo
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

                if (FINANCEIRO_DTO.Operacao == SysDTO.Operacoes.Inclusao)
                {
                    int? id = FINANCEIRO_BLL.Set_Financeiro(FINANCEIRO_DTO);
                    if (id > 0)
                    {
                        foreach (BOLETO_CHEQUE_DTO bOLETO_CHEQUE in lista_boleto_cheque)
                        {
                            bOLETO_CHEQUE.ID_FINANCEIRO = (int)id;
                            if (bOLETO_CHEQUE.Operacao == SysDTO.Operacoes.Inclusao)
                                new BOLETO_CHEQUE_BLL().Inserir(bOLETO_CHEQUE);
                            else if (bOLETO_CHEQUE.Operacao == SysDTO.Operacoes.Alteracao)
                                new BOLETO_CHEQUE_BLL().Alterar(bOLETO_CHEQUE);
                        }

                        MessageBox.Show("Registro incluído com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (FINANCEIRO_DTO.Operacao == SysDTO.Operacoes.Alteracao)
                {
                    if (FINANCEIRO_BLL.Update_Financeiro(FINANCEIRO_DTO))
                    {
                        foreach (BOLETO_CHEQUE_DTO bOLETO_CHEQUE in lista_boleto_cheque)
                        {
                            bOLETO_CHEQUE.ID_FINANCEIRO = (int)FINANCEIRO_DTO.ID;
                            if (bOLETO_CHEQUE.Operacao == SysDTO.Operacoes.Inclusao)
                                new BOLETO_CHEQUE_BLL().Inserir(bOLETO_CHEQUE);
                            else if (bOLETO_CHEQUE.Operacao == SysDTO.Operacoes.Alteracao)
                                new BOLETO_CHEQUE_BLL().Alterar(bOLETO_CHEQUE);
                            else if (bOLETO_CHEQUE.Operacao == SysDTO.Operacoes.Exclusao)
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
                                lista_boleto_cheque.Add(new BOLETO_CHEQUE_DTO() { ID = random.Next(), FORMA_PAGAMENTO = cboForma_Pagamento.Text, DATA_VENCTO = new DateTime(data.Year, data.Month, (int)nudDiaVencimento.Value), ATIVO = true, Operacao = SysDTO.Operacoes.Inclusao, ID_FINANCEIRO = FINANCEIRO_DTO.ID == null ? 0 : (int)FINANCEIRO_DTO.ID, PARCELA = i + 1 });
                            }
                        }
                        foreach (BOLETO_CHEQUE_DTO BOLETO_CHEQUE in lista_boleto_cheque)
                        {
                            BOLETO_CHEQUE.FORMA_PAGAMENTO = cboForma_Pagamento.Text;
                            if (BOLETO_CHEQUE.Operacao == SysDTO.Operacoes.Leitura)
                                BOLETO_CHEQUE.Operacao = SysDTO.Operacoes.Alteracao;
                        }

                        PopularGrid();
                    }
                    else
                    {
                        foreach (BOLETO_CHEQUE_DTO bOLETO in lista_boleto_cheque)
                        {
                            if (bOLETO.Operacao == SysDTO.Operacoes.Alteracao || bOLETO.Operacao == SysDTO.Operacoes.Leitura)
                                bOLETO.Operacao = SysDTO.Operacoes.Exclusao;
                        }

                        lista_boleto_cheque.RemoveAll(x => x.Operacao == SysDTO.Operacoes.Inclusao);
                        dtgBoletosCheques.DataSource = null;
                    }

                }
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
            Moeda(ref txtValor);
            PopularGrid();
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
            catch (Exception)
            {

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
                    frmBoletoCheque frmBoletoCheque = new frmBoletoCheque(BOLETO_CHEQUE_SELECIONADO);
                    DialogResult result = frmBoletoCheque.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (BOLETO_CHEQUE_SELECIONADO.Operacao == SysDTO.Operacoes.Leitura)
                        {
                            BOLETO_CHEQUE_SELECIONADO.Operacao = SysDTO.Operacoes.Alteracao;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao carregar registro. Caso o problema persistir, reinicie o programa", "Erro ao carregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                PopularGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDocAdd_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDocEdit_Click(object sender, EventArgs e)
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
                    frmBoletoCheque frmBoletoCheque = new frmBoletoCheque(BOLETO_CHEQUE_SELECIONADO);
                    DialogResult result = frmBoletoCheque.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (BOLETO_CHEQUE_SELECIONADO.Operacao == SysDTO.Operacoes.Leitura)
                        {
                            BOLETO_CHEQUE_SELECIONADO.Operacao = SysDTO.Operacoes.Alteracao;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao carregar registro. Caso o problema persistir, reinicie o programa", "Erro ao carregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
                            if (bOLETO.Operacao == SysDTO.Operacoes.Alteracao || bOLETO.Operacao == SysDTO.Operacoes.Leitura)
                                bOLETO.Operacao = SysDTO.Operacoes.Exclusao;
                        }

                        lista_boleto_cheque.RemoveAll(x => x.Operacao == SysDTO.Operacoes.Inclusao);
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
                        _DTO.FORMA_PAGAMENTO = cboForma_Pagamento.Text;
                        _DTO.NUMERO = "";
                        DateTime data = DateTime.Now.AddMonths(i);
                        _DTO.DATA_VENCTO = new DateTime(data.Year, data.Month, (int)nudDiaVencimento.Value);
                        _DTO.PARCELA = i + 1;
                        //  _DTO.PRECO = Convert.toDecimal;
                        _DTO.Operacao = SysDTO.Operacoes.Inclusao;
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
                    for (int i = Convert.ToInt32(numQtdParcela.Value); i < lista_boleto_cheque.Count;)
                    {
                        var list = lista_boleto_cheque.OrderBy(x => x.ID);
                        if (lista_boleto_cheque.Exists(x => x.Operacao == SysDTO.Operacoes.Inclusao))
                        {
                            lista_boleto_cheque.Remove(lista_boleto_cheque.Last(x => x.Operacao == SysDTO.Operacoes.Inclusao));
                        }
                        else
                            numQtdParcela.Value += 1;
                    }

                }
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

        private void TsbDocDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgBoletosCheques.CurrentRow == null)
                    return;

                int ID = Convert.ToInt32(dtgBoletosCheques.CurrentRow.Cells["ID"].Value.ToString());
                if (ID > 0)
                {
                    lista_boleto_cheque.First(x => x.ID == ID).Operacao = SysDTO.Operacoes.Exclusao;

                    PopularGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }

}