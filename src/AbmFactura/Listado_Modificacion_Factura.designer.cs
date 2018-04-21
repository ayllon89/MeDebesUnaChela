namespace PagoAgilFrba.AbmFactura
{
    partial class Listado_Modificacion_Factura
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
            this.textBox_mail_cliente = new System.Windows.Forms.TextBox();
            this.textBox_cuit_empresa = new System.Windows.Forms.TextBox();
            this.textBox_num_factura = new System.Windows.Forms.TextBox();
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
            this.label3.Size = new System.Drawing.Size(95, 18);
            this.label3.Text = "Nº de Factura:";
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.Text = "Cuit Empresa:";
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.Text = "Mail Cliente:";
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
            this.boton_seleccion.Location = new System.Drawing.Point(466, 343);
            this.boton_seleccion.Click += new System.EventHandler(this.boton_seleccion_Click);
            // 
            // boton_seleccionar
            // 
            this.boton_seleccionar.Visible = false;
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(192, 26);
            this.vt_titulo.Text = "Busqueda de Factura";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_num_factura);
            this.panel1.Controls.Add(this.textBox_cuit_empresa);
            this.panel1.Controls.Add(this.textBox_mail_cliente);
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
            this.panel1.Controls.SetChildIndex(this.textBox_mail_cliente, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_cuit_empresa, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_num_factura, 0);
            // 
            // textBox_mail_cliente
            // 
            this.textBox_mail_cliente.Location = new System.Drawing.Point(150, 98);
            this.textBox_mail_cliente.Name = "textBox_mail_cliente";
            this.textBox_mail_cliente.Size = new System.Drawing.Size(100, 20);
            this.textBox_mail_cliente.TabIndex = 134;
            // 
            // textBox_cuit_empresa
            // 
            this.textBox_cuit_empresa.Location = new System.Drawing.Point(150, 147);
            this.textBox_cuit_empresa.Name = "textBox_cuit_empresa";
            this.textBox_cuit_empresa.Size = new System.Drawing.Size(100, 20);
            this.textBox_cuit_empresa.TabIndex = 135;
            // 
            // textBox_num_factura
            // 
            this.textBox_num_factura.Location = new System.Drawing.Point(438, 98);
            this.textBox_num_factura.Name = "textBox_num_factura";
            this.textBox_num_factura.Size = new System.Drawing.Size(100, 20);
            this.textBox_num_factura.TabIndex = 136;
            // 
            // Listado_Modificacion_Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Name = "Listado_Modificacion_Factura";
            this.Text = "Listado_Modificacion_Factura";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_cuit_empresa;
        private System.Windows.Forms.TextBox textBox_mail_cliente;
        private System.Windows.Forms.TextBox textBox_num_factura;
    }
}