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
        List<string> Jugadores_conectados = new List<string>();
        public Form1()
        {
            InitializeComponent();
            Desconectarse.Visible = false;
            IniciarPartida.Visible = false;
            label_ID.Visible = false;
            textBox_Consulta.Visible = false;
            Nombre.Visible = false;
            Victorias.Visible = false;
            Medallas.Visible = false;
            Consulta.Visible = false;
            conectadosGrid.Visible = false;
            Iniciar_sesion.Visible = false;
            Registrarse.Visible = false;
            chat.Visible = false;
            Mensaje.Visible = false;
            Enviar.Visible = false;
        }
        private string usuario;
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
                    case 1: //registro
                        MessageBox.Show(mensaje);
                        break;
                    case 2: //inicio de sesion
                        
                        conectados.Clear();

                        // Obtener los nombres de los jugadores
                        string[] jugadores = mensaje.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        conectados.AddRange(jugadores);
                        Invoke(new Action(Iniciar_Sesion));
                        Invoke(new Action(UpdateConectadosGrid));
                        
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
                    case 6://invitacion
                         var result =MessageBox.Show(mensaje+" te ha desafiado. ¿Aceptas?",
                            "Invitación", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            string mensaje_2 = "7/"+mensaje+"/"+usuario+"/si";
                            byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje_2);
                            server.Send(msg2);
                        }
                        if (result == DialogResult.No)
                        {
                            string mensaje_2 = "7/"+mensaje+"/"+usuario+"/no";
                            byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje_2);
                            server.Send(msg2);
                        }
                        break;
                    case 7:
                        MessageBox.Show(mensaje);
                        break;
                    case 8: //chat
                        Invoke(new Action(() => Chat(mensaje)));
                        break;
                    case 9:
                        Jugadores_conectados.Clear();
                        jugadores = mensaje.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Jugadores_conectados.AddRange(jugadores);
                        break;

                }
            }
        }
        private void Chat(string mensaje)
        {
            mensaje = chat.Text + "\n" + mensaje;
            chat.Text = mensaje + Environment.NewLine;
        }
        private void Iniciar_Sesion()
        {
            Iniciar_sesion.Visible = false;
            Registrarse.Visible = false;
            label_contraseña.Visible = false;
            textBox_Contraseña.Visible = false;
            IniciarPartida.Visible = true;
            label_ID.Visible = true;
            textBox_Consulta.Visible = true;
            Nombre.Visible = true;
            Victorias.Visible = true;
            Medallas.Visible = true;
            Consulta.Visible = true;
            conectadosGrid.Visible = true;
            chat.Visible = true;
            Mensaje.Visible = true;
            Enviar.Visible = true;
        }
        private void Conectarse_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("10.4.119.5");
            IPEndPoint ipep = new IPEndPoint(direc, 50064);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                //pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
                Conectrase.Visible =false;
                Desconectarse.Visible =true;
                Iniciar_sesion.Visible =true;
                Registrarse.Visible =true;

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
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                atender.Abort();
                conectados.Clear();
                conectadosGrid.Rows.Clear();
                this.BackColor = Color.White;
                Conectrase.Visible=true;
                Desconectarse.Visible=false;
                //Iniciar_sesion.Visible=false;
                Registrarse.Visible=false;
                IniciarPartida.Visible = false;
                label_ID.Visible = false;
                textBox_Consulta.Visible = false;
                Nombre.Visible = false;
                Victorias.Visible = false;
                Medallas.Visible = false;
                Consulta.Visible = false;
                label_contraseña.Visible = true;
                textBox_Contraseña.Visible = true;
                conectadosGrid.Visible = false;
                chat.Visible = false;
                Mensaje.Visible = false;
                Enviar.Visible = false;
                chat.Clear();


            }
            catch(Exception ex)
            {
                MessageBox.Show("No hay ningun servidor conectado.");
            }          
        }

        private void Iniciar_sesion_Click(object sender, EventArgs e)
        {
            usuario = textBox_nombre.Text;
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
            Form2 f2 = new Form2(server, conectados, usuario, atender, Jugadores_conectados);
            f2.ShowDialog();
        }

        private void Consulta_Click(object sender, EventArgs e)
        {
            try
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
            catch { MessageBox.Show("Por favor, ingresa un ID de tipo entero."); }
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
            try
            {
                //Mensaje de desconexión
                string mensaje = "0/";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // Nos desconectamos
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                atender.Abort();
            }
            catch (Exception ex) { }
            
        }
        private void Enviar_Click(object sender, EventArgs e)
        {
            string mensaje = "8/"+usuario+ "/"+ Mensaje.Text;
            if (string.IsNullOrEmpty(mensaje))
            {
                return;
            }
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            Mensaje.Clear();
        }
    }
}