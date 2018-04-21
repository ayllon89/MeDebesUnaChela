namespace PagoAgilFrba.PantallasGenericas
{
    partial class Pantalla_Inicial
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pantalla_Inicial));
            this.panel1 = new System.Windows.Forms.Panel();
            this.vt_titulo = new System.Windows.Forms.Label();
            this.boton_cerrar = new System.Windows.Forms.Button();
            this.boton_atras = new System.Windows.Forms.Button();
            this.errorValidar = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.vt_titulo);
            this.panel1.Controls.Add(this.boton_cerrar);
            this.panel1.Controls.Add(this.boton_atras);
            this.panel1.Location = new System.Drawing.Point(391, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 448);
            this.panel1.TabIndex = 0;
            // 
            // vt_titulo
            // 
            this.vt_titulo.AutoSize = true;
            this.vt_titulo.BackColor = System.Drawing.Color.Transparent;
            this.vt_titulo.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vt_titulo.ForeColor = System.Drawing.Color.Black;
            this.vt_titulo.Location = new System.Drawing.Point(15, 9);
            this.vt_titulo.Name = "vt_titulo";
            this.vt_titulo.Size = new System.Drawing.Size(134, 26);
            this.vt_titulo.TabIndex = 119;
            this.vt_titulo.Text = "Ingresar Texto";
            // 
            // boton_cerrar
            // 
            this.boton_cerrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("boton_cerrar.BackgroundImage")));
            this.boton_cerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.boton_cerrar.Location = new System.Drawing.Point(495, 407);
            this.boton_cerrar.Name = "boton_cerrar";
            this.boton_cerrar.Size = new System.Drawing.Size(43, 38);
            this.boton_cerrar.TabIndex = 1;
            this.boton_cerrar.UseVisualStyleBackColor = true;
            this.boton_cerrar.Click += new System.EventHandler(this.boton_cerrar_Click);
            // 
            // boton_atras
            // 
            this.boton_atras.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("boton_atras.BackgroundImage")));
            this.boton_atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boton_atras.Location = new System.Drawing.Point(19, 407);
            this.boton_atras.Name = "boton_atras";
            this.boton_atras.Size = new System.Drawing.Size(41, 38);
            this.boton_atras.TabIndex = 0;
            this.boton_atras.UseVisualStyleBackColor = true;
            this.boton_atras.Click += new System.EventHandler(this.boton_atras_Click);
            // 
            // errorValidar
            // 
            this.errorValidar.ContainerControl = this;
            // 
            // Pantalla_Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Controls.Add(this.panel1);
            this.Name = "Pantalla_Inicial";
            this.Text = "Pantalla_Inicial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label vt_titulo;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button boton_cerrar;
        protected System.Windows.Forms.Button boton_atras;
        public System.Windows.Forms.ErrorProvider errorValidar;
    }
}