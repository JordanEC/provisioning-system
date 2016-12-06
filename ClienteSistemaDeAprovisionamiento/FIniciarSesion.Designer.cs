namespace ClienteSistemaDeAprovisionamiento
{
    partial class FIniciarSesion
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblCorreoUsuario = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnCrearCuenta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(15, 35);
            this.txtUsuario.MaxLength = 48;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(202, 20);
            this.txtUsuario.TabIndex = 0;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(15, 102);
            this.txtContrasena.MaxLength = 48;
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '•';
            this.txtContrasena.Size = new System.Drawing.Size(202, 20);
            this.txtContrasena.TabIndex = 1;
            this.txtContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContrasena_KeyPress);
            // 
            // lblCorreoUsuario
            // 
            this.lblCorreoUsuario.AutoSize = true;
            this.lblCorreoUsuario.Location = new System.Drawing.Point(12, 9);
            this.lblCorreoUsuario.Name = "lblCorreoUsuario";
            this.lblCorreoUsuario.Size = new System.Drawing.Size(192, 13);
            this.lblCorreoUsuario.TabIndex = 2;
            this.lblCorreoUsuario.Text = "Correo electrónico o nombre de usuario";
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(12, 75);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(61, 13);
            this.lblContrasena.TabIndex = 3;
            this.lblContrasena.Text = "Contraseña";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(15, 140);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(98, 22);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnCrearCuenta
            // 
            this.btnCrearCuenta.Location = new System.Drawing.Point(119, 140);
            this.btnCrearCuenta.Name = "btnCrearCuenta";
            this.btnCrearCuenta.Size = new System.Drawing.Size(98, 22);
            this.btnCrearCuenta.TabIndex = 5;
            this.btnCrearCuenta.Text = "Crear una cuenta";
            this.btnCrearCuenta.UseVisualStyleBackColor = true;
            this.btnCrearCuenta.Click += new System.EventHandler(this.btnCrearCuenta_Click);
            // 
            // FIniciarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 182);
            this.Controls.Add(this.btnCrearCuenta);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.lblCorreoUsuario);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtUsuario);
            this.MaximumSize = new System.Drawing.Size(250, 220);
            this.MinimumSize = new System.Drawing.Size(250, 220);
            this.Name = "FIniciarSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Iniciar sesión";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblCorreoUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnCrearCuenta;
    }
}