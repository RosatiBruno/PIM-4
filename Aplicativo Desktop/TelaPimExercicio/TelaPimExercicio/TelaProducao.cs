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
    public partial class TelaProducao : Form
    {

        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;

        public TelaProducao(string userType)
        {
            InitializeComponent();

            //Desativar o botão ao estar logado sem ser como T.I
            this.userType = userType;

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

            this.Resize += TelaProds_Resize;

            //Alterando o tamanho da fonte
            AlteradorFonteProducao alteradorFonte = new AlteradorFonteProducao(this);
            alteradorFonte.AlterarFonteProducao(btnLogout, btnRetornar);

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();
        }

        private void TelaProds_Resize(object sender, EventArgs e)
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
            btnRetornar.Location = new Point(btnRetornar.Location.X, this.ClientSize.Height - btnRetornar.Height - 35); //35 é a margem inferior

        }

        //Botão de Logout sai do Programa
        private void btnLogout_Click(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
        }

        //Botão Retornar volta ao Menu Inicial (Form2)
        private void btnRetornar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(userType);
            form2.FormClosed += (s, args) => this.Close();
            form2.Size = this.Size;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
            this.Hide();
        }

        private void btnCadastrarNovaProducao_Click(object sender, EventArgs e)
        {
            TelaCadastrarProducao telaCadastrarProducao = new TelaCadastrarProducao(userType);
            telaCadastrarProducao.FormClosed += (s, args) => this.Close();
            telaCadastrarProducao.Size = this.Size;
            telaCadastrarProducao.StartPosition = FormStartPosition.CenterScreen;
            telaCadastrarProducao.Show();
            this.Hide();
        }

        private void TelaProducao_Load(object sender, EventArgs e)
        {
            AtualizarListView();
        }

        public void AtualizarListView()
        {
            lvBuscarProducao.Items.Clear();
            foreach (var producao in RepositorioProducao.ListaProducao)
            {
                ListViewItem item = new ListViewItem(new[] {
            producao.ID.ToString(),
            producao.Nome,
            producao.Quantidade.ToString(),
            producao.Data,
            producao.ResponsavelProducao,
        });
                lvBuscarProducao.Items.Add(item);
            }
        }

        private void btnBuscarProducao_Click(object sender, EventArgs e)
        {
            bool itemEncontrado = false;
            string termoBusca = lvBuscarProducao.Text.ToLower().Trim();

            foreach (ListViewItem item in lvBuscarProducao.Items)
            {
                if (item.SubItems[0].Text.ToLower().Contains(termoBusca)) //O nmr entre '[]' é a casa da listview q procura
                {
                    item.Selected = true;
                    lvBuscarProducao.TopItem = item; //Traz o pedido procurado para o topo da lista
                    lvBuscarProducao.Focus(); //Define o foco na ListView
                    itemEncontrado = true;
                    break;
                }
            }
            //Exibe uma mensagem caso não ache nenhum Pedido
            if (!itemEncontrado)
            {
                MessageBox.Show("Produção não encontrada.", "Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExcluirProducao_Click(object sender, EventArgs e)
        {
            TelaExcluirProducao telaExcluirProducao = new TelaExcluirProducao(userType);
            telaExcluirProducao.FormClosed += (s, args) => this.Close();
            telaExcluirProducao.Size = this.Size;
            telaExcluirProducao.StartPosition = FormStartPosition.CenterScreen;
            telaExcluirProducao.Show();
            this.Hide();
        }

        private void btnEditarProducao_Click(object sender, EventArgs e)
        {
            TelaEditarProducao telaEditarProducao = new TelaEditarProducao(userType, this);
            telaEditarProducao.FormClosed += (s, args) => this.Close();
            telaEditarProducao.Size = this.Size;
            telaEditarProducao.StartPosition = FormStartPosition.CenterScreen;
            telaEditarProducao.Show();
            this.Hide();
        }
    }
}
