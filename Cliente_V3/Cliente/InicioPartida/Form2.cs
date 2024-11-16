using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InicioPartida
{
    public partial class Form2 : Form
    {
        List<Point> posiciones = new List<Point>();
        List<string> conectados = new List<string>();
        List<string> invitados = new List<string>();
        Random rand = new Random();
        int cont = 0;
        int turno = 0;
        Socket clienteSocket;
        public Form2()
        {
            InitializeComponent();
            ConnectToServer();
        }

        private void f2_Load(object sender, EventArgs e)
        {
            Tablero.BackgroundImageLayout = ImageLayout.Stretch;
            labelnumero.Text = "?";
            Tablero.Visible = true;

        }

        private void ConnectToServer()
        {
            try
            {
                clienteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clienteSocket.Connect("192.168.0.19", 9050);  // Dirección y puerto del servidor
                Task.Run(() => ReceiveData());
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: {ex.Message}");
                clienteSocket = null;  // Asegúrate de que clienteSocket quede como null si no se conecta
            }
        }




        private void ReceiveData()
        {
            byte[] buffer = new byte[1024];

            while (true)
            {
                try
                {
                    byte[] msg2 = new byte[1024];
                    clienteSocket.Receive(msg2);
                    string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    if (!string.IsNullOrWhiteSpace(mensaje))
                    {

                        // Si el servidor envía la lista de jugadores
                        if (mensaje.StartsWith("Jugadores en linea:"))
                        {
                            // Limpiar la lista de jugadores conectados
                            conectados.Clear();

                            // Obtener los nombres de los jugadores
                            string[] jugadores = mensaje.Substring("Jugadores en linea:".Length).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            conectados.AddRange(jugadores);

                            // Actualizar la interfaz de usuario
                            Invoke(new Action(UpdateConectadosGrid));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al recibir datos: {ex.Message}");
                    break;
                }
            }
        }

        private void UpdateConectadosGrid()
        {
            // Limpiar el DataGridView
            conectadosGrid.Rows.Clear();

            // Agregar los jugadores conectados al DataGridView
            foreach (var jugador in conectados)
            {
                conectadosGrid.Rows.Add(jugador);
            }
        }

    }
}



