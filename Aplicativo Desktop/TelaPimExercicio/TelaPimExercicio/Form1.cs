using System;
using System.Drawing;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public partial class Form1 : Form
    {
        //Declarando as variáveis dos componentes (Logo, ColorBar e ColorBg)
        private Logo logo;
        private ColorBar colorBar;
        private ColorBackground colorBg;
        private Centralizador centralizador;
        private ColorSquare colorSquare;


        public Form1()
        {
            InitializeComponent();

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

            //Criando e adicionando a barra verde superior
            colorBar = new ColorBar(this);
            this.Controls.Add(colorBar.Panel);

            //Criando e adicionando o quadrado cinza
            colorSquare = new ColorSquare(this);
            this.Controls.Add(colorSquare.Panel);    

            //Criando e adicionando a cor verde de fundo
            colorBg = new ColorBackground(this);
            this.Controls.Add(colorBg.Panel);

            //Inicializando o centralizador
            centralizador = new Centralizador(this);
            centralizador.Centralizar(txtId, txtSenha, lblId, lblSenha, btnLogin, btnSair, lblLogin, lblBemVindo);

            //Inicializando o centralizador do btnSair
            ReposicionarBtnSair reposicionarBtnSair = new ReposicionarBtnSair(this);
            reposicionarBtnSair.Centralizar(btnLogin, btnSair);

            //Atualiza os componente ao redimensionar a tela
            this.Resize += Form1_Resize;

            //Centraliza no Monitor/Tela - É efetivo apenas quando a tela não está maximizada
            CenterToScreen();
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            //Redimensionar e reposicionar os componentes com base no novo tamanho da janela
            colorBg.Panel.Size = new Size(this.ClientSize.Width, this.ClientSize.Height); //Ajustar o fundo
            colorBar.Panel.Width = this.ClientSize.Width; //Ajustar a largura da barra

            //Recalcular a centralização dos componentes
            centralizador.Centralizar(txtId, txtSenha, lblId, lblSenha, btnLogin, btnSair, lblLogin, lblBemVindo);
            ReposicionarBtnSair reposicionarBtnSair = new ReposicionarBtnSair(this);
            reposicionarBtnSair.Centralizar(btnLogin, btnSair);

            //Centralizar o quadrado cinza
            colorSquare.Panel.Location = new Point((this.ClientSize.Width - colorSquare.Panel.Width) / 2,
                                                   (this.ClientSize.Height - colorSquare.Panel.Height) / 2);
            //Centralizar a logo
            logo.Picture.Location = new Point((this.ClientSize.Width - logo.Picture.Width) / 2, logo.Picture.Top);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            //Declaração das variáveis de login & verificação do tipo do login
            string tempId, tempSenha;
            string userType = "funcionario";

            //Pega os dados digitados e passa para as variáveis para verificação.
            tempId = txtId.Text;
            tempSenha = txtSenha.Text;

            bool loginBemSucedido = RepositorioFuncionarios.AutenticarFuncionario(tempId, tempSenha);

            if (loginBemSucedido)
            {
                // Define o tipo de usuário
                if (tempId == "func" && tempSenha == "1234")
                {
                    userType = "funcionario";
                }
                else if (tempId == "gerente" && tempSenha == "1234")
                {
                    userType = "gerente";
                }
                else if (tempId == "ti" && tempSenha == "1234")
                {
                    userType = "ti";
                }

                // Exibe a tela de confirmação de login
                //ConfirmacaoLogin confirmacaoLogin = new ConfirmacaoLogin();
                string emailCadastrado = tempId != "func" && tempId != "gerente" && tempId != "ti" ? tempId + "@example.com" : string.Empty;
                ConfirmacaoLogin confirmacaoLogin = new ConfirmacaoLogin(emailCadastrado);
                confirmacaoLogin.ShowDialog();

                // Após a confirmação do login, abre o Form2 se confirmado
                if (confirmacaoLogin.LoginConfirmado)
                {
                    Form2 form2 = new Form2(userType);
                    form2.FormClosed += (s, args) => this.Close();
                    form2.Size = this.Size;
                    form2.StartPosition = FormStartPosition.CenterScreen;
                    form2.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Login ou senha incorretos! Tente novamente!", "Erro ao efetuar o Login!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Text = "";
            }
        }

        //Fecha o programa após a confirmação
        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja fechar o Programa?", "Confirmação de Fechamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }


    }
}
