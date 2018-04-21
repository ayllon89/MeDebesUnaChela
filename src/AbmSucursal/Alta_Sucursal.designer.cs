namespace PagoAgilFrba.AbmSucursal
{
    partial class Alta_Sucursal
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
            this.label_nombre = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.label_direccion = new System.Windows.Forms.Label();
            this.label_codigo_postal = new System.Windows.Forms.Label();
            this.textBox_direccion = new System.Windows.Forms.TextBox();
            this.textBox_codigo_postal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Visible = false;
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
            this.checkBox1.Visible = false;
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(179, 26);
            this.vt_titulo.Text = "ALTA DE SUCURSAL";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_codigo_postal);
            this.panel1.Controls.Add(this.textBox_direccion);
            this.panel1.Controls.Add(this.label_codigo_postal);
            this.panel1.Controls.Add(this.label_direccion);
            this.panel1.Controls.Add(this.textBox_nombre);
            this.panel1.Controls.Add(this.label_nombre);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.boton_limpiar, 0);
            this.panel1.Controls.SetChildIndex(this.boton_guardar, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.checkBox1, 0);
            this.panel1.Controls.SetChildIndex(this.label_nombre, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_nombre, 0);
            this.panel1.Controls.SetChildIndex(this.label_direccion, 0);
            this.panel1.Controls.SetChildIndex(this.label_codigo_postal, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_direccion, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_codigo_postal, 0);
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.Location = new System.Drawing.Point(17, 159);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(47, 13);
            this.label_nombre.TabIndex = 125;
            this.label_nombre.Text = "Nombre:";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(111, 156);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(100, 20);
            this.textBox_nombre.TabIndex = 126;
            // 
            // label_direccion
            // 
            this.label_direccion.AutoSize = true;
            this.label_direccion.Location = new System.Drawing.Point(17, 195);
            this.label_direccion.Name = "label_direccion";
            this.label_direccion.Size = new System.Drawing.Size(55, 13);
            this.label_direccion.TabIndex = 127;
            this.label_direccion.Text = "Direccion:";
            // 
            // label_codigo_postal
            // 
            this.label_codigo_postal.AutoSize = true;
            this.label_codigo_postal.Location = new System.Drawing.Point(17, 232);
            this.label_codigo_postal.Name = "label_codigo_postal";
            this.label_codigo_postal.Size = new System.Drawing.Size(75, 13);
            this.label_codigo_postal.TabIndex = 128;
            this.label_codigo_postal.Text = "Codigo Postal:";
            // 
            // textBox_direccion
            // 
            this.textBox_direccion.Location = new System.Drawing.Point(111, 192);
            this.textBox_direccion.Name = "textBox_direccion";
            this.textBox_direccion.Size = new System.Drawing.Size(100, 20);
            this.textBox_direccion.TabIndex = 129;
            // 
            // textBox_codigo_postal
            // 
            this.textBox_codigo_postal.Location = new System.Drawing.Point(111, 229);
            this.textBox_codigo_postal.Name = "textBox_codigo_postal";
            this.textBox_codigo_postal.Size = new System.Drawing.Size(100, 20);
            this.textBox_codigo_postal.TabIndex = 130;
            // 
            // Alta_Sucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Name = "Alta_Sucursal";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.TextBox textBox_codigo_postal;
        private System.Windows.Forms.TextBox textBox_direccion;
        private System.Windows.Forms.Label label_codigo_postal;
        private System.Windows.Forms.Label label_direccion;
    }
}