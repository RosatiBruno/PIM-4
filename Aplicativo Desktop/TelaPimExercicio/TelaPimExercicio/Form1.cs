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

            //Definindo o tamanho da tela   ------------------------------------------- TIRAR ESSAS LIMITAÇÕES E DEIXAR RESPNSIVO!
            this.Size = new System.Drawing.Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            //   ---------------------------------------------------------------------- TIRAR ESSAS LIMITAÇÕES E DEIXAR RESPNSIVO!

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
            centralizador.Centralizar(txtId, txtSenha, lblId, lblSenha, btnLogin, lblLogin, lblBemVindo);

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Declaração das variáveis de login
            string tempId, tempSenha;

            //Pega os dados digitados e passa para as variáveis para verificação.
            tempId = txtId.Text;
            tempSenha = txtSenha.Text;

            //Verificação para login
            if (tempId == "func" && tempSenha == "1234" || tempId == "gerente" && tempSenha == "1234" || tempId == "ti" && tempSenha == "1234")
            {
                Form2 form2 = new Form2();
                form2.FormClosed += (s, args) => this.Close(); //Fecha o Form1 quando o Form2 é aberto
                form2.Show();
                this.Hide(); //Oculta o Form1 enquanto o Form2 está aberto
            }
            else
            {
                MessageBox.Show("Login ou senha incorretos! Tente novamente!", "Erro ao efetuar o Login!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Text = ""; //Ao errar o login, a senha digitada é apagada automaticamente
            }
        }
    }
}
