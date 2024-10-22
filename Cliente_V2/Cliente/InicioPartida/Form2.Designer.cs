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
            this.listaconectados = new System.Windows.Forms.Button();
            this.invitar = new System.Windows.Forms.Button();
            this.conectadosGrid = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tirardado = new System.Windows.Forms.Button();
            this.labelnumero = new System.Windows.Forms.Label();
            this.seleccionarficha = new System.Windows.Forms.Button();
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
            this.Tablero.Location = new System.Drawing.Point(273, 12);
            this.Tablero.Name = "Tablero";
            this.Tablero.Size = new System.Drawing.Size(728, 548);
            this.Tablero.TabIndex = 0;
            this.Tablero.TabStop = false;
            this.Tablero.Text = "Tablero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turno";
            // 
            // listaconectados
            // 
            this.listaconectados.Location = new System.Drawing.Point(46, 24);
            this.listaconectados.Name = "listaconectados";
            this.listaconectados.Size = new System.Drawing.Size(144, 51);
            this.listaconectados.TabIndex = 1;
            this.listaconectados.Text = "Lista Conectados";
            this.listaconectados.UseVisualStyleBackColor = true;
            this.listaconectados.Click += new System.EventHandler(this.listaconectados_Click);
            // 
            // invitar
            // 
            this.invitar.Location = new System.Drawing.Point(46, 276);
            this.invitar.Name = "invitar";
            this.invitar.Size = new System.Drawing.Size(144, 51);
            this.invitar.TabIndex = 2;
            this.invitar.Text = "Invitar";
            this.invitar.UseVisualStyleBackColor = true;
            // 
            // conectadosGrid
            // 
            this.conectadosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conectadosGrid.Location = new System.Drawing.Point(37, 93);
            this.conectadosGrid.Name = "conectadosGrid";
            this.conectadosGrid.RowHeadersWidth = 51;
            this.conectadosGrid.RowTemplate.Height = 24;
            this.conectadosGrid.Size = new System.Drawing.Size(173, 137);
            this.conectadosGrid.TabIndex = 3;
            this.conectadosGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.conectadosGrid_CellContentClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 344);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 95);
            this.textBox1.TabIndex = 0;
            // 
            // tirardado
            // 
            this.tirardado.Location = new System.Drawing.Point(12, 462);
            this.tirardado.Name = "tirardado";
            this.tirardado.Size = new System.Drawing.Size(94, 48);
            this.tirardado.TabIndex = 4;
            this.tirardado.Text = "Tirar Dado";
            this.tirardado.UseVisualStyleBackColor = true;
            // 
            // labelnumero
            // 
            this.labelnumero.AutoSize = true;
            this.labelnumero.Location = new System.Drawing.Point(76, 522);
            this.labelnumero.Name = "labelnumero";
            this.labelnumero.Size = new System.Drawing.Size(92, 16);
            this.labelnumero.TabIndex = 5;
            this.labelnumero.Text = "Numero Dado";
            // 
            // seleccionarficha
            // 
            this.seleccionarficha.Location = new System.Drawing.Point(112, 462);
            this.seleccionarficha.Name = "seleccionarficha";
            this.seleccionarficha.Size = new System.Drawing.Size(150, 48);
            this.seleccionarficha.TabIndex = 1;
            this.seleccionarficha.Text = "Seleccionar Ficha";
            this.seleccionarficha.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 584);
            this.Controls.Add(this.seleccionarficha);
            this.Controls.Add(this.labelnumero);
            this.Controls.Add(this.tirardado);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.conectadosGrid);
            this.Controls.Add(this.invitar);
            this.Controls.Add(this.listaconectados);
            this.Controls.Add(this.Tablero);
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
        private System.Windows.Forms.Button listaconectados;
        private System.Windows.Forms.Button invitar;
        private System.Windows.Forms.DataGridView conectadosGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button tirardado;
        private System.Windows.Forms.Label labelnumero;
        private System.Windows.Forms.Button seleccionarficha;
    }
}

