namespace Cliente
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Contraseña = new System.Windows.Forms.TextBox();
            this.Conectrase = new System.Windows.Forms.Button();
            this.Desconectarse = new System.Windows.Forms.Button();
            this.Iniciar_sesion = new System.Windows.Forms.Button();
            this.Registrarse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Consulta = new System.Windows.Forms.TextBox();
            this.Consulta = new System.Windows.Forms.Button();
            this.Nombre = new System.Windows.Forms.RadioButton();
            this.Victorias = new System.Windows.Forms.RadioButton();
            this.Medallas = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(256, 120);
            this.textBox_nombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(120, 20);
            this.textBox_nombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // textBox_Contraseña
            // 
            this.textBox_Contraseña.Location = new System.Drawing.Point(256, 162);
            this.textBox_Contraseña.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Contraseña.Name = "textBox_Contraseña";
            this.textBox_Contraseña.Size = new System.Drawing.Size(120, 20);
            this.textBox_Contraseña.TabIndex = 2;
            // 
            // Conectrase
            // 
            this.Conectrase.Location = new System.Drawing.Point(59, 27);
            this.Conectrase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Conectrase.Name = "Conectrase";
            this.Conectrase.Size = new System.Drawing.Size(97, 37);
            this.Conectrase.TabIndex = 4;
            this.Conectrase.Text = "Conectarse";
            this.Conectrase.UseVisualStyleBackColor = true;
            this.Conectrase.Click += new System.EventHandler(this.Conectrase_Click);
            // 
            // Desconectarse
            // 
            this.Desconectarse.Location = new System.Drawing.Point(434, 27);
            this.Desconectarse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Desconectarse.Name = "Desconectarse";
            this.Desconectarse.Size = new System.Drawing.Size(97, 37);
            this.Desconectarse.TabIndex = 5;
            this.Desconectarse.Text = "Desconectarse";
            this.Desconectarse.UseVisualStyleBackColor = true;
            this.Desconectarse.Click += new System.EventHandler(this.Desconectarse_Click);
            // 
            // Iniciar_sesion
            // 
            this.Iniciar_sesion.Location = new System.Drawing.Point(154, 219);
            this.Iniciar_sesion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Iniciar_sesion.Name = "Iniciar_sesion";
            this.Iniciar_sesion.Size = new System.Drawing.Size(97, 37);
            this.Iniciar_sesion.TabIndex = 6;
            this.Iniciar_sesion.Text = "Iniciar sesion";
            this.Iniciar_sesion.UseVisualStyleBackColor = true;
            this.Iniciar_sesion.Click += new System.EventHandler(this.Iniciar_sesion_Click);
            // 
            // Registrarse
            // 
            this.Registrarse.Location = new System.Drawing.Point(336, 219);
            this.Registrarse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(97, 37);
            this.Registrarse.TabIndex = 7;
            this.Registrarse.Text = "Registrarse";
            this.Registrarse.UseVisualStyleBackColor = true;
            this.Registrarse.Click += new System.EventHandler(this.Registrarse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 301);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "ID:";
            this.label3.Visible = false;
            // 
            // textBox_Consulta
            // 
            this.textBox_Consulta.Location = new System.Drawing.Point(120, 298);
            this.textBox_Consulta.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Consulta.Name = "textBox_Consulta";
            this.textBox_Consulta.Size = new System.Drawing.Size(120, 20);
            this.textBox_Consulta.TabIndex = 8;
            this.textBox_Consulta.Visible = false;
            this.textBox_Consulta.TextChanged += new System.EventHandler(this.textBox_Consulta_TextChanged);
            // 
            // Consulta
            // 
            this.Consulta.Location = new System.Drawing.Point(256, 355);
            this.Consulta.Margin = new System.Windows.Forms.Padding(2);
            this.Consulta.Name = "Consulta";
            this.Consulta.Size = new System.Drawing.Size(97, 37);
            this.Consulta.TabIndex = 10;
            this.Consulta.Text = "Consulta";
            this.Consulta.UseVisualStyleBackColor = true;
            this.Consulta.Visible = false;
            this.Consulta.Click += new System.EventHandler(this.Consulta_Click);
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(291, 276);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(98, 17);
            this.Nombre.TabIndex = 11;
            this.Nombre.TabStop = true;
            this.Nombre.Text = "Dime el nombre";
            this.Nombre.UseVisualStyleBackColor = true;
            this.Nombre.Visible = false;
            // 
            // Victorias
            // 
            this.Victorias.AutoSize = true;
            this.Victorias.Location = new System.Drawing.Point(291, 299);
            this.Victorias.Name = "Victorias";
            this.Victorias.Size = new System.Drawing.Size(197, 17);
            this.Victorias.TabIndex = 12;
            this.Victorias.TabStop = true;
            this.Victorias.Text = "Dime el numero de partidas ganadas";
            this.Victorias.UseVisualStyleBackColor = true;
            this.Victorias.Visible = false;
            // 
            // Medallas
            // 
            this.Medallas.AutoSize = true;
            this.Medallas.Location = new System.Drawing.Point(291, 322);
            this.Medallas.Name = "Medallas";
            this.Medallas.Size = new System.Drawing.Size(206, 17);
            this.Medallas.TabIndex = 13;
            this.Medallas.TabStop = true;
            this.Medallas.Text = "Dime el numero de medallas obtenidas";
            this.Medallas.UseVisualStyleBackColor = true;
            this.Medallas.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 435);
            this.Controls.Add(this.Medallas);
            this.Controls.Add(this.Victorias);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.Consulta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Consulta);
            this.Controls.Add(this.Registrarse);
            this.Controls.Add(this.Iniciar_sesion);
            this.Controls.Add(this.Desconectarse);
            this.Controls.Add(this.Conectrase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Contraseña);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_nombre);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Contraseña;
        private System.Windows.Forms.Button Conectrase;
        private System.Windows.Forms.Button Desconectarse;
        private System.Windows.Forms.Button Iniciar_sesion;
        private System.Windows.Forms.Button Registrarse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Consulta;
        private System.Windows.Forms.Button Consulta;
        private System.Windows.Forms.RadioButton Nombre;
        private System.Windows.Forms.RadioButton Victorias;
        private System.Windows.Forms.RadioButton Medallas;
    }
}

