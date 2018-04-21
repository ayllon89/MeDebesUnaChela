namespace PagoAgilFrba.AbmCliente
{
    partial class Cliente_Modificacion
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
            this.texto_dni = new System.Windows.Forms.TextBox();
            this.texto_apellido = new System.Windows.Forms.TextBox();
            this.texto_nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.texto_mail = new System.Windows.Forms.TextBox();
            this.texto_telefono = new System.Windows.Forms.TextBox();
            this.texto_direccion = new System.Windows.Forms.TextBox();
            this.texto_cp = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Mail = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(282, 71);
            this.label2.Visible = false;
            // 
            // boton_guardar
            // 
            this.boton_guardar.Click += new System.EventHandler(this.boton_guardar_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(189, 26);
            this.vt_titulo.Text = "Cliente modificacion";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.Mail);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.texto_cp);
            this.panel1.Controls.Add(this.texto_direccion);
            this.panel1.Controls.Add(this.texto_telefono);
            this.panel1.Controls.Add(this.texto_mail);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.texto_nombre);
            this.panel1.Controls.Add(this.texto_apellido);
            this.panel1.Controls.Add(this.texto_dni);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.boton_limpiar, 0);
            this.panel1.Controls.SetChildIndex(this.boton_guardar, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.checkBox1, 0);
            this.panel1.Controls.SetChildIndex(this.texto_dni, 0);
            this.panel1.Controls.SetChildIndex(this.texto_apellido, 0);
            this.panel1.Controls.SetChildIndex(this.texto_nombre, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            this.panel1.Controls.SetChildIndex(this.label5, 0);
            this.panel1.Controls.SetChildIndex(this.texto_mail, 0);
            this.panel1.Controls.SetChildIndex(this.texto_telefono, 0);
            this.panel1.Controls.SetChildIndex(this.texto_direccion, 0);
            this.panel1.Controls.SetChildIndex(this.texto_cp, 0);
            this.panel1.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.panel1.Controls.SetChildIndex(this.Mail, 0);
            this.panel1.Controls.SetChildIndex(this.label7, 0);
            this.panel1.Controls.SetChildIndex(this.label8, 0);
            this.panel1.Controls.SetChildIndex(this.label9, 0);
            this.panel1.Controls.SetChildIndex(this.label10, 0);
            // 
            // texto_dni
            // 
            this.texto_dni.Location = new System.Drawing.Point(81, 197);
            this.texto_dni.Name = "texto_dni";
            this.texto_dni.Size = new System.Drawing.Size(100, 20);
            this.texto_dni.TabIndex = 125;
            // 
            // texto_apellido
            // 
            this.texto_apellido.Location = new System.Drawing.Point(81, 160);
            this.texto_apellido.Name = "texto_apellido";
            this.texto_apellido.Size = new System.Drawing.Size(100, 20);
            this.texto_apellido.TabIndex = 126;
            // 
            // texto_nombre
            // 
            this.texto_nombre.Location = new System.Drawing.Point(81, 125);
            this.texto_nombre.Name = "texto_nombre";
            this.texto_nombre.Size = new System.Drawing.Size(100, 20);
            this.texto_nombre.TabIndex = 127;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 128;
            this.label3.Text = "DNI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 129;
            this.label4.Text = "Apellido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 130;
            this.label5.Text = "Nombre";
            // 
            // texto_mail
            // 
            this.texto_mail.Location = new System.Drawing.Point(81, 235);
            this.texto_mail.Name = "texto_mail";
            this.texto_mail.Size = new System.Drawing.Size(100, 20);
            this.texto_mail.TabIndex = 131;
            // 
            // texto_telefono
            // 
            this.texto_telefono.Location = new System.Drawing.Point(348, 125);
            this.texto_telefono.Name = "texto_telefono";
            this.texto_telefono.Size = new System.Drawing.Size(100, 20);
            this.texto_telefono.TabIndex = 132;
            // 
            // texto_direccion
            // 
            this.texto_direccion.Location = new System.Drawing.Point(348, 160);
            this.texto_direccion.Name = "texto_direccion";
            this.texto_direccion.Size = new System.Drawing.Size(100, 20);
            this.texto_direccion.TabIndex = 133;
            // 
            // texto_cp
            // 
            this.texto_cp.Location = new System.Drawing.Point(348, 197);
            this.texto_cp.Name = "texto_cp";
            this.texto_cp.Size = new System.Drawing.Size(100, 20);
            this.texto_cp.TabIndex = 134;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(348, 238);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 135;
            // 
            // Mail
            // 
            this.Mail.AutoSize = true;
            this.Mail.Location = new System.Drawing.Point(40, 238);
            this.Mail.Name = "Mail";
            this.Mail.Size = new System.Drawing.Size(26, 13);
            this.Mail.TabIndex = 136;
            this.Mail.Text = "Mail";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 137;
            this.label7.Text = "Telefono";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(294, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 138;
            this.label8.Text = "Direccion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(294, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 139;
            this.label9.Text = "CP";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(237, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 140;
            this.label10.Text = "Fecha de nacimiento";
            // 
            // Cliente_Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Name = "Cliente_Modificacion";
            this.Text = "Cliente_Modificar";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox texto_dni;
        private System.Windows.Forms.TextBox texto_nombre;
        private System.Windows.Forms.TextBox texto_apellido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Mail;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox texto_cp;
        private System.Windows.Forms.TextBox texto_direccion;
        private System.Windows.Forms.TextBox texto_telefono;
        private System.Windows.Forms.TextBox texto_mail;
    }
}