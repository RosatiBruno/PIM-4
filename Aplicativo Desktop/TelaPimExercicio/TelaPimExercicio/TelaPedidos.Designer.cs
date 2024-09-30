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
            this.btnLogout2 = new System.Windows.Forms.Button();
            this.btnRetornar2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogout2
            // 
            this.btnLogout2.Location = new System.Drawing.Point(27, 12);
            this.btnLogout2.Name = "btnLogout2";
            this.btnLogout2.Size = new System.Drawing.Size(71, 48);
            this.btnLogout2.TabIndex = 8;
            this.btnLogout2.Text = "Logout";
            this.btnLogout2.UseVisualStyleBackColor = true;
            this.btnLogout2.Click += new System.EventHandler(this.btnLogout2_Click_1);
            // 
            // btnRetornar2
            // 
            this.btnRetornar2.Location = new System.Drawing.Point(151, 493);
            this.btnRetornar2.Name = "btnRetornar2";
            this.btnRetornar2.Size = new System.Drawing.Size(77, 29);
            this.btnRetornar2.TabIndex = 9;
            this.btnRetornar2.Text = "⬅";
            this.btnRetornar2.UseVisualStyleBackColor = true;
            this.btnRetornar2.Click += new System.EventHandler(this.btnRetornar2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tela de Pedidos";
            // 
            // TelaPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRetornar2);
            this.Controls.Add(this.btnLogout2);
            this.Name = "TelaPedidos";
            this.Text = "TelaPedidos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout2;
        private System.Windows.Forms.Button btnRetornar2;
        private System.Windows.Forms.Label label1;
    }
}