namespace TelaPimExercicio
{
    partial class TelaInativarFornecedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaInativarFornecedor));
            this.btnLogout = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.lblBuscarFornecedorInativar = new System.Windows.Forms.Label();
            this.txtBuscarFornecedorInativar = new System.Windows.Forms.TextBox();
            this.btnBuscarFornecedorInativar = new System.Windows.Forms.Button();
            this.lvBuscarFornecedorInativar = new System.Windows.Forms.ListView();
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
            this.btnRetornar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnHome = new System.Windows.Forms.Button();
            this.lblTituloInativarFornecedor = new System.Windows.Forms.Label();
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
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Engrenagem.png");
            this.imageList2.Images.SetKeyName(1, "Logout.png");
            this.imageList2.Images.SetKeyName(2, "home.png");
            // 
            // lblBuscarFornecedorInativar
            // 
            this.lblBuscarFornecedorInativar.AutoSize = true;
            this.lblBuscarFornecedorInativar.Location = new System.Drawing.Point(148, 74);
            this.lblBuscarFornecedorInativar.Name = "lblBuscarFornecedorInativar";
            this.lblBuscarFornecedorInativar.Size = new System.Drawing.Size(265, 13);
            this.lblBuscarFornecedorInativar.TabIndex = 12;
            this.lblBuscarFornecedorInativar.Text = "Digite o CNPJ/CPF do Fornecedor que Deseja Inativar";
            // 
            // txtBuscarFornecedorInativar
            // 
            this.txtBuscarFornecedorInativar.Location = new System.Drawing.Point(151, 101);
            this.txtBuscarFornecedorInativar.Name = "txtBuscarFornecedorInativar";
            this.txtBuscarFornecedorInativar.Size = new System.Drawing.Size(312, 20);
            this.txtBuscarFornecedorInativar.TabIndex = 13;
            // 
            // btnBuscarFornecedorInativar
            // 
            this.btnBuscarFornecedorInativar.Location = new System.Drawing.Point(573, 86);
            this.btnBuscarFornecedorInativar.Name = "btnBuscarFornecedorInativar";
            this.btnBuscarFornecedorInativar.Size = new System.Drawing.Size(89, 35);
            this.btnBuscarFornecedorInativar.TabIndex = 14;
            this.btnBuscarFornecedorInativar.Text = "Inativar";
            this.btnBuscarFornecedorInativar.UseVisualStyleBackColor = true;
            this.btnBuscarFornecedorInativar.Click += new System.EventHandler(this.btnBuscarFornecedorInativar_Click);
            // 
            // lvBuscarFornecedorInativar
            // 
            this.lvBuscarFornecedorInativar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.lvBuscarFornecedorInativar.HideSelection = false;
            this.lvBuscarFornecedorInativar.Location = new System.Drawing.Point(151, 142);
            this.lvBuscarFornecedorInativar.Name = "lvBuscarFornecedorInativar";
            this.lvBuscarFornecedorInativar.Size = new System.Drawing.Size(510, 335);
            this.lvBuscarFornecedorInativar.TabIndex = 15;
            this.lvBuscarFornecedorInativar.UseCompatibleStateImageBehavior = false;
            this.lvBuscarFornecedorInativar.View = System.Windows.Forms.View.Details;
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
            // btnRetornar
            // 
            this.btnRetornar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetornar.ImageKey = "SetinhaVoltar2.png";
            this.btnRetornar.ImageList = this.imageList1;
            this.btnRetornar.Location = new System.Drawing.Point(151, 493);
            this.btnRetornar.Name = "btnRetornar";
            this.btnRetornar.Size = new System.Drawing.Size(77, 29);
            this.btnRetornar.TabIndex = 16;
            this.btnRetornar.Text = "Voltar";
            this.btnRetornar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetornar.UseVisualStyleBackColor = true;
            this.btnRetornar.Click += new System.EventHandler(this.btnRetornar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "SetinhaVoltar2.png");
            // 
            // btnHome
            // 
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHome.ImageKey = "home.png";
            this.btnHome.ImageList = this.imageList2;
            this.btnHome.Location = new System.Drawing.Point(701, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(71, 59);
            this.btnHome.TabIndex = 41;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // lblTituloInativarFornecedor
            // 
            this.lblTituloInativarFornecedor.AutoSize = true;
            this.lblTituloInativarFornecedor.Location = new System.Drawing.Point(334, 29);
            this.lblTituloInativarFornecedor.Name = "lblTituloInativarFornecedor";
            this.lblTituloInativarFornecedor.Size = new System.Drawing.Size(129, 13);
            this.lblTituloInativarFornecedor.TabIndex = 42;
            this.lblTituloInativarFornecedor.Text = "Inativação de Fornecedor";
            // 
            // TelaInativarFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblTituloInativarFornecedor);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnRetornar);
            this.Controls.Add(this.lvBuscarFornecedorInativar);
            this.Controls.Add(this.btnBuscarFornecedorInativar);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.txtBuscarFornecedorInativar);
            this.Controls.Add(this.lblBuscarFornecedorInativar);
            this.Name = "TelaInativarFornecedor";
            this.Text = "Inativar Fornecedor";
            this.Load += new System.EventHandler(this.TelaInativarFornecedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblBuscarFornecedorInativar;
        private System.Windows.Forms.TextBox txtBuscarFornecedorInativar;
        private System.Windows.Forms.Button btnBuscarFornecedorInativar;
        private System.Windows.Forms.ListView lvBuscarFornecedorInativar;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader Telefone;
        private System.Windows.Forms.ColumnHeader CNPJouCPF;
        private System.Windows.Forms.ColumnHeader Endereco;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Cidade;
        private System.Windows.Forms.ColumnHeader Estado;
        private System.Windows.Forms.ColumnHeader Representante;
        private System.Windows.Forms.ColumnHeader RazaoSocial;
        private System.Windows.Forms.ColumnHeader MateriaPrima;
        private System.Windows.Forms.ColumnHeader Situacao;
        private System.Windows.Forms.ColumnHeader Complemento;
        private System.Windows.Forms.ColumnHeader CEP;
        private System.Windows.Forms.Button btnRetornar;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label lblTituloInativarFornecedor;
    }
}