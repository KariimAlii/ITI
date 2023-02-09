using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
namespace Lab11_File_Explorer
{
    public partial class FileExplorer : Form
    {
        string Path1;
        public FileExplorer()
        {
            InitializeComponent();
            //================ Adjust Window =================//
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            Path1 = "";

            //adjustListBox(listBox1, Path1, textBox1);
            initializeListBox(listBox1, textBox1);

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string name = listBox1.SelectedItem.ToString();
            if (name[name.Length - 1] == char.Parse(@"\")) Path1 = Path1 + name;
            else Path1 = Path1 + @"\" + name;
            adjustListBox(listBox1, Path1, textBox1);
        }
        public static void adjustListBox(ListBox listbox, string path, TextBox textbox)
        {
            listbox.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] dirs = dir.GetDirectories();
            for (int i = 0; i < dirs.Length; i++) listbox.Items.Add(dirs[i].ToString()); // "📁 " +

            FileInfo[] files = dir.GetFiles();
            for (int i = 0; i < files.Length; i++) listbox.Items.Add(files[i].ToString());

            textbox.Text = Path.GetFullPath(path);
        }
        public static void initializeListBox(ListBox listbox, TextBox textbox)
        {

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            for (int i = 0; i < allDrives.Length; i++) listbox.Items.Add(allDrives[i].ToString());
            textbox.Text = "";
        }
    }
}


// RESOURCES
// https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath?view=net-7.0
// https://www.c-sharpcorner.com/UploadFile/99aadd/working-with-the-directoryinfo-class-in-C-Sharp/
// https://learn.microsoft.com/en-us/dotnet/api/system.io.driveinfo.getdrives?view=net-6.0