namespace PagoAgilFrba.AbmEmpresa
{
    partial class Empresa_Modificacion
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
            this.texto_nombre = new System.Windows.Forms.TextBox();
            this.texto_cuit = new System.Windows.Forms.TextBox();
            this.texto_direccion = new System.Windows.Forms.TextBox();
            this.combo_rubro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 121);
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.Text = "Nombre";
            // 
            // boton_guardar
            // 
            this.boton_guardar.Click += new System.EventHandler(this.boton_guardar_Click);
            // 
            // boton_limpiar
            // 
            this.boton_limpiar.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(208, 19);
            this.label1.Text = "Modifique los siguientes datos";
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(202, 26);
            this.vt_titulo.Text = "Empresa modificacion";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.combo_rubro);
            this.panel1.Controls.Add(this.texto_direccion);
            this.panel1.Controls.Add(this.texto_cuit);
            this.panel1.Controls.Add(this.texto_nombre);
            this.panel1.Controls.SetChildIndex(this.texto_nombre, 0);
            this.panel1.Controls.SetChildIndex(this.texto_cuit, 0);
            this.panel1.Controls.SetChildIndex(this.texto_direccion, 0);
            this.panel1.Controls.SetChildIndex(this.combo_rubro, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            this.panel1.Controls.SetChildIndex(this.label5, 0);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.boton_limpiar, 0);
            this.panel1.Controls.SetChildIndex(this.boton_guardar, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.checkBox1, 0);
            // 
            // texto_nombre
            // 
            this.texto_nombre.Location = new System.Drawing.Point(120, 119);
            this.texto_nombre.Name = "texto_nombre";
            this.texto_nombre.Size = new System.Drawing.Size(100, 20);
            this.texto_nombre.TabIndex = 125;
            // 
            // texto_cuit
            // 
            this.texto_cuit.Location = new System.Drawing.Point(120, 162);
            this.texto_cuit.MaxLength = 11;
            this.texto_cuit.Name = "texto_cuit";
            this.texto_cuit.Size = new System.Drawing.Size(100, 20);
            this.texto_cuit.TabIndex = 126;
            this.texto_cuit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.texto_cuit_KeyPress);
            // 
            // texto_direccion
            // 
            this.texto_direccion.Location = new System.Drawing.Point(120, 206);
            this.texto_direccion.Name = "texto_direccion";
            this.texto_direccion.Size = new System.Drawing.Size(100, 20);
            this.texto_direccion.TabIndex = 127;
            // 
            // combo_rubro
            // 
            this.combo_rubro.FormattingEnabled = true;
            this.combo_rubro.Location = new System.Drawing.Point(372, 118);
            this.combo_rubro.Name = "combo_rubro";
            this.combo_rubro.Size = new System.Drawing.Size(121, 21);
            this.combo_rubro.TabIndex = 128;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 18);
            this.label3.TabIndex = 129;
            this.label3.Text = "Cuit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 130;
            this.label4.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(296, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 18);
            this.label5.TabIndex = 131;
            this.label5.Text = "Rubro";
            // 
            // Empresa_Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Name = "Empresa_Modificacion";
            this.Text = "Empresa_Modificacion";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox texto_cuit;
        private System.Windows.Forms.TextBox texto_nombre;
        private System.Windows.Forms.ComboBox combo_rubro;
        private System.Windows.Forms.TextBox texto_direccion;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
    }
}