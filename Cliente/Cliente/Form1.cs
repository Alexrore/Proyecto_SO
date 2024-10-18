using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form1 : Form
    {

        Socket server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Conectrase_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                this.BackColor = Color.Green;
            }
            catch (SocketException ex)
            { this.BackColor = Color.Red;
                return;
            }
        }

        private void Desconectarse_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = $"0/";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // Nos desconectamos
                this.BackColor = Color.White;
                server.Shutdown(SocketShutdown.Both);

                server.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No hay ningun servidor conectado.");
            }

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
            string mensaje = "2/"+usuario+"/"+pswd;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(mensaje);
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

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(mensaje);
        }
    }
}
