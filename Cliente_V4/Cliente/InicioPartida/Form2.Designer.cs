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
            this.Tablero.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tablero
            // 
            this.Tablero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Tablero.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Tablero.BackgroundImage")));
            this.Tablero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Tablero.Controls.Add(this.label1);
            this.Tablero.Location = new System.Drawing.Point(273, 12);
            this.Tablero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tablero.Name = "Tablero";
            this.Tablero.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tablero.Size = new System.Drawing.Size(728, 548);
            this.Tablero.TabIndex = 0;
            this.Tablero.TabStop = false;
            this.Tablero.Text = "Tablero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turno";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 345);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 95);
            this.textBox1.TabIndex = 0;
            // 
            // tirardado
            // 
            this.tirardado.Location = new System.Drawing.Point(12, 462);
            this.tirardado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tirardado.Name = "tirardado";
            this.tirardado.Size = new System.Drawing.Size(93, 48);
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
            this.seleccionarficha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.seleccionarficha.Name = "seleccionarficha";
            this.seleccionarficha.Size = new System.Drawing.Size(149, 48);
            this.seleccionarficha.TabIndex = 1;
            this.seleccionarficha.Text = "Seleccionar Ficha";
            this.seleccionarficha.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 583);
            this.Controls.Add(this.seleccionarficha);
            this.Controls.Add(this.labelnumero);
            this.Controls.Add(this.tirardado);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Tablero);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.f2_Load);
            this.Tablero.ResumeLayout(false);
            this.Tablero.PerformLayout();
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
    }
}

