﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public partial class TelaExcluirPedido : Form
    {
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFontePedidos alteradorFontePedidos;

        public TelaExcluirPedido(string userType)
        {
            InitializeComponent();

            //Desativar o botão ao estar logado sem ser como T.I
            this.userType = userType;

            //Alterar o tamanho da fonte
            alteradorFontePedidos = new AlteradorFontePedidos(this);
            alteradorFontePedidos.AlterarFontePedidos(btnLogout2, btnRetornar2);

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

            this.Resize += TelaExcluirPedido_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();
        }

        private void TelaExcluirPedido_Resize(object sender, EventArgs e)
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
            btnRetornar2.Location = new Point(btnRetornar2.Location.X, this.ClientSize.Height - btnRetornar2.Height - 35); //35 é a margem inferior
        }

        //Botão Home retorna pra tela inicial
        private void btnHome_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(userType);
            form2.FormClosed += (s, args) => this.Close();
            form2.Size = this.Size;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
            this.Hide();
        }

        //Botão Retornar volta a tela de pedidos
        private void btnRetornar2_Click(object sender, EventArgs e)
        {
            TelaPedidos telaPedidos = new TelaPedidos(userType);
            telaPedidos.FormClosed += (s, args) => this.Close();
            telaPedidos.Size = this.Size;
            telaPedidos.StartPosition = FormStartPosition.CenterScreen;
            telaPedidos.Show();
            this.Hide();
        }

        //Botão de Logout sai do Programa
        private void btnLogout2_Click(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
        }

        private void btnExcluirPedido_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscarPedidoExcluir.Text.Trim();
            int.TryParse(termoBusca, out int idBusca);
            Pedidos pedidos = RepositorioPedidos.ListaPedidos
                .FirstOrDefault(f => f.ID == idBusca);

            if (pedidos != null)
            {
                // Remove o fornecedor da lista ativa e adiciona à lista inativa
                RepositorioPedidos.ListaPedidos.Remove(pedidos);
                RepositorioPedidos.ListaPedidosExcluidos.Add(pedidos); // Adiciona à lista excluidos

                // Atualiza a ListViews de fornecedores Inativos
                AtualizarListViewExcluidos();

                MessageBox.Show("Pedido excluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Pedido não encontrado.", "Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AtualizarListViewAtivos()
        {
            // Acessa a tela de fornecedores ativos (lvBuscarFornecedores)
            TelaPedidos telaPedidos = Application.OpenForms.OfType<TelaPedidos>().FirstOrDefault();
            if (telaPedidos != null)
            {
                telaPedidos.AtualizarListView();
            }
        }

        private void AtualizarListViewExcluidos()
        {
            lvBuscarPedidosExcluidos.Items.Clear(); // Limpa os itens da ListView
            foreach (var pedidos in RepositorioPedidos.ListaPedidosExcluidos)
            {
                ListViewItem item = new ListViewItem(new[]
                {
            pedidos.ID.ToString(),
            pedidos.Nome,
            pedidos.Quantidade.ToString(),
            pedidos.ValorUnitario.ToString(),
            pedidos.EmpresaCompra,
        });
                lvBuscarPedidosExcluidos.Items.Add(item); // Adiciona o fornecedor à ListView
            }

        }

        private void TelaExcluirPedido_Load(object sender, EventArgs e)
        {
            AtualizarListViewExcluidos();
        }
    }
}