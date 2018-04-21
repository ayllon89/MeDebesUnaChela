namespace PagoAgilFrba.PantallasGenericas
{
    partial class Pantalla_Alta
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
            this.label1 = new System.Windows.Forms.Label();
            this.boton_limpiar = new System.Windows.Forms.Button();
            this.boton_guardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            this.SuspendLayout();
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(131, 26);
            this.vt_titulo.Text = "(funcion) Alta";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.boton_guardar);
            this.panel1.Controls.Add(this.boton_limpiar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.boton_limpiar, 0);
            this.panel1.Controls.SetChildIndex(this.boton_guardar, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.checkBox1, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 19);
            this.label1.TabIndex = 120;
            this.label1.Text = "Complete los siguientes datos";
            // 
            // boton_limpiar
            // 
            this.boton_limpiar.Location = new System.Drawing.Point(19, 360);
            this.boton_limpiar.Name = "boton_limpiar";
            this.boton_limpiar.Size = new System.Drawing.Size(100, 30);
            this.boton_limpiar.TabIndex = 121;
            this.boton_limpiar.Text = "Limpiar";
            this.boton_limpiar.UseVisualStyleBackColor = true;
            // 
            // boton_guardar
            // 
            this.boton_guardar.Location = new System.Drawing.Point(438, 360);
            this.boton_guardar.Name = "boton_guardar";
            this.boton_guardar.Size = new System.Drawing.Size(100, 30);
            this.boton_guardar.TabIndex = 122;
            this.boton_guardar.Text = "Guardar";
            this.boton_guardar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 123;
            this.label2.Text = "Ingresar (dato)";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(20, 308);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(161, 22);
            this.checkBox1.TabIndex = 124;
            this.checkBox1.Text = "Habilitar/Deshabilitar";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Pantalla_Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Pantalla_Alta";
            this.Text = "Pantalla_Alta";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button boton_guardar;
        public System.Windows.Forms.Button boton_limpiar;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.Label label1;
    }
}