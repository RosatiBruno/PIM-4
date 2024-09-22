using System;

public class Class1
{
	public Class1()
	{
        private void CentralizarItens()
        {
            //Centraliza os itens da tela inicial (Form1)
            int margem = 10;    //Margem Vertical entre os itens
            int larguraMaxima = this.ClientSize.Width;
            int alturaMaxima = this.ClientSize.Height;

            //Alinha a LabelId ao canto esquerdo dos TXTId
            txtId.Location = new Point((larguraMaxima - txtId.Width) / 2, (this.ClientSize.Height - txtId.Height) / 2 - 20);
            lblId.Location = new Point(txtId.Left, txtId.Top - lblId.Height - 10);

            //Alinha a LabelSenha ao canto esquerdo dos TXTSenha
            txtSenha.Location = new Point((larguraMaxima - txtSenha.Width) / 2, txtId.Bottom + margem * 4);
            lblSenha.Location = new Point(txtSenha.Left, txtSenha.Top - lblSenha.Height - 10);

            //Converte a senha digitada em '****'
            txtSenha.UseSystemPasswordChar = true;

            //Centraliza o Botão
            btnLogin.Location = new Point((larguraMaxima - btnLogin.Width) / 2, txtSenha.Bottom + margem * 5);

            //Aumenta as fonte do Form1
            lblId.Font = new Font(lblId.Font.FontFamily, 10);
            lblSenha.Font = new Font(lblSenha.Font.FontFamily, 10);
            txtId.Font = new Font(txtId.Font.FontFamily, 10);
            txtSenha.Font = new Font(txtSenha.Font.FontFamily, 10);
            btnLogin.Font = new Font(btnLogin.Font.FontFamily, 10);
        }
    }
}
