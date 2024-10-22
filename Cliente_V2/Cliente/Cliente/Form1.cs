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
using InicioPartida;

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
            IPAddress direc = IPAddress.Parse("192.168.56.102");
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
                Consulta.Visible = false;
                label3.Visible = false;
                textBox_Consulta.Visible = false;
                Medallas.Visible = false;
                Nombre.Visible = false;
                Victorias.Visible = false;
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
            if (mensaje == "Inicio de sesion exitoso")
            {
                Consulta.Visible = true;
                label3.Visible = true;
                textBox_Consulta.Visible = true;
                Medallas.Visible = true;
                Nombre.Visible = true;
                Victorias.Visible = true;
            }
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

        private void IniciarPartida_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
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


            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(mensaje);
        }
    }
}
