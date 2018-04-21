namespace PagoAgilFrba.AbmFactura
{
    partial class Alta_Factura
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
            this.textBox_mail = new System.Windows.Forms.TextBox();
            this.textBox_num_factura = new System.Windows.Forms.TextBox();
            this.label_mail_cliente = new System.Windows.Forms.Label();
            this.label_empresa_cuit = new System.Windows.Forms.Label();
            this.label_nro_factura = new System.Windows.Forms.Label();
            this.dateTimePicker_fecha_alta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_frcha_venc = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox_empresa = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_total = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label_item_monto = new System.Windows.Forms.Label();
            this.label_item_cant = new System.Windows.Forms.Label();
            this.textBox_monto = new System.Windows.Forms.TextBox();
            this.textBox_cantidad = new System.Windows.Forms.TextBox();
            this.button_agregar = new System.Windows.Forms.Button();
            this.button_quitar = new System.Windows.Forms.Button();
            this.label_descripcion = new System.Windows.Forms.Label();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(439, 61);
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
            this.checkBox1.Location = new System.Drawing.Point(272, 57);
            this.checkBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(220, 19);
            this.label1.Text = "Complete los datos de la factura";
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(142, 26);
            this.vt_titulo.Text = "Alta de Factura";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_descripcion);
            this.panel1.Controls.Add(this.label_descripcion);
            this.panel1.Controls.Add(this.button_quitar);
            this.panel1.Controls.Add(this.button_agregar);
            this.panel1.Controls.Add(this.textBox_cantidad);
            this.panel1.Controls.Add(this.textBox_monto);
            this.panel1.Controls.Add(this.label_item_cant);
            this.panel1.Controls.Add(this.label_item_monto);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox_total);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox_empresa);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePicker_frcha_venc);
            this.panel1.Controls.Add(this.dateTimePicker_fecha_alta);
            this.panel1.Controls.Add(this.label_nro_factura);
            this.panel1.Controls.Add(this.label_empresa_cuit);
            this.panel1.Controls.Add(this.label_mail_cliente);
            this.panel1.Controls.Add(this.textBox_num_factura);
            this.panel1.Controls.Add(this.textBox_mail);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.boton_limpiar, 0);
            this.panel1.Controls.SetChildIndex(this.boton_guardar, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.checkBox1, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_mail, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_num_factura, 0);
            this.panel1.Controls.SetChildIndex(this.label_mail_cliente, 0);
            this.panel1.Controls.SetChildIndex(this.label_empresa_cuit, 0);
            this.panel1.Controls.SetChildIndex(this.label_nro_factura, 0);
            this.panel1.Controls.SetChildIndex(this.dateTimePicker_fecha_alta, 0);
            this.panel1.Controls.SetChildIndex(this.dateTimePicker_frcha_venc, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            this.panel1.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel1.Controls.SetChildIndex(this.comboBox_empresa, 0);
            this.panel1.Controls.SetChildIndex(this.label5, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_total, 0);
            this.panel1.Controls.SetChildIndex(this.label6, 0);
            this.panel1.Controls.SetChildIndex(this.label_item_monto, 0);
            this.panel1.Controls.SetChildIndex(this.label_item_cant, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_monto, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_cantidad, 0);
            this.panel1.Controls.SetChildIndex(this.button_agregar, 0);
            this.panel1.Controls.SetChildIndex(this.button_quitar, 0);
            this.panel1.Controls.SetChildIndex(this.label_descripcion, 0);
            this.panel1.Controls.SetChildIndex(this.textBox_descripcion, 0);
            // 
            // textBox_mail
            // 
            this.textBox_mail.Location = new System.Drawing.Point(150, 102);
            this.textBox_mail.Name = "textBox_mail";
            this.textBox_mail.Size = new System.Drawing.Size(100, 20);
            this.textBox_mail.TabIndex = 125;
            // 
            // textBox_num_factura
            // 
            this.textBox_num_factura.Location = new System.Drawing.Point(150, 154);
            this.textBox_num_factura.Name = "textBox_num_factura";
            this.textBox_num_factura.Size = new System.Drawing.Size(100, 20);
            this.textBox_num_factura.TabIndex = 127;
            // 
            // label_mail_cliente
            // 
            this.label_mail_cliente.AutoSize = true;
            this.label_mail_cliente.Location = new System.Drawing.Point(18, 105);
            this.label_mail_cliente.Name = "label_mail_cliente";
            this.label_mail_cliente.Size = new System.Drawing.Size(64, 13);
            this.label_mail_cliente.TabIndex = 128;
            this.label_mail_cliente.Text = "Mail Cliente:";
            // 
            // label_empresa_cuit
            // 
            this.label_empresa_cuit.AutoSize = true;
            this.label_empresa_cuit.Location = new System.Drawing.Point(18, 131);
            this.label_empresa_cuit.Name = "label_empresa_cuit";
            this.label_empresa_cuit.Size = new System.Drawing.Size(79, 13);
            this.label_empresa_cuit.TabIndex = 129;
            this.label_empresa_cuit.Text = "CUIT Empresa:";
            // 
            // label_nro_factura
            // 
            this.label_nro_factura.AutoSize = true;
            this.label_nro_factura.Location = new System.Drawing.Point(18, 157);
            this.label_nro_factura.Name = "label_nro_factura";
            this.label_nro_factura.Size = new System.Drawing.Size(98, 13);
            this.label_nro_factura.TabIndex = 130;
            this.label_nro_factura.Text = "Numero de factura:";
            // 
            // dateTimePicker_fecha_alta
            // 
            this.dateTimePicker_fecha_alta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_fecha_alta.Location = new System.Drawing.Point(438, 102);
            this.dateTimePicker_fecha_alta.Name = "dateTimePicker_fecha_alta";
            this.dateTimePicker_fecha_alta.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker_fecha_alta.TabIndex = 131;
            // 
            // dateTimePicker_frcha_venc
            // 
            this.dateTimePicker_frcha_venc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_frcha_venc.Location = new System.Drawing.Point(438, 128);
            this.dateTimePicker_frcha_venc.Name = "dateTimePicker_frcha_venc";
            this.dateTimePicker_frcha_venc.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker_frcha_venc.TabIndex = 132;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 133;
            this.label3.Text = "Fecha de alta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "Fecha de venciminiento:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 245);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(355, 105);
            this.dataGridView1.TabIndex = 139;
            // 
            // comboBox_empresa
            // 
            this.comboBox_empresa.FormattingEnabled = true;
            this.comboBox_empresa.Location = new System.Drawing.Point(150, 127);
            this.comboBox_empresa.Name = "comboBox_empresa";
            this.comboBox_empresa.Size = new System.Drawing.Size(100, 21);
            this.comboBox_empresa.TabIndex = 126;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 137;
            this.label5.Text = "Total:";
            // 
            // textBox_total
            // 
            this.textBox_total.Location = new System.Drawing.Point(438, 330);
            this.textBox_total.Name = "textBox_total";
            this.textBox_total.ReadOnly = true;
            this.textBox_total.Size = new System.Drawing.Size(100, 20);
            this.textBox_total.TabIndex = 138;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F);
            this.label6.Location = new System.Drawing.Point(17, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 19);
            this.label6.TabIndex = 139;
            this.label6.Text = "Items";
            // 
            // label_item_monto
            // 
            this.label_item_monto.AutoSize = true;
            this.label_item_monto.Location = new System.Drawing.Point(210, 218);
            this.label_item_monto.Name = "label_item_monto";
            this.label_item_monto.Size = new System.Drawing.Size(40, 13);
            this.label_item_monto.TabIndex = 140;
            this.label_item_monto.Text = "Monto:";
            // 
            // label_item_cant
            // 
            this.label_item_cant.AutoSize = true;
            this.label_item_cant.Location = new System.Drawing.Point(332, 217);
            this.label_item_cant.Name = "label_item_cant";
            this.label_item_cant.Size = new System.Drawing.Size(52, 13);
            this.label_item_cant.TabIndex = 141;
            this.label_item_cant.Text = "Cantidad:";
            // 
            // textBox_monto
            // 
            this.textBox_monto.Location = new System.Drawing.Point(252, 214);
            this.textBox_monto.Name = "textBox_monto";
            this.textBox_monto.Size = new System.Drawing.Size(60, 20);
            this.textBox_monto.TabIndex = 134;
            this.textBox_monto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_monto_KeyPress);
            // 
            // textBox_cantidad
            // 
            this.textBox_cantidad.Location = new System.Drawing.Point(387, 214);
            this.textBox_cantidad.Name = "textBox_cantidad";
            this.textBox_cantidad.Size = new System.Drawing.Size(60, 20);
            this.textBox_cantidad.TabIndex = 135;
            this.textBox_cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_cantidad_KeyPress);
            // 
            // button_agregar
            // 
            this.button_agregar.Location = new System.Drawing.Point(463, 213);
            this.button_agregar.Name = "button_agregar";
            this.button_agregar.Size = new System.Drawing.Size(75, 23);
            this.button_agregar.TabIndex = 136;
            this.button_agregar.Text = "Agregar";
            this.button_agregar.UseVisualStyleBackColor = true;
            this.button_agregar.Click += new System.EventHandler(this.button_agregar_Click);
            // 
            // button_quitar
            // 
            this.button_quitar.Location = new System.Drawing.Point(463, 240);
            this.button_quitar.Name = "button_quitar";
            this.button_quitar.Size = new System.Drawing.Size(75, 23);
            this.button_quitar.TabIndex = 137;
            this.button_quitar.Text = "Quitar";
            this.button_quitar.UseVisualStyleBackColor = true;
            this.button_quitar.Click += new System.EventHandler(this.button_quitar_Click);
            // 
            // label_descripcion
            // 
            this.label_descripcion.AutoSize = true;
            this.label_descripcion.Location = new System.Drawing.Point(17, 217);
            this.label_descripcion.Name = "label_descripcion";
            this.label_descripcion.Size = new System.Drawing.Size(66, 13);
            this.label_descripcion.TabIndex = 146;
            this.label_descripcion.Text = "Descripcion:";
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(89, 213);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(100, 20);
            this.textBox_descripcion.TabIndex = 133;
            // 
            // Alta_Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Name = "Alta_Factura";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_mail;
        private System.Windows.Forms.Label label_nro_factura;
        private System.Windows.Forms.Label label_empresa_cuit;
        private System.Windows.Forms.Label label_mail_cliente;
        private System.Windows.Forms.TextBox textBox_num_factura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_frcha_venc;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha_alta;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox_empresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_total;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_quitar;
        private System.Windows.Forms.Button button_agregar;
        private System.Windows.Forms.TextBox textBox_cantidad;
        private System.Windows.Forms.TextBox textBox_monto;
        private System.Windows.Forms.Label label_item_cant;
        private System.Windows.Forms.Label label_item_monto;
        private System.Windows.Forms.Label label_descripcion;
        private System.Windows.Forms.TextBox textBox_descripcion;
    }
}