﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InicioPartida
{
    public partial class Form2 : Form
    {
        Socket server;
        List<string> conectados = new List<string>();
        string usuario;
        int ultimoConteo;
        public Form2(Socket sock, List<string> Conectados, string Usuario, Thread Atender)
        {
            conectados= Conectados;
            server = sock;
            usuario = Usuario;
            InitializeComponent();   
            UpdateConectadosGrid();
        }

        private void f2_Load(object sender, EventArgs e)
        {
            Tablero.BackgroundImageLayout = ImageLayout.Stretch;
            labelnumero.Text = "?";
            Tablero.Visible = true;

        }

        private void conectadosGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void UpdateConectadosGrid()
        {
            // Limpiar el DataGridView
            conectadosGrid.Rows.Clear();
            comboBox1.Items.Clear();

            // Agregar los jugadores conectados al DataGridView
            foreach (var jugador in conectados)
            {
                conectadosGrid.Rows.Add(jugador);
                comboBox1.Items.Add(jugador);

            }
        }

        private void Jugador_1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (conectados.Count != ultimoConteo)
            {
                // El número de elementos en la lista ha cambiado
                ultimoConteo = conectados.Count;
                UpdateConectadosGrid();
            }
        }

        private void Invitar_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == usuario)
            {
                MessageBox.Show("No te puedes invitar a ti mismo");
            }
            else
            {
                string mensaje = "6/" + usuario + "/" + comboBox1.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

        }
    }
}



