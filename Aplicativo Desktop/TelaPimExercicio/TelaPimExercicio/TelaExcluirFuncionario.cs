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
    public partial class TelaExcluirFuncionario : Form
    {
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFontePedidos alteradorFontePedidos;
        public TelaExcluirFuncionario(string userType)
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

            this.Resize += TelaExcluirFuncionario_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();
        }

        private void TelaExcluirFuncionario_Resize(object sender, EventArgs e)
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

        //Botão de Logout sai do Programa
        private void btnLogout2_Click(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
        }

        //Botão Home retorna pra tela inicial
        private void btnHome_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(userType);
            form2.FormClosed += (s, args) => this.Close();
            form2.Size = this.Size;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
            this.Hide();
        }

        //Botão Retornar volta a tela de funcionarios
        private void btnRetornar2_Click(object sender, EventArgs e)
        {
            TelaFuncionario telaFuncionario = new TelaFuncionario(userType);
            telaFuncionario.FormClosed += (s, args) => this.Close();
            telaFuncionario.Size = this.Size;
            telaFuncionario.StartPosition = FormStartPosition.CenterScreen;
            telaFuncionario.Show();
            this.Hide();
        }

        private void btnExcluirFuncionário_Click(object sender, EventArgs e)
        {
            //Caso o usuário não seja do T.I ou Gerente não permite excluir um pedido
            if (userType == "funcionario")
            {
                MessageBox.Show("Acesso negado! Você não tem permissão para executar essa função.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; //Impede a mudança de tela
            }
            else
            {
                string termoBusca = txtBuscarFuncionarioExcluir.Text.Trim();
                int.TryParse(termoBusca, out int idBusca);
                Funcionarios funcionarios = RepositorioFuncionarios.ListaFuncionarios
                    .FirstOrDefault(f => f.ID == idBusca);

                if (funcionarios != null)
                {

                    // Verifica se o ID é 1, 2 ou 3 (TI, Gerente, Funcionário - Logins Padrões)
                    if (idBusca == 1 || idBusca == 2 || idBusca == 3)
                    {
                        MessageBox.Show("Não é possível excluir esse funcionário! (Funcionário padrão do sistema para teste) .", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Impede a exclusão
                    }

                    // Remove o fornecedor da lista ativa e adiciona à lista inativa
                    RepositorioFuncionarios.ListaFuncionarios.Remove(funcionarios);
                    RepositorioFuncionarios.ListaFuncionariosExcluidos.Add(funcionarios); // Adiciona à lista excluidos

                    // Atualiza a ListViews de fornecedores Inativos
                    AtualizarListViewExcluidos();

                    MessageBox.Show("Funcionário excluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Funcionário não encontrado.", "Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void AtualizarListViewAtivos()
        {
            // Acessa a tela de funcionário ativos
            TelaFuncionario telaFuncionario = Application.OpenForms.OfType<TelaFuncionario>().FirstOrDefault();
            if (telaFuncionario != null)
            {
                telaFuncionario.AtualizarListView();
            }
        }

        private void AtualizarListViewExcluidos()
        {
            lvExcluirFuncionario.Items.Clear(); // Limpa os itens da ListView
            foreach (var funcionarios in RepositorioFuncionarios.ListaFuncionariosExcluidos)
            {
                ListViewItem item = new ListViewItem(new[]
                {
            funcionarios.ID.ToString(),
            funcionarios.Nome,
            funcionarios.Email.ToString(),
            funcionarios.Senha.ToString(),
        });
                lvExcluirFuncionario.Items.Add(item); // Adiciona o funcionario à ListView
            }
        }

    }
}
