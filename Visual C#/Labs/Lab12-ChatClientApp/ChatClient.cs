using System;
using System.IO;
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
        private async void ReceiveMessage()
        {
            char[] str = new char[100];
            int x = await reader.ReadAsync(str, 0, 100);
            ChatBox.Items.Add("Server: " + new string(str));
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
            client = new TcpClient("192.168.1.5", 5000);
            stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            ReceiveConnectionMessage();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            client.Close();
            StatusBox.Text = "Disconnected";
            StatusBox.BackColor = System.Drawing.Color.IndianRed;
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            writer.Write(NewMessageBox.Text);
            ChatBox.Items.Add("Client: " + NewMessageBox.Text);
            NewMessageBox.Text = "";
        }

        private void ReceiveBtn_Click(object sender, EventArgs e)
        {
            ReceiveMessage();
        }

        private void ChatClient_Load(object sender, EventArgs e)
        {
            Task.Run(() => CheckConnection());
            //CheckConnection();
        }
    }
}
