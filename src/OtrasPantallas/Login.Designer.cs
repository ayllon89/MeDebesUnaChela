namespace PagoAgilFrba.OtrasPantallas
{
    partial class Login
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
            this.vt_user = new System.Windows.Forms.TextBox();
            this.vt_pass = new System.Windows.Forms.TextBox();
            this.boton_iniciar_sesion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vt_titulo
            // 
            this.vt_titulo.Location = new System.Drawing.Point(3, 0);
            this.vt_titulo.Size = new System.Drawing.Size(52, 23);
            this.vt_titulo.Text = "Login";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.boton_iniciar_sesion);
            this.panel1.Controls.Add(this.vt_pass);
            this.panel1.Controls.Add(this.vt_user);
            this.panel1.Location = new System.Drawing.Point(545, 219);
            this.panel1.Size = new System.Drawing.Size(290, 265);
            this.panel1.Controls.SetChildIndex(this.boton_atras, 0);
            this.panel1.Controls.SetChildIndex(this.boton_cerrar, 0);
            this.panel1.Controls.SetChildIndex(this.vt_titulo, 0);
            this.panel1.Controls.SetChildIndex(this.vt_user, 0);
            this.panel1.Controls.SetChildIndex(this.vt_pass, 0);
            this.panel1.Controls.SetChildIndex(this.boton_iniciar_sesion, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            // 
            // vb_cerrar
            // 
            this.boton_cerrar.Location = new System.Drawing.Point(244, 215);
            // 
            // vb_atras
            // 
            this.boton_atras.Visible = false;
            // 
            // vt_user
            // 
            this.vt_user.Location = new System.Drawing.Point(63, 69);
            this.vt_user.Name = "vt_user";
            this.vt_user.Size = new System.Drawing.Size(150, 20);
            this.vt_user.TabIndex = 120;
            // 
            // vt_pass
            // 
            this.vt_pass.Location = new System.Drawing.Point(63, 121);
            this.vt_pass.Name = "vt_pass";
            this.vt_pass.PasswordChar = '*';
            this.vt_pass.Size = new System.Drawing.Size(150, 20);
            this.vt_pass.TabIndex = 121;
            // 
            // boton_iniciar_sesion
            // 
            this.boton_iniciar_sesion.Location = new System.Drawing.Point(63, 169);
            this.boton_iniciar_sesion.Name = "boton_iniciar_sesion";
            this.boton_iniciar_sesion.Size = new System.Drawing.Size(150, 40);
            this.boton_iniciar_sesion.TabIndex = 122;
            this.boton_iniciar_sesion.Text = "Iniciar Sesion";
            this.boton_iniciar_sesion.UseVisualStyleBackColor = true;
            this.boton_iniciar_sesion.Click += new System.EventHandler(this.boton_iniciar_sesion_Click);
            // 
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(16, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 123;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 124;
            this.label2.Text = "Pass";
            // 
            // Login
            // 
            this.AcceptButton = this.boton_iniciar_sesion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button boton_iniciar_sesion;
        private System.Windows.Forms.TextBox vt_pass;
        private System.Windows.Forms.TextBox vt_user;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}