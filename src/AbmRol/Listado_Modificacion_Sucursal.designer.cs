namespace PagoAgilFrba.AbmSucursal
{
    partial class Listado_Modificacion_Sucursal
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
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.textBox_direccion = new System.Windows.Forms.TextBox();
            this.textBox_codigo_postal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.Text = "Codigo Postal:";
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.Text = "Direccion:";
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.Text = "Nombre:";
            // 
            // boton_buscar
            // 
            this.boton_buscar.Click += new System.EventHandler(this.boton_buscar_Click);
            // 
            // boton_limpiar
            // 
            this.boton_limpiar.Click += new System.EventHandler(this.boton_limpiar_Click);
            // 
            // boton_seleccion
            // 
            this.boton_seleccion.Click += new System.EventHandler(this.boton_seleccion_Click);
            // 
            // boton_seleccionar
            // 
            this.boton_seleccionar.Visible = false;
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(246, 26);
            this.vt_titulo.Text = "MODIFICACION SUCURSAL";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_codigo_postal);
            this.panel1.Controls.Add(this.textBox_direccion);
            this.panel1.Controls.Add(this.textBox_nombre);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.boton_seleccion, 0);
            this.panel1.Controls.SetChildIndex(this.boton_limpiar, 0);
            this.panel1.Controls.SetChildIndex(this.boton_buscar, 0);
            this.panel1.Controls.SetChildIndex(this.label5, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            this.panel1.Controls.SetChildIndex(this.boton_seleccionar, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_nombre, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_direccion, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_codigo_postal, 0);
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(127, 98);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(100, 20);
            this.textBox_nombre.TabIndex = 134;
            // 
            // textBox_direccion
            // 
            this.textBox_direccion.Location = new System.Drawing.Point(127, 147);
            this.textBox_direccion.Name = "textBox_direccion";
            this.textBox_direccion.Size = new System.Drawing.Size(100, 20);
            this.textBox_direccion.TabIndex = 135;
            // 
            // textBox_codigo_postal
            // 
            this.textBox_codigo_postal.Location = new System.Drawing.Point(438, 98);
            this.textBox_codigo_postal.Name = "textBox_codigo_postal";
            this.textBox_codigo_postal.Size = new System.Drawing.Size(100, 20);
            this.textBox_codigo_postal.TabIndex = 136;
            // 
            // Listado_Modificacion_Sucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Name = "Listado_Modificacion_Sucursal";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_codigo_postal;
        private System.Windows.Forms.TextBox textBox_direccion;
        private System.Windows.Forms.TextBox textBox_nombre;
    }
}