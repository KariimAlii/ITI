using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Lab12_ChatServerApp
{
    public partial class ChatServer : Form
    {
        TcpListener listener;
        public ChatServer()
        {
            InitializeComponent();

            IPAddress ip = new IPAddress(new byte[] { 192, 168, 1, 5 });
            //IPAddress ip = IPAddress.Parse("192.168.1.5");
            listener = new TcpListener(ip, 5000);
        }
        private void AcceptConnections()
        {
            while (true)
            {
                TcpClient serverClient = listener.AcceptTcpClient();

                NetworkStream stream = serverClient.GetStream(); //stream.Write()

                StreamWriter writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                writer.Write("You are Connected Now...");   //writer.Flush();

                ConnectionLabel.Text = "Connection Accepted !";
            }
        }
        private void ListenBtn_Click(object sender, EventArgs e)
        {
            listener.Start();
            ConnectionLabel.Text = "Listening...";
            Task.Run(() => AcceptConnections());
        }
    }
}
