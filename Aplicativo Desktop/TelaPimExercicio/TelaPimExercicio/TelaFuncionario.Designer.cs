namespace TelaPimExercicio
{
    partial class TelaFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaFuncionario));
            this.btnLogout = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnRetornar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarFuncionario = new System.Windows.Forms.Button();
            this.txtBuscarFuncionario = new System.Windows.Forms.TextBox();
            this.lblBuscarFuncionario = new System.Windows.Forms.Label();
            this.lvBuscarFuncionario = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Senha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCadastrarNovoFuncionario = new System.Windows.Forms.Button();
            this.btnExcluirFuncionario = new System.Windows.Forms.Button();
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
            this.btnRetornar.TabIndex = 10;
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
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Funcionários Cadastrados";
            // 
            // btnBuscarFuncionario
            // 
            this.btnBuscarFuncionario.Location = new System.Drawing.Point(573, 86);
            this.btnBuscarFuncionario.Name = "btnBuscarFuncionario";
            this.btnBuscarFuncionario.Size = new System.Drawing.Size(89, 35);
            this.btnBuscarFuncionario.TabIndex = 52;
            this.btnBuscarFuncionario.Text = "Buscar";
            this.btnBuscarFuncionario.UseVisualStyleBackColor = true;
            this.btnBuscarFuncionario.Click += new System.EventHandler(this.btnBuscarFuncionario_Click);
            // 
            // txtBuscarFuncionario
            // 
            this.txtBuscarFuncionario.Location = new System.Drawing.Point(151, 101);
            this.txtBuscarFuncionario.Name = "txtBuscarFuncionario";
            this.txtBuscarFuncionario.Size = new System.Drawing.Size(312, 20);
            this.txtBuscarFuncionario.TabIndex = 51;
            // 
            // lblBuscarFuncionario
            // 
            this.lblBuscarFuncionario.AutoSize = true;
            this.lblBuscarFuncionario.Location = new System.Drawing.Point(148, 74);
            this.lblBuscarFuncionario.Name = "lblBuscarFuncionario";
            this.lblBuscarFuncionario.Size = new System.Drawing.Size(236, 13);
            this.lblBuscarFuncionario.TabIndex = 50;
            this.lblBuscarFuncionario.Text = "Digite o ID do Funcionário que Deseja Encontrar";
            // 
            // lvBuscarFuncionario
            // 
            this.lvBuscarFuncionario.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Nome,
            this.Email,
            this.Senha});
            this.lvBuscarFuncionario.HideSelection = false;
            this.lvBuscarFuncionario.Location = new System.Drawing.Point(151, 142);
            this.lvBuscarFuncionario.Name = "lvBuscarFuncionario";
            this.lvBuscarFuncionario.Size = new System.Drawing.Size(510, 335);
            this.lvBuscarFuncionario.TabIndex = 53;
            this.lvBuscarFuncionario.UseCompatibleStateImageBehavior = false;
            this.lvBuscarFuncionario.View = System.Windows.Forms.View.Details;
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
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 150;
            // 
            // Senha
            // 
            this.Senha.Text = "Senha";
            this.Senha.Width = 150;
            // 
            // btnCadastrarNovoFuncionario
            // 
            this.btnCadastrarNovoFuncionario.Location = new System.Drawing.Point(453, 484);
            this.btnCadastrarNovoFuncionario.Name = "btnCadastrarNovoFuncionario";
            this.btnCadastrarNovoFuncionario.Size = new System.Drawing.Size(91, 38);
            this.btnCadastrarNovoFuncionario.TabIndex = 54;
            this.btnCadastrarNovoFuncionario.Text = "Cadastrar Novo Funcionário";
            this.btnCadastrarNovoFuncionario.UseVisualStyleBackColor = true;
            this.btnCadastrarNovoFuncionario.Click += new System.EventHandler(this.btnCadastrarNovoFuncionario_Click);
            // 
            // btnExcluirFuncionario
            // 
            this.btnExcluirFuncionario.Location = new System.Drawing.Point(567, 484);
            this.btnExcluirFuncionario.Name = "btnExcluirFuncionario";
            this.btnExcluirFuncionario.Size = new System.Drawing.Size(91, 38);
            this.btnExcluirFuncionario.TabIndex = 55;
            this.btnExcluirFuncionario.Text = "Excluir um Funcionário";
            this.btnExcluirFuncionario.UseVisualStyleBackColor = true;
            this.btnExcluirFuncionario.Click += new System.EventHandler(this.btnExcluirFuncionario_Click);
            // 
            // TelaFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnExcluirFuncionario);
            this.Controls.Add(this.btnCadastrarNovoFuncionario);
            this.Controls.Add(this.lvBuscarFuncionario);
            this.Controls.Add(this.btnBuscarFuncionario);
            this.Controls.Add(this.txtBuscarFuncionario);
            this.Controls.Add(this.lblBuscarFuncionario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRetornar);
            this.Controls.Add(this.btnLogout);
            this.Name = "TelaFuncionario";
            this.Text = "Funcionários Cadastrados";
            this.Load += new System.EventHandler(this.TelaFuncionario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRetornar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnBuscarFuncionario;
        private System.Windows.Forms.TextBox txtBuscarFuncionario;
        private System.Windows.Forms.Label lblBuscarFuncionario;
        private System.Windows.Forms.ListView lvBuscarFuncionario;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.Button btnCadastrarNovoFuncionario;
        private System.Windows.Forms.Button btnExcluirFuncionario;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Senha;
    }
}