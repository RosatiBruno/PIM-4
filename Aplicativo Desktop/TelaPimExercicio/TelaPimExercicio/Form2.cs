﻿using System;
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
        private Centralizador2 centralizador2;
        private Logout logout;


        public Form2()
        {
            InitializeComponent();

            //Permitindo o redimensionamento da tela
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;

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

            //Inicializando o centralizador
            centralizador2 = new Centralizador2(this);
            Button[] linhaSuperior = { btnFornecedores, btnPedidos, btnProdutos };
            Button[] linhaInferior = { btnCadastrarFunc, btnVendas, btnProducao };

            // Centraliza os botões em duas linhas
            centralizador2.CentralizarEmDuasLinhas(linhaSuperior, linhaInferior);

            this.Resize += Form2_Resize;

            //Iniciando o Logout
            logout = new Logout(this);
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            // Reposiciona a logo no canto inferior esquerdo
            logo.Picture.Location = new Point(20, this.ClientSize.Height - logo.Picture.Height - 10);

            // Ajusta a barra verde para manter a mesma largura e aumentar apenas em altura
            colorBar.Panel.Size = new Size(colorBar.Panel.Width, this.ClientSize.Height);

            // Ajusta o fundo para cobrir toda a tela ao redimensionar
            colorBg.Panel.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);

            //Recalcular a centralização dos componentes
            centralizador2 = new Centralizador2(this);

            // Defina os botões para a linha superior e inferior
            Button[] linhaSuperior = { btnFornecedores, btnPedidos, btnProdutos };
            Button[] linhaInferior = { btnCadastrarFunc, btnVendas, btnProducao };

            // Centraliza os botões em duas linhas
            centralizador2.CentralizarEmDuasLinhas(linhaSuperior, linhaInferior);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TelaPedidos telaPedidos = new TelaPedidos();
            telaPedidos.FormClosed += (s, args) => this.Close();
            telaPedidos.Show();
            this.Hide();
        }


        //Botão de Logout volta pra tela de Login
        private void button1_Click(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
        }

        //Botão de Fornecedores vai pra tela de Fornecedores
        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            TelaFornecedores telaFornecedores = new TelaFornecedores();
            telaFornecedores.FormClosed += (s, args) => this.Close();
            telaFornecedores.Show();
            this.Hide();
        }
    }
}
