using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TelaPimExercicio
{
    public partial class TelaCadastroPedido : Form
    {
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFontePedidos alteradorFontePedidos;
        public TelaCadastroPedido(string userType)
        {
            InitializeComponent();

            //Desativar o botão ao estar logado sem ser como T.I
            this.userType = userType;

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

            this.Resize += TelaCadastrarPedido_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();

            //Não permite a digitação na área de ID já que o mesmo é gerado automaticamente
            txtIDPedido.Enabled = false;
            txtIDPedido.Text = RepositorioFornecedores.GerarNovoID().ToString();
        }

        private void TelaCadastrarPedido_Resize(object sender, EventArgs e)
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

        private void TelaCadastroPedido_Load(object sender, EventArgs e)
        {
        }

        //Botão de retornar volta a tela de Pedidos
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

        //Retorna para a tela inicial
        private void btnHome_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(userType);
            form2.FormClosed += (s, args) => this.Close();
            form2.Size = this.Size;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
            this.Hide();
        }

        //Cadastro de Pedido
        private void btnConfirmarCadastroNovoPedido_Click(object sender, EventArgs e)
        {
            Pedidos novoPedido = new Pedidos
            {
                //Informações passadas no cadastro do Fornecedor

                //ID = txtIDFornecedor.Text, //Para atribuir o ID que foi digitado
                ID = RepositorioPedidos.GerarNovoID(), //Para atribuir o ID sequencial automaticamente
                Nome = txtNomeProduto.Text,
                Quantidade = int.TryParse(txtQuantidadePedido.Text, out int quantidade) ? quantidade : 1,
                //ValorUnitario = int.TryParse(txtValorUnitario.Text, out int valorUnitario) ? valorUnitario : 1,
                ValorUnitario = decimal.TryParse(txtValorUnitario.Text, out decimal valorUnitario) ? valorUnitario : 1,
                EmpresaCompra = txtEmpresaCompra.Text,
            };

            //Dialogo de confirmação de cadastro
            DialogResult resultado = MessageBox.Show("Deseja realiza o Cadastro?", "Confirmação de Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Cadastro Realizado com Sucesso!", "Cadastro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Adiciona o Fornecedor cadastrado à lista de pedido
                RepositorioPedidos.ListaPedidos.Add(novoPedido);
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
            txtQuantidadePedido.Clear();
            txtValorUnitario.Clear();
            txtEmpresaCompra.Clear();

            //Define o foco no campo txtNomeFornecedor
            txtNomeProduto.Focus();
        }


    }
}
