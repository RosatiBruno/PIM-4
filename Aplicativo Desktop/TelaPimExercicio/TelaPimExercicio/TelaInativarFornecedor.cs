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
    public partial class TelaInativarFornecedor : Form
    {
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFonteFornecedores alteradorFonteFornecedores;
        public TelaInativarFornecedor(string userType)
        {
            InitializeComponent();

            //Desativar o botão ao estar logado sem ser como T.I
            this.userType = userType;

            //Alterando o tamanho da fonte
            alteradorFonteFornecedores = new AlteradorFonteFornecedores(this);
            alteradorFonteFornecedores.AlterarFonteFornecedores(btnLogout, btnRetornar);

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

            this.Resize += TelaInativarFornecedor_Resize;

            //Iniciando o Logout
            logout = new Logout(this);
        }


        private void TelaInativarFornecedor_Resize(object sender, EventArgs e)
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


        private void btnBuscarFornecedorInativar_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscarFornecedorInativar.Text.ToLower().Trim();
            Fornecedor fornecedor = RepositorioFornecedores.ListaFornecedores
                .FirstOrDefault(f => f.CNPJ.ToLower().Contains(termoBusca)); // Supondo que você busca pelo CNPJ

            if (fornecedor != null)
            {
                // Remove o fornecedor da lista ativa e adiciona à lista inativa
                RepositorioFornecedores.ListaFornecedores.Remove(fornecedor);
                fornecedor.SituacaoFornecedor = "Inativo"; // Atualiza o status
                RepositorioFornecedores.ListaFornecedoresInativos.Add(fornecedor); // Adiciona à lista inativa

                // Atualiza a ListViews de fornecedores Inativos
                AtualizarListViewInativos();

                MessageBox.Show("Fornecedor inativado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fornecedor não encontrado.", "Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        //VERIFICAR A NECESSIDADE!!!!!!
        private void AtualizarListViewAtivos()
        {
            // Acessa a tela de fornecedores ativos (lvBuscarFornecedores)
            TelaFornecedores telaFornecedores = Application.OpenForms.OfType<TelaFornecedores>().FirstOrDefault();
            if (telaFornecedores != null)
            {
                telaFornecedores.AtualizarListView();
            }
        }

        //Método para atualizar a listview de fornecedores inativos
        private void AtualizarListViewInativos()
        {
            lvBuscarFornecedorInativar.Items.Clear(); // Limpa os itens da ListView
            foreach (var fornecedor in RepositorioFornecedores.ListaFornecedoresInativos)
            {
                ListViewItem item = new ListViewItem(new[]
                {
            fornecedor.ID.ToString(),
            fornecedor.Nome,
            fornecedor.Telefone,
            fornecedor.CNPJ,
            fornecedor.Endereco,
            fornecedor.Email,
            fornecedor.Cidade,
            fornecedor.Estado,
            fornecedor.Representante,
            fornecedor.RazaoSocial,
            fornecedor.MateriaPrima,
            fornecedor.SituacaoFornecedor,
            fornecedor.Complemento,
            fornecedor.CEP
        });
                lvBuscarFornecedorInativar.Items.Add(item); // Adiciona o fornecedor à ListView
            }

        }

        //Retorna para a tela de Fornecedores Cadastrados
        private void btnRetornar_Click(object sender, EventArgs e)
        {
            TelaFornecedores telaFornecedores = new TelaFornecedores(userType);
            telaFornecedores.FormClosed += (s, args) => this.Close();
            telaFornecedores.Size = this.Size;
            telaFornecedores.StartPosition = FormStartPosition.CenterScreen;
            telaFornecedores.Show();
            this.Hide();
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

        private void TelaInativarFornecedor_Load(object sender, EventArgs e)
        {
            // Atualiza a ListViews de fornecedores Inativos
            AtualizarListViewInativos();
        }
    }
}
