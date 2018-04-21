namespace PagoAgilFrba.AbmSucursal
{
    partial class Sucursal_Inicio
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
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            this.SuspendLayout();
            // 
            // boton_alta
            // 
            this.boton_alta.Click += new System.EventHandler(this.boton_alta_Click);
            // 
            // boton_modificacion
            // 
            this.boton_modificacion.Click += new System.EventHandler(this.boton_modificacion_Click);
            // 
            // boton_baja
            // 
            this.boton_baja.Visible = false;
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(131, 26);
            this.vt_titulo.Text = "ABM Sucursal";
            // 
            // Sucursal_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Name = "Sucursal_Inicio";
            this.Text = "Sucursal_Inicio";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}