using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
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
        bool isConnected;
        public ChatClient()
        {
            InitializeComponent();

        }
        private async void ReceiveConnectionMessage()
        {
            char[] str = new char[100];
            int x = await reader.ReadAsync(str, 0, 100);
            StatusBox.Text = new string(str);
            StatusBox.BackColor = System.Drawing.Color.Chartreuse;
        }

        private void Disconnect()
        {
            isConnected = false;
            writer.Write("ClientStopped");
            stream.Close();
            client.Close();
            StatusBox.Text = "Disconnected";
            StatusBox.BackColor = System.Drawing.Color.IndianRed;
        }
        private async void ReceiveMessages()
        {
            bool flag = true;
            while (flag)
            {
                char[] charArr = new char[100];
                int x = await reader.ReadAsync(charArr, 0, 100);
                string str = new string(charArr);
                if (str.Contains("Disconnected"))
                {
                    Disconnect();
                    flag = false;
                }
                //else if (!isConnected) 
                else if (str.Contains("ClientStopped"))
                {
                    flag = false;
                    MessageBox.Show("Stopped at client!");
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

            ReceiveConnectionMessage();
            Task.Run(() => ReceiveMessages());


        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Task.Run(() => Disconnect());
            //Disconnect();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            writer.Write("Client: " + NewMessageBox.Text);
            ChatBox.Items.Add("Client: " + NewMessageBox.Text);
            NewMessageBox.Text = "";
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