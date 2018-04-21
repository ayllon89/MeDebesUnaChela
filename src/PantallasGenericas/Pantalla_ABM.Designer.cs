namespace PagoAgilFrba.PantallasGenericas
{
    partial class Pantalla_ABM
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
            this.boton_alta = new System.Windows.Forms.Button();
            this.boton_baja = new System.Windows.Forms.Button();
            this.boton_modificacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(250, 26);
            this.vt_titulo.Text = "ABM (ingresar nombre aca)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.boton_modificacion);
            this.panel1.Controls.Add(this.boton_baja);
            this.panel1.Controls.Add(this.boton_alta);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.boton_alta, 0);
            this.panel1.Controls.SetChildIndex(this.boton_baja, 0);
            this.panel1.Controls.SetChildIndex(this.boton_modificacion, 0);
            // 
            // boton_alta
            // 
            this.boton_alta.Location = new System.Drawing.Point(213, 120);
            this.boton_alta.Name = "boton_alta";
            this.boton_alta.Size = new System.Drawing.Size(150, 30);
            this.boton_alta.TabIndex = 121;
            this.boton_alta.Text = "Alta";
            this.boton_alta.UseVisualStyleBackColor = true;
            // 
            // boton_baja
            // 
            this.boton_baja.Location = new System.Drawing.Point(213, 229);
            this.boton_baja.Name = "boton_baja";
            this.boton_baja.Size = new System.Drawing.Size(150, 30);
            this.boton_baja.TabIndex = 122;
            this.boton_baja.Text = "Baja";
            this.boton_baja.UseVisualStyleBackColor = true;
            // 
            // boton_modificacion
            // 
            this.boton_modificacion.Location = new System.Drawing.Point(213, 176);
            this.boton_modificacion.Name = "boton_modificacion";
            this.boton_modificacion.Size = new System.Drawing.Size(150, 30);
            this.boton_modificacion.TabIndex = 123;
            this.boton_modificacion.Text = "Modificacion";
            this.boton_modificacion.UseVisualStyleBackColor = true;
            // 
            // Pantalla_ABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Pantalla_ABM";
            this.Text = "Pantalla_ABM";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button boton_alta;
        public System.Windows.Forms.Button boton_modificacion;
        public System.Windows.Forms.Button boton_baja;

    }
}