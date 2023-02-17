using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Lab12_ChatServerApp
{
    public partial class ChatServer : Form
    {
        TcpListener listener;
        StreamWriter writer;
        StreamReader reader;
        NetworkStream stream;
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

                stream = serverClient.GetStream(); //stream.Write()

                writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                writer.Write("Connected");   //writer.Flush();

                reader = new StreamReader(stream);

                StatusBox.Text = "Connection Accepted !";
                StatusBox.BackColor = System.Drawing.Color.Chartreuse;
            }
        }
        private void StopListening()
        {

            writer.Write("Disconnected");

            StatusBox.Text = "Server Stopped...";
            StatusBox.BackColor = System.Drawing.Color.IndianRed;
            listener.Stop();
        }
        //System.Drawing.Color.Chartreuse
        //System.Drawing.Color.IndianRed
        //System.Drawing.SystemColors.ButtonHighlight
        private async void ReceiveMessage()
        {
            char[] str = new char[100];
            int x = await reader.ReadAsync(str, 0, 100);

            ChatBox.Items.Add("Client: " + new string(str));
        }
        private void ListenBtn_Click(object sender, EventArgs e)
        {
            listener.Start();
            StatusBox.Text = "Listening...";
            StatusBox.BackColor = System.Drawing.Color.Chartreuse;
            Task.Run(() => AcceptConnections());
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Task.Run(() => StopListening());
        }

        private void ReceiveBtn_Click(object sender, EventArgs e)
        {
            ReceiveMessage();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            writer.Write(NewMessageBox.Text);
            ChatBox.Items.Add("Server: " + NewMessageBox.Text);
            NewMessageBox.Text = "";
        }
    }
}
