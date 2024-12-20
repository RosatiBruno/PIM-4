﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public partial class TelaFuncionario : Form
    {

        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFonteCadastrarFuncionario alteradorFonteCadastrarFuncionario;

        public TelaFuncionario(string userType)
        {
            InitializeComponent();

            //Desativar o botão ao estar logado sem ser como T.I
            this.userType = userType;

            //Alterar o tamanho da fonte
            alteradorFonteCadastrarFuncionario = new AlteradorFonteCadastrarFuncionario(this);
            alteradorFonteCadastrarFuncionario.AlterarFonteCadastrarFuncionario(btnLogout, btnRetornar);

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

            this.Resize += TelaFornecedores_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();
            this.userType = userType;
        }

        private void TelaFornecedores_Resize(object sender, EventArgs e)
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
            btnRetornar.Location = new Point(btnRetornar.Location.X, this.ClientSize.Height - btnRetornar.Height - 35); //35 é a margem inferior

        }

        private void TelaFornecedores_Load(object sender, EventArgs e)
        {

        }

        //Botão de Logout sai do Programa
        private void btnLogout_Click(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
        }

        //Botão Retornar volta ao Menu Inicial (Form2)
        private void btnRetornar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(userType);
            form2.FormClosed += (s, args) => this.Close();
            form2.Size = this.Size;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
            this.Hide();
        }





        
        
        //Função para atualizar a ListView após o cadastro de algum pedido
        public void AtualizarListView()
        {
            lvBuscarFuncionario.Items.Clear();
            foreach (var funcionario in RepositorioFuncionarios.ListaFuncionarios)
            {
                ListViewItem item = new ListViewItem(new[] {
            funcionario.ID.ToString(),
            funcionario.Nome,
            funcionario.Email,
            funcionario.Senha,
        });
                lvBuscarFuncionario.Items.Add(item);
            }
        }
        
        //Atualizar a LV ao abrir a tela
        private void TelaFuncionario_Load(object sender, EventArgs e)
        {
            AtualizarListView();
        }

        private void btnBuscarFuncionario_Click(object sender, EventArgs e)
        {
            bool itemEncontrado = false;
            string termoBusca = lvBuscarFuncionario.Text.Trim();

            foreach (ListViewItem item in lvBuscarFuncionario.Items)
            {
                if (item.SubItems[0].Text.Contains(termoBusca)) //O nmr entre '[]' é a casa da listview q procura
                {
                    item.Selected = true;
                    lvBuscarFuncionario.TopItem = item; //Traz o pedido procurado para o topo da lista
                    lvBuscarFuncionario.Focus(); //Define o foco na ListView
                    itemEncontrado = true;
                    break;
                }
            }
            //Exibe uma mensagem caso não ache nenhum Pedido
            if (!itemEncontrado)
            {
                MessageBox.Show("Funcionário não encontrado.", "Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Botão que vai pra tela de cadastro de novo funcionário
        private void btnCadastrarNovoFuncionario_Click(object sender, EventArgs e)
        {
            TelaCadastrarFuncionario telaCadastrarFuncionario = new TelaCadastrarFuncionario(userType);
            telaCadastrarFuncionario.Size = this.Size; //Passa o tamanho do Form2 para o TelaFornecedores
            telaCadastrarFuncionario.StartPosition = FormStartPosition.CenterScreen; //Centraliza a nova tela na tela
            telaCadastrarFuncionario.FormClosed += (s, args) => this.Close();
            telaCadastrarFuncionario.Show();
            this.Hide();
        }

        private void btnExcluirFuncionario_Click(object sender, EventArgs e)
        {
            TelaExcluirFuncionario telaExcluirFuncionario = new TelaExcluirFuncionario(userType);
            telaExcluirFuncionario.Size = this.Size; //Passa o tamanho do Form2 para o TelaFornecedores
            telaExcluirFuncionario.StartPosition = FormStartPosition.CenterScreen; //Centraliza a nova tela na tela
            telaExcluirFuncionario.FormClosed += (s, args) => this.Close();
            telaExcluirFuncionario.Show();
            this.Hide();
        }
    }
}
