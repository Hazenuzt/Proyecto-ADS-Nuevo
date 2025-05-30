namespace Distribuidora_de_caroos
{
    partial class Administrador
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnEliminarCarro = new System.Windows.Forms.Button();
            this.btnSalirB = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(452, 436);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.btnEliminarCarro);
            this.tabPage3.Controls.Add(this.btnSalirB);
            this.tabPage3.Controls.Add(this.btnEliminar);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(444, 406);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Borrar";
            // 
            // btnEliminarCarro
            // 
            this.btnEliminarCarro.AutoSize = true;
            this.btnEliminarCarro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(154)))), ((int)(((byte)(190)))));
            this.btnEliminarCarro.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCarro.Location = new System.Drawing.Point(160, 226);
            this.btnEliminarCarro.Name = "btnEliminarCarro";
            this.btnEliminarCarro.Size = new System.Drawing.Size(97, 36);
            this.btnEliminarCarro.TabIndex = 8;
            this.btnEliminarCarro.Text = "VEHÍCULO";
            this.btnEliminarCarro.UseVisualStyleBackColor = false;
            this.btnEliminarCarro.Click += new System.EventHandler(this.btnEliminarCarro_Click);
            // 
            // btnSalirB
            // 
            this.btnSalirB.AutoSize = true;
            this.btnSalirB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(154)))), ((int)(((byte)(190)))));
            this.btnSalirB.ForeColor = System.Drawing.Color.White;
            this.btnSalirB.Location = new System.Drawing.Point(160, 311);
            this.btnSalirB.Name = "btnSalirB";
            this.btnSalirB.Size = new System.Drawing.Size(97, 36);
            this.btnSalirB.TabIndex = 7;
            this.btnSalirB.Text = "SALIR";
            this.btnSalirB.UseVisualStyleBackColor = false;
            this.btnSalirB.Click += new System.EventHandler(this.btnSalirB_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(154)))), ((int)(((byte)(190)))));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(156, 142);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(101, 36);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "USUARIO";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(82, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(251, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Selecciones una opción a borrar:";
            // 
            // Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(186)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(455, 450);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Administrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador";
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalirB;
        private System.Windows.Forms.Button btnEliminarCarro;
    }
}