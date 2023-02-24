using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.Threading;
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
        bool flag;
        bool isListening;
        SynchronizationContext context;
        public ChatServer()
        {
            InitializeComponent();

            IPAddress ip = new IPAddress(new byte[] { 192, 168, 1, 5 });
            //IPAddress ip = IPAddress.Parse("192.168.1.5");
            listener = new TcpListener(ip, 5000);
            context = SynchronizationContext.Current;
        }

        private async void ReceiveMessages()
        {
            //flag = true;
            while (flag)
            {
                char[] charArr = new char[100];
                int x = await reader.ReadAsync(charArr, 0, 100);
                string str = new string(charArr);

                //if (!str.Contains("ServerDisconnected") && !str.Contains("ClientStopped")) ChatBox.Items.Add(str);
                if (str.Contains("ServerDisconnected"))
                {
                    flag = false;
                }
                else if (str.Contains("ClientStopped"))
                {
                    flag = false;

                    //if (isListening)
                    //{
                    //    StatusBox.Text = "Listening...";
                    //    StatusBox.BackColor = System.Drawing.Color.Chartreuse;
                    //    //flag = true;
                    //}
                    //else flag = false;
                    //MessageBox.Show("Bye bye My Client!");
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
                writer.Write("Connected..");   //writer.Flush();
                reader = new StreamReader(stream);
                context.Post((object obj) => StatusBox.Text = "Connection Accepted !", null);
                context.Post((object obj) => StatusBox.BackColor = System.Drawing.Color.Chartreuse, null);
            }
        }
        private void StopListening()
        {

            writer.Write("ServerDisconnected");
            context.Post((object obj) => StatusBox.Text = "Server Stopped...", null);
            context.Post((object obj) => StatusBox.BackColor = System.Drawing.Color.IndianRed, null);
            listener.Stop();
        }

        private void ListenBtn_Click(object sender, EventArgs e)
        {
            listener.Start();
            //isListening = true;
            flag = true;

            context.Post((object obj) => StatusBox.Text = "Listening...", null);
            context.Post((object obj) => StatusBox.BackColor = System.Drawing.Color.Chartreuse, null);

            Task.Run(() => AcceptConnections());
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //isListening = false;
            flag = false;
            Task.Run(() => StopListening());
            //StopListening();
        }



        private void SendBtn_Click(object sender, EventArgs e)
        {
            writer.Write("Server: " + NewMessageBox.Text);
            context.Post((object obj) => ChatBox.Items.Add("Server: " + NewMessageBox.Text), null);
            context.Post((object obj) => NewMessageBox.Text = "", null);
        }
    }
}

