namespace TelaPimExercicio
{
    partial class ConfirmacaoLogin
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnVerificarEmail = new System.Windows.Forms.Button();
            this.txtVerificarCodigo = new System.Windows.Forms.TextBox();
            this.btnVerificarCodigo = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(235, 258);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(156, 20);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnVerificarEmail
            // 
            this.btnVerificarEmail.Location = new System.Drawing.Point(509, 241);
            this.btnVerificarEmail.Name = "btnVerificarEmail";
            this.btnVerificarEmail.Size = new System.Drawing.Size(107, 53);
            this.btnVerificarEmail.TabIndex = 2;
            this.btnVerificarEmail.Text = "Enviar Código";
            this.btnVerificarEmail.UseVisualStyleBackColor = true;
            this.btnVerificarEmail.Click += new System.EventHandler(this.btnVerificarEmail_Click);
            // 
            // txtVerificarCodigo
            // 
            this.txtVerificarCodigo.Location = new System.Drawing.Point(235, 395);
            this.txtVerificarCodigo.Name = "txtVerificarCodigo";
            this.txtVerificarCodigo.Size = new System.Drawing.Size(156, 20);
            this.txtVerificarCodigo.TabIndex = 3;
            // 
            // btnVerificarCodigo
            // 
            this.btnVerificarCodigo.Location = new System.Drawing.Point(509, 378);
            this.btnVerificarCodigo.Name = "btnVerificarCodigo";
            this.btnVerificarCodigo.Size = new System.Drawing.Size(107, 53);
            this.btnVerificarCodigo.TabIndex = 4;
            this.btnVerificarCodigo.Text = "Verificar Código";
            this.btnVerificarCodigo.UseVisualStyleBackColor = true;
            this.btnVerificarCodigo.Click += new System.EventHandler(this.btnVerificarCodigo_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(183, 221);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(266, 13);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "Informe seu email para receber o código de verificação";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Informe o código informado em seu email para realizar o login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Confirmação de Login";
            // 
            // ConfirmacaoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnVerificarCodigo);
            this.Controls.Add(this.txtVerificarCodigo);
            this.Controls.Add(this.btnVerificarEmail);
            this.Controls.Add(this.txtEmail);
            this.Name = "ConfirmacaoLogin";
            this.Text = "Confirmação de Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnVerificarEmail;
        private System.Windows.Forms.TextBox txtVerificarCodigo;
        private System.Windows.Forms.Button btnVerificarCodigo;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}