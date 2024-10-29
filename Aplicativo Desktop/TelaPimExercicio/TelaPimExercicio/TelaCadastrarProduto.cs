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
    public partial class TelaCadastrarProduto : Form
    {
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFonteProdutos alteradorFonteProdutos;

        public TelaCadastrarProduto(string userType)
        {
            InitializeComponent();

            //Desativar o botão ao estar logado sem ser como T.I
            this.userType = userType;

            //Alterar o tamanho da fonte
            alteradorFonteProdutos = new AlteradorFonteProdutos(this);
            alteradorFonteProdutos.AlterarFonteProdutos(btnLogout, btnRetornar);

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

            this.Resize += TelaCadastrarProduto_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();

            //Não permite a digitação na área de ID já que o mesmo é gerado automaticamente
            txtIDProduto.Enabled = false;
            txtIDProduto.Text = RepositorioFornecedores.GerarNovoID().ToString();
        }

        private void TelaCadastrarProduto_Resize(object sender, EventArgs e)
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

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            TelaProdutos telaProdutos = new TelaProdutos(userType);
            telaProdutos.FormClosed += (s, args) => this.Close();
            telaProdutos.Size = this.Size;
            telaProdutos.StartPosition = FormStartPosition.CenterScreen;
            telaProdutos.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(userType);
            form2.FormClosed += (s, args) => this.Close();
            form2.Size = this.Size;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
            this.Hide();
        }

        private void btnConfirmarCadastroNovoProduto_Click(object sender, EventArgs e)
        {

            Produtos novoProduto = new Produtos
            {
                //Informações passadas no cadastro do Fornecedor

                //ID = txtIDFornecedor.Text, //Para atribuir o ID que foi digitado
                ID = RepositorioProdutos.GerarNovoID(), //Para atribuir o ID sequencial automaticamente
                Nome = txtNomeProduto.Text,
                Quantidade = int.TryParse(txtQuantidadeProduto.Text, out int quantidade) ? quantidade : 1,
                ValorUnitario = decimal.TryParse(txtValorUnitarioProduto.Text, out decimal valorUnitario) ? valorUnitario : 1,
                EmpresaCompra = txtEmpresaCompraProduto.Text,
            };

            //Dialogo de confirmação de cadastro
            DialogResult resultado = MessageBox.Show("Deseja realiza o Cadastro?", "Confirmação de Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Cadastro Realizado com Sucesso!", "Cadastro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Adiciona o Fornecedor cadastrado à lista de pedido
                RepositorioProdutos.ListaProdutos.Add(novoProduto);
            }
            else
            {
                MessageBox.Show("Cadastro Não Realizado!", "Cadastro Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Chama a função de limpar o que já está escrito após cadastrar um fornecedor
            LimparCampos();
        }

        //Limpa tudo que foi escrito após cadastrar um Fornecedor
        private void LimparCampos()
        {
            txtNomeProduto.Clear();
            txtQuantidadeProduto.Clear();
            txtValorUnitarioProduto.Clear();
            txtEmpresaCompraProduto.Clear();

            //Define o foco no campo txtNomeFornecedor
            txtNomeProduto.Focus();
        }


    }
}
