namespace TelaPimExercicio
{
    partial class TelaExcluirProducao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaExcluirProducao));
            this.lblTituloPedidosCadastrados = new System.Windows.Forms.Label();
            this.btnLogout2 = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnRetornar2 = new System.Windows.Forms.Button();
            this.lblBuscarProducao = new System.Windows.Forms.Label();
            this.txtBuscarProducaoExcluir = new System.Windows.Forms.TextBox();
            this.btnExcluirProducao = new System.Windows.Forms.Button();
            this.lvBuscarProducaoExcluir = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataProducao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResponsavelProducao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lblTituloPedidosCadastrados
            // 
            this.lblTituloPedidosCadastrados.AutoSize = true;
            this.lblTituloPedidosCadastrados.Location = new System.Drawing.Point(334, 29);
            this.lblTituloPedidosCadastrados.Name = "lblTituloPedidosCadastrados";
            this.lblTituloPedidosCadastrados.Size = new System.Drawing.Size(87, 13);
            this.lblTituloPedidosCadastrados.TabIndex = 46;
            this.lblTituloPedidosCadastrados.Text = "Excluir Produção";
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
            // lblBuscarProducao
            // 
            this.lblBuscarProducao.AutoSize = true;
            this.lblBuscarProducao.Location = new System.Drawing.Point(148, 74);
            this.lblBuscarProducao.Name = "lblBuscarProducao";
            this.lblBuscarProducao.Size = new System.Drawing.Size(212, 13);
            this.lblBuscarProducao.TabIndex = 54;
            this.lblBuscarProducao.Text = "Digite o ID da Produção que Deseja Excluir";
            // 
            // txtBuscarProducaoExcluir
            // 
            this.txtBuscarProducaoExcluir.Location = new System.Drawing.Point(151, 101);
            this.txtBuscarProducaoExcluir.Name = "txtBuscarProducaoExcluir";
            this.txtBuscarProducaoExcluir.Size = new System.Drawing.Size(312, 20);
            this.txtBuscarProducaoExcluir.TabIndex = 55;
            // 
            // btnExcluirProducao
            // 
            this.btnExcluirProducao.Location = new System.Drawing.Point(573, 86);
            this.btnExcluirProducao.Name = "btnExcluirProducao";
            this.btnExcluirProducao.Size = new System.Drawing.Size(89, 35);
            this.btnExcluirProducao.TabIndex = 56;
            this.btnExcluirProducao.Text = "Excluir";
            this.btnExcluirProducao.UseVisualStyleBackColor = true;
            this.btnExcluirProducao.Click += new System.EventHandler(this.btnExcluirProducao_Click);
            // 
            // lvBuscarProducaoExcluir
            // 
            this.lvBuscarProducaoExcluir.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Produto,
            this.Quantidade,
            this.DataProducao,
            this.ResponsavelProducao});
            this.lvBuscarProducaoExcluir.HideSelection = false;
            this.lvBuscarProducaoExcluir.Location = new System.Drawing.Point(151, 142);
            this.lvBuscarProducaoExcluir.Name = "lvBuscarProducaoExcluir";
            this.lvBuscarProducaoExcluir.Size = new System.Drawing.Size(510, 335);
            this.lvBuscarProducaoExcluir.TabIndex = 57;
            this.lvBuscarProducaoExcluir.UseCompatibleStateImageBehavior = false;
            this.lvBuscarProducaoExcluir.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 30;
            // 
            // Produto
            // 
            this.Produto.Text = "Produto";
            this.Produto.Width = 150;
            // 
            // Quantidade
            // 
            this.Quantidade.Text = "Quantidade";
            this.Quantidade.Width = 100;
            // 
            // DataProducao
            // 
            this.DataProducao.Text = "Data da Produção";
            this.DataProducao.Width = 100;
            // 
            // ResponsavelProducao
            // 
            this.ResponsavelProducao.Text = "Responsável pela Produção";
            this.ResponsavelProducao.Width = 170;
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
            // TelaExcluirProducao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lvBuscarProducaoExcluir);
            this.Controls.Add(this.btnExcluirProducao);
            this.Controls.Add(this.txtBuscarProducaoExcluir);
            this.Controls.Add(this.lblBuscarProducao);
            this.Controls.Add(this.btnRetornar2);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnLogout2);
            this.Controls.Add(this.lblTituloPedidosCadastrados);
            this.Name = "TelaExcluirProducao";
            this.Text = "Excluir Produção";
            this.Load += new System.EventHandler(this.TelaExcluirProducao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloPedidosCadastrados;
        private System.Windows.Forms.Button btnLogout2;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnRetornar2;
        private System.Windows.Forms.Label lblBuscarProducao;
        private System.Windows.Forms.TextBox txtBuscarProducaoExcluir;
        private System.Windows.Forms.Button btnExcluirProducao;
        private System.Windows.Forms.ListView lvBuscarProducaoExcluir;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Produto;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader DataProducao;
        private System.Windows.Forms.ColumnHeader ResponsavelProducao;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
    }
}