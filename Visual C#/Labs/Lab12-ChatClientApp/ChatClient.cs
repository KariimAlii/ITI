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
        public ChatClient()
        {
            InitializeComponent();

        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            client = new TcpClient("192.168.1.5", 5000);
            NetworkStream stream = client.GetStream();
            reader = new StreamReader(stream);
            ReceiveMessage();
        }
        private async void ReceiveMessage()
        {
            char[] str = new char[100];
            int x = await reader.ReadAsync(str, 0, 100);
            MessageLabel.Text = new string(str);
        }
    }
}
