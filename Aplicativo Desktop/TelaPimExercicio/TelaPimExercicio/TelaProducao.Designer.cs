namespace TelaPimExercicio
{
    partial class TelaProducao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaProducao));
            this.btnLogout = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnRetornar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblBuscarProducao = new System.Windows.Forms.Label();
            this.txtBuscarProducao = new System.Windows.Forms.TextBox();
            this.btnBuscarProducao = new System.Windows.Forms.Button();
            this.lvBuscarProducao = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataProducao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResponsavelProducao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCadastrarNovaProducao = new System.Windows.Forms.Button();
            this.btnEditarProducao = new System.Windows.Forms.Button();
            this.btnExcluirProducao = new System.Windows.Forms.Button();
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
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
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
            this.btnRetornar.TabIndex = 12;
            this.btnRetornar.Text = "Voltar";
            this.btnRetornar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetornar.UseVisualStyleBackColor = true;
            this.btnRetornar.Click += new System.EventHandler(this.btnRetornar_Click);
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
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Produções Cadastradas";
            // 
            // lblBuscarProducao
            // 
            this.lblBuscarProducao.AutoSize = true;
            this.lblBuscarProducao.Location = new System.Drawing.Point(148, 74);
            this.lblBuscarProducao.Name = "lblBuscarProducao";
            this.lblBuscarProducao.Size = new System.Drawing.Size(227, 13);
            this.lblBuscarProducao.TabIndex = 47;
            this.lblBuscarProducao.Text = "Digite o ID da Produção que Deseja Encontrar";
            // 
            // txtBuscarProducao
            // 
            this.txtBuscarProducao.Location = new System.Drawing.Point(151, 101);
            this.txtBuscarProducao.Name = "txtBuscarProducao";
            this.txtBuscarProducao.Size = new System.Drawing.Size(312, 20);
            this.txtBuscarProducao.TabIndex = 48;
            // 
            // btnBuscarProducao
            // 
            this.btnBuscarProducao.Location = new System.Drawing.Point(573, 86);
            this.btnBuscarProducao.Name = "btnBuscarProducao";
            this.btnBuscarProducao.Size = new System.Drawing.Size(89, 35);
            this.btnBuscarProducao.TabIndex = 49;
            this.btnBuscarProducao.Text = "Buscar";
            this.btnBuscarProducao.UseVisualStyleBackColor = true;
            this.btnBuscarProducao.Click += new System.EventHandler(this.btnBuscarProducao_Click);
            // 
            // lvBuscarProducao
            // 
            this.lvBuscarProducao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Produto,
            this.Quantidade,
            this.DataProducao,
            this.ResponsavelProducao});
            this.lvBuscarProducao.HideSelection = false;
            this.lvBuscarProducao.Location = new System.Drawing.Point(151, 142);
            this.lvBuscarProducao.Name = "lvBuscarProducao";
            this.lvBuscarProducao.Size = new System.Drawing.Size(510, 335);
            this.lvBuscarProducao.TabIndex = 50;
            this.lvBuscarProducao.UseCompatibleStateImageBehavior = false;
            this.lvBuscarProducao.View = System.Windows.Forms.View.Details;
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
            // btnCadastrarNovaProducao
            // 
            this.btnCadastrarNovaProducao.Location = new System.Drawing.Point(335, 484);
            this.btnCadastrarNovaProducao.Name = "btnCadastrarNovaProducao";
            this.btnCadastrarNovaProducao.Size = new System.Drawing.Size(91, 38);
            this.btnCadastrarNovaProducao.TabIndex = 51;
            this.btnCadastrarNovaProducao.Text = "Cadastrar Nova Produção";
            this.btnCadastrarNovaProducao.UseVisualStyleBackColor = true;
            this.btnCadastrarNovaProducao.Click += new System.EventHandler(this.btnCadastrarNovaProducao_Click);
            // 
            // btnEditarProducao
            // 
            this.btnEditarProducao.Location = new System.Drawing.Point(453, 484);
            this.btnEditarProducao.Name = "btnEditarProducao";
            this.btnEditarProducao.Size = new System.Drawing.Size(91, 38);
            this.btnEditarProducao.TabIndex = 52;
            this.btnEditarProducao.Text = "Editar uma Produção";
            this.btnEditarProducao.UseVisualStyleBackColor = true;
            this.btnEditarProducao.Click += new System.EventHandler(this.btnEditarProducao_Click);
            // 
            // btnExcluirProducao
            // 
            this.btnExcluirProducao.Location = new System.Drawing.Point(567, 484);
            this.btnExcluirProducao.Name = "btnExcluirProducao";
            this.btnExcluirProducao.Size = new System.Drawing.Size(91, 38);
            this.btnExcluirProducao.TabIndex = 53;
            this.btnExcluirProducao.Text = "Excluir uma Produção";
            this.btnExcluirProducao.UseVisualStyleBackColor = true;
            this.btnExcluirProducao.Click += new System.EventHandler(this.btnExcluirProducao_Click);
            // 
            // TelaProducao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnExcluirProducao);
            this.Controls.Add(this.btnEditarProducao);
            this.Controls.Add(this.btnCadastrarNovaProducao);
            this.Controls.Add(this.lvBuscarProducao);
            this.Controls.Add(this.btnBuscarProducao);
            this.Controls.Add(this.txtBuscarProducao);
            this.Controls.Add(this.lblBuscarProducao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRetornar);
            this.Controls.Add(this.btnLogout);
            this.Name = "TelaProducao";
            this.Text = "Produções";
            this.Load += new System.EventHandler(this.TelaProducao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRetornar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblBuscarProducao;
        private System.Windows.Forms.TextBox txtBuscarProducao;
        private System.Windows.Forms.Button btnBuscarProducao;
        private System.Windows.Forms.ListView lvBuscarProducao;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Produto;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader DataProducao;
        private System.Windows.Forms.ColumnHeader ResponsavelProducao;
        private System.Windows.Forms.Button btnCadastrarNovaProducao;
        private System.Windows.Forms.Button btnEditarProducao;
        private System.Windows.Forms.Button btnExcluirProducao;
    }
}