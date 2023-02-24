using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab12_ChatClientApp
{
    public partial class ChatClient : Form
    {
        TcpClient client;
        StreamReader reader;
        StreamWriter writer;
        NetworkStream stream;
        bool flag = true;
        bool isConnected;
        SynchronizationContext context;
        public ChatClient()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
        }

        private void Disconnect()
        {
            isConnected = false;
            writer.Write("ClientStopped");

            //stream.Close(); //client.GetStream().Close();
            //client.Close();

            context.Post((object obj) => StatusBox.Text = "Disconnected", null);
            context.Post((object obj) => StatusBox.BackColor = System.Drawing.Color.IndianRed, null);
        }
        private async void ReceiveMessages()
        {

            while (flag)
            {
                char[] charArr = new char[100];
                int x = await reader.ReadAsync(charArr, 0, 100);
                string str = new string(charArr);
                if (str.Contains("ServerDisconnected"))
                {
                    //Disconnect();
                    isConnected = false;
                    context.Post((object obj) => StatusBox.Text = "Disconnected", null);
                    context.Post((object obj) => StatusBox.BackColor = System.Drawing.Color.IndianRed, null);
                    flag = false;
                }
                //else if (!isConnected) 
                //else if (str.Contains("ClientStopped"))
                //{
                //    flag = false;
                //    MessageBox.Show("Stopped at client!");
                //}
                else if (str.Contains("Connected.."))
                {
                    context.Post((object obj) => StatusBox.Text = str, null);
                    context.Post((object obj) => StatusBox.BackColor = System.Drawing.Color.Chartreuse, null);
                }
                else
                {
                    ChatBox.Items.Add(str);
                }

            }

        }


        private void CheckConnection()
        {
            while (true)
            {
                //if (!client.Connected) StatusBox.Text = "You are Disconnected!";
                //if (!client.Client.Connected) MessageBox.Show("Disconnected");
                //ReceiveMessage();
            }

        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {

            isConnected = true;
            client = new TcpClient("192.168.1.5", 5000);
            stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            flag = true;
            Task.Run(() => ReceiveMessages());


        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //Task.Run(() => Disconnect());
            flag = false;
            Disconnect();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {

            writer.Write("Client: " + NewMessageBox.Text);

            context.Post((object obj) => ChatBox.Items.Add("Client: " + NewMessageBox.Text), null);
            context.Post((object obj) => NewMessageBox.Text = "", null);
        }



        private void ChatClient_Load(object sender, EventArgs e)
        {
            //Task.Run(() => CheckConnection());
            //CheckConnection();
        }
    }
}


//https://www.geeksforgeeks.org/c-sharp-program-to-find-the-ip-address-of-the-machine/
//http://csharp.net-informations.com/communications/csharp-chat-server.htm
//http://csharp.net-informations.com/communications/csharp-chat-client.htm
//http://csharp.net-informations.com/communications/csharp-ip-address.htm
//https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcpclient.close?view=net-6.0