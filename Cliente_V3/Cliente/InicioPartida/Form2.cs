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
        }

        private void f2_Load(object sender, EventArgs e)
        {
            Tablero.BackgroundImageLayout = ImageLayout.Stretch;
            labelnumero.Text = "?";
            Tablero.Visible = true;

        }

        private void ConnectToServer()
        {
            // Crear un socket para conectarse al servidor
            clienteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clienteSocket.Connect("127.0.0.1", 9050);  // Dirección y puerto del servidor

            // Iniciar un hilo para recibir datos
            Task.Run(() => ReceiveData());
        }



        private void ReceiveData()
        {
            byte[] buffer = new byte[1024];

            while (true)
            {
                try
                {
                    int bytesReceived = clienteSocket.Receive(buffer);
                    if (bytesReceived > 0)
                    {
                        string data = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                        // Si el servidor envía la lista de jugadores
                        if (data.StartsWith("Jugadores en linea:"))
                        {
                            // Limpiar la lista de jugadores conectados
                            conectados.Clear();

                            // Obtener los nombres de los jugadores
                            string[] jugadores = data.Substring("Jugadores en linea:".Length).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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

        private void listaconectados_Click(object sender, EventArgs e)
        {
            // Mostrar la lista de jugadores conectados al hacer clic en el botón
            UpdateConectadosGrid();
        }
    }
}



