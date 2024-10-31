namespace TelaPimExercicio
{
    partial class TelaEditarPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaEditarPedidos));
            this.btnHome = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnLogout2 = new System.Windows.Forms.Button();
            this.lblTituloPedidosCadastrados = new System.Windows.Forms.Label();
            this.lblBuscarEditarPedido = new System.Windows.Forms.Label();
            this.txtBuscarEditarPedido = new System.Windows.Forms.TextBox();
            this.btnBuscarEditarPedido = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnRetornar2 = new System.Windows.Forms.Button();
            this.btnConfirmarEdicaoPedido = new System.Windows.Forms.Button();
            this.txtEditarEmpresaCompra = new System.Windows.Forms.TextBox();
            this.lblEmpresaCompra = new System.Windows.Forms.Label();
            this.txtEditarValorUnitario = new System.Windows.Forms.TextBox();
            this.lblValorUnitario = new System.Windows.Forms.Label();
            this.txtEditarQuantidadePedido = new System.Windows.Forms.TextBox();
            this.lblQuantidadePedido = new System.Windows.Forms.Label();
            this.txtEditarIDPedido = new System.Windows.Forms.TextBox();
            this.lblIDPedido = new System.Windows.Forms.Label();
            this.txtEditarNomeProduto = new System.Windows.Forms.TextBox();
            this.lblNomeProduto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHome.ImageKey = "home.png";
            this.btnHome.ImageList = this.imageList2;
            this.btnHome.Location = new System.Drawing.Point(701, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(71, 59);
            this.btnHome.TabIndex = 42;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "home.png");
            this.imageList2.Images.SetKeyName(1, "Logout.png");
            // 
            // btnLogout2
            // 
            this.btnLogout2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogout2.ImageKey = "Logout.png";
            this.btnLogout2.ImageList = this.imageList2;
            this.btnLogout2.Location = new System.Drawing.Point(27, 12);
            this.btnLogout2.Name = "btnLogout2";
            this.btnLogout2.Size = new System.Drawing.Size(71, 59);
            this.btnLogout2.TabIndex = 43;
            this.btnLogout2.Text = "Logout";
            this.btnLogout2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout2.UseVisualStyleBackColor = true;
            this.btnLogout2.Click += new System.EventHandler(this.btnLogout2_Click);
            // 
            // lblTituloPedidosCadastrados
            // 
            this.lblTituloPedidosCadastrados.AutoSize = true;
            this.lblTituloPedidosCadastrados.Location = new System.Drawing.Point(334, 29);
            this.lblTituloPedidosCadastrados.Name = "lblTituloPedidosCadastrados";
            this.lblTituloPedidosCadastrados.Size = new System.Drawing.Size(70, 13);
            this.lblTituloPedidosCadastrados.TabIndex = 45;
            this.lblTituloPedidosCadastrados.Text = "Editar Pedido";
            // 
            // lblBuscarEditarPedido
            // 
            this.lblBuscarEditarPedido.AutoSize = true;
            this.lblBuscarEditarPedido.Location = new System.Drawing.Point(148, 74);
            this.lblBuscarEditarPedido.Name = "lblBuscarEditarPedido";
            this.lblBuscarEditarPedido.Size = new System.Drawing.Size(195, 13);
            this.lblBuscarEditarPedido.TabIndex = 47;
            this.lblBuscarEditarPedido.Text = "Digite o ID do Pedido que Deseja Editar";
            // 
            // txtBuscarEditarPedido
            // 
            this.txtBuscarEditarPedido.Location = new System.Drawing.Point(151, 101);
            this.txtBuscarEditarPedido.Name = "txtBuscarEditarPedido";
            this.txtBuscarEditarPedido.Size = new System.Drawing.Size(312, 20);
            this.txtBuscarEditarPedido.TabIndex = 48;
            // 
            // btnBuscarEditarPedido
            // 
            this.btnBuscarEditarPedido.Location = new System.Drawing.Point(573, 86);
            this.btnBuscarEditarPedido.Name = "btnBuscarEditarPedido";
            this.btnBuscarEditarPedido.Size = new System.Drawing.Size(89, 35);
            this.btnBuscarEditarPedido.TabIndex = 49;
            this.btnBuscarEditarPedido.Text = "Buscar";
            this.btnBuscarEditarPedido.UseVisualStyleBackColor = true;
            this.btnBuscarEditarPedido.Click += new System.EventHandler(this.btnBuscarEditarPedido_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "SetinhaVoltar2.png");
            // 
            // btnRetornar2
            // 
            this.btnRetornar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetornar2.ImageKey = "SetinhaVoltar2.png";
            this.btnRetornar2.ImageList = this.imageList1;
            this.btnRetornar2.Location = new System.Drawing.Point(151, 493);
            this.btnRetornar2.Name = "btnRetornar2";
            this.btnRetornar2.Size = new System.Drawing.Size(77, 29);
            this.btnRetornar2.TabIndex = 50;
            this.btnRetornar2.Text = "Voltar";
            this.btnRetornar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetornar2.UseVisualStyleBackColor = true;
            this.btnRetornar2.Click += new System.EventHandler(this.btnRetornar2_Click);
            // 
            // btnConfirmarEdicaoPedido
            // 
            this.btnConfirmarEdicaoPedido.Location = new System.Drawing.Point(567, 484);
            this.btnConfirmarEdicaoPedido.Name = "btnConfirmarEdicaoPedido";
            this.btnConfirmarEdicaoPedido.Size = new System.Drawing.Size(91, 38);
            this.btnConfirmarEdicaoPedido.TabIndex = 51;
            this.btnConfirmarEdicaoPedido.Text = "Salvar Informações";
            this.btnConfirmarEdicaoPedido.UseVisualStyleBackColor = true;
            this.btnConfirmarEdicaoPedido.Click += new System.EventHandler(this.btnConfirmarEdicaoPedido_Click);
            // 
            // txtEditarEmpresaCompra
            // 
            this.txtEditarEmpresaCompra.Location = new System.Drawing.Point(314, 415);
            this.txtEditarEmpresaCompra.Name = "txtEditarEmpresaCompra";
            this.txtEditarEmpresaCompra.Size = new System.Drawing.Size(159, 20);
            this.txtEditarEmpresaCompra.TabIndex = 63;
            // 
            // lblEmpresaCompra
            // 
            this.lblEmpresaCompra.AutoSize = true;
            this.lblEmpresaCompra.Location = new System.Drawing.Point(311, 399);
            this.lblEmpresaCompra.Name = "lblEmpresaCompra";
            this.lblEmpresaCompra.Size = new System.Drawing.Size(175, 13);
            this.lblEmpresaCompra.TabIndex = 62;
            this.lblEmpresaCompra.Text = "Empresa Responsável pela Compra";
            // 
            // txtEditarValorUnitario
            // 
            this.txtEditarValorUnitario.Location = new System.Drawing.Point(314, 351);
            this.txtEditarValorUnitario.Name = "txtEditarValorUnitario";
            this.txtEditarValorUnitario.Size = new System.Drawing.Size(159, 20);
            this.txtEditarValorUnitario.TabIndex = 61;
            // 
            // lblValorUnitario
            // 
            this.lblValorUnitario.AutoSize = true;
            this.lblValorUnitario.Location = new System.Drawing.Point(311, 335);
            this.lblValorUnitario.Name = "lblValorUnitario";
            this.lblValorUnitario.Size = new System.Drawing.Size(70, 13);
            this.lblValorUnitario.TabIndex = 60;
            this.lblValorUnitario.Text = "Valor Unitário";
            // 
            // txtEditarQuantidadePedido
            // 
            this.txtEditarQuantidadePedido.Location = new System.Drawing.Point(314, 292);
            this.txtEditarQuantidadePedido.Name = "txtEditarQuantidadePedido";
            this.txtEditarQuantidadePedido.Size = new System.Drawing.Size(159, 20);
            this.txtEditarQuantidadePedido.TabIndex = 59;
            // 
            // lblQuantidadePedido
            // 
            this.lblQuantidadePedido.AutoSize = true;
            this.lblQuantidadePedido.Location = new System.Drawing.Point(311, 276);
            this.lblQuantidadePedido.Name = "lblQuantidadePedido";
            this.lblQuantidadePedido.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidadePedido.TabIndex = 58;
            this.lblQuantidadePedido.Text = "Quantidade";
            // 
            // txtEditarIDPedido
            // 
            this.txtEditarIDPedido.Location = new System.Drawing.Point(314, 228);
            this.txtEditarIDPedido.Name = "txtEditarIDPedido";
            this.txtEditarIDPedido.Size = new System.Drawing.Size(159, 20);
            this.txtEditarIDPedido.TabIndex = 57;
            // 
            // lblIDPedido
            // 
            this.lblIDPedido.AutoSize = true;
            this.lblIDPedido.Location = new System.Drawing.Point(311, 212);
            this.lblIDPedido.Name = "lblIDPedido";
            this.lblIDPedido.Size = new System.Drawing.Size(69, 13);
            this.lblIDPedido.TabIndex = 56;
            this.lblIDPedido.Text = "ID do Pedido";
            // 
            // txtEditarNomeProduto
            // 
            this.txtEditarNomeProduto.Location = new System.Drawing.Point(314, 164);
            this.txtEditarNomeProduto.Name = "txtEditarNomeProduto";
            this.txtEditarNomeProduto.Size = new System.Drawing.Size(159, 20);
            this.txtEditarNomeProduto.TabIndex = 55;
            // 
            // lblNomeProduto
            // 
            this.lblNomeProduto.AutoSize = true;
            this.lblNomeProduto.Location = new System.Drawing.Point(311, 148);
            this.lblNomeProduto.Name = "lblNomeProduto";
            this.lblNomeProduto.Size = new System.Drawing.Size(90, 13);
            this.lblNomeProduto.TabIndex = 54;
            this.lblNomeProduto.Text = "Nome do Produto";
            // 
            // TelaEditarPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.txtEditarEmpresaCompra);
            this.Controls.Add(this.lblEmpresaCompra);
            this.Controls.Add(this.txtEditarValorUnitario);
            this.Controls.Add(this.lblValorUnitario);
            this.Controls.Add(this.txtEditarQuantidadePedido);
            this.Controls.Add(this.lblQuantidadePedido);
            this.Controls.Add(this.txtEditarIDPedido);
            this.Controls.Add(this.lblIDPedido);
            this.Controls.Add(this.txtEditarNomeProduto);
            this.Controls.Add(this.lblNomeProduto);
            this.Controls.Add(this.btnConfirmarEdicaoPedido);
            this.Controls.Add(this.btnRetornar2);
            this.Controls.Add(this.btnBuscarEditarPedido);
            this.Controls.Add(this.txtBuscarEditarPedido);
            this.Controls.Add(this.lblBuscarEditarPedido);
            this.Controls.Add(this.lblTituloPedidosCadastrados);
            this.Controls.Add(this.btnLogout2);
            this.Controls.Add(this.btnHome);
            this.Name = "TelaEditarPedidos";
            this.Text = "TelaEditarPedidos";
            this.Load += new System.EventHandler(this.TelaEditarPedidos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnLogout2;
        private System.Windows.Forms.Label lblTituloPedidosCadastrados;
        private System.Windows.Forms.Label lblBuscarEditarPedido;
        private System.Windows.Forms.TextBox txtBuscarEditarPedido;
        private System.Windows.Forms.Button btnBuscarEditarPedido;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnRetornar2;
        private System.Windows.Forms.Button btnConfirmarEdicaoPedido;
        private System.Windows.Forms.TextBox txtEditarEmpresaCompra;
        private System.Windows.Forms.Label lblEmpresaCompra;
        private System.Windows.Forms.TextBox txtEditarValorUnitario;
        private System.Windows.Forms.Label lblValorUnitario;
        private System.Windows.Forms.TextBox txtEditarQuantidadePedido;
        private System.Windows.Forms.Label lblQuantidadePedido;
        private System.Windows.Forms.TextBox txtEditarIDPedido;
        private System.Windows.Forms.Label lblIDPedido;
        private System.Windows.Forms.TextBox txtEditarNomeProduto;
        private System.Windows.Forms.Label lblNomeProduto;
    }
}