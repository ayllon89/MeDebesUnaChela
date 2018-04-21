namespace PagoAgilFrba.Rendicion
{
    partial class Rendicion
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
            this.bVerificarEmpresa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvFacturasRendidas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCantidadFacturas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbImporteMenosComision = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbComision = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbImporte = new System.Windows.Forms.TextBox();
            this.bRendir = new System.Windows.Forms.Button();
            this.bLimpiar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.bIngresarPorc = new System.Windows.Forms.Button();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.dtpFechaRendicion = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasRendidas)).BeginInit();
            this.SuspendLayout();
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(281, 26);
            this.vt_titulo.Text = "Rendición de facturas cobradas";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpFechaRendicion);
            this.panel1.Controls.Add(this.cbEmpresa);
            this.panel1.Controls.Add(this.bIngresarPorc);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.bLimpiar);
            this.panel1.Controls.Add(this.bRendir);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbImporte);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbComision);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbImporteMenosComision);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbCantidadFacturas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvFacturasRendidas);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bVerificarEmpresa);
            this.panel1.Size = new System.Drawing.Size(602, 488);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.bVerificarEmpresa, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.dgvFacturasRendidas, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.tbCantidadFacturas, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.tbImporteMenosComision, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            this.panel1.Controls.SetChildIndex(this.tbComision, 0);
            this.panel1.Controls.SetChildIndex(this.label5, 0);
            this.panel1.Controls.SetChildIndex(this.tbImporte, 0);
            this.panel1.Controls.SetChildIndex(this.label6, 0);
            this.panel1.Controls.SetChildIndex(this.bRendir, 0);
            this.panel1.Controls.SetChildIndex(this.bLimpiar, 0);
            this.panel1.Controls.SetChildIndex(this.label7, 0);
            this.panel1.Controls.SetChildIndex(this.bIngresarPorc, 0);
            this.panel1.Controls.SetChildIndex(this.cbEmpresa, 0);
            this.panel1.Controls.SetChildIndex(this.dtpFechaRendicion, 0);
            // 
            // boton_cerrar
            // 
            this.boton_cerrar.Location = new System.Drawing.Point(541, 447);
            // 
            // boton_atras
            // 
            this.boton_atras.Location = new System.Drawing.Point(20, 447);
            // 
            // bVerificarEmpresa
            // 
            this.bVerificarEmpresa.Location = new System.Drawing.Point(300, 74);
            this.bVerificarEmpresa.Name = "bVerificarEmpresa";
            this.bVerificarEmpresa.Size = new System.Drawing.Size(105, 23);
            this.bVerificarEmpresa.TabIndex = 121;
            this.bVerificarEmpresa.Text = "Verificar empresa";
            this.bVerificarEmpresa.UseVisualStyleBackColor = true;
            this.bVerificarEmpresa.Click += new System.EventHandler(this.bVerificarEmpresa_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(92, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 124;
            this.label1.Text = "Empresa:";
            // 
            // dgvFacturasRendidas
            // 
            this.dgvFacturasRendidas.AllowUserToAddRows = false;
            this.dgvFacturasRendidas.AllowUserToDeleteRows = false;
            this.dgvFacturasRendidas.AllowUserToResizeColumns = false;
            this.dgvFacturasRendidas.AllowUserToResizeRows = false;
            this.dgvFacturasRendidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasRendidas.Location = new System.Drawing.Point(200, 158);
            this.dgvFacturasRendidas.Name = "dgvFacturasRendidas";
            this.dgvFacturasRendidas.ReadOnly = true;
            this.dgvFacturasRendidas.RowHeadersVisible = false;
            this.dgvFacturasRendidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturasRendidas.Size = new System.Drawing.Size(355, 150);
            this.dgvFacturasRendidas.TabIndex = 126;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(34, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 125;
            this.label2.Text = "Conjunto de facturas rendidas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(297, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 129;
            this.label3.Text = "Cantidad de facturas rendidas: ";
            // 
            // tbCantidadFacturas
            // 
            this.tbCantidadFacturas.Location = new System.Drawing.Point(457, 325);
            this.tbCantidadFacturas.Name = "tbCantidadFacturas";
            this.tbCantidadFacturas.ReadOnly = true;
            this.tbCantidadFacturas.Size = new System.Drawing.Size(100, 20);
            this.tbCantidadFacturas.TabIndex = 130;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(349, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 131;
            this.label4.Text = "Importe - Comisión:";
            // 
            // tbImporteMenosComision
            // 
            this.tbImporteMenosComision.Location = new System.Drawing.Point(457, 365);
            this.tbImporteMenosComision.Name = "tbImporteMenosComision";
            this.tbImporteMenosComision.ReadOnly = true;
            this.tbImporteMenosComision.Size = new System.Drawing.Size(100, 20);
            this.tbImporteMenosComision.TabIndex = 132;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(26, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 127;
            this.label5.Text = "Porcentaje de comisión";
            // 
            // tbComision
            // 
            this.tbComision.Enabled = false;
            this.tbComision.Location = new System.Drawing.Point(150, 113);
            this.tbComision.Name = "tbComision";
            this.tbComision.Size = new System.Drawing.Size(120, 20);
            this.tbComision.TabIndex = 128;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(17, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 133;
            this.label6.Text = "Importe Total de la rendición";
            // 
            // tbImporte
            // 
            this.tbImporte.Location = new System.Drawing.Point(165, 365);
            this.tbImporte.Name = "tbImporte";
            this.tbImporte.ReadOnly = true;
            this.tbImporte.Size = new System.Drawing.Size(100, 20);
            this.tbImporte.TabIndex = 134;
            // 
            // bRendir
            // 
            this.bRendir.Location = new System.Drawing.Point(163, 397);
            this.bRendir.Name = "bRendir";
            this.bRendir.Size = new System.Drawing.Size(75, 23);
            this.bRendir.TabIndex = 122;
            this.bRendir.Text = "Rendir";
            this.bRendir.UseVisualStyleBackColor = true;
            this.bRendir.Click += new System.EventHandler(this.bRendir_Click_1);
            // 
            // bLimpiar
            // 
            this.bLimpiar.Location = new System.Drawing.Point(375, 397);
            this.bLimpiar.Name = "bLimpiar";
            this.bLimpiar.Size = new System.Drawing.Size(75, 23);
            this.bLimpiar.TabIndex = 123;
            this.bLimpiar.Text = "Limpiar";
            this.bLimpiar.UseVisualStyleBackColor = true;
            this.bLimpiar.Click += new System.EventHandler(this.bLimpiar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(454, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 135;
            this.label7.Text = "Fecha de rendición:";
            // 
            // bIngresarPorc
            // 
            this.bIngresarPorc.Location = new System.Drawing.Point(300, 111);
            this.bIngresarPorc.Name = "bIngresarPorc";
            this.bIngresarPorc.Size = new System.Drawing.Size(110, 23);
            this.bIngresarPorc.TabIndex = 137;
            this.bIngresarPorc.Text = "Ingresar porcentaje";
            this.bIngresarPorc.UseVisualStyleBackColor = true;
            this.bIngresarPorc.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(150, 76);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(121, 21);
            this.cbEmpresa.TabIndex = 144;
            // 
            // dtpFechaRendicion
            // 
            this.dtpFechaRendicion.Enabled = false;
            this.dtpFechaRendicion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRendicion.Location = new System.Drawing.Point(455, 113);
            this.dtpFechaRendicion.Name = "dtpFechaRendicion";
            this.dtpFechaRendicion.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaRendicion.TabIndex = 145;
            // 
            // Rendicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 683);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Rendicion";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasRendidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bLimpiar;
        private System.Windows.Forms.Button bRendir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbImporte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbComision;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbImporteMenosComision;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCantidadFacturas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFacturasRendidas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bVerificarEmpresa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bIngresarPorc;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.DateTimePicker dtpFechaRendicion;
    }
}