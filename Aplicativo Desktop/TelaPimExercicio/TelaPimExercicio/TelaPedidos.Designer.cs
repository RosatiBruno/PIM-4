namespace TelaPimExercicio
{
    partial class TelaPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPedidos));
            this.btnLogout2 = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnRetornar2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lvBuscarPedidos = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValorUnitario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmpresaCompra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCadastrarNovoPedido = new System.Windows.Forms.Button();
            this.btnExcluirPedido = new System.Windows.Forms.Button();
            this.btnEditarPedido = new System.Windows.Forms.Button();
            this.lblTituloPedidosCadastrados = new System.Windows.Forms.Label();
            this.btnBuscarPedido = new System.Windows.Forms.Button();
            this.lblBuscarFornecedor = new System.Windows.Forms.Label();
            this.txtBuscarPedido = new System.Windows.Forms.TextBox();
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
            this.btnLogout2.TabIndex = 8;
            this.btnLogout2.Text = "Logout";
            this.btnLogout2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout2.UseVisualStyleBackColor = true;
            this.btnLogout2.Click += new System.EventHandler(this.btnLogout2_Click_1);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Logout.png");
            // 
            // btnRetornar2
            // 
            this.btnRetornar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetornar2.ImageKey = "SetinhaVoltar2.png";
            this.btnRetornar2.ImageList = this.imageList1;
            this.btnRetornar2.Location = new System.Drawing.Point(151, 493);
            this.btnRetornar2.Name = "btnRetornar2";
            this.btnRetornar2.Size = new System.Drawing.Size(77, 29);
            this.btnRetornar2.TabIndex = 9;
            this.btnRetornar2.Text = "Voltar";
            this.btnRetornar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetornar2.UseVisualStyleBackColor = true;
            this.btnRetornar2.Click += new System.EventHandler(this.btnRetornar2_Click_1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Logout.png");
            this.imageList1.Images.SetKeyName(1, "SetinhaVoltar2.png");
            // 
            // lvBuscarPedidos
            // 
            this.lvBuscarPedidos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Nome,
            this.Quantidade,
            this.ValorUnitario,
            this.EmpresaCompra});
            this.lvBuscarPedidos.HideSelection = false;
            this.lvBuscarPedidos.Location = new System.Drawing.Point(151, 142);
            this.lvBuscarPedidos.Name = "lvBuscarPedidos";
            this.lvBuscarPedidos.Size = new System.Drawing.Size(510, 335);
            this.lvBuscarPedidos.TabIndex = 14;
            this.lvBuscarPedidos.UseCompatibleStateImageBehavior = false;
            this.lvBuscarPedidos.View = System.Windows.Forms.View.Details;
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
            // btnCadastrarNovoPedido
            // 
            this.btnCadastrarNovoPedido.Location = new System.Drawing.Point(335, 484);
            this.btnCadastrarNovoPedido.Name = "btnCadastrarNovoPedido";
            this.btnCadastrarNovoPedido.Size = new System.Drawing.Size(91, 38);
            this.btnCadastrarNovoPedido.TabIndex = 16;
            this.btnCadastrarNovoPedido.Text = "Cadastrar Novo Pedido";
            this.btnCadastrarNovoPedido.UseVisualStyleBackColor = true;
            this.btnCadastrarNovoPedido.Click += new System.EventHandler(this.btnCadastrarNovoPedido_Click);
            // 
            // btnExcluirPedido
            // 
            this.btnExcluirPedido.Location = new System.Drawing.Point(567, 484);
            this.btnExcluirPedido.Name = "btnExcluirPedido";
            this.btnExcluirPedido.Size = new System.Drawing.Size(91, 38);
            this.btnExcluirPedido.TabIndex = 17;
            this.btnExcluirPedido.Text = "Excluir um Pedido";
            this.btnExcluirPedido.UseVisualStyleBackColor = true;
            this.btnExcluirPedido.Click += new System.EventHandler(this.btnExcluirPedido_Click);
            // 
            // btnEditarPedido
            // 
            this.btnEditarPedido.Location = new System.Drawing.Point(453, 484);
            this.btnEditarPedido.Name = "btnEditarPedido";
            this.btnEditarPedido.Size = new System.Drawing.Size(91, 38);
            this.btnEditarPedido.TabIndex = 18;
            this.btnEditarPedido.Text = "Editar um Pedido";
            this.btnEditarPedido.UseVisualStyleBackColor = true;
            this.btnEditarPedido.Click += new System.EventHandler(this.btnEditarPedido_Click);
            // 
            // lblTituloPedidosCadastrados
            // 
            this.lblTituloPedidosCadastrados.AutoSize = true;
            this.lblTituloPedidosCadastrados.Location = new System.Drawing.Point(334, 29);
            this.lblTituloPedidosCadastrados.Name = "lblTituloPedidosCadastrados";
            this.lblTituloPedidosCadastrados.Size = new System.Drawing.Size(107, 13);
            this.lblTituloPedidosCadastrados.TabIndex = 44;
            this.lblTituloPedidosCadastrados.Text = "Pedidos Cadastrados";
            // 
            // btnBuscarPedido
            // 
            this.btnBuscarPedido.Location = new System.Drawing.Point(573, 86);
            this.btnBuscarPedido.Name = "btnBuscarPedido";
            this.btnBuscarPedido.Size = new System.Drawing.Size(89, 35);
            this.btnBuscarPedido.TabIndex = 47;
            this.btnBuscarPedido.Text = "Buscar";
            this.btnBuscarPedido.UseVisualStyleBackColor = true;
            this.btnBuscarPedido.Click += new System.EventHandler(this.btnBuscarPedido_Click);
            // 
            // lblBuscarFornecedor
            // 
            this.lblBuscarFornecedor.AutoSize = true;
            this.lblBuscarFornecedor.Location = new System.Drawing.Point(148, 74);
            this.lblBuscarFornecedor.Name = "lblBuscarFornecedor";
            this.lblBuscarFornecedor.Size = new System.Drawing.Size(214, 13);
            this.lblBuscarFornecedor.TabIndex = 46;
            this.lblBuscarFornecedor.Text = "Digite o ID do Pedido que Deseja Encontrar";
            // 
            // txtBuscarPedido
            // 
            this.txtBuscarPedido.Location = new System.Drawing.Point(151, 101);
            this.txtBuscarPedido.Name = "txtBuscarPedido";
            this.txtBuscarPedido.Size = new System.Drawing.Size(312, 20);
            this.txtBuscarPedido.TabIndex = 45;
            // 
            // TelaPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnBuscarPedido);
            this.Controls.Add(this.lblBuscarFornecedor);
            this.Controls.Add(this.txtBuscarPedido);
            this.Controls.Add(this.lblTituloPedidosCadastrados);
            this.Controls.Add(this.btnEditarPedido);
            this.Controls.Add(this.btnExcluirPedido);
            this.Controls.Add(this.btnCadastrarNovoPedido);
            this.Controls.Add(this.lvBuscarPedidos);
            this.Controls.Add(this.btnRetornar2);
            this.Controls.Add(this.btnLogout2);
            this.Name = "TelaPedidos";
            this.Text = "Pedidos";
            this.Load += new System.EventHandler(this.TelaPedidos_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout2;
        private System.Windows.Forms.Button btnRetornar2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ListView lvBuscarPedidos;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.Button btnCadastrarNovoPedido;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader ValorUnitario;
        private System.Windows.Forms.ColumnHeader EmpresaCompra;
        private System.Windows.Forms.Button btnExcluirPedido;
        private System.Windows.Forms.Button btnEditarPedido;
        private System.Windows.Forms.Label lblTituloPedidosCadastrados;
        private System.Windows.Forms.Button btnBuscarPedido;
        private System.Windows.Forms.Label lblBuscarFornecedor;
        private System.Windows.Forms.TextBox txtBuscarPedido;
    }
}