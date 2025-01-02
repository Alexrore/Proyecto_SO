using System;
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
        int Conectados_Cont, Jugadores_Cont;
        List<string> jugadores = new List<string>();

        public Form2(Socket sock, List<string> Conectados, string Usuario, Thread Atender, List<string> Jugadores)
        {
            conectados= Conectados;
            server = sock;
            usuario = Usuario;
            jugadores= Jugadores;
            InitializeComponent();   
            UpdateConectadosGrid();
        }

        private void f2_Load(object sender, EventArgs e)
        {
            Tablero.BackgroundImageLayout = ImageLayout.Stretch;
            labelnumero.Text = "?";
            Tablero.Visible = true;

        }


        private void UpdateConectadosGrid()
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
        private void UpdateInvitadosGrid()
        {
            // Limpiar el DataGridView
            jugadoresGrid.Rows.Clear();

            // Agregar los jugadores conectados al DataGridView
            foreach (var jugador in jugadores)
            {
                jugadoresGrid.Rows.Add(jugador);

            }
            Nombres();
        }
        private void Nombres()
        {
            try
            {
                Jugador_1.Text="Jugador 1: "+jugadores[0];
            }
            catch { }
            try
            {
                Jugador_2.Text = "Jugador 2: " + jugadores[1];
            }
            catch { }
            try
            {
                Jugador_3.Text = "Jugador 3: " + jugadores[2];
            }
            catch { }
            try
            {
                Jugador_4.Text = "Jugador 4: " + jugadores[3];
            }
            catch { }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (conectados.Count != Conectados_Cont)
            {
                // El número de elementos en la lista ha cambiado
                Conectados_Cont = conectados.Count;
                UpdateConectadosGrid();
            }
            if (jugadores.Count != Jugadores_Cont)
            {

                Jugadores_Cont = jugadores.Count;
                UpdateInvitadosGrid();
            }
            
        }

        private void Invitar_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == usuario)
            {
                MessageBox.Show("No te puedes invitar a ti mismo");
            }
            else if(comboBox1.Text == "")
            {
                MessageBox.Show("Selecciona a alguien al que invitar");
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



