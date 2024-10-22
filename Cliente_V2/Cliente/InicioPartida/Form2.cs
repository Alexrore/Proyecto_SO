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



        private void CargarJugadoresConectados()
        {
            // Supongamos que tienes un socket conectado al servidor
            Socket clienteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Este socket debe estar correctamente inicializado y conectado.

            // Buffer para recibir datos
            byte[] buffer = new byte[1024];

            try
            {
                // Recibir la cantidad de jugadores conectados
                int bytesRecibidos = clienteSocket.Receive(buffer, sizeof(int), SocketFlags.None);

                if (bytesRecibidos == sizeof(int)) // Asegúrate de que se recibieron los bytes esperados
                {
                    int jugadoresConectadosCount = BitConverter.ToInt32(buffer, 0);

                    // Limpiar el DataGridView antes de añadir los datos
                    conectadosGrid.Rows.Clear();

                    // Configurar el DataGridView con una columna para los jugadores conectados
                    conectadosGrid.ColumnCount = 1;
                    conectadosGrid.Columns[0].Name = "Jugadores Conectados";

                    // Verifica que haya jugadores conectados antes de añadir filas
                    if (jugadoresConectadosCount > 0)
                    {
                        // Establecer el RowCount antes de añadir datos
                        conectadosGrid.RowCount = jugadoresConectadosCount;

                        // Recibir los nombres de los jugadores y añadirlos al DataGridView
                        for (int i = 0; i < jugadoresConectadosCount; i++)
                        {
                            // Recibir el tamaño del nombre del jugador
                            int nombreLength = clienteSocket.Receive(buffer);

                            // Asegúrate de que se recibieron los bytes esperados
                            if (nombreLength > 0)
                            {
                                // Recibir el nombre del jugador
                                string nombreJugador = Encoding.UTF8.GetString(buffer, 0, nombreLength);

                                // Añadir el nombre del jugador al DataGridView en la fila correspondiente
                                conectadosGrid.Rows[i].Cells[0].Value = nombreJugador; // Añadir directamente a la celda
                            }
                        }
                    }
                    else
                    {
                        // Si no hay jugadores, limpia el DataGridView y muestra un mensaje
                        conectadosGrid.Rows.Clear();
                        MessageBox.Show("No hay jugadores conectados.");
                    }
                }
                else
                {
                    MessageBox.Show("Error al recibir la cantidad de jugadores conectados.");
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Error de socket: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }





        private void listaconectados_Click(object sender, EventArgs e)
        {
            conectadosGrid.ColumnCount = 1;
            conectadosGrid.RowCount = conectados.Count;
            for (int i = 0; i < conectados.Count; i++)
                conectadosGrid.Rows[i].Cells[0].Value = conectados[i];
        }

        private void conectadosGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
