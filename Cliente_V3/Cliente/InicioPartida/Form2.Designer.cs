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
            this.invitar = new System.Windows.Forms.Button();
            this.conectadosGrid = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tirardado = new System.Windows.Forms.Button();
            this.labelnumero = new System.Windows.Forms.Label();
            this.seleccionarficha = new System.Windows.Forms.Button();
            this.Jugadores = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Tablero.Size = new System.Drawing.Size(546, 445);
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
            // invitar
            // 
            this.invitar.Location = new System.Drawing.Point(34, 224);
            this.invitar.Margin = new System.Windows.Forms.Padding(2);
            this.invitar.Name = "invitar";
            this.invitar.Size = new System.Drawing.Size(108, 41);
            this.invitar.TabIndex = 2;
            this.invitar.Text = "Invitar";
            this.invitar.UseVisualStyleBackColor = true;
            // 
            // conectadosGrid
            // 
            this.conectadosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conectadosGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Jugadores});
            this.conectadosGrid.Location = new System.Drawing.Point(30, 76);
            this.conectadosGrid.Margin = new System.Windows.Forms.Padding(2);
            this.conectadosGrid.Name = "conectadosGrid";
            this.conectadosGrid.RowHeadersWidth = 51;
            this.conectadosGrid.RowTemplate.Height = 24;
            this.conectadosGrid.Size = new System.Drawing.Size(144, 111);
            this.conectadosGrid.TabIndex = 3;
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
            // Jugadores
            // 
            this.Jugadores.HeaderText = "Jugadores";
            this.Jugadores.Name = "Jugadores";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 474);
            this.Controls.Add(this.seleccionarficha);
            this.Controls.Add(this.labelnumero);
            this.Controls.Add(this.tirardado);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.conectadosGrid);
            this.Controls.Add(this.invitar);
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
        private System.Windows.Forms.Button invitar;
        private System.Windows.Forms.DataGridView conectadosGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button tirardado;
        private System.Windows.Forms.Label labelnumero;
        private System.Windows.Forms.Button seleccionarficha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugadores;
    }
}

