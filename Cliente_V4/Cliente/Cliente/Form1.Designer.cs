using System.Windows.Forms;

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
            this.label_contraseña = new System.Windows.Forms.Label();
            this.textBox_Contraseña = new System.Windows.Forms.TextBox();
            this.Conectrase = new System.Windows.Forms.Button();
            this.Desconectarse = new System.Windows.Forms.Button();
            this.Iniciar_sesion = new System.Windows.Forms.Button();
            this.Registrarse = new System.Windows.Forms.Button();
            this.IniciarPartida = new System.Windows.Forms.Button();
            this.label_ID = new System.Windows.Forms.Label();
            this.textBox_Consulta = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.RadioButton();
            this.Victorias = new System.Windows.Forms.RadioButton();
            this.Medallas = new System.Windows.Forms.RadioButton();
            this.Consulta = new System.Windows.Forms.Button();
            this.conectadosGrid = new System.Windows.Forms.DataGridView();
            this.Jugadores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_invitar = new System.Windows.Forms.Label();
            this.Invitar = new System.Windows.Forms.Button();
            this.chat = new System.Windows.Forms.RichTextBox();
            this.Mensaje = new System.Windows.Forms.TextBox();
            this.Enviar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.conectadosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(298, 113);
            this.textBox_nombre.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(120, 20);
            this.textBox_nombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de usuario:";
            // 
            // label_contraseña
            // 
            this.label_contraseña.AutoSize = true;
            this.label_contraseña.Location = new System.Drawing.Point(218, 160);
            this.label_contraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_contraseña.Name = "label_contraseña";
            this.label_contraseña.Size = new System.Drawing.Size(64, 13);
            this.label_contraseña.TabIndex = 3;
            this.label_contraseña.Text = "Contraseña:";
            // 
            // textBox_Contraseña
            // 
            this.textBox_Contraseña.Location = new System.Drawing.Point(298, 155);
            this.textBox_Contraseña.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Contraseña.Name = "textBox_Contraseña";
            this.textBox_Contraseña.Size = new System.Drawing.Size(120, 20);
            this.textBox_Contraseña.TabIndex = 2;
            // 
            // Conectrase
            // 
            this.Conectrase.Location = new System.Drawing.Point(106, 27);
            this.Conectrase.Margin = new System.Windows.Forms.Padding(2);
            this.Conectrase.Name = "Conectrase";
            this.Conectrase.Size = new System.Drawing.Size(100, 40);
            this.Conectrase.TabIndex = 4;
            this.Conectrase.Text = "Conectarse";
            this.Conectrase.UseVisualStyleBackColor = true;
            this.Conectrase.Click += new System.EventHandler(this.Conectarse_Click);
            // 
            // Desconectarse
            // 
            this.Desconectarse.Location = new System.Drawing.Point(365, 27);
            this.Desconectarse.Margin = new System.Windows.Forms.Padding(2);
            this.Desconectarse.Name = "Desconectarse";
            this.Desconectarse.Size = new System.Drawing.Size(100, 40);
            this.Desconectarse.TabIndex = 5;
            this.Desconectarse.Text = "Desconectarse";
            this.Desconectarse.UseVisualStyleBackColor = true;
            this.Desconectarse.Click += new System.EventHandler(this.Desconectarse_Click);
            // 
            // Iniciar_sesion
            // 
            this.Iniciar_sesion.Location = new System.Drawing.Point(196, 212);
            this.Iniciar_sesion.Margin = new System.Windows.Forms.Padding(2);
            this.Iniciar_sesion.Name = "Iniciar_sesion";
            this.Iniciar_sesion.Size = new System.Drawing.Size(100, 40);
            this.Iniciar_sesion.TabIndex = 6;
            this.Iniciar_sesion.Text = "Iniciar sesion";
            this.Iniciar_sesion.UseVisualStyleBackColor = true;
            this.Iniciar_sesion.Click += new System.EventHandler(this.Iniciar_sesion_Click);
            // 
            // Registrarse
            // 
            this.Registrarse.Location = new System.Drawing.Point(378, 212);
            this.Registrarse.Margin = new System.Windows.Forms.Padding(2);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(100, 40);
            this.Registrarse.TabIndex = 7;
            this.Registrarse.Text = "Registrarse";
            this.Registrarse.UseVisualStyleBackColor = true;
            this.Registrarse.Click += new System.EventHandler(this.Registrarse_Click);
            // 
            // IniciarPartida
            // 
            this.IniciarPartida.Location = new System.Drawing.Point(456, 127);
            this.IniciarPartida.Margin = new System.Windows.Forms.Padding(2);
            this.IniciarPartida.Name = "IniciarPartida";
            this.IniciarPartida.Size = new System.Drawing.Size(100, 40);
            this.IniciarPartida.TabIndex = 8;
            this.IniciarPartida.Text = "Iniciar Partida";
            this.IniciarPartida.UseVisualStyleBackColor = true;
            this.IniciarPartida.Click += new System.EventHandler(this.IniciarPartida_Click);
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(104, 306);
            this.label_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(21, 13);
            this.label_ID.TabIndex = 9;
            this.label_ID.Text = "ID:";
            // 
            // textBox_Consulta
            // 
            this.textBox_Consulta.Location = new System.Drawing.Point(132, 301);
            this.textBox_Consulta.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Consulta.Name = "textBox_Consulta";
            this.textBox_Consulta.Size = new System.Drawing.Size(120, 20);
            this.textBox_Consulta.TabIndex = 10;
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(298, 283);
            this.Nombre.Margin = new System.Windows.Forms.Padding(2);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(98, 17);
            this.Nombre.TabIndex = 11;
            this.Nombre.TabStop = true;
            this.Nombre.Text = "Dime el nombre";
            this.Nombre.UseVisualStyleBackColor = true;
            // 
            // Victorias
            // 
            this.Victorias.AutoSize = true;
            this.Victorias.Location = new System.Drawing.Point(298, 304);
            this.Victorias.Margin = new System.Windows.Forms.Padding(2);
            this.Victorias.Name = "Victorias";
            this.Victorias.Size = new System.Drawing.Size(197, 17);
            this.Victorias.TabIndex = 12;
            this.Victorias.TabStop = true;
            this.Victorias.Text = "Dime el numero de partidas ganadas";
            this.Victorias.UseVisualStyleBackColor = true;
            // 
            // Medallas
            // 
            this.Medallas.AutoSize = true;
            this.Medallas.Location = new System.Drawing.Point(298, 325);
            this.Medallas.Margin = new System.Windows.Forms.Padding(2);
            this.Medallas.Name = "Medallas";
            this.Medallas.Size = new System.Drawing.Size(206, 17);
            this.Medallas.TabIndex = 13;
            this.Medallas.TabStop = true;
            this.Medallas.Text = "Dime el numero de medallas obtenidas";
            this.Medallas.UseVisualStyleBackColor = true;
            // 
            // Consulta
            // 
            this.Consulta.Location = new System.Drawing.Point(526, 290);
            this.Consulta.Margin = new System.Windows.Forms.Padding(2);
            this.Consulta.Name = "Consulta";
            this.Consulta.Size = new System.Drawing.Size(100, 40);
            this.Consulta.TabIndex = 14;
            this.Consulta.Text = "Consulta";
            this.Consulta.UseVisualStyleBackColor = true;
            this.Consulta.Click += new System.EventHandler(this.Consulta_Click);
            // 
            // conectadosGrid
            // 
            this.conectadosGrid.AllowUserToAddRows = false;
            this.conectadosGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.conectadosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conectadosGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Jugadores});
            this.conectadosGrid.Enabled = false;
            this.conectadosGrid.Location = new System.Drawing.Point(9, 76);
            this.conectadosGrid.Margin = new System.Windows.Forms.Padding(2);
            this.conectadosGrid.Name = "conectadosGrid";
            this.conectadosGrid.RowHeadersWidth = 51;
            this.conectadosGrid.RowTemplate.Height = 24;
            this.conectadosGrid.Size = new System.Drawing.Size(172, 179);
            this.conectadosGrid.TabIndex = 15;
            // 
            // Jugadores
            // 
            this.Jugadores.HeaderText = "Jugadores";
            this.Jugadores.MinimumWidth = 6;
            this.Jugadores.Name = "Jugadores";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(236, 367);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // label_invitar
            // 
            this.label_invitar.AutoSize = true;
            this.label_invitar.Location = new System.Drawing.Point(187, 370);
            this.label_invitar.Name = "label_invitar";
            this.label_invitar.Size = new System.Drawing.Size(39, 13);
            this.label_invitar.TabIndex = 17;
            this.label_invitar.Text = "Invitar:";
            // 
            // Invitar
            // 
            this.Invitar.Location = new System.Drawing.Point(404, 356);
            this.Invitar.Margin = new System.Windows.Forms.Padding(2);
            this.Invitar.Name = "Invitar";
            this.Invitar.Size = new System.Drawing.Size(100, 40);
            this.Invitar.TabIndex = 18;
            this.Invitar.Text = "Invitar";
            this.Invitar.UseVisualStyleBackColor = true;
            this.Invitar.Click += new System.EventHandler(this.Invitar_Click);
            // 
            // chat
            // 
            this.chat.Location = new System.Drawing.Point(39, 408);
            this.chat.Name = "chat";
            this.chat.ReadOnly = true;
            this.chat.Size = new System.Drawing.Size(465, 267);
            this.chat.TabIndex = 19;
            this.chat.Text = "";
            this.chat.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Mensaje
            // 
            this.Mensaje.Location = new System.Drawing.Point(39, 696);
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.Size = new System.Drawing.Size(465, 20);
            this.Mensaje.TabIndex = 20;
            // 
            // Enviar
            // 
            this.Enviar.Location = new System.Drawing.Point(526, 685);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(100, 40);
            this.Enviar.TabIndex = 21;
            this.Enviar.Text = "Enviar";
            this.Enviar.UseVisualStyleBackColor = true;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 745);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.Mensaje);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.Invitar);
            this.Controls.Add(this.label_invitar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.conectadosGrid);
            this.Controls.Add(this.Consulta);
            this.Controls.Add(this.Medallas);
            this.Controls.Add(this.Victorias);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.textBox_Consulta);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.IniciarPartida);
            this.Controls.Add(this.Registrarse);
            this.Controls.Add(this.Iniciar_sesion);
            this.Controls.Add(this.Desconectarse);
            this.Controls.Add(this.Conectrase);
            this.Controls.Add(this.label_contraseña);
            this.Controls.Add(this.textBox_Contraseña);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_nombre);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.conectadosGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_contraseña;
        private System.Windows.Forms.TextBox textBox_Contraseña;
        private System.Windows.Forms.Button Conectrase;
        private System.Windows.Forms.Button Desconectarse;
        private System.Windows.Forms.Button Iniciar_sesion;
        private System.Windows.Forms.Button Registrarse;
        private System.Windows.Forms.Button IniciarPartida;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.TextBox textBox_Consulta;
        private System.Windows.Forms.RadioButton Nombre;
        private System.Windows.Forms.RadioButton Victorias;
        private System.Windows.Forms.RadioButton Medallas;
        private System.Windows.Forms.Button Consulta;
        private System.Windows.Forms.DataGridView conectadosGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugadores;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_invitar;
        private Button Invitar;
        private RichTextBox chat;
        private TextBox Mensaje;
        private Button Enviar;
    }
}

