using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;



class SimpleTcpSocketClient
{
    private string m_Usuario_Conectado;
    private string m_Password;
    private string m_Invite;
    private string m_Mensaje_Chat;
    private string m_Personas_Jugadas;
    private string m_Fecha;
    private Socket socket;
    public static void Main()
    {
     
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Console.WriteLine("Write the server IP:");
        string ip = Console.ReadLine();
        Console.WriteLine("Write the server Gate:");
        int gate = Int32.Parse(Console.ReadLine());
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), gate);
        SimpleTcpSocketClient client = new SimpleTcpSocketClient();
        try
        {
            socket.Connect(remoteEP);
        }
        catch (SocketException e)
        {
            Console.WriteLine("Unable to connect to server. ");
            Console.WriteLine(e);
            return;
        }

        byte[] data = new byte[1024];
        int dataSize = socket.Receive(data);
        Console.WriteLine(Encoding.ASCII.GetString(data, 0, dataSize));
        String input = null;
        while (true)
        {
            Console.Write("Enter Message for Server <Enter to Stop>: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                break;
            if (input == "1")
            {
                client.RegisterOrLogin();
            }

            socket.Send(Encoding.ASCII.GetBytes(input));

           // dataSize = socket.Receive(data);
            //Console.WriteLine("Server response: " + Encoding.ASCII.GetString(data, 0, dataSize));
        }

        
        Console.WriteLine("Disconnecting from Server..");
        socket.Shutdown(SocketShutdown.Both);
        socket.Close();

    }

    public void RegisterOrLogin()
    {
        string userName = m_Usuario_Conectado;
        string password = m_Password;

        Console.WriteLine("Write the User name: ");
        userName = Console.ReadLine();
        Console.WriteLine("Write User Password: ");
        password = Console.ReadLine();

    }

    public void SendInvite()
    {
        string invite = m_Invite;

        // Lógica para invitar a los jugadores
    }

    public void SendChatMessage()
    {
        string chatMessage = m_Mensaje_Chat;

        // Lógica para enviar el mensaje de chat
    }

    public void QueryPlayedGames()
    {
        string player = m_Personas_Jugadas;
        string date = m_Fecha;

        // Lógica para consultar las partidas jugadas con el jugador y en la fecha indicada
    }


    public void Log_In()        //Funcion del boton login
    {
        if (string.IsNullOrEmpty(m_Usuario_Conectado))
        {
            if (!string.IsNullOrEmpty(m_Usuario_Conectado) && !string.IsNullOrEmpty(m_Password))
            {
                string NOMBRE = m_Usuario_Conectado;
                string CONTRASEÑA = m_Password;
                byte[] Mensaje_Cliente = Encoding.ASCII.GetBytes("1/" + NOMBRE + "/" + CONTRASEÑA);
                socket.Send(Mensaje_Cliente);
            }
           

        }
       
    }
}
