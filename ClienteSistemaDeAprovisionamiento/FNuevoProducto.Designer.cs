namespace ClienteSistemaDeAprovisionamiento
{
    partial class FNuevoProducto
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblDescripcionDetallada = new System.Windows.Forms.Label();
            this.txtDescripcionDetallada = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numericUpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblCombo1 = new System.Windows.Forms.Label();
            this.cmbDescripcion = new System.Windows.Forms.ComboBox();
            this.lblNuevoProd = new System.Windows.Forms.Label();
            this.lblDescripcionCombo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(15, 144);
            this.txtDescripcion.MaxLength = 48;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(237, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 128);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(12, 177);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(57, 13);
            this.lblFabricante.TabIndex = 3;
            this.lblFabricante.Text = "Fabricante";
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(15, 193);
            this.txtFabricante.MaxLength = 48;
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(237, 20);
            this.txtFabricante.TabIndex = 2;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(12, 274);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 5;
            this.lblPrecio.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(15, 290);
            this.txtPrecio.MaxLength = 8;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(125, 20);
            this.txtPrecio.TabIndex = 4;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            this.txtPrecio.Leave += new System.EventHandler(this.txtPrecio_Leave);
            // 
            // lblDescripcionDetallada
            // 
            this.lblDescripcionDetallada.AutoSize = true;
            this.lblDescripcionDetallada.Location = new System.Drawing.Point(12, 323);
            this.lblDescripcionDetallada.Name = "lblDescripcionDetallada";
            this.lblDescripcionDetallada.Size = new System.Drawing.Size(109, 13);
            this.lblDescripcionDetallada.TabIndex = 7;
            this.lblDescripcionDetallada.Text = "Descripción detallada";
            // 
            // txtDescripcionDetallada
            // 
            this.txtDescripcionDetallada.Location = new System.Drawing.Point(15, 339);
            this.txtDescripcionDetallada.MaxLength = 98;
            this.txtDescripcionDetallada.Multiline = true;
            this.txtDescripcionDetallada.Name = "txtDescripcionDetallada";
            this.txtDescripcionDetallada.Size = new System.Drawing.Size(237, 74);
            this.txtDescripcionDetallada.TabIndex = 6;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(12, 226);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 9;
            this.lblCantidad.Text = "Cantidad";
            // 
            // numericUpDownCantidad
            // 
            this.numericUpDownCantidad.Location = new System.Drawing.Point(15, 242);
            this.numericUpDownCantidad.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownCantidad.Name = "numericUpDownCantidad";
            this.numericUpDownCantidad.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownCantidad.TabIndex = 10;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(81, 430);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(104, 28);
            this.btnConfirmar.TabIndex = 11;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblCombo1
            // 
            this.lblCombo1.AutoSize = true;
            this.lblCombo1.Location = new System.Drawing.Point(56, 17);
            this.lblCombo1.Name = "lblCombo1";
            this.lblCombo1.Size = new System.Drawing.Size(138, 13);
            this.lblCombo1.TabIndex = 12;
            this.lblCombo1.Text = "Elegir un producto existente";
            // 
            // cmbDescripcion
            // 
            this.cmbDescripcion.FormattingEnabled = true;
            this.cmbDescripcion.Location = new System.Drawing.Point(15, 62);
            this.cmbDescripcion.Name = "cmbDescripcion";
            this.cmbDescripcion.Size = new System.Drawing.Size(170, 21);
            this.cmbDescripcion.TabIndex = 13;
            // 
            // lblNuevoProd
            // 
            this.lblNuevoProd.AutoSize = true;
            this.lblNuevoProd.Location = new System.Drawing.Point(56, 106);
            this.lblNuevoProd.Name = "lblNuevoProd";
            this.lblNuevoProd.Size = new System.Drawing.Size(138, 13);
            this.lblNuevoProd.TabIndex = 14;
            this.lblNuevoProd.Text = "Ingresar un nuevo producto";
            // 
            // lblDescripcionCombo
            // 
            this.lblDescripcionCombo.AutoSize = true;
            this.lblDescripcionCombo.Location = new System.Drawing.Point(14, 46);
            this.lblDescripcionCombo.Name = "lblDescripcionCombo";
            this.lblDescripcionCombo.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcionCombo.TabIndex = 15;
            this.lblDescripcionCombo.Text = "Descripción";
            // 
            // FNuevoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 514);
            this.Controls.Add(this.lblDescripcionCombo);
            this.Controls.Add(this.lblNuevoProd);
            this.Controls.Add(this.cmbDescripcion);
            this.Controls.Add(this.lblCombo1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.numericUpDownCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblDescripcionDetallada);
            this.Controls.Add(this.txtDescripcionDetallada);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblFabricante);
            this.Controls.Add(this.txtFabricante);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.MaximumSize = new System.Drawing.Size(277, 892);
            this.MinimumSize = new System.Drawing.Size(277, 392);
            this.Name = "FNuevoProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo producto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FNuevoProducto_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.TextBox txtFabricante;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblDescripcionDetallada;
        private System.Windows.Forms.TextBox txtDescripcionDetallada;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numericUpDownCantidad;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblCombo1;
        private System.Windows.Forms.ComboBox cmbDescripcion;
        private System.Windows.Forms.Label lblNuevoProd;
        private System.Windows.Forms.Label lblDescripcionCombo;
    }
}