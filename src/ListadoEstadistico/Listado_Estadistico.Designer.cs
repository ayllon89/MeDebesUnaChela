namespace PagoAgilFrba.ListadoEstadistico
{
    partial class Listado_Estadistico
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
            this.label2 = new System.Windows.Forms.Label();
            this.combo_listado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_trimestre = new System.Windows.Forms.ComboBox();
            this.boton_consultar = new System.Windows.Forms.Button();
            this.año = new System.Windows.Forms.DateTimePicker();
            this.listado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).BeginInit();
            this.SuspendLayout();
            // 
            // vt_titulo
            // 
            this.vt_titulo.Size = new System.Drawing.Size(170, 26);
            this.vt_titulo.Text = "Listado estadistico";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listado);
            this.panel1.Controls.Add(this.año);
            this.panel1.Controls.Add(this.boton_consultar);
            this.panel1.Controls.Add(this.combo_trimestre);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.combo_listado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.combo_listado, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.combo_trimestre, 0);
            this.panel1.Controls.SetChildIndex(this.boton_consultar, 0);
            this.panel1.Controls.SetChildIndex(this.año, 0);
            this.panel1.Controls.SetChildIndex(this.listado, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 124;
            this.label2.Text = "Tipo de listado";
            // 
            // combo_listado
            // 
            this.combo_listado.FormattingEnabled = true;
            this.combo_listado.Location = new System.Drawing.Point(135, 73);
            this.combo_listado.Name = "combo_listado";
            this.combo_listado.Size = new System.Drawing.Size(268, 21);
            this.combo_listado.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 18);
            this.label1.TabIndex = 126;
            this.label1.Text = "Año";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 127;
            this.label3.Text = "Trimestre";
            // 
            // combo_trimestre
            // 
            this.combo_trimestre.FormattingEnabled = true;
            this.combo_trimestre.Location = new System.Drawing.Point(135, 135);
            this.combo_trimestre.Name = "combo_trimestre";
            this.combo_trimestre.Size = new System.Drawing.Size(100, 21);
            this.combo_trimestre.TabIndex = 128;
            // 
            // boton_consultar
            // 
            this.boton_consultar.Location = new System.Drawing.Point(454, 138);
            this.boton_consultar.Name = "boton_consultar";
            this.boton_consultar.Size = new System.Drawing.Size(75, 23);
            this.boton_consultar.TabIndex = 130;
            this.boton_consultar.Text = "Consultar";
            this.boton_consultar.UseVisualStyleBackColor = true;
            this.boton_consultar.Click += new System.EventHandler(this.boton_consultar_Click);
            // 
            // año
            // 
            this.año.CustomFormat = "yyyy";
            this.año.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.año.Location = new System.Drawing.Point(135, 104);
            this.año.Name = "año";
            this.año.Size = new System.Drawing.Size(50, 20);
            this.año.TabIndex = 194;
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
            this.listado.Location = new System.Drawing.Point(20, 214);
            this.listado.MultiSelect = false;
            this.listado.Name = "listado";
            this.listado.ReadOnly = true;
            this.listado.RowHeadersVisible = false;
            this.listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado.Size = new System.Drawing.Size(510, 135);
            this.listado.TabIndex = 195;
            // 
            // Listado_Estadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Listado_Estadistico";
            this.Text = "Listado_Estadistico";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_trimestre;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_listado;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button boton_consultar;
        private System.Windows.Forms.DateTimePicker año;
        protected System.Windows.Forms.DataGridView listado;
    }
}