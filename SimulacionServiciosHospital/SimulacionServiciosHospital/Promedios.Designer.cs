namespace SimulacionServiciosHospital
{
    partial class Promedios
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVtablas = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNivelSignificancia = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPruebaPromedio = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPromedio = new System.Windows.Forms.Button();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.lblpromedio2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbldisnor = new System.Windows.Forms.TextBox();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtVtablas);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtNivelSignificancia);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.btnPruebaPromedio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 670);
            this.panel1.TabIndex = 25;
            // 
            // txtVtablas
            // 
            this.txtVtablas.Enabled = false;
            this.txtVtablas.Font = new System.Drawing.Font("Arial", 11.25F);
            this.txtVtablas.Location = new System.Drawing.Point(392, 103);
            this.txtVtablas.Name = "txtVtablas";
            this.txtVtablas.Size = new System.Drawing.Size(108, 25);
            this.txtVtablas.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(166)))));
            this.label13.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(81, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(593, 23);
            this.label13.TabIndex = 22;
            this.label13.Text = "TABLA DE DISTRIBUCIÓN NORMAL";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNivelSignificancia
            // 
            this.txtNivelSignificancia.Font = new System.Drawing.Font("Arial", 11.25F);
            this.txtNivelSignificancia.Location = new System.Drawing.Point(392, 72);
            this.txtNivelSignificancia.Name = "txtNivelSignificancia";
            this.txtNivelSignificancia.Size = new System.Drawing.Size(108, 25);
            this.txtNivelSignificancia.TabIndex = 22;
            this.txtNivelSignificancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNivelSignificancia_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F);
            this.label11.Location = new System.Drawing.Point(228, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "Valor de tablas:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F);
            this.label12.Location = new System.Drawing.Point(228, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 17);
            this.label12.TabIndex = 22;
            this.label12.Text = "Nivel de significancia:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Z,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dataGridView2.Location = new System.Drawing.Point(81, 135);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(593, 190);
            this.dataGridView2.TabIndex = 18;
            // 
            // Z
            // 
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            this.Z.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = ".00";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = ".01";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = ".02";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = ".03";
            this.Column4.Name = "Column4";
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = ".04";
            this.Column5.Name = "Column5";
            this.Column5.Width = 50;
            // 
            // Column6
            // 
            this.Column6.HeaderText = ".05";
            this.Column6.Name = "Column6";
            this.Column6.Width = 50;
            // 
            // Column7
            // 
            this.Column7.HeaderText = ".06";
            this.Column7.Name = "Column7";
            this.Column7.Width = 50;
            // 
            // Column8
            // 
            this.Column8.HeaderText = ".07";
            this.Column8.Name = "Column8";
            this.Column8.Width = 50;
            // 
            // Column9
            // 
            this.Column9.HeaderText = ".08";
            this.Column9.Name = "Column9";
            this.Column9.Width = 50;
            // 
            // Column10
            // 
            this.Column10.HeaderText = ".09";
            this.Column10.Name = "Column10";
            this.Column10.Width = 50;
            // 
            // btnPruebaPromedio
            // 
            this.btnPruebaPromedio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(138)))), ((int)(((byte)(158)))));
            this.btnPruebaPromedio.FlatAppearance.BorderSize = 0;
            this.btnPruebaPromedio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPruebaPromedio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPruebaPromedio.ForeColor = System.Drawing.Color.White;
            this.btnPruebaPromedio.Location = new System.Drawing.Point(535, 75);
            this.btnPruebaPromedio.Name = "btnPruebaPromedio";
            this.btnPruebaPromedio.Size = new System.Drawing.Size(126, 43);
            this.btnPruebaPromedio.TabIndex = 19;
            this.btnPruebaPromedio.Text = "Calcular valor de tablas";
            this.btnPruebaPromedio.UseVisualStyleBackColor = false;
            this.btnPruebaPromedio.Click += new System.EventHandler(this.btnPruebaPromedio_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(102)))));
            this.panel4.Controls.Add(this.btnAyuda);
            this.panel4.Controls.Add(this.btnAtras);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(752, 31);
            this.panel4.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(130, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(320, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Promedio de los numeros pseodoaleatorios:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(232, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Valor calculado Zo:";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(0, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(752, 30);
            this.label9.TabIndex = 17;
            this.label9.Text = "PRUEBA DE PROMEDIOS";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPromedio
            // 
            this.btnPromedio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPromedio.FlatAppearance.BorderSize = 0;
            this.btnPromedio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromedio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPromedio.Location = new System.Drawing.Point(324, 188);
            this.btnPromedio.Name = "btnPromedio";
            this.btnPromedio.Size = new System.Drawing.Size(126, 23);
            this.btnPromedio.TabIndex = 18;
            this.btnPromedio.Text = "Realizar prueba";
            this.btnPromedio.UseVisualStyleBackColor = false;
            this.btnPromedio.Click += new System.EventHandler(this.btnPromedio_Click);
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.BackColor = System.Drawing.Color.White;
            this.lblRespuesta.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblRespuesta.ForeColor = System.Drawing.Color.Red;
            this.lblRespuesta.Location = new System.Drawing.Point(204, 237);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(363, 93);
            this.lblRespuesta.TabIndex = 19;
            // 
            // lblpromedio2
            // 
            this.lblpromedio2.Enabled = false;
            this.lblpromedio2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpromedio2.Location = new System.Drawing.Point(456, 100);
            this.lblpromedio2.Name = "lblpromedio2";
            this.lblpromedio2.Size = new System.Drawing.Size(100, 25);
            this.lblpromedio2.TabIndex = 20;
            this.lblpromedio2.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(141)))), ((int)(((byte)(172)))));
            this.panel2.Controls.Add(this.lbldisnor);
            this.panel2.Controls.Add(this.lblpromedio2);
            this.panel2.Controls.Add(this.lblRespuesta);
            this.panel2.Controls.Add(this.btnPromedio);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 331);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(752, 339);
            this.panel2.TabIndex = 26;
            // 
            // lbldisnor
            // 
            this.lbldisnor.Enabled = false;
            this.lbldisnor.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldisnor.Location = new System.Drawing.Point(393, 139);
            this.lbldisnor.Name = "lbldisnor";
            this.lbldisnor.Size = new System.Drawing.Size(100, 25);
            this.lbldisnor.TabIndex = 21;
            this.lbldisnor.Visible = false;
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAyuda.FlatAppearance.BorderSize = 0;
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAyuda.ForeColor = System.Drawing.Color.White;
            this.btnAyuda.Image = global::SimulacionServiciosHospital.Properties.Resources.help;
            this.btnAyuda.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAyuda.Location = new System.Drawing.Point(655, 3);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(85, 23);
            this.btnAyuda.TabIndex = 1;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(102)))));
            this.btnAtras.BackgroundImage = global::SimulacionServiciosHospital.Properties.Resources.atras__25;
            this.btnAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.Location = new System.Drawing.Point(12, 3);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 25);
            this.btnAtras.TabIndex = 0;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // Promedios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 670);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Promedios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pruebas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtVtablas;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNivelSignificancia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Button btnPruebaPromedio;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPromedio;
        private System.Windows.Forms.Label lblRespuesta;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox lblpromedio2;
        public System.Windows.Forms.TextBox lbldisnor;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnAyuda;
    }
}