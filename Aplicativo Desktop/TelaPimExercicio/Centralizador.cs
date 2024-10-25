using System.Drawing;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public class Centralizador
    {
        private Form form;

        public Centralizador(Form form)
        {
            this.form = form;
        }

        public void Centralizar(TextBox txtId, TextBox txtSenha, Label lblId, Label lblSenha, Button btnLogin, Label lblLogin, Label lblBemVindo)
        {
            int margem = 10; // Margem Vertical entre os itens
            int larguraMaxima = form.ClientSize.Width;

            // Alinha a LabelId ao canto esquerdo dos TXTId
            txtId.Location = new Point((larguraMaxima - txtId.Width) / 2, lblBemVindo.Bottom + margem);
            lblId.Location = new Point(txtId.Left, txtId.Top - lblId.Height - 10);

            // Alinha a LabelSenha ao canto esquerdo dos TXTSenha
            txtSenha.Location = new Point((larguraMaxima - txtSenha.Width) / 2, txtId.Bottom + margem * 4);
            lblSenha.Location = new Point(txtSenha.Left, txtSenha.Top - lblSenha.Height - 10);

            // Converte a senha digitada em '****'
            txtSenha.UseSystemPasswordChar = true;

            // Centraliza o Botão btnLogin
            btnLogin.Location = new Point((larguraMaxima - btnLogin.Width) / 2, txtSenha.Bottom + margem * 5);

            // Aumenta as fontes do Form1
            float fontSize = 10; // Define o tamanho da fonte
            lblId.Font = new Font(lblId.Font.FontFamily, fontSize);
            lblSenha.Font = new Font(lblSenha.Font.FontFamily, fontSize);
            txtId.Font = new Font(txtId.Font.FontFamily, fontSize);
            txtSenha.Font = new Font(txtSenha.Font.FontFamily, fontSize);
            btnLogin.Font = new Font(btnLogin.Font.FontFamily, fontSize);
        }
    }
}