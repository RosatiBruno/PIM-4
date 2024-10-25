using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public class ReposicionarBtnSair
    {
        private Form form;

        public ReposicionarBtnSair(Form form)
        {
            this.form = form;
        }

        public void Centralizar(Button btnLogin, Button btnSair)
        {
            int margem = 10; //Margem Vertical entre os botões
            int larguraMaxima = form.ClientSize.Width;

            //Centraliza o Botão btnSair  abaixo do btnLogin
            btnSair.Location = new Point((larguraMaxima - btnSair.Width) / 2, btnLogin.Bottom + margem);

            //Aumenta as fontes do Form1
            float tamanhoFonte = 10; //Variavel que define o tamanho da fonte
            btnSair.Font = new Font(btnSair.Font.FontFamily, tamanhoFonte);
        }
    }
}
