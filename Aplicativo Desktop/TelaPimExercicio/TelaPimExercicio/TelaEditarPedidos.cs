using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public partial class TelaEditarPedidos : Form
    {
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFontePedidos alteradorFontePedidos;
        private TelaPedidos telaPedidos;

        // Conexão com o banco de dados (NOTEBOOK)
        private string connectionString = "Data Source=MARCIA-DELL\\SQLURBAGRO;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public TelaEditarPedidos(string userType, TelaPedidos telaPedidos)
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

            this.Resize += TelaEditarPedidos_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();

            //Não permite a digitação na área de ID já que o mesmo é gerado automaticamente
            txtEditarIDPedido.Enabled = false;
        }

        private void TelaEditarPedidos_Resize(object sender, EventArgs e)
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

        //Volta para o menu inicial
        private void btnHome_Click(object sender, EventArgs e)
        {
            //Retorna para a tela inicial
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

        private Pedidos BuscarPedidoPorId(int idPedido)
        {
            Pedidos pedido = null;

            // Conectar ao banco de dados
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query para buscar o pedido pelo ID
                    string query = "SELECT idPedido, nomePedido, quantidadePedido, valorUnitarioPedido, empresaResponsavelPedido " +
                                   "FROM bdPedidos.dbo.Pedidos WHERE idPedido = @idPedido";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idPedido", idPedido);

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Se encontrar um pedido, cria o objeto Pedido e popula os dados
                    if (reader.Read())
                    {
                        pedido = new Pedidos
                        {
                            ID = Convert.ToInt32(reader["idPedido"]),
                            Nome = reader["nomePedido"].ToString(),
                            Quantidade = Convert.ToInt32(reader["quantidadePedido"]),
                            ValorUnitario = Convert.ToDecimal(reader["valorUnitarioPedido"]),
                            EmpresaCompra = reader["empresaResponsavelPedido"].ToString()
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar o pedido: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return pedido;
        }

        //Botão de buscar o pedido para exibir suas informações para edição
        private void btnBuscarEditarPedido_Click(object sender, EventArgs e)
        {
            // Tenta converter o ID de pedido digitado para um inteiro
            if (int.TryParse(txtBuscarEditarPedido.Text, out int idPedido))
            {
                // Chama o método para buscar e exibir o pedido com base no ID
                ExibirPedidoParaEdicao(idPedido);
            }
            else
            {
                MessageBox.Show("ID do pedido inválido.", "Pedido não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ExibirPedidoParaEdicao(int idPedido)
        {
            // Busca o pedido no banco de dados pelo ID
            var pedido = BuscarPedidoPorId(idPedido);

            if (pedido != null)
            {
                // Preenche os campos de edição com os dados recuperados do banco
                txtEditarNomeProduto.Text = pedido.Nome;
                txtEditarIDPedido.Text = pedido.ID.ToString();
                txtEditarQuantidadePedido.Text = pedido.Quantidade.ToString();
                txtEditarValorUnitario.Text = pedido.ValorUnitario.ToString("F2");
                txtEditarEmpresaCompra.Text = pedido.EmpresaCompra;
            }
            else
            {
                // Exibe mensagem se o pedido não for encontrado
                MessageBox.Show("Pedido não encontrado. Verifique o ID e tente novamente.", "Pedido não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    

        //Botão de logout
        private void btnLogout2_Click(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
        }


        //Botão de confirmação de edição das informações alteradas do pedido
        private void btnConfirmarEdicaoPedido_Click(object sender, EventArgs e)
        {
            // Caso o usuário não seja do T.I ou Gerente não permite editar um pedido
            if (userType == "funcionario")
            {
                MessageBox.Show("Acesso negado! Você não tem permissão para executar essa função.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Impede a mudança de tela
            }
            else
            {
                // Converte o ID do pedido para um int - Sem essa conversão dá erro
                if (int.TryParse(txtEditarIDPedido.Text, out int idPedido))
                {
                    // Verifica se os campos necessários estão preenchidos corretamente
                    if (string.IsNullOrEmpty(txtEditarNomeProduto.Text) ||
                        string.IsNullOrEmpty(txtEditarQuantidadePedido.Text) ||
                        string.IsNullOrEmpty(txtEditarValorUnitario.Text) ||
                        string.IsNullOrEmpty(txtEditarEmpresaCompra.Text))
                    {
                        MessageBox.Show("Todos os campos devem ser preenchidos.", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tenta converter os dados do formulário
                    if (int.TryParse(txtEditarQuantidadePedido.Text, out int quantidade) && decimal.TryParse(txtEditarValorUnitario.Text, out decimal valorUnitario))
                    {
                        try
                        {
                            // Comando SQL para atualizar os dados no banco
                            string query = "UPDATE bdPedidos.dbo.Pedidos SET " +
                                           "nomePedido = @nomePedido, " +
                                           "quantidadePedido = @quantidadePedido, " +
                                           "valorUnitarioPedido = @valorUnitarioPedido, " +
                                           "empresaResponsavelPedido = @empresaResponsavelPedido " +
                                           "WHERE idPedido = @idPedido";

                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                conn.Open();

                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    // Definir os parâmetros para evitar SQL Injection
                                    cmd.Parameters.AddWithValue("@nomePedido", txtEditarNomeProduto.Text);
                                    cmd.Parameters.AddWithValue("@quantidadePedido", quantidade);
                                    cmd.Parameters.AddWithValue("@valorUnitarioPedido", valorUnitario);
                                    cmd.Parameters.AddWithValue("@empresaResponsavelPedido", txtEditarEmpresaCompra.Text);
                                    cmd.Parameters.AddWithValue("@idPedido", idPedido);

                                    // Executa a atualização no banco
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Pedido atualizado com sucesso!", "Pedido atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        // Atualiza a ListView na TelaPedidos após a alteração
                                        telaPedidos?.AtualizarListView();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não foi possível atualizar o pedido. Verifique o ID e tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao atualizar o pedido no banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, insira valores válidos para quantidade e valor unitário.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("ID do pedido inválido.", "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            txtBuscarEditarPedido.Text = "";
            txtEditarNomeProduto.Text = "";
            txtEditarIDPedido.Text = "";
            txtEditarQuantidadePedido.Text = "";
            txtEditarValorUnitario.Text = "";
            txtEditarEmpresaCompra.Text = "";
        }

        private void TelaEditarPedidos_Load(object sender, EventArgs e)
        {
        }
    }
}
