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
using System.Data.SqlClient;

namespace TelaPimExercicio
{
    public partial class TelaCadastroPedido : Form
    {
        //private string connectionString = "Data Source=DESKTOP-0T3JO2U\\SQLURBAGRO;Initial Catalog=bdPedidos;Integrated Security=True";
        private string connectionString = "Data Source=MARCIA-DELL\\SQLURBAGRO;Integrated Security=True;Connect Timeout=30;Encrypt=False";

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
            txtIDPedido.Text = RepositorioPedidos2.GerarNovoID().ToString();
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
            AtualizarIDPedido();
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

        //Atualiza o ID na tela de cadastro
        private void AtualizarIDPedido()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(MAX(idPedido), 0) + 1 FROM bdPedidos.dbo.Pedidos"; // Busca o próximo ID

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    // Pega o próximo ID do banco e define no campo txtIDPedido
                    int novoID = Convert.ToInt32(command.ExecuteScalar());
                    txtIDPedido.Text = novoID.ToString(); // Atualiza o campo txtIDPedido com o ID retornado
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao obter o próximo ID: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Obtém o ID para cadastrar o novo pedido (ID q irá aparecer no banco)
        private int ObterProximoID()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(MAX(idPedido), 0) + 1 FROM bdPedidos.dbo.Pedidos";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao obter próximo ID: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1; // Retorna 1 como padrão em caso de erro
                }
            }
        }


        //Cadastro de Pedido
        private void btnConfirmarCadastroNovoPedido_Click(object sender, EventArgs e)
        {
            Pedidos novoPedido = new Pedidos
            {
                ID = ObterProximoID(),
                Nome = txtNomeProduto.Text,
                Quantidade = int.TryParse(txtQuantidadePedido.Text, out int quantidade) ? quantidade : 1,
                ValorUnitario = decimal.TryParse(txtValorUnitario.Text, out decimal valorUnitario) ? valorUnitario : 1,
                EmpresaCompra = txtEmpresaCompra.Text,
            };

            // Dialogo de confirmação de cadastro
            DialogResult resultado = MessageBox.Show("Deseja realizar o Cadastro?", "Confirmação de Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO bdPedidos.dbo.Pedidos (idPedido, nomePedido, quantidadePedido, valorUnitarioPedido, empresaResponsavelPedido) " +
                                   "VALUES (@idPedido, @nomePedido, @quantidadePedido, @valorUnitarioPedido, @empresaResponsavelPedido)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idPedido", novoPedido.ID);
                    command.Parameters.AddWithValue("@nomePedido", novoPedido.Nome);
                    command.Parameters.AddWithValue("@quantidadePedido", novoPedido.Quantidade);
                    command.Parameters.AddWithValue("@valorUnitarioPedido", novoPedido.ValorUnitario);
                    command.Parameters.AddWithValue("@empresaResponsavelPedido", novoPedido.EmpresaCompra);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Cadastro realizado com sucesso!", "Cadastro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao cadastrar pedido: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Cadastro Não Realizado!", "Cadastro Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Chama a função de limpar o que já está escrito após cadastrar um fornecedor
            LimparCampos();

            //Atualiza o ID na tela de cadastro
            //txtIDPedido.Text = RepositorioPedidos2.GerarNovoID().ToString();
            AtualizarIDPedido();
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
