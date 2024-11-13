using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace TelaPimExercicio
{
    public partial class TelaPedidos : Form
    {
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFontePedidos alteradorFontePedidos;

        // Conexão com o banco de dados (COMPUTADOR)
        //private string connectionString = "Data Source=DESKTOP-0T3JO2U\\SQLURBAGRO;Initial Catalog=bdPedidos;Integrated Security=True";

        // Conexão com o banco de dados (NOTEBOOK)
        private string connectionString = "Data Source=MARCIA-DELL\\SQLURBAGRO;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public TelaPedidos(string userType)
        {
            InitializeComponent();

            // Desativar o botão ao estar logado sem ser como T.I
            this.userType = userType;

            // Alterar o tamanho da fonte
            alteradorFontePedidos = new AlteradorFontePedidos(this);
            alteradorFontePedidos.AlterarFontePedidos(btnLogout2, btnRetornar2);

            // Permitindo o redimensionamento da tela
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(800, 600);

            // Criando e adicionando a logo
            logo = new Logo(this);
            this.Controls.Add(logo.Picture);
            logo.Picture.Location = new Point(20, this.ClientSize.Height - logo.Picture.Height - 10);

            // Criando e adicionando a barra verde superior
            colorBar = new ColorBar2(this);
            this.Controls.Add(colorBar.Panel);

            // Criando e adicionando a cor verde de fundo
            colorBg = new ColorBackground(this);
            this.Controls.Add(colorBg.Panel);

            this.Resize += TelaPedidos_Resize;

            // Iniciando o Logout
            logout = new Logout(this);

            // Centraliza no Monitor/Tela
            CenterToScreen();
        }

        private void TelaPedidos_Resize(object sender, EventArgs e)
        {
            logo.Picture.Location = new Point(20, this.ClientSize.Height - logo.Picture.Height - 10);
            colorBar.Panel.Size = new Size(colorBar.Panel.Width, this.ClientSize.Height);
            colorBg.Panel.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            centralizador2 = new Centralizador2(this);
            btnRetornar2.Location = new Point(btnRetornar2.Location.X, this.ClientSize.Height - btnRetornar2.Height - 35);
        }

        // Função para atualizar a ListView a partir do banco de dados
        public void AtualizarListView()
        {
            lvBuscarPedidos.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT idPedido, nomePedido, quantidadePedido, valorUnitarioPedido, empresaResponsavelPedido FROM bdPedidos.dbo.Pedidos";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(new[] {
                    reader["idPedido"].ToString(),
                    reader["nomePedido"].ToString(),
                    reader["quantidadePedido"].ToString(),
                    reader["valorUnitarioPedido"].ToString(),
                    reader["empresaResponsavelPedido"].ToString()
                });
                        lvBuscarPedidos.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar pedidos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Botão Retornar volta ao Menu Inicial (Form2)
        private void btnRetornar2_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(userType);
            form2.FormClosed += (s, args) => this.Close();
            form2.Size = this.Size;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
            this.Hide();
        }

        // Botão de Logout sai do Programa
        private void btnLogout2_Click_1(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
        }

        // Função de busca de pedido na ListView
        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscarPedido.Text.Trim(); // Supondo que você tenha um TextBox para digitar o ID de busca

            if (string.IsNullOrEmpty(termoBusca))
            {
                MessageBox.Show("Digite um ID para realizar a busca.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Limpar a seleção anterior
            lvBuscarPedidos.SelectedItems.Clear();

            bool pedidoEncontrado = false;

            // Percorre todos os itens da ListView para procurar o ID correspondente
            foreach (ListViewItem item in lvBuscarPedidos.Items)
            {
                // Verifica se o ID do pedido é igual ao termo de busca
                if (item.SubItems[0].Text == termoBusca)  // SubItems[0] é a coluna com o ID do pedido
                {
                    // Destaca o item encontrado, selecionando-o
                    item.Selected = true;
                    lvBuscarPedidos.TopItem = item;  // Faz o item ser visível (caso esteja fora da tela)
                    pedidoEncontrado = true;
                    break;  // Para a busca quando encontrar o pedido
                }
            }

            // Caso nenhum pedido tenha sido encontrado
            if (!pedidoEncontrado)
            {
                MessageBox.Show("Pedido não encontrado.", "Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Botão de cadastro de novo pedido
        private void btnCadastrarNovoPedido_Click(object sender, EventArgs e)
        {
            TelaCadastroPedido telaCadastroPedido = new TelaCadastroPedido(userType);
            telaCadastroPedido.Size = this.Size;
            telaCadastroPedido.StartPosition = FormStartPosition.CenterScreen;
            telaCadastroPedido.FormClosed += (s, args) => this.Close();
            telaCadastroPedido.Show();
            this.Hide();
        }

        // Carregar os pedidos ao abrir a TelaPedidos
        private void TelaPedidos_Load(object sender, EventArgs e)
        {
            AtualizarListView();
        }

        private void btnExcluirPedido_Click(object sender, EventArgs e)
        {
            TelaExcluirPedido telaExcluirPedido = new TelaExcluirPedido(userType);
            telaExcluirPedido.FormClosed += (s, args) => this.Close();
            telaExcluirPedido.Size = this.Size;
            telaExcluirPedido.StartPosition = FormStartPosition.CenterScreen;
            telaExcluirPedido.Show();
            this.Hide();
        }

        private void btnEditarPedido_Click(object sender, EventArgs e)
        {
            TelaEditarPedidos telaEditarPedidos = new TelaEditarPedidos(userType, this);
            telaEditarPedidos.FormClosed += (s, args) => this.Close();
            telaEditarPedidos.Size = this.Size;
            telaEditarPedidos.StartPosition = FormStartPosition.CenterScreen;
            telaEditarPedidos.Show();
            this.Hide();
        }

        private void TelaPedidos_Load_1(object sender, EventArgs e)
        {
            AtualizarListView();
        }
    }
}
