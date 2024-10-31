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
    public partial class TelaCadastrarProducao : Form
    {
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        public TelaCadastrarProducao(string userType)
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

            this.Resize += TelaCadastrarProducao_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();

            //Não permite a digitação na área de ID já que o mesmo é gerado automaticamente
            txtIDProducao.Enabled = false;
            txtIDProducao.Text = RepositorioProducao2.GerarNovoID().ToString();
        }

        private void TelaCadastrarProducao_Resize(object sender, EventArgs e)
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

        private void btnLogout2_Click(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(userType);
            form2.FormClosed += (s, args) => this.Close();
            form2.Size = this.Size;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
            this.Hide();
        }

        private void btnConfirmarCadastroNovaProducao_Click(object sender, EventArgs e)
        {
            Producao novaProducao = new Producao
            {
                //Informações passadas no cadastro do Fornecedor

                //ID = txtIDFornecedor.Text, //Para atribuir o ID que foi digitado
                ID = RepositorioProducao.GerarNovoID(), //Para atribuir o ID sequencial automaticamente
                Nome = txtNomeProducao.Text,
                Quantidade = int.TryParse(txtQuantidadeProducao.Text, out int quantidade) ? quantidade : 1,
                Data = txtDataProducao.Text,
                ResponsavelProducao = txtResponsavelProducao.Text,
            };

            //Dialogo de confirmação de cadastro
            DialogResult resultado = MessageBox.Show("Deseja realiza o Cadastro?", "Confirmação de Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Cadastro Realizado com Sucesso!", "Cadastro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Adiciona à lista de producao
                RepositorioProducao.ListaProducao.Add(novaProducao);
            }
            else
            {
                MessageBox.Show("Cadastro Não Realizado!", "Cadastro Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Chama a função de limpar o que já está escrito após cadastrar um fornecedor
            LimparCampos();

            //Atualiza o ID na tela de cadastro
            txtIDProducao.Text = RepositorioProducao2.GerarNovoID().ToString();
        }
        private void LimparCampos()
        {
            txtNomeProducao.Clear();
            txtQuantidadeProducao.Clear();
            txtDataProducao.Clear();
            txtResponsavelProducao.Clear();

            //Define o foco no campo txtNomeFornecedor
            txtNomeProducao.Focus();
        }

    }
}