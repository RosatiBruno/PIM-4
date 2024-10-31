using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public partial class TelaExcluirProducao : Form
    {
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFontePedidos alteradorFontePedidos;
        public TelaExcluirProducao(string userType)
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

            this.Resize += TelaExcluirProducao_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();
        }

        private void TelaExcluirProducao_Resize(object sender, EventArgs e)
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

        private void TelaExcluirProducao_Load(object sender, EventArgs e)
        {
            AtualizarListViewExcluidos();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(userType);
            form2.FormClosed += (s, args) => this.Close();
            form2.Size = this.Size;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
            this.Hide();
        }

        private void btnRetornar2_Click(object sender, EventArgs e)
        {
            TelaProducao telaProducao = new TelaProducao(userType);
            telaProducao.FormClosed += (s, args) => this.Close();
            telaProducao.Size = this.Size;
            telaProducao.StartPosition = FormStartPosition.CenterScreen;
            telaProducao.Show();
            this.Hide();
        }

        private void AtualizarListViewAtivos()
        {
            // Acessa a tela de fornecedores ativos (lvBuscarFornecedores)
            TelaProducao telaProducao = Application.OpenForms.OfType<TelaProducao>().FirstOrDefault();
            if (telaProducao != null)
            {
                telaProducao.AtualizarListView();
            }
        }

        private void AtualizarListViewExcluidos()
        {
            lvBuscarProducaoExcluir.Items.Clear(); // Limpa os itens da ListView
            foreach (var producao in RepositorioProducao.ListaProducaoExcluidos)
            {
                ListViewItem item = new ListViewItem(new[]
                {
            producao.ID.ToString(),
            producao.Nome,
            producao.Quantidade.ToString(),
            producao.Data,
            producao.ResponsavelProducao,
        });
                lvBuscarProducaoExcluir.Items.Add(item); // Adiciona o fornecedor à ListView
            }

        }

        private void btnLogout2_Click(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
        }

        private void btnExcluirProducao_Click(object sender, EventArgs e)
        {
            //Caso o usuário não seja do T.I ou Gerente não permite excluir um pedido
            if (userType == "funcionario")
            {
                MessageBox.Show("Acesso negado! Você não tem permissão para executar essa função.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; //Impede a mudança de tela
            }
            else
            {
                string termoBusca = txtBuscarProducaoExcluir.Text.Trim();
                int.TryParse(termoBusca, out int idBusca);
                Producao producao = RepositorioProducao.ListaProducao
                    .FirstOrDefault(f => f.ID == idBusca);

                if (producao != null)
                {
                    // Remove o fornecedor da lista ativa e adiciona à lista inativa
                    RepositorioProducao.ListaProducao.Remove(producao);
                    RepositorioProducao.ListaProducaoExcluidos.Add(producao); // Adiciona à lista excluidos

                    // Atualiza a ListViews de fornecedores Inativos
                    AtualizarListViewExcluidos();

                    MessageBox.Show("Produção excluida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Produção não encontrado.", "Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


    }
}
