namespace PagoAgilFrba.AbmRol
{
    partial class Rol_Alta
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
            this.label3 = new System.Windows.Forms.Label();
            this.texto_nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boton_agregar = new System.Windows.Forms.Button();
            this.boton_sacar = new System.Windows.Forms.Button();
            this.listado_funciones = new System.Windows.Forms.DataGridView();
            this.rol_funciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_funciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rol_funciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 146);
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.Text = "Funciones";
            // 
            // boton_guardar
            // 
            this.boton_guardar.Click += new System.EventHandler(this.boton_guardar_Click);
            // 
            // boton_limpiar
            // 
            this.boton_limpiar.Click += new System.EventHandler(this.boton_limpiar_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(199, 360);
            this.checkBox1.Visible = false;
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(77, 26);
            this.vt_titulo.Text = "Rol alta";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rol_funciones);
            this.panel1.Controls.Add(this.listado_funciones);
            this.panel1.Controls.Add(this.boton_sacar);
            this.panel1.Controls.Add(this.boton_agregar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.texto_nombre);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.checkBox1, 0);
            this.panel1.Controls.SetChildIndex(this.boton_limpiar, 0);
            this.panel1.Controls.SetChildIndex(this.boton_guardar, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.texto_nombre, 0);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            this.panel1.Controls.SetChildIndex(this.boton_agregar, 0);
            this.panel1.Controls.SetChildIndex(this.boton_sacar, 0);
            this.panel1.Controls.SetChildIndex(this.listado_funciones, 0);
            this.panel1.Controls.SetChildIndex(this.rol_funciones, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 124;
            this.label3.Text = "Nombre";
            // 
            // texto_nombre
            // 
            this.texto_nombre.Location = new System.Drawing.Point(98, 106);
            this.texto_nombre.Name = "texto_nombre";
            this.texto_nombre.Size = new System.Drawing.Size(121, 20);
            this.texto_nombre.TabIndex = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 18);
            this.label4.TabIndex = 129;
            this.label4.Text = "Nuevas funciones del rol";
            // 
            // boton_agregar
            // 
            this.boton_agregar.Location = new System.Drawing.Point(243, 203);
            this.boton_agregar.Name = "boton_agregar";
            this.boton_agregar.Size = new System.Drawing.Size(75, 23);
            this.boton_agregar.TabIndex = 130;
            this.boton_agregar.Text = "Agregar>>";
            this.boton_agregar.UseVisualStyleBackColor = true;
            this.boton_agregar.Click += new System.EventHandler(this.boton_agregar_Click);
            // 
            // boton_sacar
            // 
            this.boton_sacar.Location = new System.Drawing.Point(243, 255);
            this.boton_sacar.Name = "boton_sacar";
            this.boton_sacar.Size = new System.Drawing.Size(75, 23);
            this.boton_sacar.TabIndex = 131;
            this.boton_sacar.Text = "<<Sacar";
            this.boton_sacar.UseVisualStyleBackColor = true;
            this.boton_sacar.Click += new System.EventHandler(this.boton_sacar_Click);
            // 
            // listado_funciones
            // 
            this.listado_funciones.AllowUserToAddRows = false;
            this.listado_funciones.AllowUserToDeleteRows = false;
            this.listado_funciones.AllowUserToResizeColumns = false;
            this.listado_funciones.AllowUserToResizeRows = false;
            this.listado_funciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listado_funciones.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.listado_funciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listado_funciones.ColumnHeadersVisible = false;
            this.listado_funciones.Location = new System.Drawing.Point(19, 183);
            this.listado_funciones.MultiSelect = false;
            this.listado_funciones.Name = "listado_funciones";
            this.listado_funciones.ReadOnly = true;
            this.listado_funciones.RowHeadersVisible = false;
            this.listado_funciones.Size = new System.Drawing.Size(200, 150);
            this.listado_funciones.TabIndex = 143;
            // 
            // rol_funciones
            // 
            this.rol_funciones.AllowUserToAddRows = false;
            this.rol_funciones.AllowUserToDeleteRows = false;
            this.rol_funciones.AllowUserToResizeColumns = false;
            this.rol_funciones.AllowUserToResizeRows = false;
            this.rol_funciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rol_funciones.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.rol_funciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rol_funciones.ColumnHeadersVisible = false;
            this.rol_funciones.Location = new System.Drawing.Point(338, 183);
            this.rol_funciones.MultiSelect = false;
            this.rol_funciones.Name = "rol_funciones";
            this.rol_funciones.ReadOnly = true;
            this.rol_funciones.RowHeadersVisible = false;
            this.rol_funciones.Size = new System.Drawing.Size(200, 150);
            this.rol_funciones.TabIndex = 144;
            // 
            // Rol_Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Name = "Rol_Alta";
            this.Text = "Rol_Alta";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado_funciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rol_funciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox texto_nombre;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button boton_sacar;
        private System.Windows.Forms.Button boton_agregar;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView listado_funciones;
        public System.Windows.Forms.DataGridView rol_funciones;

    }
}