namespace PagoAgilFrba.AbmCliente
{
    partial class Cliente_Listado
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
            this.texto_name = new System.Windows.Forms.TextBox();
            this.texto_surname = new System.Windows.Forms.TextBox();
            this.texto_listado_dni = new System.Windows.Forms.TextBox();
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
            this.label3.Size = new System.Drawing.Size(31, 18);
            this.label3.Text = "DNI";
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.Text = "Apellido";
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
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(162, 26);
            this.vt_titulo.Text = "Cliente busqueda";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.texto_listado_dni);
            this.panel1.Controls.Add(this.texto_surname);
            this.panel1.Controls.Add(this.texto_name);
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
            this.panel1.Controls.SetChildIndex(this.texto_name, 0);
            this.panel1.Controls.SetChildIndex(this.texto_surname, 0);
            this.panel1.Controls.SetChildIndex(this.texto_listado_dni, 0);
            // 
            // texto_name
            // 
            this.texto_name.Location = new System.Drawing.Point(91, 98);
            this.texto_name.Name = "texto_name";
            this.texto_name.Size = new System.Drawing.Size(100, 20);
            this.texto_name.TabIndex = 134;
            // 
            // texto_surname
            // 
            this.texto_surname.Location = new System.Drawing.Point(91, 150);
            this.texto_surname.Name = "texto_surname";
            this.texto_surname.Size = new System.Drawing.Size(100, 20);
            this.texto_surname.TabIndex = 135;
            // 
            // texto_listado_dni
            // 
            this.texto_listado_dni.Location = new System.Drawing.Point(383, 98);
            this.texto_listado_dni.Name = "texto_listado_dni";
            this.texto_listado_dni.Size = new System.Drawing.Size(100, 20);
            this.texto_listado_dni.TabIndex = 136;
            // 
            // Cliente_Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Name = "Cliente_Listado";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox texto_listado_dni;
        private System.Windows.Forms.TextBox texto_surname;
        private System.Windows.Forms.TextBox texto_name;
    }
}