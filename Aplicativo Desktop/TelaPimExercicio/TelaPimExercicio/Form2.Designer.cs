namespace TelaPimExercicio
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btnFornecedores = new System.Windows.Forms.Button();
            this.btnPedidos = new System.Windows.Forms.Button();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnProducao = new System.Windows.Forms.Button();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnCadastrarFunc = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // btnFornecedores
            // 
            this.btnFornecedores.ImageKey = "fornecedores-icon.png";
            this.btnFornecedores.ImageList = this.imageList1;
            this.btnFornecedores.Location = new System.Drawing.Point(183, 136);
            this.btnFornecedores.Name = "btnFornecedores";
            this.btnFornecedores.Size = new System.Drawing.Size(154, 132);
            this.btnFornecedores.TabIndex = 0;
            this.btnFornecedores.Text = "Fornecedores";
            this.btnFornecedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFornecedores.UseVisualStyleBackColor = true;
            this.btnFornecedores.Click += new System.EventHandler(this.btnFornecedores_Click);
            // 
            // btnPedidos
            // 
            this.btnPedidos.ImageKey = "pedidos-icon.png";
            this.btnPedidos.ImageList = this.imageList1;
            this.btnPedidos.Location = new System.Drawing.Point(343, 136);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(154, 132);
            this.btnPedidos.TabIndex = 1;
            this.btnPedidos.Text = "Pedidos";
            this.btnPedidos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPedidos.UseVisualStyleBackColor = true;
            this.btnPedidos.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnProdutos
            // 
            this.btnProdutos.ImageKey = "produtos-icon.png";
            this.btnProdutos.ImageList = this.imageList1;
            this.btnProdutos.Location = new System.Drawing.Point(503, 136);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(154, 132);
            this.btnProdutos.TabIndex = 2;
            this.btnProdutos.Text = "Produtos";
            this.btnProdutos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProdutos.UseVisualStyleBackColor = true;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnProducao
            // 
            this.btnProducao.ImageKey = "producao-icon.png";
            this.btnProducao.ImageList = this.imageList1;
            this.btnProducao.Location = new System.Drawing.Point(503, 297);
            this.btnProducao.Name = "btnProducao";
            this.btnProducao.Size = new System.Drawing.Size(154, 132);
            this.btnProducao.TabIndex = 5;
            this.btnProducao.Text = "Produção";
            this.btnProducao.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProducao.UseVisualStyleBackColor = true;
            this.btnProducao.Click += new System.EventHandler(this.btnProducao_Click);
            // 
            // btnVendas
            // 
            this.btnVendas.ImageKey = "vendas-icon.png";
            this.btnVendas.ImageList = this.imageList1;
            this.btnVendas.Location = new System.Drawing.Point(343, 297);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(154, 132);
            this.btnVendas.TabIndex = 4;
            this.btnVendas.Text = "Vendas";
            this.btnVendas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVendas.UseVisualStyleBackColor = true;
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);
            // 
            // btnCadastrarFunc
            // 
            this.btnCadastrarFunc.ImageKey = "registro.png";
            this.btnCadastrarFunc.ImageList = this.imageList1;
            this.btnCadastrarFunc.Location = new System.Drawing.Point(183, 297);
            this.btnCadastrarFunc.Name = "btnCadastrarFunc";
            this.btnCadastrarFunc.Size = new System.Drawing.Size(154, 132);
            this.btnCadastrarFunc.TabIndex = 3;
            this.btnCadastrarFunc.Text = "Cadastrar Funcionário";
            this.btnCadastrarFunc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCadastrarFunc.UseVisualStyleBackColor = true;
            this.btnCadastrarFunc.Click += new System.EventHandler(this.btnCadastrarFunc_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogout.ImageKey = "Logout.png";
            this.btnLogout.ImageList = this.imageList2;
            this.btnLogout.Location = new System.Drawing.Point(27, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(71, 59);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "fornecedores-icon.png");
            this.imageList1.Images.SetKeyName(1, "pedidos-icon.png");
            this.imageList1.Images.SetKeyName(2, "produtos-icon.png");
            this.imageList1.Images.SetKeyName(3, "registro.png");
            this.imageList1.Images.SetKeyName(4, "vendas-icon.png");
            this.imageList1.Images.SetKeyName(5, "producao-icon.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Engrenagem.png");
            this.imageList2.Images.SetKeyName(1, "Logout.png");
            this.imageList2.Images.SetKeyName(2, "SetinhaVoltar.png");
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnProducao);
            this.Controls.Add(this.btnVendas);
            this.Controls.Add(this.btnCadastrarFunc);
            this.Controls.Add(this.btnProdutos);
            this.Controls.Add(this.btnPedidos);
            this.Controls.Add(this.btnFornecedores);
            this.Name = "Form2";
            this.Text = "Tela Inicial";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFornecedores;
        private System.Windows.Forms.Button btnPedidos;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Button btnProducao;
        private System.Windows.Forms.Button btnVendas;
        private System.Windows.Forms.Button btnCadastrarFunc;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
    }
}