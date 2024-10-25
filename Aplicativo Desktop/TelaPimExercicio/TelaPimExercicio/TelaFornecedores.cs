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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TelaPimExercicio
{
    public partial class TelaFornecedores : Form
    {

        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFonteFornecedores alteradorFonteFornecedores;

        public TelaFornecedores(string userType)
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

            this.Resize += TelaFornecedores_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();
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



        //Chamada da função de atualização da ListView após cadastrar um Fornecedor novo
        private void TelaFornecedores_Load(object sender, EventArgs e)
        {
            AtualizarListView();
        }

        //Função para atualizar a ListView após o cadastro de algum fornecedor
        private void AtualizarListView()
        {
            lvBuscarFornecedor.Items.Clear();
            foreach (var fornecedor in RepositorioFornecedores.ListaFornecedores)
            {
                ListViewItem item = new ListViewItem(new[] {
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
                lvBuscarFornecedor.Items.Add(item);
            }
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

        //PROCURANDO DADOS NA LISTVIEW (VAI SER ALTERADO AINDA!!!! - EM DESENVOLVIMENTO)
        private void btnBuscarFornecedor_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvBuscarFornecedor.Items)
            {
                if (txtBuscarFornecedor.Text.ToLower() == item.SubItems[2].Text.ToLower()) //O nmr entre '[]' é a casa da listview q procura
                {
                    lvBuscarFornecedor.Focus();
                    item.Selected = true;
                    lvBuscarFornecedor.TopItem = item;
                    break;
                }
            }
        }

        private void lvBuscarFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //Botão que vai para a tela de cadastro de novo fornecedor
        private void btnCadastrarNovoFornecedor_Click(object sender, EventArgs e)
        {
            TelaCadastroFornecedor telaCadastroFornecedor = new TelaCadastroFornecedor(userType);
            telaCadastroFornecedor.Size = this.Size; //Passa o tamanho do Form2 para o TelaFornecedores
            telaCadastroFornecedor.StartPosition = FormStartPosition.CenterScreen; //Centraliza a nova tela na tela
            telaCadastroFornecedor.FormClosed += (s, args) => this.Close();
            telaCadastroFornecedor.Show();
            this.Hide();
        }
    }
}
