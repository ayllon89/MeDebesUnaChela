namespace PagoAgilFrba.PantallasGenericas
{
    partial class Pantalla_Listado
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
            this.listado = new System.Windows.Forms.DataGridView();
            this.boton_seleccion = new System.Windows.Forms.Button();
            this.boton_limpiar = new System.Windows.Forms.Button();
            this.boton_buscar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.boton_seleccionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.boton_seleccionar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.boton_buscar);
            this.panel1.Controls.Add(this.boton_limpiar);
            this.panel1.Controls.Add(this.boton_seleccion);
            this.panel1.Controls.Add(this.listado);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.listado, 0);
            this.panel1.Controls.SetChildIndex(this.boton_seleccion, 0);
            this.panel1.Controls.SetChildIndex(this.boton_limpiar, 0);
            this.panel1.Controls.SetChildIndex(this.boton_buscar, 0);
            this.panel1.Controls.SetChildIndex(this.label5, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            this.panel1.Controls.SetChildIndex(this.boton_seleccionar, 0);
            // 
            // listado
            // 
            this.listado.AllowUserToAddRows = false;
            this.listado.AllowUserToDeleteRows = false;
            this.listado.AllowUserToResizeColumns = false;
            this.listado.AllowUserToResizeRows = false;
            this.listado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listado.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listado.Location = new System.Drawing.Point(20, 240);
            this.listado.Name = "listado";
            this.listado.ReadOnly = true;
            this.listado.RowHeadersVisible = false;
            this.listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado.Size = new System.Drawing.Size(440, 150);
            this.listado.TabIndex = 120;
            // 
            // boton_seleccion
            // 
            this.boton_seleccion.Location = new System.Drawing.Point(463, 291);
            this.boton_seleccion.Name = "boton_seleccion";
            this.boton_seleccion.Size = new System.Drawing.Size(75, 23);
            this.boton_seleccion.TabIndex = 121;
            this.boton_seleccion.Text = "Seleccionar";
            this.boton_seleccion.UseVisualStyleBackColor = true;
            // 
            // boton_limpiar
            // 
            this.boton_limpiar.Location = new System.Drawing.Point(19, 193);
            this.boton_limpiar.Name = "boton_limpiar";
            this.boton_limpiar.Size = new System.Drawing.Size(75, 23);
            this.boton_limpiar.TabIndex = 122;
            this.boton_limpiar.Text = "Limpiar";
            this.boton_limpiar.UseVisualStyleBackColor = true;
            // 
            // boton_buscar
            // 
            this.boton_buscar.Location = new System.Drawing.Point(463, 193);
            this.boton_buscar.Name = "boton_buscar";
            this.boton_buscar.Size = new System.Drawing.Size(75, 23);
            this.boton_buscar.TabIndex = 123;
            this.boton_buscar.Text = "Buscar";
            this.boton_buscar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 19);
            this.label5.TabIndex = 128;
            this.label5.Text = "Filtros de busqueda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 129;
            this.label2.Text = "Filtro 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 130;
            this.label1.Text = "Filtro 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(303, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 131;
            this.label3.Text = "Filtro 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(303, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 132;
            this.label4.Text = "Filtro 4";
            // 
            // boton_seleccionar
            // 
            this.boton_seleccionar.Location = new System.Drawing.Point(463, 147);
            this.boton_seleccionar.Name = "boton_seleccionar";
            this.boton_seleccionar.Size = new System.Drawing.Size(75, 23);
            this.boton_seleccionar.TabIndex = 133;
            this.boton_seleccionar.Text = "Seleccionar";
            this.boton_seleccionar.UseVisualStyleBackColor = true;
            // 
            // Pantalla_Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Pantalla_Listado";
            this.Text = "Pantalla_Listado";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button boton_buscar;
        public System.Windows.Forms.Button boton_limpiar;
        public System.Windows.Forms.Button boton_seleccion;
        public System.Windows.Forms.Button boton_seleccionar;
        public System.Windows.Forms.Label label5;
        protected System.Windows.Forms.DataGridView listado;

    }
}