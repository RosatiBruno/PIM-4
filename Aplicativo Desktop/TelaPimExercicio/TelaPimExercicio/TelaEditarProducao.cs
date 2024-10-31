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
    public partial class TelaEditarProducao : Form
    {
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFontePedidos alteradorFontePedidos;
        private TelaProducao telaProducao;
        public TelaEditarProducao(string userType, TelaProducao telaProducao)
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

            this.Resize += TelaEditarProducao_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();

            //Não permite a digitação na área de ID já que o mesmo é gerado automaticamente
            txtIDProducaoEditar.Enabled = false;
        }

        private void TelaEditarProducao_Resize(object sender, EventArgs e)
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

        private void TelaEditarProducao_Load(object sender, EventArgs e)
        {

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

        private void btnBuscarEditarProducao_Click(object sender, EventArgs e)
        {
            // Tenta converter o ID de pedido digitado para um inteiro
            if (int.TryParse(txtBuscarEditarProducao.Text, out int idProducao))
            {
                // Chama o método para buscar e exibir o pedido com base no ID
                ExibirProducaoParaEdicao(idProducao);
            }
            else
            {
                MessageBox.Show("ID da produção inválido.", "Produção não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void ExibirProducaoParaEdicao(int idProducao)
        {
            // Busca o pedido na lista de pedidos pelo ID
            var producao = RepositorioProducao.ListaProducao.FirstOrDefault(p => p.ID == idProducao);

            if (producao != null)
            {
                // Se o pedido for encontrado, preenche os campos de edição com os dados
                txtNomeEditarProducao.Text = producao.Nome;
                txtIDProducaoEditar.Text = producao.ID.ToString();
                txtQuantidadeProducaoEditar.Text = producao.Quantidade.ToString();
                txtDataProducaoEditar.Text = producao.Data;
                txtResponsavelProducaoEditar.Text = producao.ResponsavelProducao;
            }
            else
            {
                // Exibe mensagem se o pedido não for encontrado
                MessageBox.Show("Produção não encontrada. Verifique o ID e tente novamente.", "Produção não encontrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnLogout2_Click(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
        }

        private void btnConfirmarEdicaoProducao_Click(object sender, EventArgs e)
        {
            //Caso o usuário não seja do T.I ou Gerente não permite excluir um pedido
            if (userType == "funcionario")
            {
                MessageBox.Show("Acesso negado! Você não tem permissão para executar essa função.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; //Impede a mudança de tela
            }
            else
            {
                //Converte o ID do pedido para um int - Sem essa conversão da erro
                if (int.TryParse(txtIDProducaoEditar.Text, out int idProducao))
                {
                    //Busca o pedido na lista de pedidos pelo ID que foi convertido
                    var producao = RepositorioProducao.ListaProducao.FirstOrDefault(p => p.ID == idProducao);

                    if (producao != null)
                    {
                        //Atualiza as informações do pedido
                        producao.Nome = txtNomeEditarProducao.Text;
                        producao.Quantidade = int.Parse(txtQuantidadeProducaoEditar.Text);
                        producao.Data = txtDataProducaoEditar.Text;
                        producao.ResponsavelProducao = txtResponsavelProducaoEditar.Text;

                        MessageBox.Show("Produção atualizada com sucesso!", "Produção atualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Atualiza a ListView na TelaPedidos
                        telaProducao?.AtualizarListView();

                    }
                    else
                    {
                        MessageBox.Show("Produção não encontrada.", "Produção não encontrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("ID da produção inválida.", "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

    }
}
