namespace TelaPimExercicio
{
    partial class TelaExcluirProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaExcluirProduto));
            this.btnLogout2 = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnRetornar2 = new System.Windows.Forms.Button();
            this.lblTituloPedidosCadastrados = new System.Windows.Forms.Label();
            this.lblBuscarPedido = new System.Windows.Forms.Label();
            this.txtBuscarPedidoExcluir = new System.Windows.Forms.TextBox();
            this.btnExcluirPedido = new System.Windows.Forms.Button();
            this.lvBuscarPedidosExcluidos = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValorUnitario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmpresaCompra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
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
            // lblTituloPedidosCadastrados
            // 
            this.lblTituloPedidosCadastrados.AutoSize = true;
            this.lblTituloPedidosCadastrados.Location = new System.Drawing.Point(334, 29);
            this.lblTituloPedidosCadastrados.Name = "lblTituloPedidosCadastrados";
            this.lblTituloPedidosCadastrados.Size = new System.Drawing.Size(78, 13);
            this.lblTituloPedidosCadastrados.TabIndex = 54;
            this.lblTituloPedidosCadastrados.Text = "Excluir Produto";
            // 
            // lblBuscarPedido
            // 
            this.lblBuscarPedido.AutoSize = true;
            this.lblBuscarPedido.Location = new System.Drawing.Point(148, 74);
            this.lblBuscarPedido.Name = "lblBuscarPedido";
            this.lblBuscarPedido.Size = new System.Drawing.Size(203, 13);
            this.lblBuscarPedido.TabIndex = 55;
            this.lblBuscarPedido.Text = "Digite o ID do Produto que Deseja Excluir";
            // 
            // txtBuscarPedidoExcluir
            // 
            this.txtBuscarPedidoExcluir.Location = new System.Drawing.Point(151, 101);
            this.txtBuscarPedidoExcluir.Name = "txtBuscarPedidoExcluir";
            this.txtBuscarPedidoExcluir.Size = new System.Drawing.Size(312, 20);
            this.txtBuscarPedidoExcluir.TabIndex = 56;
            // 
            // btnExcluirPedido
            // 
            this.btnExcluirPedido.Location = new System.Drawing.Point(573, 86);
            this.btnExcluirPedido.Name = "btnExcluirPedido";
            this.btnExcluirPedido.Size = new System.Drawing.Size(89, 35);
            this.btnExcluirPedido.TabIndex = 57;
            this.btnExcluirPedido.Text = "Excluir";
            this.btnExcluirPedido.UseVisualStyleBackColor = true;
            this.btnExcluirPedido.Click += new System.EventHandler(this.btnExcluirPedido_Click);
            // 
            // lvBuscarPedidosExcluidos
            // 
            this.lvBuscarPedidosExcluidos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Nome,
            this.Quantidade,
            this.ValorUnitario,
            this.EmpresaCompra});
            this.lvBuscarPedidosExcluidos.HideSelection = false;
            this.lvBuscarPedidosExcluidos.Location = new System.Drawing.Point(151, 142);
            this.lvBuscarPedidosExcluidos.Name = "lvBuscarPedidosExcluidos";
            this.lvBuscarPedidosExcluidos.Size = new System.Drawing.Size(510, 335);
            this.lvBuscarPedidosExcluidos.TabIndex = 58;
            this.lvBuscarPedidosExcluidos.UseCompatibleStateImageBehavior = false;
            this.lvBuscarPedidosExcluidos.View = System.Windows.Forms.View.Details;
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
            // Quantidade
            // 
            this.Quantidade.Text = "Quantidade";
            this.Quantidade.Width = 100;
            // 
            // ValorUnitario
            // 
            this.ValorUnitario.Text = "Valor Unitário";
            this.ValorUnitario.Width = 100;
            // 
            // EmpresaCompra
            // 
            this.EmpresaCompra.Text = "Empresa Responsável pela Compra";
            this.EmpresaCompra.Width = 170;
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
            // TelaExcluirProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lvBuscarPedidosExcluidos);
            this.Controls.Add(this.btnExcluirPedido);
            this.Controls.Add(this.txtBuscarPedidoExcluir);
            this.Controls.Add(this.lblBuscarPedido);
            this.Controls.Add(this.lblTituloPedidosCadastrados);
            this.Controls.Add(this.btnRetornar2);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnLogout2);
            this.Name = "TelaExcluirProduto";
            this.Text = "Excluir Produto";
            this.Load += new System.EventHandler(this.TelaExcluirProduto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout2;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnRetornar2;
        private System.Windows.Forms.Label lblTituloPedidosCadastrados;
        private System.Windows.Forms.Label lblBuscarPedido;
        private System.Windows.Forms.TextBox txtBuscarPedidoExcluir;
        private System.Windows.Forms.Button btnExcluirPedido;
        private System.Windows.Forms.ListView lvBuscarPedidosExcluidos;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader ValorUnitario;
        private System.Windows.Forms.ColumnHeader EmpresaCompra;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
    }
}