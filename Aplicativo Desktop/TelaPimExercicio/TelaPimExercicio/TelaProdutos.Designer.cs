namespace TelaPimExercicio
{
    partial class TelaProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaProdutos));
            this.btnLogout = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnRetornar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblBuscarFornecedor = new System.Windows.Forms.Label();
            this.txtBuscarProdutos = new System.Windows.Forms.TextBox();
            this.btnBuscarProdutos = new System.Windows.Forms.Button();
            this.lvBuscarProdutos = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValorUnitario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmpresaCompra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCadastrarNovoProduto = new System.Windows.Forms.Button();
            this.btnExcluirProduto = new System.Windows.Forms.Button();
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
            this.btnLogout.TabIndex = 8;
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
            this.btnRetornar.TabIndex = 9;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Produtos Cadastrados";
            // 
            // lblBuscarFornecedor
            // 
            this.lblBuscarFornecedor.AutoSize = true;
            this.lblBuscarFornecedor.Location = new System.Drawing.Point(148, 74);
            this.lblBuscarFornecedor.Name = "lblBuscarFornecedor";
            this.lblBuscarFornecedor.Size = new System.Drawing.Size(218, 13);
            this.lblBuscarFornecedor.TabIndex = 47;
            this.lblBuscarFornecedor.Text = "Digite o ID do Produto que Deseja Encontrar";
            // 
            // txtBuscarProdutos
            // 
            this.txtBuscarProdutos.Location = new System.Drawing.Point(151, 101);
            this.txtBuscarProdutos.Name = "txtBuscarProdutos";
            this.txtBuscarProdutos.Size = new System.Drawing.Size(312, 20);
            this.txtBuscarProdutos.TabIndex = 48;
            // 
            // btnBuscarProdutos
            // 
            this.btnBuscarProdutos.Location = new System.Drawing.Point(573, 86);
            this.btnBuscarProdutos.Name = "btnBuscarProdutos";
            this.btnBuscarProdutos.Size = new System.Drawing.Size(89, 35);
            this.btnBuscarProdutos.TabIndex = 49;
            this.btnBuscarProdutos.Text = "Buscar";
            this.btnBuscarProdutos.UseVisualStyleBackColor = true;
            this.btnBuscarProdutos.Click += new System.EventHandler(this.btnBuscarProdutos_Click);
            // 
            // lvBuscarProdutos
            // 
            this.lvBuscarProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Nome,
            this.Quantidade,
            this.ValorUnitario,
            this.EmpresaCompra});
            this.lvBuscarProdutos.HideSelection = false;
            this.lvBuscarProdutos.Location = new System.Drawing.Point(151, 142);
            this.lvBuscarProdutos.Name = "lvBuscarProdutos";
            this.lvBuscarProdutos.Size = new System.Drawing.Size(510, 335);
            this.lvBuscarProdutos.TabIndex = 50;
            this.lvBuscarProdutos.UseCompatibleStateImageBehavior = false;
            this.lvBuscarProdutos.View = System.Windows.Forms.View.Details;
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
            // btnCadastrarNovoProduto
            // 
            this.btnCadastrarNovoProduto.Location = new System.Drawing.Point(453, 484);
            this.btnCadastrarNovoProduto.Name = "btnCadastrarNovoProduto";
            this.btnCadastrarNovoProduto.Size = new System.Drawing.Size(91, 38);
            this.btnCadastrarNovoProduto.TabIndex = 51;
            this.btnCadastrarNovoProduto.Text = "Cadastrar Novo Produto";
            this.btnCadastrarNovoProduto.UseVisualStyleBackColor = true;
            this.btnCadastrarNovoProduto.Click += new System.EventHandler(this.btnCadastrarNovoProduto_Click);
            // 
            // btnExcluirProduto
            // 
            this.btnExcluirProduto.Location = new System.Drawing.Point(567, 484);
            this.btnExcluirProduto.Name = "btnExcluirProduto";
            this.btnExcluirProduto.Size = new System.Drawing.Size(91, 38);
            this.btnExcluirProduto.TabIndex = 53;
            this.btnExcluirProduto.Text = "Excluir um Produto";
            this.btnExcluirProduto.UseVisualStyleBackColor = true;
            this.btnExcluirProduto.Click += new System.EventHandler(this.btnExcluirProduto_Click);
            // 
            // TelaProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnExcluirProduto);
            this.Controls.Add(this.btnCadastrarNovoProduto);
            this.Controls.Add(this.lvBuscarProdutos);
            this.Controls.Add(this.btnBuscarProdutos);
            this.Controls.Add(this.txtBuscarProdutos);
            this.Controls.Add(this.lblBuscarFornecedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRetornar);
            this.Controls.Add(this.btnLogout);
            this.Name = "TelaProdutos";
            this.Text = "Produtos";
            this.Load += new System.EventHandler(this.TelaProdutos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRetornar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label lblBuscarFornecedor;
        private System.Windows.Forms.TextBox txtBuscarProdutos;
        private System.Windows.Forms.Button btnBuscarProdutos;
        private System.Windows.Forms.ListView lvBuscarProdutos;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader ValorUnitario;
        private System.Windows.Forms.ColumnHeader EmpresaCompra;
        private System.Windows.Forms.Button btnCadastrarNovoProduto;
        private System.Windows.Forms.Button btnExcluirProduto;
    }
}