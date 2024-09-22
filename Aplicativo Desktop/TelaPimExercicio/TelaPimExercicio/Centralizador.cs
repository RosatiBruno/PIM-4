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
            txtId.Location = new Point((larguraMaxima - txtId.Width) / 2, (form.ClientSize.Height - txtId.Height) / 2 - 20);
            lblId.Location = new Point(txtId.Left, txtId.Top - lblId.Height - 10);

            // Alinha a LabelSenha ao canto esquerdo dos TXTSenha
            txtSenha.Location = new Point((larguraMaxima - txtSenha.Width) / 2, txtId.Bottom + margem * 4);
            lblSenha.Location = new Point(txtSenha.Left, txtSenha.Top - lblSenha.Height - 10);

            //Alinhando a LabelBemVindo ao canto esquerdo da LabelId
            lblBemVindo.Location = new Point(lblId.Left, lblId.Top - lblId.Height - 10 - margem);

            //Alinhando a LabelLogin ao canto esquerdo da LabelId
            lblLogin.Location = new Point(lblId.Left, lblId.Top - lblId.Height - 10 - margem * 4);

            // Converte a senha digitada em '****'
            txtSenha.UseSystemPasswordChar = true;

            // Centraliza o Botão
            btnLogin.Location = new Point((larguraMaxima - btnLogin.Width) / 2, txtSenha.Bottom + margem * 5);

            // Aumenta as fontes do Form1
            float tamanhoFonte = 10; //Variavel que define o tamanho da fonte
            lblLogin.Font = new Font(lblLogin.Font.FontFamily, tamanhoFonte);
            lblBemVindo.Font = new Font(lblBemVindo.Font.FontFamily, tamanhoFonte);
            lblId.Font = new Font(lblId.Font.FontFamily, tamanhoFonte);
            lblSenha.Font = new Font(lblSenha.Font.FontFamily, tamanhoFonte);
            txtId.Font = new Font(txtId.Font.FontFamily, tamanhoFonte);
            txtSenha.Font = new Font(txtSenha.Font.FontFamily, tamanhoFonte);
            btnLogin.Font = new Font(btnLogin.Font.FontFamily, tamanhoFonte);
        }
    }
}