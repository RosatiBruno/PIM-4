using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Linq;

namespace TelaPimExercicio
{
    public partial class ConfirmacaoLogin : Form
    {
        private string codigoConfirmacao;
        private string userType;
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private AlteradorFontePedidos alteradorFontePedidos;
        public bool LoginConfirmado { get; private set; } //Propriedade para verificar se o login foi confirmado

        public ConfirmacaoLogin(string usarID)
        {
            InitializeComponent();

            //Não permitindo o redimensionamento da tela
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

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

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();
        }

        //Botão para mandar o código para o email informado
        private void btnVerificarEmail_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            codigoConfirmacao = GerarCodigo(); // Gera o código de confirmação
            EnviarEmail(email, codigoConfirmacao); // Envia o e-mail

            MessageBox.Show("Código de confirmação enviado para seu e-mail.", "Código enviado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Geração do código aleatório de login
        private string GerarCodigo()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); //Gera um código entre 100000 e 999999
        }

        //Botão para verificar se o código inserido é igual ao código gerado
        private void btnVerificarCodigo_Click(object sender, EventArgs e)
        {
            string codigoInserido = txtVerificarCodigo.Text;

            if (codigoInserido == codigoConfirmacao)
            {
                MessageBox.Show("Login realizado com sucesso!", "Login realizado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginConfirmado = true; // Define que o login foi confirmado
                this.Close(); // Fecha a tela de confirmação
            }
            else
            {
                MessageBox.Show("Código de confirmação inválido! Tente novamente!", "Código ínválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Envio da mensagem por email
        public void EnviarEmail(string emailDestinatario, string codigo)
        {
            //Mensagem de e-mail
            var mensagem = new MailMessage();
            mensagem.From = new MailAddress("brunomito.srosati@gmail.com", "UrbAgro");
            mensagem.To.Add(emailDestinatario);
            mensagem.Subject = "Código de Confirmação";
            mensagem.Body = $"Olá! \n\nBem vindo ao sistema UrbAgro! \n\nSeu código de acesso é: {codigo} \n\nSe você não solicitou este código, por favor, ignore este e-mail. \n\nAgradecemos pela sua confiança! \n\nAtenciosamente, \nEquipe UrbAgro"; //Email

            //Configuração do cliente SMTP
            using (var smtp = new SmtpClient("smtp.gmail.com", 587)) //Servidor SMTP
            {
                smtp.Credentials = new NetworkCredential("brunomito.srosati@gmail.com", "vpxi ugmt kxpe lbvb"); //Credenciais SMTP - NÃO ALTERA-LÁS PARA NÃO GERAR ERROS!!!
                smtp.EnableSsl = true; //Habilita SSL
                smtp.Send(mensagem); //Envia o e-mail
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
