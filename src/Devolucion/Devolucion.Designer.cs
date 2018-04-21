namespace PagoAgilFrba.Devolucion
{
    partial class Devolucion
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
            this.texto_motivo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.texto_factura = new System.Windows.Forms.TextBox();
            this.texto_empresa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 164);
            this.label2.Size = new System.Drawing.Size(123, 18);
            this.label2.Text = "Motivo devolucion";
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
            this.vt_titulo.Size = new System.Drawing.Size(109, 26);
            this.vt_titulo.Text = "Devolucion";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.texto_empresa);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.texto_factura);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.texto_motivo);
            this.panel1.Controls.SetChildIndex(this.texto_motivo, 0);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.boton_limpiar, 0);
            this.panel1.Controls.SetChildIndex(this.boton_guardar, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.checkBox1, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.texto_factura, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            this.panel1.Controls.SetChildIndex(this.texto_empresa, 0);
            // 
            // texto_motivo
            // 
            this.texto_motivo.Location = new System.Drawing.Point(199, 164);
            this.texto_motivo.Multiline = true;
            this.texto_motivo.Name = "texto_motivo";
            this.texto_motivo.Size = new System.Drawing.Size(300, 150);
            this.texto_motivo.TabIndex = 125;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 126;
            this.label3.Text = "Factura nº";
            // 
            // texto_factura
            // 
            this.texto_factura.Location = new System.Drawing.Point(108, 112);
            this.texto_factura.Name = "texto_factura";
            this.texto_factura.ReadOnly = true;
            this.texto_factura.Size = new System.Drawing.Size(100, 20);
            this.texto_factura.TabIndex = 127;
            // 
            // texto_empresa
            // 
            this.texto_empresa.Location = new System.Drawing.Point(345, 110);
            this.texto_empresa.Name = "texto_empresa";
            this.texto_empresa.ReadOnly = true;
            this.texto_empresa.Size = new System.Drawing.Size(100, 20);
            this.texto_empresa.TabIndex = 129;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 18);
            this.label4.TabIndex = 128;
            this.label4.Text = "Empresa cuit";
            // 
            // Devolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Name = "Devolucion";
            this.Text = "Devolucion";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox texto_motivo;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox texto_factura;
        private System.Windows.Forms.TextBox texto_empresa;
        public System.Windows.Forms.Label label4;
    }
}