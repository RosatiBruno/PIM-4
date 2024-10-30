namespace TelaPimExercicio
{
    partial class TelaCadastrarFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCadastrarFuncionario));
            this.btnLogout = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnHome = new System.Windows.Forms.Button();
            this.btnRetornar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmarCadastroNovoFuncionario = new System.Windows.Forms.Button();
            this.lblTituloCadastroFuncionario = new System.Windows.Forms.Label();
            this.lblNomeFuncionario = new System.Windows.Forms.Label();
            this.txtNomeFuncionario = new System.Windows.Forms.TextBox();
            this.txtIDFuncionario = new System.Windows.Forms.TextBox();
            this.lblIDFuncionario = new System.Windows.Forms.Label();
            this.txtEmailFuncionario = new System.Windows.Forms.TextBox();
            this.lblEmailFuncionario = new System.Windows.Forms.Label();
            this.lblSenhaFuncionario = new System.Windows.Forms.Label();
            this.txtSenhaFuncionario = new System.Windows.Forms.TextBox();
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
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "home.png");
            this.imageList2.Images.SetKeyName(1, "Logout.png");
            // 
            // btnHome
            // 
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHome.ImageKey = "home.png";
            this.btnHome.ImageList = this.imageList2;
            this.btnHome.Location = new System.Drawing.Point(701, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(71, 59);
            this.btnHome.TabIndex = 53;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnRetornar
            // 
            this.btnRetornar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetornar.ImageKey = "SetinhaVoltar2.png";
            this.btnRetornar.ImageList = this.imageList1;
            this.btnRetornar.Location = new System.Drawing.Point(151, 493);
            this.btnRetornar.Name = "btnRetornar";
            this.btnRetornar.Size = new System.Drawing.Size(77, 29);
            this.btnRetornar.TabIndex = 54;
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
            // btnConfirmarCadastroNovoFuncionario
            // 
            this.btnConfirmarCadastroNovoFuncionario.Location = new System.Drawing.Point(611, 488);
            this.btnConfirmarCadastroNovoFuncionario.Name = "btnConfirmarCadastroNovoFuncionario";
            this.btnConfirmarCadastroNovoFuncionario.Size = new System.Drawing.Size(91, 38);
            this.btnConfirmarCadastroNovoFuncionario.TabIndex = 66;
            this.btnConfirmarCadastroNovoFuncionario.Text = "Cadastrar";
            this.btnConfirmarCadastroNovoFuncionario.UseVisualStyleBackColor = true;
            this.btnConfirmarCadastroNovoFuncionario.Click += new System.EventHandler(this.btnConfirmarCadastroNovoFuncionario_Click);
            // 
            // lblTituloCadastroFuncionario
            // 
            this.lblTituloCadastroFuncionario.AutoSize = true;
            this.lblTituloCadastroFuncionario.Location = new System.Drawing.Point(330, 25);
            this.lblTituloCadastroFuncionario.Name = "lblTituloCadastroFuncionario";
            this.lblTituloCadastroFuncionario.Size = new System.Drawing.Size(122, 13);
            this.lblTituloCadastroFuncionario.TabIndex = 67;
            this.lblTituloCadastroFuncionario.Text = "Cadastro de Funcionário";
            // 
            // lblNomeFuncionario
            // 
            this.lblNomeFuncionario.AutoSize = true;
            this.lblNomeFuncionario.Location = new System.Drawing.Point(330, 101);
            this.lblNomeFuncionario.Name = "lblNomeFuncionario";
            this.lblNomeFuncionario.Size = new System.Drawing.Size(108, 13);
            this.lblNomeFuncionario.TabIndex = 68;
            this.lblNomeFuncionario.Text = "Nome do Funcionário";
            // 
            // txtNomeFuncionario
            // 
            this.txtNomeFuncionario.Location = new System.Drawing.Point(333, 117);
            this.txtNomeFuncionario.Name = "txtNomeFuncionario";
            this.txtNomeFuncionario.Size = new System.Drawing.Size(159, 20);
            this.txtNomeFuncionario.TabIndex = 69;
            // 
            // txtIDFuncionario
            // 
            this.txtIDFuncionario.Location = new System.Drawing.Point(333, 181);
            this.txtIDFuncionario.Name = "txtIDFuncionario";
            this.txtIDFuncionario.Size = new System.Drawing.Size(159, 20);
            this.txtIDFuncionario.TabIndex = 71;
            // 
            // lblIDFuncionario
            // 
            this.lblIDFuncionario.AutoSize = true;
            this.lblIDFuncionario.Location = new System.Drawing.Point(330, 165);
            this.lblIDFuncionario.Name = "lblIDFuncionario";
            this.lblIDFuncionario.Size = new System.Drawing.Size(91, 13);
            this.lblIDFuncionario.TabIndex = 70;
            this.lblIDFuncionario.Text = "ID do Funcionário";
            // 
            // txtEmailFuncionario
            // 
            this.txtEmailFuncionario.Location = new System.Drawing.Point(333, 245);
            this.txtEmailFuncionario.Name = "txtEmailFuncionario";
            this.txtEmailFuncionario.Size = new System.Drawing.Size(159, 20);
            this.txtEmailFuncionario.TabIndex = 73;
            // 
            // lblEmailFuncionario
            // 
            this.lblEmailFuncionario.AutoSize = true;
            this.lblEmailFuncionario.Location = new System.Drawing.Point(330, 229);
            this.lblEmailFuncionario.Name = "lblEmailFuncionario";
            this.lblEmailFuncionario.Size = new System.Drawing.Size(32, 13);
            this.lblEmailFuncionario.TabIndex = 72;
            this.lblEmailFuncionario.Text = "Email";
            // 
            // lblSenhaFuncionario
            // 
            this.lblSenhaFuncionario.AutoSize = true;
            this.lblSenhaFuncionario.Location = new System.Drawing.Point(330, 288);
            this.lblSenhaFuncionario.Name = "lblSenhaFuncionario";
            this.lblSenhaFuncionario.Size = new System.Drawing.Size(38, 13);
            this.lblSenhaFuncionario.TabIndex = 74;
            this.lblSenhaFuncionario.Text = "Senha";
            // 
            // txtSenhaFuncionario
            // 
            this.txtSenhaFuncionario.Location = new System.Drawing.Point(333, 304);
            this.txtSenhaFuncionario.Name = "txtSenhaFuncionario";
            this.txtSenhaFuncionario.Size = new System.Drawing.Size(159, 20);
            this.txtSenhaFuncionario.TabIndex = 75;
            // 
            // TelaCadastrarFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.txtSenhaFuncionario);
            this.Controls.Add(this.lblSenhaFuncionario);
            this.Controls.Add(this.txtEmailFuncionario);
            this.Controls.Add(this.lblEmailFuncionario);
            this.Controls.Add(this.txtIDFuncionario);
            this.Controls.Add(this.lblIDFuncionario);
            this.Controls.Add(this.txtNomeFuncionario);
            this.Controls.Add(this.lblNomeFuncionario);
            this.Controls.Add(this.lblTituloCadastroFuncionario);
            this.Controls.Add(this.btnConfirmarCadastroNovoFuncionario);
            this.Controls.Add(this.btnRetornar);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnLogout);
            this.Name = "TelaCadastrarFuncionario";
            this.Text = "Cadastrar Funcionário";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnRetornar;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnConfirmarCadastroNovoFuncionario;
        private System.Windows.Forms.Label lblTituloCadastroFuncionario;
        private System.Windows.Forms.Label lblNomeFuncionario;
        private System.Windows.Forms.TextBox txtNomeFuncionario;
        private System.Windows.Forms.TextBox txtIDFuncionario;
        private System.Windows.Forms.Label lblIDFuncionario;
        private System.Windows.Forms.Label lblEmailFuncionario;
        private System.Windows.Forms.Label lblSenhaFuncionario;
        private System.Windows.Forms.TextBox txtSenhaFuncionario;
        private System.Windows.Forms.TextBox txtEmailFuncionario;
    }
}