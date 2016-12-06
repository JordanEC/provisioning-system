namespace ServidorSistemaDeAprovisionamiento
{
    partial class FPrincipalServidor
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPrincipalServidor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu = new System.Windows.Forms.ToolStripMenuItem();
            this.opcVerProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.opcHabilitarNuevasCuentas = new System.Windows.Forms.ToolStripMenuItem();
            this.opcSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaProveedores = new System.Windows.Forms.DataGridView();
            this.iDProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tablaProductosDeProveedor = new System.Windows.Forms.DataGridView();
            this.iDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDetallada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblProveedores = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProductosDeProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(924, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcVerProveedores,
            this.opcHabilitarNuevasCuentas,
            this.opcSalir});
            this.menu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menu.ForeColor = System.Drawing.Color.White;
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(51, 20);
            this.menu.Text = "Menú";
            // 
            // opcVerProveedores
            // 
            this.opcVerProveedores.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opcVerProveedores.BackgroundImage")));
            this.opcVerProveedores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.opcVerProveedores.ForeColor = System.Drawing.Color.White;
            this.opcVerProveedores.Name = "opcVerProveedores";
            this.opcVerProveedores.Size = new System.Drawing.Size(209, 22);
            this.opcVerProveedores.Text = "Ver proveedores";
            this.opcVerProveedores.Click += new System.EventHandler(this.opcVerProveedores_Click);
            // 
            // opcHabilitarNuevasCuentas
            // 
            this.opcHabilitarNuevasCuentas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opcHabilitarNuevasCuentas.BackgroundImage")));
            this.opcHabilitarNuevasCuentas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.opcHabilitarNuevasCuentas.ForeColor = System.Drawing.Color.White;
            this.opcHabilitarNuevasCuentas.Name = "opcHabilitarNuevasCuentas";
            this.opcHabilitarNuevasCuentas.Size = new System.Drawing.Size(209, 22);
            this.opcHabilitarNuevasCuentas.Text = "Habilitar nuevas cuentas";
            this.opcHabilitarNuevasCuentas.Click += new System.EventHandler(this.opcHabilitarNuevasCuentas_Click);
            // 
            // opcSalir
            // 
            this.opcSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opcSalir.BackgroundImage")));
            this.opcSalir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.opcSalir.ForeColor = System.Drawing.Color.White;
            this.opcSalir.Name = "opcSalir";
            this.opcSalir.Size = new System.Drawing.Size(209, 22);
            this.opcSalir.Text = "Salir";
            this.opcSalir.Click += new System.EventHandler(this.opcSalir_Click);
            // 
            // tablaProveedores
            // 
            this.tablaProveedores.AllowUserToAddRows = false;
            this.tablaProveedores.AllowUserToDeleteRows = false;
            this.tablaProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaProveedores.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaProveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDProveedor,
            this.nombreUsuario,
            this.empresa,
            this.correo,
            this.habilitado});
            this.tablaProveedores.Location = new System.Drawing.Point(28, 68);
            this.tablaProveedores.Name = "tablaProveedores";
            this.tablaProveedores.Size = new System.Drawing.Size(861, 152);
            this.tablaProveedores.TabIndex = 1;
            this.tablaProveedores.Visible = false;
            this.tablaProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaProveedores_CellContentClick);
            // 
            // iDProveedor
            // 
            this.iDProveedor.HeaderText = "ID proveedor";
            this.iDProveedor.Name = "iDProveedor";
            this.iDProveedor.ReadOnly = true;
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.HeaderText = "Nombre de usuario";
            this.nombreUsuario.Name = "nombreUsuario";
            // 
            // empresa
            // 
            this.empresa.HeaderText = "Empresa";
            this.empresa.Name = "empresa";
            // 
            // correo
            // 
            this.correo.HeaderText = "Correo";
            this.correo.Name = "correo";
            // 
            // habilitado
            // 
            this.habilitado.HeaderText = "Habilitado";
            this.habilitado.Name = "habilitado";
            // 
            // tablaProductosDeProveedor
            // 
            this.tablaProductosDeProveedor.AllowUserToAddRows = false;
            this.tablaProductosDeProveedor.AllowUserToDeleteRows = false;
            this.tablaProductosDeProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaProductosDeProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaProductosDeProveedor.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaProductosDeProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tablaProductosDeProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaProductosDeProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDProducto,
            this.descripcion,
            this.fabricante,
            this.cantidad,
            this.precio,
            this.descripcionDetallada});
            this.tablaProductosDeProveedor.Location = new System.Drawing.Point(28, 308);
            this.tablaProductosDeProveedor.Name = "tablaProductosDeProveedor";
            this.tablaProductosDeProveedor.Size = new System.Drawing.Size(861, 153);
            this.tablaProductosDeProveedor.TabIndex = 2;
            this.tablaProductosDeProveedor.Visible = false;
            // 
            // iDProducto
            // 
            this.iDProducto.HeaderText = "Número de identificación";
            this.iDProducto.Name = "iDProducto";
            this.iDProducto.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // fabricante
            // 
            this.fabricante.HeaderText = "Fabricante";
            this.fabricante.Name = "fabricante";
            this.fabricante.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            // 
            // descripcionDetallada
            // 
            this.descripcionDetallada.HeaderText = "Descripción detallada";
            this.descripcionDetallada.Name = "descripcionDetallada";
            this.descripcionDetallada.ReadOnly = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnGuardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.BackgroundImage")));
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(314, 226);
            this.btnGuardar.MaximumSize = new System.Drawing.Size(150, 50);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(127, 30);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(496, 226);
            this.btnEliminar.MaximumSize = new System.Drawing.Size(150, 50);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(127, 30);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar cuenta";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblProveedores
            // 
            this.lblProveedores.AutoSize = true;
            this.lblProveedores.BackColor = System.Drawing.Color.Transparent;
            this.lblProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedores.ForeColor = System.Drawing.Color.White;
            this.lblProveedores.Location = new System.Drawing.Point(24, 41);
            this.lblProveedores.Name = "lblProveedores";
            this.lblProveedores.Size = new System.Drawing.Size(215, 20);
            this.lblProveedores.TabIndex = 5;
            this.lblProveedores.Text = "Proveedores registrados";
            this.lblProveedores.Visible = false;
            // 
            // lblProductos
            // 
            this.lblProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProductos.AutoSize = true;
            this.lblProductos.BackColor = System.Drawing.Color.Transparent;
            this.lblProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.ForeColor = System.Drawing.Color.White;
            this.lblProductos.Location = new System.Drawing.Point(24, 276);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(214, 20);
            this.lblProductos.TabIndex = 6;
            this.lblProductos.Text = "Productos del proveedor";
            this.lblProductos.Visible = false;
            // 
            // FPrincipalServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(924, 473);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.lblProveedores);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tablaProductosDeProveedor);
            this.Controls.Add(this.tablaProveedores);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(931, 500);
            this.Name = "FPrincipalServidor";
            this.Text = "Servidor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FPrincipalServidor_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProductosDeProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu;
        private System.Windows.Forms.ToolStripMenuItem opcVerProveedores;
        private System.Windows.Forms.ToolStripMenuItem opcHabilitarNuevasCuentas;
        private System.Windows.Forms.ToolStripMenuItem opcSalir;
        private System.Windows.Forms.DataGridView tablaProveedores;
        private System.Windows.Forms.DataGridView tablaProductosDeProveedor;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblProveedores;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn habilitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDetallada;
    }
}

