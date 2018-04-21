namespace PagoAgilFrba.RegistroPago
{
    partial class RegistroPago
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
            this.tbClienteDNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bVerificarCliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSucursal = new System.Windows.Forms.TextBox();
            this.dgvFacAPagar = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNumeroFactura = new System.Windows.Forms.TextBox();
            this.bAgregarFactura = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.bRegistrarPago = new System.Windows.Forms.Button();
            this.bLimpiar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNombreCli = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbApellidoCli = new System.Windows.Forms.TextBox();
            this.bBorrarFact = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbFormaPago = new System.Windows.Forms.ComboBox();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFechaCobro = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacAPagar)).BeginInit();
            this.SuspendLayout();
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(260, 26);
            this.vt_titulo.Text = "Registro de Pago de Facturas";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpFechaCobro);
            this.panel1.Controls.Add(this.cbEmpresa);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbFormaPago);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.bBorrarFact);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tbApellidoCli);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbNombreCli);
            this.panel1.Controls.Add(this.bLimpiar);
            this.panel1.Controls.Add(this.bRegistrarPago);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbTotal);
            this.panel1.Controls.Add(this.bAgregarFactura);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbNumeroFactura);
            this.panel1.Controls.Add(this.dgvFacAPagar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbSucursal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bVerificarCliente);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbClienteDNI);
            this.panel1.Size = new System.Drawing.Size(562, 538);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.tbClienteDNI, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.bVerificarCliente, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.tbSucursal, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.dgvFacAPagar, 0);
            this.panel1.Controls.SetChildIndex(this.tbNumeroFactura, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            this.panel1.Controls.SetChildIndex(this.bAgregarFactura, 0);
            this.panel1.Controls.SetChildIndex(this.tbTotal, 0);
            this.panel1.Controls.SetChildIndex(this.label6, 0);
            this.panel1.Controls.SetChildIndex(this.bRegistrarPago, 0);
            this.panel1.Controls.SetChildIndex(this.bLimpiar, 0);
            this.panel1.Controls.SetChildIndex(this.tbNombreCli, 0);
            this.panel1.Controls.SetChildIndex(this.label7, 0);
            this.panel1.Controls.SetChildIndex(this.tbApellidoCli, 0);
            this.panel1.Controls.SetChildIndex(this.label8, 0);
            this.panel1.Controls.SetChildIndex(this.bBorrarFact, 0);
            this.panel1.Controls.SetChildIndex(this.label5, 0);
            this.panel1.Controls.SetChildIndex(this.cbFormaPago, 0);
            this.panel1.Controls.SetChildIndex(this.label9, 0);
            this.panel1.Controls.SetChildIndex(this.cbEmpresa, 0);
            this.panel1.Controls.SetChildIndex(this.dtpFechaCobro, 0);
            // 
            // boton_cerrar
            // 
            this.boton_cerrar.Location = new System.Drawing.Point(497, 489);
            // 
            // boton_atras
            // 
            this.boton_atras.Location = new System.Drawing.Point(20, 489);
            // 
            // tbClienteDNI
            // 
            this.tbClienteDNI.Location = new System.Drawing.Point(143, 67);
            this.tbClienteDNI.Name = "tbClienteDNI";
            this.tbClienteDNI.Size = new System.Drawing.Size(120, 20);
            this.tbClienteDNI.TabIndex = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(45, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 127;
            this.label1.Text = "DNI de Cliente:";
            // 
            // bVerificarCliente
            // 
            this.bVerificarCliente.Location = new System.Drawing.Point(303, 65);
            this.bVerificarCliente.Name = "bVerificarCliente";
            this.bVerificarCliente.Size = new System.Drawing.Size(105, 23);
            this.bVerificarCliente.TabIndex = 121;
            this.bVerificarCliente.Text = "Verificar Cliente";
            this.bVerificarCliente.UseVisualStyleBackColor = true;
            this.bVerificarCliente.Click += new System.EventHandler(this.bVerificarCliente_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(39, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 128;
            this.label2.Text = "Fecha de cobro:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(307, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 130;
            this.label3.Text = "Sucursal:";
            // 
            // tbSucursal
            // 
            this.tbSucursal.Location = new System.Drawing.Point(377, 138);
            this.tbSucursal.Name = "tbSucursal";
            this.tbSucursal.ReadOnly = true;
            this.tbSucursal.Size = new System.Drawing.Size(120, 20);
            this.tbSucursal.TabIndex = 131;
            // 
            // dgvFacAPagar
            // 
            this.dgvFacAPagar.AllowUserToAddRows = false;
            this.dgvFacAPagar.AllowUserToDeleteRows = false;
            this.dgvFacAPagar.AllowUserToResizeColumns = false;
            this.dgvFacAPagar.AllowUserToResizeRows = false;
            this.dgvFacAPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacAPagar.Location = new System.Drawing.Point(15, 252);
            this.dgvFacAPagar.Name = "dgvFacAPagar";
            this.dgvFacAPagar.RowHeadersVisible = false;
            this.dgvFacAPagar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacAPagar.Size = new System.Drawing.Size(520, 150);
            this.dgvFacAPagar.TabIndex = 134;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(26, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 132;
            this.label4.Text = "Numero de factura:";
            // 
            // tbNumeroFactura
            // 
            this.tbNumeroFactura.Enabled = false;
            this.tbNumeroFactura.Location = new System.Drawing.Point(143, 200);
            this.tbNumeroFactura.Name = "tbNumeroFactura";
            this.tbNumeroFactura.Size = new System.Drawing.Size(120, 20);
            this.tbNumeroFactura.TabIndex = 122;
            // 
            // bAgregarFactura
            // 
            this.bAgregarFactura.Location = new System.Drawing.Point(225, 225);
            this.bAgregarFactura.Name = "bAgregarFactura";
            this.bAgregarFactura.Size = new System.Drawing.Size(105, 23);
            this.bAgregarFactura.TabIndex = 124;
            this.bAgregarFactura.Text = "Agregar Factura";
            this.bAgregarFactura.UseVisualStyleBackColor = true;
            this.bAgregarFactura.Click += new System.EventHandler(this.bAgregarFactura_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(354, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 135;
            this.label6.Text = "Total:";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(423, 411);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(100, 20);
            this.tbTotal.TabIndex = 136;
            // 
            // bRegistrarPago
            // 
            this.bRegistrarPago.Location = new System.Drawing.Point(143, 451);
            this.bRegistrarPago.Name = "bRegistrarPago";
            this.bRegistrarPago.Size = new System.Drawing.Size(105, 23);
            this.bRegistrarPago.TabIndex = 125;
            this.bRegistrarPago.Text = "Registrar pago";
            this.bRegistrarPago.UseVisualStyleBackColor = true;
            this.bRegistrarPago.Click += new System.EventHandler(this.bRegistrarPago_Click);
            // 
            // bLimpiar
            // 
            this.bLimpiar.Location = new System.Drawing.Point(323, 451);
            this.bLimpiar.Name = "bLimpiar";
            this.bLimpiar.Size = new System.Drawing.Size(105, 23);
            this.bLimpiar.TabIndex = 126;
            this.bLimpiar.Text = "Limpiar";
            this.bLimpiar.UseVisualStyleBackColor = true;
            this.bLimpiar.Click += new System.EventHandler(this.bLimpiar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(82, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 137;
            this.label7.Text = "Nombre:";
            // 
            // tbNombreCli
            // 
            this.tbNombreCli.Location = new System.Drawing.Point(143, 102);
            this.tbNombreCli.Name = "tbNombreCli";
            this.tbNombreCli.ReadOnly = true;
            this.tbNombreCli.Size = new System.Drawing.Size(120, 20);
            this.tbNombreCli.TabIndex = 138;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(307, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 139;
            this.label8.Text = "Apellido:";
            // 
            // tbApellidoCli
            // 
            this.tbApellidoCli.Location = new System.Drawing.Point(377, 103);
            this.tbApellidoCli.Name = "tbApellidoCli";
            this.tbApellidoCli.ReadOnly = true;
            this.tbApellidoCli.Size = new System.Drawing.Size(120, 20);
            this.tbApellidoCli.TabIndex = 140;
            // 
            // bBorrarFact
            // 
            this.bBorrarFact.Location = new System.Drawing.Point(48, 411);
            this.bBorrarFact.Name = "bBorrarFact";
            this.bBorrarFact.Size = new System.Drawing.Size(105, 23);
            this.bBorrarFact.TabIndex = 141;
            this.bBorrarFact.Text = "Borrar Factura";
            this.bBorrarFact.UseVisualStyleBackColor = true;
            this.bBorrarFact.Click += new System.EventHandler(this.bBorrarFact_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(48, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 142;
            this.label5.Text = "Forma de pago:";
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaPago.FormattingEnabled = true;
            this.cbFormaPago.Location = new System.Drawing.Point(142, 170);
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.Size = new System.Drawing.Size(121, 21);
            this.cbFormaPago.TabIndex = 143;
            this.cbFormaPago.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(376, 199);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(121, 21);
            this.cbEmpresa.TabIndex = 145;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(303, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 144;
            this.label9.Text = "Empresa:";
            // 
            // dtpFechaCobro
            // 
            this.dtpFechaCobro.Enabled = false;
            this.dtpFechaCobro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCobro.Location = new System.Drawing.Point(142, 137);
            this.dtpFechaCobro.Name = "dtpFechaCobro";
            this.dtpFechaCobro.Size = new System.Drawing.Size(120, 20);
            this.dtpFechaCobro.TabIndex = 146;
            // 
            // RegistroPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 655);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "RegistroPago";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacAPagar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbClienteDNI;
        private System.Windows.Forms.Button bLimpiar;
        private System.Windows.Forms.Button bRegistrarPago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Button bAgregarFactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNumeroFactura;
        private System.Windows.Forms.DataGridView dgvFacAPagar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bVerificarCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbApellidoCli;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbNombreCli;
        private System.Windows.Forms.Button bBorrarFact;
        private System.Windows.Forms.ComboBox cbFormaPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFechaCobro;
    }
}