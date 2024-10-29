namespace TelaPimExercicio
{
    partial class TelaVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaVendas));
            this.btnLogout = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnRetornar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lvBuscarPedidos = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValorUnitario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmpresaCompra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTituloPedidosCadastrados = new System.Windows.Forms.Label();
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
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
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
            this.btnRetornar.TabIndex = 11;
            this.btnRetornar.Text = "Voltar";
            this.btnRetornar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetornar.UseVisualStyleBackColor = true;
            this.btnRetornar.Click += new System.EventHandler(this.btnRetornar_Click_1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "SetinhaVoltar2.png");
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
            this.lvBuscarPedidos.Location = new System.Drawing.Point(151, 71);
            this.lvBuscarPedidos.Name = "lvBuscarPedidos";
            this.lvBuscarPedidos.Size = new System.Drawing.Size(563, 406);
            this.lvBuscarPedidos.TabIndex = 51;
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
            // lblTituloPedidosCadastrados
            // 
            this.lblTituloPedidosCadastrados.AutoSize = true;
            this.lblTituloPedidosCadastrados.Location = new System.Drawing.Point(360, 29);
            this.lblTituloPedidosCadastrados.Name = "lblTituloPedidosCadastrados";
            this.lblTituloPedidosCadastrados.Size = new System.Drawing.Size(43, 13);
            this.lblTituloPedidosCadastrados.TabIndex = 52;
            this.lblTituloPedidosCadastrados.Text = "Vendas";
            // 
            // TelaVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblTituloPedidosCadastrados);
            this.Controls.Add(this.lvBuscarPedidos);
            this.Controls.Add(this.btnRetornar);
            this.Controls.Add(this.btnLogout);
            this.Name = "TelaVendas";
            this.Text = "Vendas";
            this.Load += new System.EventHandler(this.TelaVendas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRetornar;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lvBuscarPedidos;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader ValorUnitario;
        private System.Windows.Forms.ColumnHeader EmpresaCompra;
        private System.Windows.Forms.Label lblTituloPedidosCadastrados;
    }
}