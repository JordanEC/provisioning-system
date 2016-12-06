namespace ClienteSistemaDeAprovisionamiento
{
    partial class FPrincipalCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menu = new System.Windows.Forms.ToolStripMenuItem();
            this.opcIniciarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.opcCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.opcSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tablaProductos = new System.Windows.Forms.DataGridView();
            this.iDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDetallada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblArticulos = new System.Windows.Forms.Label();
            this.btnActualizarProductos = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.tablaProveedor = new System.Windows.Forms.DataGridView();
            this.nombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnActualizarProveedor = new System.Windows.Forms.Button();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.btnCambiarContrasena = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackgroundImage = global::ClienteSistemaDeAprovisionamiento.Properties.Resources.tekstura_peq;
            this.menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcIniciarSesion,
            this.opcCerrarSesion,
            this.opcSalir});
            this.menu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.ForeColor = System.Drawing.Color.White;
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(55, 21);
            this.menu.Text = "Menú";
            // 
            // opcIniciarSesion
            // 
            this.opcIniciarSesion.BackColor = System.Drawing.Color.White;
            this.opcIniciarSesion.BackgroundImage = global::ClienteSistemaDeAprovisionamiento.Properties.Resources.tekstura_peq;
            this.opcIniciarSesion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcIniciarSesion.ForeColor = System.Drawing.Color.White;
            this.opcIniciarSesion.Name = "opcIniciarSesion";
            this.opcIniciarSesion.Size = new System.Drawing.Size(157, 22);
            this.opcIniciarSesion.Text = "Iniciar sesión";
            this.opcIniciarSesion.Click += new System.EventHandler(this.opcIniciarSesion_Click);
            // 
            // opcCerrarSesion
            // 
            this.opcCerrarSesion.BackColor = System.Drawing.Color.White;
            this.opcCerrarSesion.BackgroundImage = global::ClienteSistemaDeAprovisionamiento.Properties.Resources.tekstura_peq;
            this.opcCerrarSesion.Enabled = false;
            this.opcCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.opcCerrarSesion.Name = "opcCerrarSesion";
            this.opcCerrarSesion.Size = new System.Drawing.Size(157, 22);
            this.opcCerrarSesion.Text = "Cerrar sesión";
            this.opcCerrarSesion.Click += new System.EventHandler(this.opcCerrarSesion_Click);
            // 
            // opcSalir
            // 
            this.opcSalir.BackColor = System.Drawing.Color.White;
            this.opcSalir.BackgroundImage = global::ClienteSistemaDeAprovisionamiento.Properties.Resources.tekstura_peq;
            this.opcSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcSalir.ForeColor = System.Drawing.Color.White;
            this.opcSalir.Name = "opcSalir";
            this.opcSalir.Size = new System.Drawing.Size(157, 22);
            this.opcSalir.Text = "Salir";
            this.opcSalir.Click += new System.EventHandler(this.opcSalir_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tablaProductos
            // 
            this.tablaProductos.AllowUserToAddRows = false;
            this.tablaProductos.AllowUserToDeleteRows = false;
            this.tablaProductos.AllowUserToOrderColumns = true;
            this.tablaProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaProductos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDProducto,
            this.descripcion,
            this.fabricante,
            this.cantidad,
            this.precio,
            this.descripcionDetallada});
            this.tablaProductos.Location = new System.Drawing.Point(12, 252);
            this.tablaProductos.Name = "tablaProductos";
            this.tablaProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablaProductos.Size = new System.Drawing.Size(760, 199);
            this.tablaProductos.TabIndex = 1;
            this.tablaProductos.Visible = false;
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
            this.descripcion.MaxInputLength = 48;
            this.descripcion.Name = "descripcion";
            // 
            // fabricante
            // 
            this.fabricante.HeaderText = "Fabricante";
            this.fabricante.MaxInputLength = 48;
            this.fabricante.Name = "fabricante";
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MaxInputLength = 6;
            this.cantidad.Name = "cantidad";
            // 
            // precio
            // 
            this.precio.HeaderText = "Precio";
            this.precio.MaxInputLength = 9;
            this.precio.Name = "precio";
            // 
            // descripcionDetallada
            // 
            this.descripcionDetallada.HeaderText = "Descripción detallada";
            this.descripcionDetallada.MaxInputLength = 99;
            this.descripcionDetallada.Name = "descripcionDetallada";
            // 
            // lblArticulos
            // 
            this.lblArticulos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblArticulos.AutoSize = true;
            this.lblArticulos.BackColor = System.Drawing.Color.Transparent;
            this.lblArticulos.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulos.ForeColor = System.Drawing.Color.White;
            this.lblArticulos.Location = new System.Drawing.Point(285, 222);
            this.lblArticulos.Name = "lblArticulos";
            this.lblArticulos.Size = new System.Drawing.Size(229, 27);
            this.lblArticulos.TabIndex = 2;
            this.lblArticulos.Text = "Artículos que provee";
            this.lblArticulos.Visible = false;
            // 
            // btnActualizarProductos
            // 
            this.btnActualizarProductos.BackColor = System.Drawing.Color.White;
            this.btnActualizarProductos.BackgroundImage = global::ClienteSistemaDeAprovisionamiento.Properties.Resources.tekstura_peq;
            this.btnActualizarProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarProductos.ForeColor = System.Drawing.Color.White;
            this.btnActualizarProductos.Location = new System.Drawing.Point(335, 457);
            this.btnActualizarProductos.Name = "btnActualizarProductos";
            this.btnActualizarProductos.Size = new System.Drawing.Size(97, 46);
            this.btnActualizarProductos.TabIndex = 3;
            this.btnActualizarProductos.Text = "Guardar cambios";
            this.btnActualizarProductos.UseVisualStyleBackColor = false;
            this.btnActualizarProductos.Visible = false;
            this.btnActualizarProductos.Click += new System.EventHandler(this.btnActualizarProductos_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackColor = System.Drawing.Color.White;
            this.btnEliminarProducto.BackgroundImage = global::ClienteSistemaDeAprovisionamiento.Properties.Resources.tekstura_peq;
            this.btnEliminarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProducto.ForeColor = System.Drawing.Color.White;
            this.btnEliminarProducto.Location = new System.Drawing.Point(438, 457);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(97, 46);
            this.btnEliminarProducto.TabIndex = 4;
            this.btnEliminarProducto.Text = "Eliminar producto";
            this.btnEliminarProducto.UseVisualStyleBackColor = false;
            this.btnEliminarProducto.Visible = false;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.Color.White;
            this.btnAgregarProducto.BackgroundImage = global::ClienteSistemaDeAprovisionamiento.Properties.Resources.tekstura_peq;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProducto.Location = new System.Drawing.Point(232, 457);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(97, 46);
            this.btnAgregarProducto.TabIndex = 5;
            this.btnAgregarProducto.Text = "Agregar producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Visible = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // tablaProveedor
            // 
            this.tablaProveedor.AllowUserToAddRows = false;
            this.tablaProveedor.AllowUserToDeleteRows = false;
            this.tablaProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaProveedor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.tablaProveedor.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tablaProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreUsuario,
            this.empresa,
            this.correo,
            this.habilitado});
            this.tablaProveedor.GridColor = System.Drawing.Color.Black;
            this.tablaProveedor.Location = new System.Drawing.Point(12, 96);
            this.tablaProveedor.MultiSelect = false;
            this.tablaProveedor.Name = "tablaProveedor";
            this.tablaProveedor.Size = new System.Drawing.Size(760, 43);
            this.tablaProveedor.TabIndex = 6;
            this.tablaProveedor.Visible = false;
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.HeaderText = "Nombre de usuario";
            this.nombreUsuario.MaxInputLength = 48;
            this.nombreUsuario.Name = "nombreUsuario";
            // 
            // empresa
            // 
            this.empresa.HeaderText = "Empresa";
            this.empresa.MaxInputLength = 48;
            this.empresa.Name = "empresa";
            // 
            // correo
            // 
            this.correo.HeaderText = "Correo";
            this.correo.MaxInputLength = 48;
            this.correo.Name = "correo";
            // 
            // habilitado
            // 
            this.habilitado.HeaderText = "Habilitado";
            this.habilitado.Name = "habilitado";
            this.habilitado.ReadOnly = true;
            // 
            // btnActualizarProveedor
            // 
            this.btnActualizarProveedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnActualizarProveedor.BackColor = System.Drawing.Color.White;
            this.btnActualizarProveedor.BackgroundImage = global::ClienteSistemaDeAprovisionamiento.Properties.Resources.tekstura_peq;
            this.btnActualizarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnActualizarProveedor.Location = new System.Drawing.Point(245, 145);
            this.btnActualizarProveedor.Name = "btnActualizarProveedor";
            this.btnActualizarProveedor.Size = new System.Drawing.Size(121, 45);
            this.btnActualizarProveedor.TabIndex = 7;
            this.btnActualizarProveedor.Text = "Actualizar información";
            this.btnActualizarProveedor.UseVisualStyleBackColor = false;
            this.btnActualizarProveedor.Visible = false;
            this.btnActualizarProveedor.Click += new System.EventHandler(this.btnActualizarProveedor_Click);
            // 
            // lblProveedor
            // 
            this.lblProveedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.BackColor = System.Drawing.Color.Transparent;
            this.lblProveedor.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.ForeColor = System.Drawing.Color.White;
            this.lblProveedor.Location = new System.Drawing.Point(285, 50);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(223, 27);
            this.lblProveedor.TabIndex = 8;
            this.lblProveedor.Text = "Datos del proveedor";
            this.lblProveedor.Visible = false;
            // 
            // btnCambiarContrasena
            // 
            this.btnCambiarContrasena.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCambiarContrasena.BackgroundImage = global::ClienteSistemaDeAprovisionamiento.Properties.Resources.tekstura_peq;
            this.btnCambiarContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarContrasena.ForeColor = System.Drawing.Color.White;
            this.btnCambiarContrasena.Location = new System.Drawing.Point(414, 145);
            this.btnCambiarContrasena.Name = "btnCambiarContrasena";
            this.btnCambiarContrasena.Size = new System.Drawing.Size(121, 45);
            this.btnCambiarContrasena.TabIndex = 9;
            this.btnCambiarContrasena.Text = "Cambiar contraseña";
            this.btnCambiarContrasena.UseVisualStyleBackColor = true;
            this.btnCambiarContrasena.Visible = false;
            this.btnCambiarContrasena.Click += new System.EventHandler(this.btnCambiarContrasena_Click);
            // 
            // FPrincipalCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::ClienteSistemaDeAprovisionamiento.Properties.Resources.tekstura;
            this.ClientSize = new System.Drawing.Size(784, 515);
            this.Controls.Add(this.btnCambiarContrasena);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.btnActualizarProveedor);
            this.Controls.Add(this.tablaProveedor);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.btnActualizarProductos);
            this.Controls.Add(this.lblArticulos);
            this.Controls.Add(this.tablaProductos);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "FPrincipalCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FPrincipalCliente_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem menu;
        private System.Windows.Forms.ToolStripMenuItem opcIniciarSesion;
        private System.Windows.Forms.ToolStripMenuItem opcSalir;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView tablaProductos;
        private System.Windows.Forms.Label lblArticulos;
        private System.Windows.Forms.ToolStripMenuItem opcCerrarSesion;
        private System.Windows.Forms.Button btnActualizarProductos;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.DataGridView tablaProveedor;
        private System.Windows.Forms.Button btnActualizarProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn habilitado;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Button btnCambiarContrasena;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDetallada;

    }
}

