using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        // Conexão com o banco de dados (NOTEBOOK)
        private string connectionString = "Data Source=MARCIA-DELL\\SQLURBAGRO;Integrated Security=True;Connect Timeout=30;Encrypt=False";

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

        // Método para buscar o pedido no banco de dados usando o ID
        private Pedidos BuscarPedidoPorId(int idPedido)
        {
            // Definir a consulta SQL para buscar o pedido
            string query = "SELECT * FROM dbo.Pedidos WHERE idPedido = @idPedido";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();  // Verifica se a conexão foi aberta com sucesso

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adiciona o parâmetro para a consulta com tipo explícito
                        cmd.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;

                        // Log para verificar o valor do parâmetro
                        Console.WriteLine($"Consultando pedido com ID: {idPedido}");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Preenche um objeto Pedidos com os dados retornados
                                Pedidos pedido = new Pedidos
                                {
                                    ID = reader.GetInt32(reader.GetOrdinal("idPedido")),
                                    Nome = reader.GetString(reader.GetOrdinal("nomePedido")),
                                    Quantidade = reader.GetInt32(reader.GetOrdinal("quantidadePedido")),
                                    ValorUnitario = reader.GetDecimal(reader.GetOrdinal("valorUnitarioPedido")),
                                    EmpresaCompra = reader.GetString(reader.GetOrdinal("empresaResponsavelPedido"))
                                };
                                return pedido;
                            }
                            else
                            {
                                // Log quando não encontra nenhum pedido
                                Console.WriteLine("Pedido não encontrado.");
                                MessageBox.Show("Pedido não encontrado no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log do erro
                MessageBox.Show("Erro ao consultar o banco de dados: " + ex.Message, "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Método para inserir o pedido na tabela dbo.PedidosExcluidos
        private void InserirPedidoNaTabelaExcluidos(Pedidos pedido, SqlConnection conn, SqlTransaction transaction)
        {
            string query = "INSERT INTO dbo.PedidosExcluidos (idPedido, nomePedido, quantidadePedido, valorUnitarioPedido, empresaResponsavelPedido) " +
                           "VALUES (@idPedido, @nomePedido, @quantidadePedido, @valorUnitarioPedido, @empresaResponsavelPedido)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                {
                    // Adiciona os parâmetros para a consulta
                    cmd.Parameters.AddWithValue("@idPedido", pedido.ID);
                    cmd.Parameters.AddWithValue("@nomePedido", pedido.Nome);
                    cmd.Parameters.AddWithValue("@quantidadePedido", pedido.Quantidade);
                    cmd.Parameters.AddWithValue("@valorUnitarioPedido", pedido.ValorUnitario);
                    cmd.Parameters.AddWithValue("@empresaResponsavelPedido", pedido.EmpresaCompra);

                    // Executa a inserção na tabela de pedidos excluídos
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Pedido com ID {pedido.ID} inserido na tabela de excluídos.", "Inserção bem-sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao inserir o pedido na tabela de excluídos: " + ex.Message, "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para excluir o pedido da tabela dbo.Pedidos e adicionar à tabela dbo.PedidosExcluidos
        private void ExcluirPedidoDoBanco(int idPedido)
        {
            string queryExcluir = "DELETE FROM dbo.Pedidos WHERE idPedido = @idPedido";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Inicia a transação para garantir que ambas as operações sejam feitas com sucesso ou nenhuma delas
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Inserir pedido na tabela dbo.PedidosExcluidos antes de excluir
                            Pedidos pedido = BuscarPedidoPorId(idPedido); // Busca o pedido
                            if (pedido != null)
                            {
                                // Inserir na tabela dbo.PedidosExcluidos
                                InserirPedidoNaTabelaExcluidos(pedido, conn, transaction);
                            }

                            // Exclui o pedido da tabela dbo.Pedidos
                            using (SqlCommand cmdExcluir = new SqlCommand(queryExcluir, conn, transaction))
                            {
                                cmdExcluir.Parameters.AddWithValue("@idPedido", idPedido);
                                int rowsAffected = cmdExcluir.ExecuteNonQuery();

                                // Log de linhas afetadas
                                Console.WriteLine($"Linhas excluídas: {rowsAffected}");

                                if (rowsAffected == 0)
                                {
                                    MessageBox.Show("Nenhum pedido foi excluído. Verifique o ID.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            // Commit da transação se tudo ocorrer corretamente
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Rollback em caso de erro
                            transaction.Rollback();
                            MessageBox.Show("Erro ao excluir o pedido: " + ex.Message, "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao conectar-se ao banco de dados: " + ex.Message, "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento de clique do botão para excluir o pedido
        private void btnExcluirPedido_Click(object sender, EventArgs e)
        {
            int idPedido;
            if (!int.TryParse(txtBuscarPedidoExcluir.Text, out idPedido) || idPedido <= 0)
            {
                MessageBox.Show("Por favor, insira um ID de pedido válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ExcluirPedidoDoBanco(idPedido); // Chama o método para excluir o pedido
        }
    }
}
