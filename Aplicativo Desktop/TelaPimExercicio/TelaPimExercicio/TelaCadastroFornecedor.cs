using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TelaPimExercicio
{
    public partial class TelaCadastroFornecedor : Form
    {
        private Logo logo;
        private ColorBar2 colorBar;
        private ColorBackground colorBg;
        private Centralizador2 centralizador2;
        private Logout logout;
        private string userType;
        private AlteradorFonteFornecedores alteradorFonteFornecedores;
        public TelaCadastroFornecedor(string userType)
        {
            InitializeComponent();

            //Alterando o tamanho da fonte
            alteradorFonteFornecedores = new AlteradorFonteFornecedores(this);
            alteradorFonteFornecedores.AlterarFonteFornecedores(btnLogout, btnRetornar);

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

            this.Resize += TelaCadastroFornecedor_Resize;

            //Iniciando o Logout
            logout = new Logout(this);

            //Centraliza no Monitor/Tela
            CenterToScreen();

            //Não permite a digitação na área de ID já que o mesmo é gerado automaticamente
            txtIDFornecedor.Enabled = false;
            txtIDFornecedor.Text = RepositorioFornecedores.GerarNovoID().ToString();
        }

        private void TelaCadastroFornecedor_Resize(object sender, EventArgs e)
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            logout.ShowLogoutDialog();
        }

        //Botão Retornar volta a tela de fornecedores
        private void btnRetornar_Click(object sender, EventArgs e)
        {
            TelaFornecedores telaFornecedores = new TelaFornecedores(userType);
            telaFornecedores.FormClosed += (s, args) => this.Close();
            telaFornecedores.Size = this.Size;
            telaFornecedores.StartPosition = FormStartPosition.CenterScreen;
            telaFornecedores.Show();
            this.Hide();
        }

        //Botão Home volta ao Menu Inicial (Form2)
        private void btnHome_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(userType);
            form2.FormClosed += (s, args) => this.Close();
            form2.Size = this.Size;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
            this.Hide();
        }

        //Cadastro de Fornecedor
        private void btnConfirmarCadastroNovoFornecedor_Click(object sender, EventArgs e)
        {
            Fornecedor novoFornecedor = new Fornecedor
            {
                //Informações passadas no cadastro do Fornecedor

                //ID = txtIDFornecedor.Text, //Para atribuir o ID que foi digitado
                ID = RepositorioFornecedores.GerarNovoID(), //Para atribuir o ID sequencial automaticamente
                Nome = txtNomeFornecedor.Text,
                CNPJ = txtCpfCnpjFornecedor.Text,
                Telefone = txtTelefoneFornecedor.Text,
                Endereco = txtEnderecoFornecedor.Text,
                Email = txtEmailFornecedor.Text,
                Cidade = txtCidadeFornecedor.Text,
                Estado = txtEstadoFornecedor.Text,
                Representante = txtRepresentanteFornecedor.Text,
                RazaoSocial = txtRazaoSocialFornecedor.Text,
                MateriaPrima = txtMateriaPrima.Text,
                SituacaoFornecedor = txtSituacaoFornecedor.Text,
            };

            //Dialogo de confirmação de cadastro
            DialogResult resultado = MessageBox.Show("Deseja realiza o Cadastro?", "Confirmação de Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Cadastro Realizado com Sucesso!", "Cadastro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //Adiciona o Fornecedor cadastrado à lista de fornecedores
                RepositorioFornecedores.ListaFornecedores.Add(novoFornecedor);
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
            txtNomeFornecedor.Clear();
            txtCpfCnpjFornecedor.Clear();
            txtTelefoneFornecedor.Clear();
            txtEnderecoFornecedor.Clear();
            txtEmailFornecedor.Clear();
            txtCidadeFornecedor.Clear();
            txtEstadoFornecedor.Clear();
            txtRepresentanteFornecedor.Clear();
            txtRazaoSocialFornecedor.Clear();
            txtMateriaPrima.Clear();
            txtSituacaoFornecedor.Clear();
            //txtCepFornecedor.Clear;
            txtComplementoFornecedor.Clear();

            //Define o foco no campo txtNomeFornecedor
            txtNomeFornecedor.Focus();
        }

    }
}