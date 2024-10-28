namespace TelaPimExercicio
{
    partial class TelaCadastroPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCadastroPedido));
            this.btnRetornar2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnLogout2 = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnHome = new System.Windows.Forms.Button();
            this.lblNomeProduto = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.lblTituloCadastroPedido = new System.Windows.Forms.Label();
            this.lblIDPedido = new System.Windows.Forms.Label();
            this.txtIDPedido = new System.Windows.Forms.TextBox();
            this.lblQuantidadePedido = new System.Windows.Forms.Label();
            this.txtQuantidadePedido = new System.Windows.Forms.TextBox();
            this.lblValorUnitario = new System.Windows.Forms.Label();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.lblEmpresaCompra = new System.Windows.Forms.Label();
            this.txtEmpresaCompra = new System.Windows.Forms.TextBox();
            this.btnConfirmarCadastroNovoPedido = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRetornar2
            // 
            this.btnRetornar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetornar2.ImageKey = "SetinhaVoltar2.png";
            this.btnRetornar2.ImageList = this.imageList1;
            this.btnRetornar2.Location = new System.Drawing.Point(151, 493);
            this.btnRetornar2.Name = "btnRetornar2";
            this.btnRetornar2.Size = new System.Drawing.Size(77, 29);
            this.btnRetornar2.TabIndex = 10;
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
            // btnLogout2
            // 
            this.btnLogout2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogout2.ImageKey = "Logout.png";
            this.btnLogout2.ImageList = this.imageList2;
            this.btnLogout2.Location = new System.Drawing.Point(27, 12);
            this.btnLogout2.Name = "btnLogout2";
            this.btnLogout2.Size = new System.Drawing.Size(71, 59);
            this.btnLogout2.TabIndex = 11;
            this.btnLogout2.Text = "Logout";
            this.btnLogout2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout2.UseVisualStyleBackColor = true;
            this.btnLogout2.Click += new System.EventHandler(this.btnLogout2_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Logout.png");
            this.imageList2.Images.SetKeyName(1, "home.png");
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
            // lblNomeProduto
            // 
            this.lblNomeProduto.AutoSize = true;
            this.lblNomeProduto.Location = new System.Drawing.Point(330, 101);
            this.lblNomeProduto.Name = "lblNomeProduto";
            this.lblNomeProduto.Size = new System.Drawing.Size(90, 13);
            this.lblNomeProduto.TabIndex = 43;
            this.lblNomeProduto.Text = "Nome do Produto";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(333, 117);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(159, 20);
            this.txtNomeProduto.TabIndex = 44;
            // 
            // lblTituloCadastroPedido
            // 
            this.lblTituloCadastroPedido.AutoSize = true;
            this.lblTituloCadastroPedido.Location = new System.Drawing.Point(330, 25);
            this.lblTituloCadastroPedido.Name = "lblTituloCadastroPedido";
            this.lblTituloCadastroPedido.Size = new System.Drawing.Size(100, 13);
            this.lblTituloCadastroPedido.TabIndex = 45;
            this.lblTituloCadastroPedido.Text = "Cadastro de Pedido";
            // 
            // lblIDPedido
            // 
            this.lblIDPedido.AutoSize = true;
            this.lblIDPedido.Location = new System.Drawing.Point(330, 165);
            this.lblIDPedido.Name = "lblIDPedido";
            this.lblIDPedido.Size = new System.Drawing.Size(69, 13);
            this.lblIDPedido.TabIndex = 46;
            this.lblIDPedido.Text = "ID do Pedido";
            // 
            // txtIDPedido
            // 
            this.txtIDPedido.Location = new System.Drawing.Point(333, 181);
            this.txtIDPedido.Name = "txtIDPedido";
            this.txtIDPedido.Size = new System.Drawing.Size(159, 20);
            this.txtIDPedido.TabIndex = 47;
            // 
            // lblQuantidadePedido
            // 
            this.lblQuantidadePedido.AutoSize = true;
            this.lblQuantidadePedido.Location = new System.Drawing.Point(330, 229);
            this.lblQuantidadePedido.Name = "lblQuantidadePedido";
            this.lblQuantidadePedido.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidadePedido.TabIndex = 48;
            this.lblQuantidadePedido.Text = "Quantidade";
            // 
            // txtQuantidadePedido
            // 
            this.txtQuantidadePedido.Location = new System.Drawing.Point(333, 245);
            this.txtQuantidadePedido.Name = "txtQuantidadePedido";
            this.txtQuantidadePedido.Size = new System.Drawing.Size(159, 20);
            this.txtQuantidadePedido.TabIndex = 49;
            // 
            // lblValorUnitario
            // 
            this.lblValorUnitario.AutoSize = true;
            this.lblValorUnitario.Location = new System.Drawing.Point(330, 288);
            this.lblValorUnitario.Name = "lblValorUnitario";
            this.lblValorUnitario.Size = new System.Drawing.Size(70, 13);
            this.lblValorUnitario.TabIndex = 50;
            this.lblValorUnitario.Text = "Valor Unitário";
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.Location = new System.Drawing.Point(333, 304);
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.Size = new System.Drawing.Size(159, 20);
            this.txtValorUnitario.TabIndex = 51;
            // 
            // lblEmpresaCompra
            // 
            this.lblEmpresaCompra.AutoSize = true;
            this.lblEmpresaCompra.Location = new System.Drawing.Point(330, 352);
            this.lblEmpresaCompra.Name = "lblEmpresaCompra";
            this.lblEmpresaCompra.Size = new System.Drawing.Size(175, 13);
            this.lblEmpresaCompra.TabIndex = 52;
            this.lblEmpresaCompra.Text = "Empresa Responsável pela Compra";
            // 
            // txtEmpresaCompra
            // 
            this.txtEmpresaCompra.Location = new System.Drawing.Point(333, 368);
            this.txtEmpresaCompra.Name = "txtEmpresaCompra";
            this.txtEmpresaCompra.Size = new System.Drawing.Size(159, 20);
            this.txtEmpresaCompra.TabIndex = 53;
            // 
            // btnConfirmarCadastroNovoPedido
            // 
            this.btnConfirmarCadastroNovoPedido.Location = new System.Drawing.Point(611, 488);
            this.btnConfirmarCadastroNovoPedido.Name = "btnConfirmarCadastroNovoPedido";
            this.btnConfirmarCadastroNovoPedido.Size = new System.Drawing.Size(91, 38);
            this.btnConfirmarCadastroNovoPedido.TabIndex = 54;
            this.btnConfirmarCadastroNovoPedido.Text = "Cadastrar";
            this.btnConfirmarCadastroNovoPedido.UseVisualStyleBackColor = true;
            this.btnConfirmarCadastroNovoPedido.Click += new System.EventHandler(this.btnConfirmarCadastroNovoPedido_Click);
            // 
            // TelaCadastroPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnConfirmarCadastroNovoPedido);
            this.Controls.Add(this.txtEmpresaCompra);
            this.Controls.Add(this.lblEmpresaCompra);
            this.Controls.Add(this.txtValorUnitario);
            this.Controls.Add(this.lblValorUnitario);
            this.Controls.Add(this.txtQuantidadePedido);
            this.Controls.Add(this.lblQuantidadePedido);
            this.Controls.Add(this.txtIDPedido);
            this.Controls.Add(this.lblIDPedido);
            this.Controls.Add(this.lblTituloCadastroPedido);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.lblNomeProduto);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnLogout2);
            this.Controls.Add(this.btnRetornar2);
            this.Name = "TelaCadastroPedido";
            this.Text = "Cadastro de Pedido";
            this.Load += new System.EventHandler(this.TelaCadastroPedido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRetornar2;
        private System.Windows.Forms.Button btnLogout2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label lblNomeProduto;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.Label lblTituloCadastroPedido;
        private System.Windows.Forms.Label lblIDPedido;
        private System.Windows.Forms.TextBox txtIDPedido;
        private System.Windows.Forms.Label lblQuantidadePedido;
        private System.Windows.Forms.TextBox txtQuantidadePedido;
        private System.Windows.Forms.Label lblValorUnitario;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.Label lblEmpresaCompra;
        private System.Windows.Forms.TextBox txtEmpresaCompra;
        private System.Windows.Forms.Button btnConfirmarCadastroNovoPedido;
    }
}