using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
namespace Lab11_File_Explorer
{
    public enum Target
    {
        Drive, Directory, File
    }
    public partial class FileExplorer : Form
    {
        string Path1;
        string Path2;
        Target targetType;
        public FileExplorer()
        {
            InitializeComponent();
            //================ Adjust Window =================//
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            Path1 = "";
            Path2 = "";

            //adjustListBox(listBox1, Path1, textBox1);
            initializeListBox(listBox1, textBox1);
            initializeListBox(listBox2, textBox2);

        }


        public static void initializeListBox(ListBox listbox, TextBox textbox)
        {
            listbox.Items.Clear();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            for (int i = 0; i < allDrives.Length; i++) listbox.Items.Add(allDrives[i].ToString());
            textbox.Text = "";
        }
        public static void adjustListBox(ListBox listbox, string path, TextBox textbox)
        {
            listbox.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] dirs = dir.GetDirectories();
            for (int i = 0; i < dirs.Length; i++) listbox.Items.Add(dirs[i].ToString()); // "📁 " +

            FileInfo[] files = dir.GetFiles();
            for (int i = 0; i < files.Length; i++) listbox.Items.Add(files[i].ToString());
            listbox.Items.Add(".");
            listbox.Items.Add("..");
            textbox.Text = Path.GetFullPath(path);
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string name = listBox1.SelectedItem.ToString();
            if (name == ".")
            {
                DirectoryInfo dir = new DirectoryInfo(Path1);
                if (dir.Parent == null) targetType = Target.Drive;
                else targetType = Target.Directory;
                switch (targetType)
                {
                    case Target.Drive:
                        Path1 = "";
                        textBox1.Text = Path1;
                        initializeListBox(listBox1, textBox1);
                        break;
                    case Target.Directory:
                        Path1 = dir.Parent.FullName;
                        adjustListBox(listBox1, Path1, textBox1);
                        break;
                }

            }
            else if (name == "..")
            {
                Path1 = "";
                textBox1.Text = Path1;
                initializeListBox(listBox1, textBox1);
            }
            else
            {
                if (name[name.Length - 1] == char.Parse(@"\")) targetType = Target.Drive;
                else targetType = Target.Directory;
                switch (targetType)
                {
                    case Target.Drive:
                        Path1 = Path1 + name;
                        adjustListBox(listBox1, Path1, textBox1);
                        break;
                    case Target.Directory:
                        Path1 = Path1 + @"\" + name;
                        adjustListBox(listBox1, Path1, textBox1);
                        break;
                    case Target.File:
                        MessageBox.Show("File Clicked!");
                        break;
                }
            }


            //catch
            //{
            //    MessageBox.Show("Drive Not Found:(");
            //    initializeListBox(listBox1, textBox1);
            //}

        }
        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string name = listBox2.SelectedItem.ToString();
            if (name == ".")
            {
                DirectoryInfo dir = new DirectoryInfo(Path2);
                if (dir.Parent == null) targetType = Target.Drive;
                else targetType = Target.Directory;
                switch (targetType)
                {
                    case Target.Drive:
                        Path2 = "";
                        textBox2.Text = Path2;
                        initializeListBox(listBox2, textBox2);
                        break;
                    case Target.Directory:
                        Path1 = dir.Parent.FullName;
                        adjustListBox(listBox2, Path2, textBox2);
                        break;
                }

            }
            else if (name == "..")
            {
                Path2 = "";
                textBox2.Text = Path2;
                initializeListBox(listBox2, textBox2);
            }
            else
            {
                if (name[name.Length - 1] == char.Parse(@"\")) targetType = Target.Drive;
                else targetType = Target.Directory;
                switch (targetType)
                {
                    case Target.Drive:
                        Path2 = Path2 + name;
                        adjustListBox(listBox2, Path2, textBox2);
                        break;
                    case Target.Directory:
                        Path2 = Path2 + @"\" + name;
                        adjustListBox(listBox2, Path2, textBox2);
                        break;
                    case Target.File:
                        MessageBox.Show("File Clicked!");
                        break;
                }
            }
            //catch
            //{
            //    MessageBox.Show("Drive Not Found:(");
            //    initializeListBox(listBox2, textBox2);
            //}

        }
    }
}


// RESOURCES
// https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath?view=net-7.0
// https://www.c-sharpcorner.com/UploadFile/99aadd/working-with-the-directoryinfo-class-in-C-Sharp/
// https://learn.microsoft.com/en-us/dotnet/api/system.io.driveinfo.getdrives?view=net-6.0