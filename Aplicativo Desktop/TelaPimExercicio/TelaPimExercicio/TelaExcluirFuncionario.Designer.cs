namespace TelaPimExercicio
{
    partial class TelaExcluirFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaExcluirFuncionario));
            this.btnLogout2 = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnHome = new System.Windows.Forms.Button();
            this.btnRetornar2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblTituloPedidosCadastrados = new System.Windows.Forms.Label();
            this.lblExcluirFuncionario = new System.Windows.Forms.Label();
            this.txtBuscarFuncionarioExcluir = new System.Windows.Forms.TextBox();
            this.btnExcluirFuncionário = new System.Windows.Forms.Button();
            this.lvExcluirFuncionario = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Senha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnLogout2
            // 
            this.btnLogout2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogout2.ImageKey = "Logout.png";
            this.btnLogout2.ImageList = this.imageList2;
            this.btnLogout2.Location = new System.Drawing.Point(27, 12);
            this.btnLogout2.Name = "btnLogout2";
            this.btnLogout2.Size = new System.Drawing.Size(71, 59);
            this.btnLogout2.TabIndex = 10;
            this.btnLogout2.Text = "Logout";
            this.btnLogout2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout2.UseVisualStyleBackColor = true;
            this.btnLogout2.Click += new System.EventHandler(this.btnLogout2_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "home.png");
            this.imageList2.Images.SetKeyName(1, "Logout.png");
            // 
            // btnHome
            // 
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHome.ImageKey = "home.png";
            this.btnHome.ImageList = this.imageList2;
            this.btnHome.Location = new System.Drawing.Point(701, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(71, 59);
            this.btnHome.TabIndex = 52;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnRetornar2
            // 
            this.btnRetornar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetornar2.ImageKey = "SetinhaVoltar2.png";
            this.btnRetornar2.ImageList = this.imageList1;
            this.btnRetornar2.Location = new System.Drawing.Point(151, 493);
            this.btnRetornar2.Name = "btnRetornar2";
            this.btnRetornar2.Size = new System.Drawing.Size(77, 29);
            this.btnRetornar2.TabIndex = 53;
            this.btnRetornar2.Text = "Voltar";
            this.btnRetornar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetornar2.UseVisualStyleBackColor = true;
            this.btnRetornar2.Click += new System.EventHandler(this.btnRetornar2_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "SetinhaVoltar2.png");
            // 
            // lblTituloPedidosCadastrados
            // 
            this.lblTituloPedidosCadastrados.AutoSize = true;
            this.lblTituloPedidosCadastrados.Location = new System.Drawing.Point(334, 29);
            this.lblTituloPedidosCadastrados.Name = "lblTituloPedidosCadastrados";
            this.lblTituloPedidosCadastrados.Size = new System.Drawing.Size(96, 13);
            this.lblTituloPedidosCadastrados.TabIndex = 54;
            this.lblTituloPedidosCadastrados.Text = "Excluir Funcionário";
            // 
            // lblExcluirFuncionario
            // 
            this.lblExcluirFuncionario.AutoSize = true;
            this.lblExcluirFuncionario.Location = new System.Drawing.Point(148, 74);
            this.lblExcluirFuncionario.Name = "lblExcluirFuncionario";
            this.lblExcluirFuncionario.Size = new System.Drawing.Size(221, 13);
            this.lblExcluirFuncionario.TabIndex = 55;
            this.lblExcluirFuncionario.Text = "Digite o ID do Funcionário que Deseja Excluir";
            // 
            // txtBuscarFuncionarioExcluir
            // 
            this.txtBuscarFuncionarioExcluir.Location = new System.Drawing.Point(151, 101);
            this.txtBuscarFuncionarioExcluir.Name = "txtBuscarFuncionarioExcluir";
            this.txtBuscarFuncionarioExcluir.Size = new System.Drawing.Size(312, 20);
            this.txtBuscarFuncionarioExcluir.TabIndex = 56;
            // 
            // btnExcluirFuncionário
            // 
            this.btnExcluirFuncionário.Location = new System.Drawing.Point(573, 86);
            this.btnExcluirFuncionário.Name = "btnExcluirFuncionário";
            this.btnExcluirFuncionário.Size = new System.Drawing.Size(89, 35);
            this.btnExcluirFuncionário.TabIndex = 57;
            this.btnExcluirFuncionário.Text = "Excluir";
            this.btnExcluirFuncionário.UseVisualStyleBackColor = true;
            this.btnExcluirFuncionário.Click += new System.EventHandler(this.btnExcluirFuncionário_Click);
            // 
            // lvExcluirFuncionario
            // 
            this.lvExcluirFuncionario.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Nome,
            this.Email,
            this.Senha});
            this.lvExcluirFuncionario.HideSelection = false;
            this.lvExcluirFuncionario.Location = new System.Drawing.Point(151, 142);
            this.lvExcluirFuncionario.Name = "lvExcluirFuncionario";
            this.lvExcluirFuncionario.Size = new System.Drawing.Size(510, 335);
            this.lvExcluirFuncionario.TabIndex = 58;
            this.lvExcluirFuncionario.UseCompatibleStateImageBehavior = false;
            this.lvExcluirFuncionario.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 30;
            // 
            // Nome
            // 
            this.Nome.Text = "Nome";
            this.Nome.Width = 150;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 150;
            // 
            // Senha
            // 
            this.Senha.Text = "Senha";
            this.Senha.Width = 150;
            // 
            // TelaExcluirFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lvExcluirFuncionario);
            this.Controls.Add(this.btnExcluirFuncionário);
            this.Controls.Add(this.txtBuscarFuncionarioExcluir);
            this.Controls.Add(this.lblExcluirFuncionario);
            this.Controls.Add(this.lblTituloPedidosCadastrados);
            this.Controls.Add(this.btnRetornar2);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnLogout2);
            this.Name = "TelaExcluirFuncionario";
            this.Text = "TelaEscluirFuncionario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout2;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnRetornar2;
        private System.Windows.Forms.Label lblTituloPedidosCadastrados;
        private System.Windows.Forms.Label lblExcluirFuncionario;
        private System.Windows.Forms.TextBox txtBuscarFuncionarioExcluir;
        private System.Windows.Forms.Button btnExcluirFuncionário;
        private System.Windows.Forms.ListView lvExcluirFuncionario;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Senha;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
    }
}