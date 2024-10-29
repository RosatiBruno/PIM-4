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

        public TelaPedidos(string userType)
        {
            InitializeComponent();

            //Desativar o botão ao estar logado sem ser como T.I
            this.userType = userType;

            //Alterar o tamanho da fonte
            alteradorFontePedidos = new AlteradorFontePedidos(this);
            alteradorFontePedidos.AlterarFontePedidos(btnLogout2, btnRetornar2);

            //Permitindo o redimensionamento da tela
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;

            //Abre em Tela Cheia - Verificar a Necessidade e a Viabilidade
            this.WindowState = FormWindowState.Maximized;

            //Definindo o tamanho mínimo da tela para 800x600
            this.MinimumSize = new Size(800, 600);

            //Criando e adicionando a logo
            logo = new Logo(this);
            this.Controls.Add(logo.Picture);

            // Posicionando a logo no canto inferior esquerdo
            logo.Picture.Location = new Point(20, this.ClientSize.Height - logo.Picture.Height - 10);

            //Criando e adicionando a barra verde superior
            colorBar = new ColorBar2(this);
            this.Controls.Add(colorBar.Panel);

            //Criando e adicionando a cor verde de fundo
            colorBg = new ColorBackground(this);
            this.Controls.Add(colorBg.Panel);

            this.Resize += TelaFornecedores_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();
        }

        private void TelaFornecedores_Resize(object sender, EventArgs e)
        {
            //Reposiciona a logo no canto inferior esquerdo
            logo.Picture.Location = new Point(20, this.ClientSize.Height - logo.Picture.Height - 10);

            //Ajusta a barra verde para manter a mesma largura e aumentar apenas em altura
            colorBar.Panel.Size = new Size(colorBar.Panel.Width, this.ClientSize.Height);

            //Ajusta o fundo para cobrir toda a tela ao redimensionar
            colorBg.Panel.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);

            //Recalcular a centralização dos componentes
            centralizador2 = new Centralizador2(this);

            //Reposiciona o botão de voltar no canto inferior esquerdo
            btnRetornar2.Location = new Point(btnRetornar2.Location.X, this.ClientSize.Height - btnRetornar2.Height - 35); //35 é a margem inferior
        }


        //Função para atualizar a ListView após o cadastro de algum pedido
        public void AtualizarListView()
        {
            lvBuscarPedidos.Items.Clear();
            foreach (var pedidos in RepositorioPedidos.ListaPedidos)
            {
                ListViewItem item = new ListViewItem(new[] {
            pedidos.ID.ToString(),
            pedidos.Nome,
            pedidos.Quantidade.ToString(),
            pedidos.ValorUnitario.ToString(),
            pedidos.EmpresaCompra,
        });
                lvBuscarPedidos.Items.Add(item);
            }
        }


        //Botão Retornar volta ao Menu Inicial (Form2)
        private void btnRetornar2_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(userType);
            form2.FormClosed += (s, args) => this.Close();
            form2.Size = this.Size;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
            this.Hide();
        }


        //Botão de Logout sai do Programa
        private void btnLogout2_Click_1(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
        }


        //PROCURANDO DADOS NA LISTVIEW (VAI SER ALTERADO AINDA!!!! - EM DESENVOLVIMENTO)
        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            bool itemEncontrado = false;
            string termoBusca = lvBuscarPedidos.Text.ToLower().Trim();

            foreach (ListViewItem item in lvBuscarPedidos.Items)
            {
                if (item.SubItems[0].Text.ToLower().Contains(termoBusca)) //O nmr entre '[]' é a casa da listview q procura
                {
                    item.Selected = true;
                    lvBuscarPedidos.TopItem = item; //Traz o pedido procurado para o topo da lista
                    lvBuscarPedidos.Focus(); //Define o foco na ListView
                    itemEncontrado = true;
                    break;
                }
            }
            //Exibe uma mensagem caso não ache nenhum Pedido
            if (!itemEncontrado)
            {
                MessageBox.Show("Pedido não encontrado.", "Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //Botão de cadastro de novo pedido
        private void btnCadastrarNovoPedido_Click(object sender, EventArgs e)
        {
            TelaCadastroPedido telaCadastroPedido = new TelaCadastroPedido(userType);
            telaCadastroPedido.Size = this.Size; //Passa o tamanho do Form2 para o TelaFornecedores
            telaCadastroPedido.StartPosition = FormStartPosition.CenterScreen; //Centraliza a nova tela na tela
            telaCadastroPedido.FormClosed += (s, args) => this.Close();
            telaCadastroPedido.Show();
            this.Hide();
        }


        //Chamada da função de atualização da ListView após cadastrar um Pedido novo
        private void TelaPedidos_Load_1(object sender, EventArgs e)
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
    }
}
