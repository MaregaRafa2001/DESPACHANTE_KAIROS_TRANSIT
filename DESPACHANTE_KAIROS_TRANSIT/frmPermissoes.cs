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
    public partial class frmPermissoes : Form
    {
        SYS_PERFIL_BLL SYS_PERFIL_BLL = null;
        List<TreeNode> Nodes_Pai = new List<TreeNode>();


        public frmPermissoes(mdi_principal mdi)
        {
            InitializeComponent();
            Popular_Combos();
        }
        #region TELAS
        List<SYS_MENU_DTO> lista_telas = new SYS_MENU_BLL().Listar();

        private void Popular_Combos()
        {
            //PERFIL
            cboPerfil.SelectedIndexChanged -= CboPerfil_SelectedIndexChanged;
            cboPerfil.ValueMember = "ID";
            cboPerfil.DisplayMember = "DESCRICAO";
            cboPerfil.DataSource = new SYS_PERFIL_BLL().Listar();
            cboPerfil.SelectedIndex = -1;
            cboPerfil.SelectedIndexChanged += CboPerfil_SelectedIndexChanged;

        }

        void PopularTreeView()
        {
            trwTelasDisponiveis.Nodes.Clear();
            trwTelasSelecionadas.Nodes.Clear();
            trwTelasSelecionadas.Nodes.Add(new TreeNode() { Text = "Tela", Tag = "" });
            trwTelasDisponiveis.Nodes.Add(new TreeNode() { Text = "Tela", Tag = "" });

            //TELAS
            List<SYS_MENU_DTO> lista_menu = new SYS_MENU_BLL().Listar();
            lista_telas = lista_menu;
            if (lista_menu.Count > 0)
            {
                TreeNode node = trwTelasDisponiveis.Nodes[0];
                foreach (SYS_MENU_DTO menu in lista_menu)
                {
                    TreeNode node_Filho = new TreeNode();
                    node_Filho.Text = menu.DESCRICAO;
                    node_Filho.Tag = menu.ID;
                    node.Nodes.Add(node_Filho);
                }
                trwTelasDisponiveis.Nodes[0].Expand();
            }
        }

        private void FrmApoio_Load(object sender, EventArgs e)
        {
            PopularTreeView();
        }

        private void CboPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tssMSG.Text = "";
                tssMSG.Visible = false;

                PopularTreeView();
                if (cboPerfil.SelectedValue != null)
                {
                    trwTelasDisponiveis.Enabled = true;

                    GRUPO_ACESSO_DTO lista_acesso = new GRUPO_ACESSO_BLL().Listar((int)cboPerfil.SelectedValue);
                    if (lista_acesso.SYS_MENU.Count > 0)
                    {

                        TreeNode node = trwTelasSelecionadas.Nodes[0];

                        foreach (SYS_MENU_DTO menu in lista_acesso.SYS_MENU)
                        {
                            TreeNode node_Filho = new TreeNode();
                            node_Filho.Text = menu.DESCRICAO;
                            node_Filho.Tag = menu.ID;
                            TreeNodeCollection lista_nodes = trwTelasDisponiveis.Nodes[0].Nodes;
                            foreach (TreeNode nodes in lista_nodes)
                            {

                                trwTelasDisponiveis.AfterSelect -= TrwTelasDisponiveis_AfterSelect;
                                try
                                {
                                    if (nodes.Tag.ToString() == menu.ID.ToString())
                                    {
                                        trwTelasDisponiveis.Nodes[0].Nodes.Remove(nodes);
                                    }
                                }
                                catch
                                {
                                }
                                trwTelasDisponiveis.AfterSelect += TrwTelasDisponiveis_AfterSelect;

                            }
                            node.Nodes.Add(node_Filho);
                        }
                        trwTelasSelecionadas.Nodes[0].Expand();
                    }
                }
                else
                {
                    trwTelasDisponiveis.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrwTelasDisponiveis_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                trwTelasDisponiveis.AfterSelect -= TrwTelasDisponiveis_AfterSelect;
                if (trwTelasDisponiveis.SelectedNode.Tag.ToString() != "")
                {
                    TreeNode node = trwTelasDisponiveis.SelectedNode;
                    trwTelasDisponiveis.Nodes.Remove(node);
                    trwTelasSelecionadas.Nodes[0].Nodes.Add(node);
                }
                trwTelasDisponiveis.SelectedNode = trwTelasDisponiveis.Nodes[0];
                trwTelasDisponiveis.AfterSelect += TrwTelasDisponiveis_AfterSelect;
                trwTelasSelecionadas.Nodes[0].Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrwTelasSelecionadas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                trwTelasSelecionadas.AfterSelect -= TrwTelasSelecionadas_AfterSelect;
                if (trwTelasSelecionadas.SelectedNode.Tag.ToString() != "")
                {
                    TreeNode node = trwTelasSelecionadas.SelectedNode;
                    trwTelasSelecionadas.Nodes.Remove(node);
                    trwTelasDisponiveis.Nodes[0].Nodes.Add(node);
                }
                trwTelasSelecionadas.SelectedNode = trwTelasSelecionadas.Nodes[0];
                trwTelasSelecionadas.AfterSelect += TrwTelasSelecionadas_AfterSelect;
                trwTelasDisponiveis.Nodes[0].Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int?)cboPerfil.SelectedValue > 0)
                {
                    bool Exclusao = new GRUPO_ACESSO_BLL().Excluir((int)cboPerfil.SelectedValue);
                    if (Exclusao)
                    {
                        int ID_PERFIL = (int)cboPerfil.SelectedValue;
                        foreach (TreeNode itens in trwTelasSelecionadas.Nodes[0].Nodes)
                        {
                            if (lista_telas.Exists(x => x.ID == Convert.ToInt32(itens.Tag)))
                            {
                                SYS_MENU_DTO tela = lista_telas.First(x => x.ID == Convert.ToInt32(itens.Tag));
                                GRUPO_ACESSO_DTO DTO = new GRUPO_ACESSO_DTO();
                                DTO.ID_PERFIL = ID_PERFIL;
                                DTO.ID_SYS_MENU = tela.ID;
                                new GRUPO_ACESSO_BLL().Inserir(DTO);
                            }
                        }
                    }
                    cboPerfil.SelectedIndex = -1;
                    tssMSG.Text = "Permissões alteradas";
                    tssMSG.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion




        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
