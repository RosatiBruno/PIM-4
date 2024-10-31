namespace TelaPimExercicio
{
    partial class TelaEditarProducao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaEditarProducao));
            this.lblTituloPedidosCadastrados = new System.Windows.Forms.Label();
            this.btnLogout2 = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnRetornar2 = new System.Windows.Forms.Button();
            this.lblBuscarEditarProducao = new System.Windows.Forms.Label();
            this.txtBuscarEditarProducao = new System.Windows.Forms.TextBox();
            this.btnBuscarEditarProducao = new System.Windows.Forms.Button();
            this.lblNomeEditarProducao = new System.Windows.Forms.Label();
            this.txtNomeEditarProducao = new System.Windows.Forms.TextBox();
            this.lblIDProducaoEditar = new System.Windows.Forms.Label();
            this.txtIDProducaoEditar = new System.Windows.Forms.TextBox();
            this.lblQuantidadeProducaoEditar = new System.Windows.Forms.Label();
            this.txtQuantidadeProducaoEditar = new System.Windows.Forms.TextBox();
            this.lblDataProducaoEditar = new System.Windows.Forms.Label();
            this.txtDataProducaoEditar = new System.Windows.Forms.TextBox();
            this.lblResponsavelProducaoEditar = new System.Windows.Forms.Label();
            this.txtResponsavelProducaoEditar = new System.Windows.Forms.TextBox();
            this.btnConfirmarEdicaoProducao = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lblTituloPedidosCadastrados
            // 
            this.lblTituloPedidosCadastrados.AutoSize = true;
            this.lblTituloPedidosCadastrados.Location = new System.Drawing.Point(334, 29);
            this.lblTituloPedidosCadastrados.Name = "lblTituloPedidosCadastrados";
            this.lblTituloPedidosCadastrados.Size = new System.Drawing.Size(83, 13);
            this.lblTituloPedidosCadastrados.TabIndex = 46;
            this.lblTituloPedidosCadastrados.Text = "Editar Produção";
            // 
            // btnLogout2
            // 
            this.btnLogout2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogout2.ImageKey = "Logout.png";
            this.btnLogout2.ImageList = this.imageList2;
            this.btnLogout2.Location = new System.Drawing.Point(27, 12);
            this.btnLogout2.Name = "btnLogout2";
            this.btnLogout2.Size = new System.Drawing.Size(71, 59);
            this.btnLogout2.TabIndex = 47;
            this.btnLogout2.Text = "Logout";
            this.btnLogout2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout2.UseVisualStyleBackColor = true;
            this.btnLogout2.Click += new System.EventHandler(this.btnLogout2_Click);
            // 
            // btnHome
            // 
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHome.ImageKey = "home.png";
            this.btnHome.ImageList = this.imageList2;
            this.btnHome.Location = new System.Drawing.Point(701, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(71, 59);
            this.btnHome.TabIndex = 48;
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
            this.btnRetornar2.TabIndex = 49;
            this.btnRetornar2.Text = "Voltar";
            this.btnRetornar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetornar2.UseVisualStyleBackColor = true;
            this.btnRetornar2.Click += new System.EventHandler(this.btnRetornar2_Click);
            // 
            // lblBuscarEditarProducao
            // 
            this.lblBuscarEditarProducao.AutoSize = true;
            this.lblBuscarEditarProducao.Location = new System.Drawing.Point(148, 74);
            this.lblBuscarEditarProducao.Name = "lblBuscarEditarProducao";
            this.lblBuscarEditarProducao.Size = new System.Drawing.Size(208, 13);
            this.lblBuscarEditarProducao.TabIndex = 50;
            this.lblBuscarEditarProducao.Text = "Digite o ID da Produção que Deseja Editar";
            // 
            // txtBuscarEditarProducao
            // 
            this.txtBuscarEditarProducao.Location = new System.Drawing.Point(151, 101);
            this.txtBuscarEditarProducao.Name = "txtBuscarEditarProducao";
            this.txtBuscarEditarProducao.Size = new System.Drawing.Size(312, 20);
            this.txtBuscarEditarProducao.TabIndex = 51;
            // 
            // btnBuscarEditarProducao
            // 
            this.btnBuscarEditarProducao.Location = new System.Drawing.Point(573, 86);
            this.btnBuscarEditarProducao.Name = "btnBuscarEditarProducao";
            this.btnBuscarEditarProducao.Size = new System.Drawing.Size(89, 35);
            this.btnBuscarEditarProducao.TabIndex = 52;
            this.btnBuscarEditarProducao.Text = "Buscar";
            this.btnBuscarEditarProducao.UseVisualStyleBackColor = true;
            this.btnBuscarEditarProducao.Click += new System.EventHandler(this.btnBuscarEditarProducao_Click);
            // 
            // lblNomeEditarProducao
            // 
            this.lblNomeEditarProducao.AutoSize = true;
            this.lblNomeEditarProducao.Location = new System.Drawing.Point(311, 148);
            this.lblNomeEditarProducao.Name = "lblNomeEditarProducao";
            this.lblNomeEditarProducao.Size = new System.Drawing.Size(44, 13);
            this.lblNomeEditarProducao.TabIndex = 55;
            this.lblNomeEditarProducao.Text = "Produto";
            // 
            // txtNomeEditarProducao
            // 
            this.txtNomeEditarProducao.Location = new System.Drawing.Point(314, 164);
            this.txtNomeEditarProducao.Name = "txtNomeEditarProducao";
            this.txtNomeEditarProducao.Size = new System.Drawing.Size(159, 20);
            this.txtNomeEditarProducao.TabIndex = 56;
            // 
            // lblIDProducaoEditar
            // 
            this.lblIDProducaoEditar.AutoSize = true;
            this.lblIDProducaoEditar.Location = new System.Drawing.Point(311, 212);
            this.lblIDProducaoEditar.Name = "lblIDProducaoEditar";
            this.lblIDProducaoEditar.Size = new System.Drawing.Size(82, 13);
            this.lblIDProducaoEditar.TabIndex = 58;
            this.lblIDProducaoEditar.Text = "ID da Produção";
            // 
            // txtIDProducaoEditar
            // 
            this.txtIDProducaoEditar.Location = new System.Drawing.Point(314, 228);
            this.txtIDProducaoEditar.Name = "txtIDProducaoEditar";
            this.txtIDProducaoEditar.Size = new System.Drawing.Size(159, 20);
            this.txtIDProducaoEditar.TabIndex = 59;
            // 
            // lblQuantidadeProducaoEditar
            // 
            this.lblQuantidadeProducaoEditar.AutoSize = true;
            this.lblQuantidadeProducaoEditar.Location = new System.Drawing.Point(311, 276);
            this.lblQuantidadeProducaoEditar.Name = "lblQuantidadeProducaoEditar";
            this.lblQuantidadeProducaoEditar.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidadeProducaoEditar.TabIndex = 60;
            this.lblQuantidadeProducaoEditar.Text = "Quantidade";
            // 
            // txtQuantidadeProducaoEditar
            // 
            this.txtQuantidadeProducaoEditar.Location = new System.Drawing.Point(314, 292);
            this.txtQuantidadeProducaoEditar.Name = "txtQuantidadeProducaoEditar";
            this.txtQuantidadeProducaoEditar.Size = new System.Drawing.Size(159, 20);
            this.txtQuantidadeProducaoEditar.TabIndex = 61;
            // 
            // lblDataProducaoEditar
            // 
            this.lblDataProducaoEditar.AutoSize = true;
            this.lblDataProducaoEditar.Location = new System.Drawing.Point(311, 335);
            this.lblDataProducaoEditar.Name = "lblDataProducaoEditar";
            this.lblDataProducaoEditar.Size = new System.Drawing.Size(94, 13);
            this.lblDataProducaoEditar.TabIndex = 62;
            this.lblDataProducaoEditar.Text = "Data da Produção";
            // 
            // txtDataProducaoEditar
            // 
            this.txtDataProducaoEditar.Location = new System.Drawing.Point(314, 351);
            this.txtDataProducaoEditar.Name = "txtDataProducaoEditar";
            this.txtDataProducaoEditar.Size = new System.Drawing.Size(159, 20);
            this.txtDataProducaoEditar.TabIndex = 63;
            // 
            // lblResponsavelProducaoEditar
            // 
            this.lblResponsavelProducaoEditar.AutoSize = true;
            this.lblResponsavelProducaoEditar.Location = new System.Drawing.Point(311, 399);
            this.lblResponsavelProducaoEditar.Name = "lblResponsavelProducaoEditar";
            this.lblResponsavelProducaoEditar.Size = new System.Drawing.Size(141, 13);
            this.lblResponsavelProducaoEditar.TabIndex = 64;
            this.lblResponsavelProducaoEditar.Text = "Responsável pela Produção";
            // 
            // txtResponsavelProducaoEditar
            // 
            this.txtResponsavelProducaoEditar.Location = new System.Drawing.Point(314, 415);
            this.txtResponsavelProducaoEditar.Name = "txtResponsavelProducaoEditar";
            this.txtResponsavelProducaoEditar.Size = new System.Drawing.Size(159, 20);
            this.txtResponsavelProducaoEditar.TabIndex = 65;
            // 
            // btnConfirmarEdicaoProducao
            // 
            this.btnConfirmarEdicaoProducao.Location = new System.Drawing.Point(567, 484);
            this.btnConfirmarEdicaoProducao.Name = "btnConfirmarEdicaoProducao";
            this.btnConfirmarEdicaoProducao.Size = new System.Drawing.Size(91, 38);
            this.btnConfirmarEdicaoProducao.TabIndex = 66;
            this.btnConfirmarEdicaoProducao.Text = "Salvar Informações";
            this.btnConfirmarEdicaoProducao.UseVisualStyleBackColor = true;
            this.btnConfirmarEdicaoProducao.Click += new System.EventHandler(this.btnConfirmarEdicaoProducao_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "SetinhaVoltar2.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "home.png");
            this.imageList2.Images.SetKeyName(1, "Logout.png");
            // 
            // TelaEditarProducao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnConfirmarEdicaoProducao);
            this.Controls.Add(this.txtResponsavelProducaoEditar);
            this.Controls.Add(this.lblResponsavelProducaoEditar);
            this.Controls.Add(this.txtDataProducaoEditar);
            this.Controls.Add(this.lblDataProducaoEditar);
            this.Controls.Add(this.txtQuantidadeProducaoEditar);
            this.Controls.Add(this.lblQuantidadeProducaoEditar);
            this.Controls.Add(this.txtIDProducaoEditar);
            this.Controls.Add(this.lblIDProducaoEditar);
            this.Controls.Add(this.txtNomeEditarProducao);
            this.Controls.Add(this.lblNomeEditarProducao);
            this.Controls.Add(this.btnBuscarEditarProducao);
            this.Controls.Add(this.txtBuscarEditarProducao);
            this.Controls.Add(this.lblBuscarEditarProducao);
            this.Controls.Add(this.btnRetornar2);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnLogout2);
            this.Controls.Add(this.lblTituloPedidosCadastrados);
            this.Name = "TelaEditarProducao";
            this.Text = "Editar Produção";
            this.Load += new System.EventHandler(this.TelaEditarProducao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloPedidosCadastrados;
        private System.Windows.Forms.Button btnLogout2;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnRetornar2;
        private System.Windows.Forms.Label lblBuscarEditarProducao;
        private System.Windows.Forms.TextBox txtBuscarEditarProducao;
        private System.Windows.Forms.Button btnBuscarEditarProducao;
        private System.Windows.Forms.Label lblNomeEditarProducao;
        private System.Windows.Forms.TextBox txtNomeEditarProducao;
        private System.Windows.Forms.Label lblIDProducaoEditar;
        private System.Windows.Forms.TextBox txtIDProducaoEditar;
        private System.Windows.Forms.Label lblQuantidadeProducaoEditar;
        private System.Windows.Forms.TextBox txtQuantidadeProducaoEditar;
        private System.Windows.Forms.Label lblDataProducaoEditar;
        private System.Windows.Forms.TextBox txtDataProducaoEditar;
        private System.Windows.Forms.Label lblResponsavelProducaoEditar;
        private System.Windows.Forms.TextBox txtResponsavelProducaoEditar;
        private System.Windows.Forms.Button btnConfirmarEdicaoProducao;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
    }
}