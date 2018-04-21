namespace PagoAgilFrba.AbmEmpresa
{
    partial class Empresa_Listado
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
            this.combo_rubro = new System.Windows.Forms.ComboBox();
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
            this.label3.Size = new System.Drawing.Size(45, 18);
            this.label3.Text = "Rubro";
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(33, 18);
            this.label1.Text = "Cuit";
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.Text = "Nombre";
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
            this.boton_seleccionar.Click += new System.EventHandler(this.boton_seleccionar_Click);
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(175, 26);
            this.vt_titulo.Text = "Empresa busqueda";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.combo_rubro);
            this.panel1.Controls.Add(this.texto_cuit);
            this.panel1.Controls.Add(this.texto_nombre);
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
            this.panel1.Controls.SetChildIndex(this.texto_nombre, 0);
            this.panel1.Controls.SetChildIndex(this.texto_cuit, 0);
            this.panel1.Controls.SetChildIndex(this.combo_rubro, 0);
            // 
            // texto_nombre
            // 
            this.texto_nombre.Location = new System.Drawing.Point(90, 97);
            this.texto_nombre.Name = "texto_nombre";
            this.texto_nombre.Size = new System.Drawing.Size(100, 20);
            this.texto_nombre.TabIndex = 134;
            // 
            // texto_cuit
            // 
            this.texto_cuit.Location = new System.Drawing.Point(90, 147);
            this.texto_cuit.Name = "texto_cuit";
            this.texto_cuit.Size = new System.Drawing.Size(100, 20);
            this.texto_cuit.TabIndex = 135;
            // 
            // combo_rubro
            // 
            this.combo_rubro.FormattingEnabled = true;
            this.combo_rubro.Location = new System.Drawing.Point(354, 96);
            this.combo_rubro.Name = "combo_rubro";
            this.combo_rubro.Size = new System.Drawing.Size(121, 21);
            this.combo_rubro.TabIndex = 136;
            this.combo_rubro.Text = "Seleccione";
            // 
            // Empresa_Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Name = "Empresa_Listado";
            this.Text = "Empresa_Listado";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_rubro;
        private System.Windows.Forms.TextBox texto_cuit;
        private System.Windows.Forms.TextBox texto_nombre;
    }
}