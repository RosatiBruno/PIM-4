namespace TelaPimExercicio
{
    partial class TelaFornecedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaFornecedores));
            this.btnLogout = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnRetornar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtBuscarFornecedor = new System.Windows.Forms.TextBox();
            this.lblBuscarFornecedor = new System.Windows.Forms.Label();
            this.btnBuscarFornecedor = new System.Windows.Forms.Button();
            this.lvBuscarFornecedor = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Telefone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CNPJouCPF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Endereco = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Estado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Representante = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RazaoSocial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MateriaPrima = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Situacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Complemento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CEP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCadastrarNovoFornecedor = new System.Windows.Forms.Button();
            this.btnInativarFornecedor = new System.Windows.Forms.Button();
            this.lblTituloFornecedoresCadastrados = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogout.ImageKey = "Logout.png";
            this.btnLogout.ImageList = this.imageList2;
            this.btnLogout.Location = new System.Drawing.Point(27, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(71, 59);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Logout.png");
            // 
            // btnRetornar
            // 
            this.btnRetornar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetornar.ImageKey = "SetinhaVoltar2.png";
            this.btnRetornar.ImageList = this.imageList1;
            this.btnRetornar.Location = new System.Drawing.Point(151, 493);
            this.btnRetornar.Name = "btnRetornar";
            this.btnRetornar.Size = new System.Drawing.Size(77, 29);
            this.btnRetornar.TabIndex = 8;
            this.btnRetornar.Text = "Voltar";
            this.btnRetornar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetornar.UseVisualStyleBackColor = true;
            this.btnRetornar.Click += new System.EventHandler(this.btnRetornar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Logout.png");
            this.imageList1.Images.SetKeyName(1, "SetinhaVoltar.png");
            this.imageList1.Images.SetKeyName(2, "SetinhaVoltar2.png");
            // 
            // txtBuscarFornecedor
            // 
            this.txtBuscarFornecedor.Location = new System.Drawing.Point(151, 101);
            this.txtBuscarFornecedor.Name = "txtBuscarFornecedor";
            this.txtBuscarFornecedor.Size = new System.Drawing.Size(312, 20);
            this.txtBuscarFornecedor.TabIndex = 10;
            // 
            // lblBuscarFornecedor
            // 
            this.lblBuscarFornecedor.AutoSize = true;
            this.lblBuscarFornecedor.Location = new System.Drawing.Point(148, 74);
            this.lblBuscarFornecedor.Name = "lblBuscarFornecedor";
            this.lblBuscarFornecedor.Size = new System.Drawing.Size(276, 13);
            this.lblBuscarFornecedor.TabIndex = 11;
            this.lblBuscarFornecedor.Text = "Digite o CNPJ/CPF do Fornecedor que Deseja Encontrar";
            // 
            // btnBuscarFornecedor
            // 
            this.btnBuscarFornecedor.Location = new System.Drawing.Point(573, 86);
            this.btnBuscarFornecedor.Name = "btnBuscarFornecedor";
            this.btnBuscarFornecedor.Size = new System.Drawing.Size(89, 35);
            this.btnBuscarFornecedor.TabIndex = 12;
            this.btnBuscarFornecedor.Text = "Buscar";
            this.btnBuscarFornecedor.UseVisualStyleBackColor = true;
            this.btnBuscarFornecedor.Click += new System.EventHandler(this.btnBuscarFornecedor_Click_1);
            // 
            // lvBuscarFornecedor
            // 
            this.lvBuscarFornecedor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Nome,
            this.Telefone,
            this.CNPJouCPF,
            this.Endereco,
            this.Email,
            this.Cidade,
            this.Estado,
            this.Representante,
            this.RazaoSocial,
            this.MateriaPrima,
            this.Situacao,
            this.Complemento,
            this.CEP});
            this.lvBuscarFornecedor.HideSelection = false;
            this.lvBuscarFornecedor.Location = new System.Drawing.Point(151, 142);
            this.lvBuscarFornecedor.Name = "lvBuscarFornecedor";
            this.lvBuscarFornecedor.Size = new System.Drawing.Size(510, 335);
            this.lvBuscarFornecedor.TabIndex = 13;
            this.lvBuscarFornecedor.UseCompatibleStateImageBehavior = false;
            this.lvBuscarFornecedor.View = System.Windows.Forms.View.Details;
            this.lvBuscarFornecedor.SelectedIndexChanged += new System.EventHandler(this.lvBuscarFornecedor_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 30;
            // 
            // Nome
            // 
            this.Nome.Text = "Nome";
            this.Nome.Width = 100;
            // 
            // Telefone
            // 
            this.Telefone.Text = "Telefone";
            this.Telefone.Width = 100;
            // 
            // CNPJouCPF
            // 
            this.CNPJouCPF.Text = "CNPJ/CPF";
            this.CNPJouCPF.Width = 100;
            // 
            // Endereco
            // 
            this.Endereco.Text = "Endereço";
            this.Endereco.Width = 100;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 100;
            // 
            // Cidade
            // 
            this.Cidade.Text = "Cidade";
            this.Cidade.Width = 100;
            // 
            // Estado
            // 
            this.Estado.Text = "Estado";
            // 
            // Representante
            // 
            this.Representante.Text = "Representante";
            this.Representante.Width = 100;
            // 
            // RazaoSocial
            // 
            this.RazaoSocial.DisplayIndex = 11;
            this.RazaoSocial.Text = "Razão Social";
            this.RazaoSocial.Width = 100;
            // 
            // MateriaPrima
            // 
            this.MateriaPrima.DisplayIndex = 9;
            this.MateriaPrima.Text = "Matéria Prima";
            this.MateriaPrima.Width = 100;
            // 
            // Situacao
            // 
            this.Situacao.DisplayIndex = 10;
            this.Situacao.Text = "Situação";
            this.Situacao.Width = 65;
            // 
            // Complemento
            // 
            this.Complemento.Text = "Complemento";
            this.Complemento.Width = 100;
            // 
            // CEP
            // 
            this.CEP.Text = "CEP";
            this.CEP.Width = 100;
            // 
            // btnCadastrarNovoFornecedor
            // 
            this.btnCadastrarNovoFornecedor.Location = new System.Drawing.Point(440, 488);
            this.btnCadastrarNovoFornecedor.Name = "btnCadastrarNovoFornecedor";
            this.btnCadastrarNovoFornecedor.Size = new System.Drawing.Size(91, 38);
            this.btnCadastrarNovoFornecedor.TabIndex = 15;
            this.btnCadastrarNovoFornecedor.Text = "Cadastrar Novo Fornecedor";
            this.btnCadastrarNovoFornecedor.UseVisualStyleBackColor = true;
            this.btnCadastrarNovoFornecedor.Click += new System.EventHandler(this.btnCadastrarNovoFornecedor_Click);
            // 
            // btnInativarFornecedor
            // 
            this.btnInativarFornecedor.Location = new System.Drawing.Point(570, 488);
            this.btnInativarFornecedor.Name = "btnInativarFornecedor";
            this.btnInativarFornecedor.Size = new System.Drawing.Size(91, 38);
            this.btnInativarFornecedor.TabIndex = 16;
            this.btnInativarFornecedor.Text = "Inativar Fornecedor";
            this.btnInativarFornecedor.UseVisualStyleBackColor = true;
            this.btnInativarFornecedor.Click += new System.EventHandler(this.btnInativarFornecedor_Click);
            // 
            // lblTituloFornecedoresCadastrados
            // 
            this.lblTituloFornecedoresCadastrados.AutoSize = true;
            this.lblTituloFornecedoresCadastrados.Location = new System.Drawing.Point(334, 29);
            this.lblTituloFornecedoresCadastrados.Name = "lblTituloFornecedoresCadastrados";
            this.lblTituloFornecedoresCadastrados.Size = new System.Drawing.Size(134, 13);
            this.lblTituloFornecedoresCadastrados.TabIndex = 43;
            this.lblTituloFornecedoresCadastrados.Text = "Fornecedores Cadastrados";
            // 
            // TelaFornecedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblTituloFornecedoresCadastrados);
            this.Controls.Add(this.btnInativarFornecedor);
            this.Controls.Add(this.btnCadastrarNovoFornecedor);
            this.Controls.Add(this.lvBuscarFornecedor);
            this.Controls.Add(this.btnBuscarFornecedor);
            this.Controls.Add(this.lblBuscarFornecedor);
            this.Controls.Add(this.txtBuscarFornecedor);
            this.Controls.Add(this.btnRetornar);
            this.Controls.Add(this.btnLogout);
            this.Name = "TelaFornecedores";
            this.Text = "Fornecedores Cadastrados";
            this.Load += new System.EventHandler(this.TelaFornecedores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRetornar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.TextBox txtBuscarFornecedor;
        private System.Windows.Forms.Label lblBuscarFornecedor;
        private System.Windows.Forms.Button btnBuscarFornecedor;
        private System.Windows.Forms.ListView lvBuscarFornecedor;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader Telefone;
        private System.Windows.Forms.ColumnHeader CNPJouCPF;
        private System.Windows.Forms.ColumnHeader Endereco;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Cidade;
        private System.Windows.Forms.ColumnHeader Estado;
        private System.Windows.Forms.ColumnHeader Representante;
        private System.Windows.Forms.ColumnHeader MateriaPrima;
        private System.Windows.Forms.ColumnHeader Situacao;
        private System.Windows.Forms.Button btnCadastrarNovoFornecedor;
        private System.Windows.Forms.Button btnInativarFornecedor;
        private System.Windows.Forms.ColumnHeader RazaoSocial;
        private System.Windows.Forms.ColumnHeader Complemento;
        private System.Windows.Forms.ColumnHeader CEP;
        private System.Windows.Forms.Label lblTituloFornecedoresCadastrados;
    }
}