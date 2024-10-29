namespace TelaPimExercicio
{
    partial class TelaCadastrarProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCadastrarProduto));
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRetornar = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.txtEmpresaCompraProduto = new System.Windows.Forms.TextBox();
            this.lblEmpresaCompra = new System.Windows.Forms.Label();
            this.txtValorUnitarioProduto = new System.Windows.Forms.TextBox();
            this.lblValorUnitario = new System.Windows.Forms.Label();
            this.txtQuantidadeProduto = new System.Windows.Forms.TextBox();
            this.lblQuantidadePedido = new System.Windows.Forms.Label();
            this.txtIDProduto = new System.Windows.Forms.TextBox();
            this.lblIDProduto = new System.Windows.Forms.Label();
            this.lblTituloCadastroProduto = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.lblNomeProduto = new System.Windows.Forms.Label();
            this.btnConfirmarCadastroNovoProduto = new System.Windows.Forms.Button();
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
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnRetornar
            // 
            this.btnRetornar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetornar.ImageKey = "SetinhaVoltar2.png";
            this.btnRetornar.ImageList = this.imageList1;
            this.btnRetornar.Location = new System.Drawing.Point(151, 493);
            this.btnRetornar.Name = "btnRetornar";
            this.btnRetornar.Size = new System.Drawing.Size(77, 29);
            this.btnRetornar.TabIndex = 10;
            this.btnRetornar.Text = "Voltar";
            this.btnRetornar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetornar.UseVisualStyleBackColor = true;
            this.btnRetornar.Click += new System.EventHandler(this.btnRetornar_Click);
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
            // txtEmpresaCompraProduto
            // 
            this.txtEmpresaCompraProduto.Location = new System.Drawing.Point(333, 368);
            this.txtEmpresaCompraProduto.Name = "txtEmpresaCompraProduto";
            this.txtEmpresaCompraProduto.Size = new System.Drawing.Size(159, 20);
            this.txtEmpresaCompraProduto.TabIndex = 64;
            // 
            // lblEmpresaCompra
            // 
            this.lblEmpresaCompra.AutoSize = true;
            this.lblEmpresaCompra.Location = new System.Drawing.Point(330, 352);
            this.lblEmpresaCompra.Name = "lblEmpresaCompra";
            this.lblEmpresaCompra.Size = new System.Drawing.Size(175, 13);
            this.lblEmpresaCompra.TabIndex = 63;
            this.lblEmpresaCompra.Text = "Empresa Responsável pela Compra";
            // 
            // txtValorUnitarioProduto
            // 
            this.txtValorUnitarioProduto.Location = new System.Drawing.Point(333, 304);
            this.txtValorUnitarioProduto.Name = "txtValorUnitarioProduto";
            this.txtValorUnitarioProduto.Size = new System.Drawing.Size(159, 20);
            this.txtValorUnitarioProduto.TabIndex = 62;
            // 
            // lblValorUnitario
            // 
            this.lblValorUnitario.AutoSize = true;
            this.lblValorUnitario.Location = new System.Drawing.Point(330, 288);
            this.lblValorUnitario.Name = "lblValorUnitario";
            this.lblValorUnitario.Size = new System.Drawing.Size(70, 13);
            this.lblValorUnitario.TabIndex = 61;
            this.lblValorUnitario.Text = "Valor Unitário";
            // 
            // txtQuantidadeProduto
            // 
            this.txtQuantidadeProduto.Location = new System.Drawing.Point(333, 245);
            this.txtQuantidadeProduto.Name = "txtQuantidadeProduto";
            this.txtQuantidadeProduto.Size = new System.Drawing.Size(159, 20);
            this.txtQuantidadeProduto.TabIndex = 60;
            // 
            // lblQuantidadePedido
            // 
            this.lblQuantidadePedido.AutoSize = true;
            this.lblQuantidadePedido.Location = new System.Drawing.Point(330, 229);
            this.lblQuantidadePedido.Name = "lblQuantidadePedido";
            this.lblQuantidadePedido.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidadePedido.TabIndex = 59;
            this.lblQuantidadePedido.Text = "Quantidade";
            // 
            // txtIDProduto
            // 
            this.txtIDProduto.Location = new System.Drawing.Point(333, 181);
            this.txtIDProduto.Name = "txtIDProduto";
            this.txtIDProduto.Size = new System.Drawing.Size(159, 20);
            this.txtIDProduto.TabIndex = 58;
            // 
            // lblIDProduto
            // 
            this.lblIDProduto.AutoSize = true;
            this.lblIDProduto.Location = new System.Drawing.Point(330, 165);
            this.lblIDProduto.Name = "lblIDProduto";
            this.lblIDProduto.Size = new System.Drawing.Size(73, 13);
            this.lblIDProduto.TabIndex = 57;
            this.lblIDProduto.Text = "ID do Produto";
            // 
            // lblTituloCadastroProduto
            // 
            this.lblTituloCadastroProduto.AutoSize = true;
            this.lblTituloCadastroProduto.Location = new System.Drawing.Point(330, 25);
            this.lblTituloCadastroProduto.Name = "lblTituloCadastroProduto";
            this.lblTituloCadastroProduto.Size = new System.Drawing.Size(104, 13);
            this.lblTituloCadastroProduto.TabIndex = 56;
            this.lblTituloCadastroProduto.Text = "Cadastro de Produto";
//            this.lblTituloCadastroProduto.Click += new System.EventHandler(this.lblTituloCadastroPedido_Click);
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(333, 117);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(159, 20);
            this.txtNomeProduto.TabIndex = 55;
            // 
            // lblNomeProduto
            // 
            this.lblNomeProduto.AutoSize = true;
            this.lblNomeProduto.Location = new System.Drawing.Point(330, 101);
            this.lblNomeProduto.Name = "lblNomeProduto";
            this.lblNomeProduto.Size = new System.Drawing.Size(90, 13);
            this.lblNomeProduto.TabIndex = 54;
            this.lblNomeProduto.Text = "Nome do Produto";
            // 
            // btnConfirmarCadastroNovoProduto
            // 
            this.btnConfirmarCadastroNovoProduto.Location = new System.Drawing.Point(611, 488);
            this.btnConfirmarCadastroNovoProduto.Name = "btnConfirmarCadastroNovoProduto";
            this.btnConfirmarCadastroNovoProduto.Size = new System.Drawing.Size(91, 38);
            this.btnConfirmarCadastroNovoProduto.TabIndex = 65;
            this.btnConfirmarCadastroNovoProduto.Text = "Cadastrar";
            this.btnConfirmarCadastroNovoProduto.UseVisualStyleBackColor = true;
            this.btnConfirmarCadastroNovoProduto.Click += new System.EventHandler(this.btnConfirmarCadastroNovoProduto_Click);
            // 
            // TelaCadastrarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnConfirmarCadastroNovoProduto);
            this.Controls.Add(this.txtEmpresaCompraProduto);
            this.Controls.Add(this.lblEmpresaCompra);
            this.Controls.Add(this.txtValorUnitarioProduto);
            this.Controls.Add(this.lblValorUnitario);
            this.Controls.Add(this.txtQuantidadeProduto);
            this.Controls.Add(this.lblQuantidadePedido);
            this.Controls.Add(this.txtIDProduto);
            this.Controls.Add(this.lblIDProduto);
            this.Controls.Add(this.lblTituloCadastroProduto);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.lblNomeProduto);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnRetornar);
            this.Controls.Add(this.btnLogout);
            this.Name = "TelaCadastrarProduto";
            this.Text = "Cadastrar Produto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRetornar;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.TextBox txtEmpresaCompraProduto;
        private System.Windows.Forms.Label lblEmpresaCompra;
        private System.Windows.Forms.TextBox txtValorUnitarioProduto;
        private System.Windows.Forms.Label lblValorUnitario;
        private System.Windows.Forms.TextBox txtQuantidadeProduto;
        private System.Windows.Forms.Label lblQuantidadePedido;
        private System.Windows.Forms.TextBox txtIDProduto;
        private System.Windows.Forms.Label lblIDProduto;
        private System.Windows.Forms.Label lblTituloCadastroProduto;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.Label lblNomeProduto;
        private System.Windows.Forms.Button btnConfirmarCadastroNovoProduto;
    }
}