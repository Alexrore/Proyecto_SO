namespace InicioPartida
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.Tablero = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tirardado = new System.Windows.Forms.Button();
            this.labelnumero = new System.Windows.Forms.Label();
            this.seleccionarficha = new System.Windows.Forms.Button();
            this.conectadosGrid = new System.Windows.Forms.DataGridView();
            this.Jugadores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invitar = new System.Windows.Forms.Button();
            this.label_invitar = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Tablero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conectadosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Tablero
            // 
            this.Tablero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Tablero.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Tablero.BackgroundImage")));
            this.Tablero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Tablero.Controls.Add(this.label1);
            this.Tablero.Location = new System.Drawing.Point(205, 10);
            this.Tablero.Margin = new System.Windows.Forms.Padding(2);
            this.Tablero.Name = "Tablero";
            this.Tablero.Padding = new System.Windows.Forms.Padding(2);
            this.Tablero.Size = new System.Drawing.Size(931, 646);
            this.Tablero.TabIndex = 0;
            this.Tablero.TabStop = false;
            this.Tablero.Text = "Tablero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turno";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 280);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 78);
            this.textBox1.TabIndex = 0;
            // 
            // tirardado
            // 
            this.tirardado.Location = new System.Drawing.Point(9, 375);
            this.tirardado.Margin = new System.Windows.Forms.Padding(2);
            this.tirardado.Name = "tirardado";
            this.tirardado.Size = new System.Drawing.Size(70, 39);
            this.tirardado.TabIndex = 4;
            this.tirardado.Text = "Tirar Dado";
            this.tirardado.UseVisualStyleBackColor = true;
            // 
            // labelnumero
            // 
            this.labelnumero.AutoSize = true;
            this.labelnumero.Location = new System.Drawing.Point(57, 424);
            this.labelnumero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelnumero.Name = "labelnumero";
            this.labelnumero.Size = new System.Drawing.Size(73, 13);
            this.labelnumero.TabIndex = 5;
            this.labelnumero.Text = "Numero Dado";
            // 
            // seleccionarficha
            // 
            this.seleccionarficha.Location = new System.Drawing.Point(84, 375);
            this.seleccionarficha.Margin = new System.Windows.Forms.Padding(2);
            this.seleccionarficha.Name = "seleccionarficha";
            this.seleccionarficha.Size = new System.Drawing.Size(112, 39);
            this.seleccionarficha.TabIndex = 1;
            this.seleccionarficha.Text = "Seleccionar Ficha";
            this.seleccionarficha.UseVisualStyleBackColor = true;
            // 
            // conectadosGrid
            // 
            this.conectadosGrid.AllowUserToAddRows = false;
            this.conectadosGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.conectadosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conectadosGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Jugadores});
            this.conectadosGrid.Enabled = false;
            this.conectadosGrid.Location = new System.Drawing.Point(16, 24);
            this.conectadosGrid.Margin = new System.Windows.Forms.Padding(2);
            this.conectadosGrid.Name = "conectadosGrid";
            this.conectadosGrid.RowHeadersWidth = 51;
            this.conectadosGrid.RowTemplate.Height = 24;
            this.conectadosGrid.Size = new System.Drawing.Size(172, 179);
            this.conectadosGrid.TabIndex = 16;
            this.conectadosGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.conectadosGrid_CellContentClick);
            // 
            // Jugadores
            // 
            this.Jugadores.HeaderText = "Jugadores";
            this.Jugadores.MinimumWidth = 6;
            this.Jugadores.Name = "Jugadores";
            // 
            // Invitar
            // 
            this.Invitar.Location = new System.Drawing.Point(241, 671);
            this.Invitar.Margin = new System.Windows.Forms.Padding(2);
            this.Invitar.Name = "Invitar";
            this.Invitar.Size = new System.Drawing.Size(100, 40);
            this.Invitar.TabIndex = 21;
            this.Invitar.Text = "Invitar";
            this.Invitar.UseVisualStyleBackColor = true;
            // 
            // label_invitar
            // 
            this.label_invitar.AutoSize = true;
            this.label_invitar.Location = new System.Drawing.Point(24, 685);
            this.label_invitar.Name = "label_invitar";
            this.label_invitar.Size = new System.Drawing.Size(39, 13);
            this.label_invitar.TabIndex = 20;
            this.label_invitar.Text = "Invitar:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(73, 682);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 21);
            this.comboBox1.TabIndex = 19;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 725);
            this.Controls.Add(this.Invitar);
            this.Controls.Add(this.label_invitar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.conectadosGrid);
            this.Controls.Add(this.seleccionarficha);
            this.Controls.Add(this.labelnumero);
            this.Controls.Add(this.tirardado);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Tablero);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.f2_Load);
            this.Tablero.ResumeLayout(false);
            this.Tablero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conectadosGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Tablero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button tirardado;
        private System.Windows.Forms.Label labelnumero;
        private System.Windows.Forms.Button seleccionarficha;
        private System.Windows.Forms.DataGridView conectadosGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugadores;
        private System.Windows.Forms.Button Invitar;
        private System.Windows.Forms.Label label_invitar;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

