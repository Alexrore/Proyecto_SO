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
        private string usuario;
        public Form2(Socket sock, List<string> Conectados, string Usuario, Thread atender)
        {
            server = sock;
            conectados = Conectados;
            usuario = Usuario;

            InitializeComponent();
            //UpdateConectadosGrid();
            /*ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();*/

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
        private void AtenderServidor()
        {
            while (true)
            {
                byte[] msg = new byte[80];
                server.Receive(msg);
                string[] trozos = Encoding.ASCII.GetString(msg).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];
                UpdateConectadosGrid();
                switch (codigo)
                {


                    case 6://invitacion
                        var result = MessageBox.Show(mensaje + " te ha desafiado. ¿Aceptas?",
                           "Invitación", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            string mensaje_2 = "7/" + mensaje + "/" + usuario + "/si";
                            byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje_2);
                            server.Send(msg2);
                        }
                        if (result == DialogResult.No)
                        {
                            string mensaje_2 = "7/" + mensaje + "/" + usuario + "/no";
                            byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje_2);
                            server.Send(msg2);
                        }
                        break;
                    case 7:
                        MessageBox.Show(mensaje);
                        break;

                }
            }
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
    }
}



