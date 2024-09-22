using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TelaPimExercicio
{
    public partial class Form2 : Form
    {


        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;


        public Form2()
        {
            InitializeComponent();

            //Definindo o tamanho da tela
            this.Size = new System.Drawing.Size(800, 600);
            //Impedindo o redimensionamento da tela
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //Impedindo a maximização da tela
            this.MaximizeBox = false;



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



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        //Botão de Logout volta pra tela de Login
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.FormClosed += (s, args) => this.Close(); //Fecha o Form2 quando o Form1 é aberto ao clicar no botão de logout
            form1.Show();
            this.Hide(); //Oculta o Form2 enquanto o Form1 está aberto
        }
    }
}
