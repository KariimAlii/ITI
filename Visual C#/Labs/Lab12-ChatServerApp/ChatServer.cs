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

        private async void ReceiveMessages()
        {
            bool flag = true;
            while (flag)
            {
                char[] charArr = new char[100];
                int x = await reader.ReadAsync(charArr, 0, 100);
                string str = new string(charArr);
                //ChatBox.Items.Add(str);


                if (str.Contains("ServerDisconnected"))
                {
                    flag = false;
                }
                else if (str.Contains("ClientStopped"))
                {
                    flag = false;
                }
                else
                {
                    ChatBox.Items.Add(str);
                }

            }

        }
        private void AcceptConnections()
        {
            while (true)
            {
                TcpClient serverClient = listener.AcceptTcpClient();

                stream = serverClient.GetStream(); //stream.Write()
                Task.Run(() => ReceiveMessages());
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


            writer.Write("ServerDisconnected");
            StatusBox.Text = "Server Stopped...";
            StatusBox.BackColor = System.Drawing.Color.IndianRed;
            listener.Stop();
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
            //StopListening();
        }



        private void SendBtn_Click(object sender, EventArgs e)
        {
            writer.Write("Server: " + NewMessageBox.Text);
            ChatBox.Items.Add("Server: " + NewMessageBox.Text);
            NewMessageBox.Text = "";
        }
    }
}
