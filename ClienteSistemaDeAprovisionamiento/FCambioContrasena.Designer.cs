namespace ClienteSistemaDeAprovisionamiento
{
    partial class FCambioContrasena
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
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblNuevaContrasena = new System.Windows.Forms.Label();
            this.txtNuevaContrasena = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(44, 108);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(139, 24);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblNuevaContrasena
            // 
            this.lblNuevaContrasena.AutoSize = true;
            this.lblNuevaContrasena.Location = new System.Drawing.Point(41, 38);
            this.lblNuevaContrasena.Name = "lblNuevaContrasena";
            this.lblNuevaContrasena.Size = new System.Drawing.Size(142, 13);
            this.lblNuevaContrasena.TabIndex = 1;
            this.lblNuevaContrasena.Text = "Ingrese la nueva contraseña";
            // 
            // txtNuevaContrasena
            // 
            this.txtNuevaContrasena.Location = new System.Drawing.Point(44, 68);
            this.txtNuevaContrasena.MaxLength = 20;
            this.txtNuevaContrasena.Name = "txtNuevaContrasena";
            this.txtNuevaContrasena.PasswordChar = '•';
            this.txtNuevaContrasena.Size = new System.Drawing.Size(139, 20);
            this.txtNuevaContrasena.TabIndex = 2;
            this.txtNuevaContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNuevaContrasena_KeyPress);
            // 
            // FCambioContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 175);
            this.Controls.Add(this.txtNuevaContrasena);
            this.Controls.Add(this.lblNuevaContrasena);
            this.Controls.Add(this.btnConfirmar);
            this.MaximumSize = new System.Drawing.Size(248, 213);
            this.MinimumSize = new System.Drawing.Size(248, 213);
            this.Name = "FCambioContrasena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambiar contraseña";
            this.Load += new System.EventHandler(this.FCambioContrasena_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblNuevaContrasena;
        private System.Windows.Forms.TextBox txtNuevaContrasena;
    }
}