﻿namespace Cliente
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
            this.SuspendLayout();
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(342, 148);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(159, 22);
            this.textBox_nombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // textBox_Contraseña
            // 
            this.textBox_Contraseña.Location = new System.Drawing.Point(342, 199);
            this.textBox_Contraseña.Name = "textBox_Contraseña";
            this.textBox_Contraseña.Size = new System.Drawing.Size(159, 22);
            this.textBox_Contraseña.TabIndex = 2;
            // 
            // Conectrase
            // 
            this.Conectrase.Location = new System.Drawing.Point(79, 33);
            this.Conectrase.Name = "Conectrase";
            this.Conectrase.Size = new System.Drawing.Size(129, 45);
            this.Conectrase.TabIndex = 4;
            this.Conectrase.Text = "Conectarse";
            this.Conectrase.UseVisualStyleBackColor = true;
            this.Conectrase.Click += new System.EventHandler(this.Conectrase_Click);
            // 
            // Desconectarse
            // 
            this.Desconectarse.Location = new System.Drawing.Point(579, 33);
            this.Desconectarse.Name = "Desconectarse";
            this.Desconectarse.Size = new System.Drawing.Size(129, 45);
            this.Desconectarse.TabIndex = 5;
            this.Desconectarse.Text = "Desconectarse";
            this.Desconectarse.UseVisualStyleBackColor = true;
            this.Desconectarse.Click += new System.EventHandler(this.Desconectarse_Click);
            // 
            // Iniciar_sesion
            // 
            this.Iniciar_sesion.Location = new System.Drawing.Point(206, 269);
            this.Iniciar_sesion.Name = "Iniciar_sesion";
            this.Iniciar_sesion.Size = new System.Drawing.Size(129, 45);
            this.Iniciar_sesion.TabIndex = 6;
            this.Iniciar_sesion.Text = "Iniciar sesion";
            this.Iniciar_sesion.UseVisualStyleBackColor = true;
            this.Iniciar_sesion.Click += new System.EventHandler(this.Iniciar_sesion_Click);
            // 
            // Registrarse
            // 
            this.Registrarse.Location = new System.Drawing.Point(448, 269);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(129, 45);
            this.Registrarse.TabIndex = 7;
            this.Registrarse.Text = "Registrarse";
            this.Registrarse.UseVisualStyleBackColor = true;
            this.Registrarse.Click += new System.EventHandler(this.Registrarse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Registrarse);
            this.Controls.Add(this.Iniciar_sesion);
            this.Controls.Add(this.Desconectarse);
            this.Controls.Add(this.Conectrase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Contraseña);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_nombre);
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
    }
}
