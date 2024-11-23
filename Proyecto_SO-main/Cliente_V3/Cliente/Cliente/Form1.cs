using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using InicioPartida;

namespace Cliente
{
    public partial class Form1 : Form
    {

        Socket server;
        Thread atender;
        List<string> conectados = new List<string>();
        public Form1()
        {
            InitializeComponent();
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

                switch (codigo)
                {
                    case 7:
                        MessageBox.Show(mensaje);
                        break;
                    case 1: //registro
                        MessageBox.Show(mensaje);
                        break;
                    case 2: //inicio de sesion
                        MessageBox.Show(mensaje);
                        break;
                    case 3: //consulta
                        MessageBox.Show(mensaje);
                        break;
                    case 4: //consulta
                        MessageBox.Show(mensaje);
                        break;
                    case 5: //consulta
                        MessageBox.Show(mensaje);
                        break; 
                    case 6: //actualizacion conectados
                        conectados.Clear();

                        // Obtener los nombres de los jugadores
                        string[] jugadores = mensaje.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        conectados.AddRange(jugadores);
                        Invoke(new Action(UpdateConectadosGrid));
                        break;
                }
            }
        }
        private void Conectarse_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");
                //pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                this.BackColor = Color.Red;
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }

        private void Desconectarse_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "0/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                this.BackColor = Color.White;
            }
            catch(Exception ex)
            {
                MessageBox.Show("No hay ningun servidor conectado.");
            }
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();

        }

        private void Iniciar_sesion_Click(object sender, EventArgs e)
        {
            string usuario = textBox_nombre.Text;
            string pswd = textBox_Contraseña.Text;

            // Enviamos al servidor el nombre tecleado
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pswd))
            {
                MessageBox.Show("Por favor, ingresa un nombre de usuario y una contraseña.");
                return;
            }
            string mensaje = "2/" + usuario + "/" + pswd;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }    

        private void Registrarse_Click(object sender, EventArgs e)
        {
            string usuario = textBox_nombre.Text;
            string pswd = textBox_Contraseña.Text;

            // Enviamos al servidor el nombre tecleado
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pswd))
            {
                MessageBox.Show("Por favor, ingresa un nombre de usuario y una contraseña.");
                return;
            }
            string mensaje = "1/" + usuario + "/" + pswd;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void IniciarPartida_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(server);
            f2.ShowDialog();
        }

        private void Consulta_Click(object sender, EventArgs e)
        {
            string mensaje;
            // Enviamos al servidor el nombre tecleado
            if (string.IsNullOrEmpty(textBox_Consulta.Text))
            {
                MessageBox.Show("Por favor, ingresa un ID.");
                return;
            }
            int id = Convert.ToInt32(textBox_Consulta.Text);
            if (Nombre.Checked == true)
            {
                mensaje = "3/" + id;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            if (Victorias.Checked == true)
            {
                mensaje = "4/" + id;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            if (Medallas.Checked == true)
            {
                mensaje = "5/" + id;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void ListaJugadores_Click(object sender, EventArgs e)
        {
            string mensaje = "6/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
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
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();

        }
    }
}
