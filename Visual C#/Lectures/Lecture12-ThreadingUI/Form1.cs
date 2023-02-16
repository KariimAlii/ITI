using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture12_ThreadingUI
{


    #region Async Await
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void StartBtn_Click(object sender, EventArgs e)
        {
            DoWork();
        }
        async void DoWork()
        {
            int x = await Print();
            ResultTextBox.Text = x.ToString();
        }
        Task<int> Print()
        {
            return Task.Run(() =>
            {
                int count = 0;
                for (int i = 0; i < 2000; i++)
                {
                    count++;
                }
                return count;
            });
        }
    }
    #endregion

}

#region Threading with UI
//public partial class Form1 : Form
//{
//    public Form1()
//    {
//        InitializeComponent();
//    }
//    private void StartBtn_Click(object sender, EventArgs e)
//    {
//        Task<int> t = Task.Run(() => Print());
//        t.GetAwaiter().OnCompleted(() => UpdateResultBox(t));
//    }
//    int Print()
//    {
//        int count = 0;
//        for (int i = 0; i < 2000; i++)
//        {
//            count++;
//            ResultTextBox.Text = count.ToString();
//        }
//        return count;
//    }
//    void UpdateResultBox(Task<int> task)
//    {
//        ResultTextBox.Text = "Sub-Thread Finished!";
//    }
//    int Updating()
//    {
//        ResultTextBox.Text = "Hello From Sub-Thread!";
//        return 3;
//    }

//} 
#endregion

#region Main Thread Invoke()
//public delegate void MyDel(int count);
//public partial class Form1 : Form
//{
//    public Form1()
//    {
//        InitializeComponent();
//    }
//    private void StartBtn_Click(object sender, EventArgs e)
//    {
//        Task<int> t = Task.Run(() => Print());
//    }

//    int Print()
//    {
//        MyDel del = new MyDel(UpdateResultBox);
//        int count = 0;
//        for (int i = 0; i < 2000; i++)
//        {
//            count++;
//            this.Invoke(del, new object[] { count });
//        }
//        return count;
//    }

//    void UpdateResultBox(int count)
//    {
//        ResultTextBox.Text = count.ToString();
//    }
//}
#endregion