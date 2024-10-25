using System;
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
    public partial class Form2 : Form
    {
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFonteMenu alteradorFonteMenu;

        public Form2(string userType)
        {
            InitializeComponent();

            //Desativar o botão ao estar logado sem ser como T.I
            this.userType = userType;
            ConfigurarAcesso();
            this.MouseDown += new MouseEventHandler(Form2_MouseDown);

            //Permitindo o redimensionamento da tela
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;

            //Abre em Tela Cheia
            this.WindowState = FormWindowState.Maximized;

            //Definindo o tamanho mínimo da tela para 800x600
            this.MinimumSize = new Size(800, 600);

            //Criando e adicionando a logo
            logo = new Logo(this);
            this.Controls.Add(logo.Picture);

            //Posicionando a logo no canto inferior esquerdo
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

            //Centraliza os botões em duas linhas
            centralizador2.CentralizarEmDuasLinhas(linhaSuperior, linhaInferior);

            this.Resize += Form2_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela - É efetivo apenas quando a tela não está maximizada
            CenterToScreen();

            //Inicializando o alterador da fonte
            alteradorFonteMenu = new AlteradorFonteMenu(this);
            alteradorFonteMenu.AlterarFonteMenu(btnFornecedores, btnPedidos, btnProdutos, btnCadastrarFunc, btnVendas, btnProducao, btnLogout);
        }

        //Configurar o acesso ao botão "Cadastrar Funcionário"
        private void ConfigurarAcesso()
        {
            if (userType == "gerente" || userType == "funcionario")
            {
                //Acesso negado, mas o botão fica ativado
                btnCadastrarFunc.Enabled = true;
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            //Reposiciona a logo no canto inferior esquerdo
            logo.Picture.Location = new Point(20, this.ClientSize.Height - logo.Picture.Height - 10);

            //Ajusta a barra verde para manter a mesma largura e aumentar apenas em altura
            colorBar.Panel.Size = new Size(colorBar.Panel.Width, this.ClientSize.Height);

            //Ajusta o fundo para cobrir toda a tela ao redimensionar
            colorBg.Panel.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);

            //Recalcular a centralização dos componentes
            Button[] linhaSuperior = { btnFornecedores, btnPedidos, btnProdutos };
            Button[] linhaInferior = { btnCadastrarFunc, btnVendas, btnProducao };

            //Centraliza os botões em duas linhas
            centralizador2.CentralizarEmDuasLinhas(linhaSuperior, linhaInferior);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TelaPedidos telaPedidos = new TelaPedidos(userType);
            telaPedidos.Size = this.Size; //Passa o tamanho do Form2 para o TelaPedidos
            telaPedidos.StartPosition = FormStartPosition.CenterScreen; //Centraliza a nova tela na tela
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
            TelaFornecedores telaFornecedores = new TelaFornecedores(userType);
            telaFornecedores.Size = this.Size; //Passa o tamanho do Form2 para o TelaFornecedores
            telaFornecedores.StartPosition = FormStartPosition.CenterScreen; //Centraliza a nova tela na tela
            telaFornecedores.FormClosed += (s, args) => this.Close();
            telaFornecedores.Show();
            this.Hide();
        }

        //Botão Produtos vai pra tela de Produtos
        private void btnProdutos_Click(object sender, EventArgs e)
        {
            TelaProdutos telaProdutos = new TelaProdutos(userType);
            telaProdutos.Size = this.Size; //Passa o tamanho do Form2 para o TelaProdutos
            telaProdutos.StartPosition = FormStartPosition.CenterScreen; //Centraliza a nova tela na tela
            telaProdutos.FormClosed += (s, args) => this.Close();
            telaProdutos.Show();
            this.Hide();
        }

        //Botão Cadastrar Funcionário vai pra tela de Cadastro de Novo Funcionário
        private void btnCadastrarFunc_Click(object sender, EventArgs e)
        {
            //Caso o usuário não seja do T.I, não permite cadastrar outro funcionário
            if (userType == "gerente" || userType == "funcionario")
            {
                MessageBox.Show("Acesso negado! Você não tem permissão para executar essa função.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; //Impede a mudança de tela para a tela de caddastro de funcionário
            }
            else
            {
                CadastrarFunc cadastrarFunc = new CadastrarFunc(userType);
                cadastrarFunc.Size = this.Size; //Passa o tamanho do Form2 para o CadastrarFunc
                cadastrarFunc.StartPosition = FormStartPosition.CenterScreen; //Centraliza a nova tela na tela
                cadastrarFunc.FormClosed += (s, args) => this.Close();
                cadastrarFunc.Show();
                this.Hide();
            }
        }

        //Botão de Vendas vai pra tela de Vendas
        private void btnVendas_Click(object sender, EventArgs e)
        {
            TelaVendas telaVendas = new TelaVendas(userType);
            telaVendas.Size = this.Size; //Passa o tamanho do Form2 para o TelaVendas
            telaVendas.StartPosition = FormStartPosition.CenterScreen; //Centraliza a nova tela na tela
            telaVendas.FormClosed += (s, args) => this.Close();
            telaVendas.Show();
            this.Hide();
        }

        //Botão de Produção vai pra tela de Produção
        private void btnProducao_Click(object sender, EventArgs e)
        {
            TelaProd telaProd = new TelaProd(userType);
            telaProd.Size = this.Size; //Passa o tamanho do Form2 para o TelaProd
            telaProd.StartPosition = FormStartPosition.CenterScreen; //Centraliza a nova tela na tela
            telaProd.FormClosed += (s, args) => this.Close();
            telaProd.Show();
            this.Hide();
        }
    }
}
