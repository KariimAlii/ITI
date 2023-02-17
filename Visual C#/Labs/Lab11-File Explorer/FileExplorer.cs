using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;

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
        int nDirectories1;
        int nFiles1;
        int nDirectories2;
        int nFiles2;
        int LastAccessedPanel;
        public FileExplorer()
        {
            InitializeComponent();
            //================ Adjust Window =================//
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            Path1 = "";
            Path2 = "";
            initializeListBox(listBox1, textBox1);
            initializeListBox(listBox2, textBox2);

        }


        public static void initializeListBox(ListBox listbox, TextBox textbox)
        {
            listbox.Items.Clear();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            for (int i = 0; i < allDrives.Length; i++) listbox.Items.Add("📁 " + allDrives[i].ToString());
            textbox.Text = "";
        }
        public static void adjustListBox(ListBox listbox, string path, TextBox textbox, ref int nDirectories, ref int nFiles)
        {
            nDirectories = nFiles = 0;

            listbox.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] dirs = dir.GetDirectories();
            for (int i = 0; i < dirs.Length; i++)
            {
                listbox.Items.Add("📁 " + dirs[i].ToString());
                nDirectories++;
            }

            FileInfo[] files = dir.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                listbox.Items.Add(files[i].ToString());
                nFiles++;
            }
            listbox.Items.Add(".");
            listbox.Items.Add("..");
            textbox.Text = Path.GetFullPath(path);
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            LastAccessedPanel = 1;
            string name = listBox1.SelectedItem.ToString();
            int index = listBox1.Items.IndexOf(listBox1.SelectedItem);
            if (name.Length >= 3) name = listBox1.SelectedItem.ToString().Substring(3);
            //MessageBox.Show($"Name is ,{name},");
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
                        adjustListBox(listBox1, Path1, textBox1, ref nDirectories1, ref nFiles1);
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
                else if (index >= 0 && index < nDirectories1) targetType = Target.Directory;
                else targetType = Target.File;
                switch (targetType)
                {
                    case Target.Drive:
                        Path1 = Path1 + name;
                        adjustListBox(listBox1, Path1, textBox1, ref nDirectories1, ref nFiles1);
                        break;
                    case Target.Directory:
                        if (Path1[Path1.Length - 1] == char.Parse(@"\")) Path1 = Path1 + name;
                        else Path1 = Path1 + @"\" + name;
                        adjustListBox(listBox1, Path1, textBox1, ref nDirectories1, ref nFiles1);
                        break;
                    case Target.File:
                        name = listBox1.SelectedItem.ToString();
                        Path1 = Path1 + @"\" + name;
                        Process.Start(Path1);
                        Path1 = textBox1.Text;
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
            LastAccessedPanel = 2;
            string name = listBox2.SelectedItem.ToString();
            int index = listBox2.Items.IndexOf(listBox2.SelectedItem);
            if (name.Length >= 3) name = listBox2.SelectedItem.ToString().Substring(3);
            //MessageBox.Show($"Name is ,{name},");
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
                        Path2 = dir.Parent.FullName;
                        adjustListBox(listBox2, Path2, textBox2, ref nDirectories2, ref nFiles2);
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
                else if (index >= 0 && index < nDirectories2) targetType = Target.Directory;
                else targetType = Target.File;
                switch (targetType)
                {
                    case Target.Drive:
                        Path2 = Path2 + name;
                        adjustListBox(listBox2, Path2, textBox2, ref nDirectories2, ref nFiles2);
                        break;
                    case Target.Directory:
                        if (Path2[Path2.Length - 1] == char.Parse(@"\")) Path2 = Path2 + name;
                        else Path2 = Path2 + @"\" + name;
                        adjustListBox(listBox2, Path2, textBox2, ref nDirectories2, ref nFiles2);
                        break;
                    case Target.File:
                        name = listBox2.SelectedItem.ToString();
                        Path2 = Path2 + @"\" + name;
                        Process.Start(Path2);
                        Path2 = textBox2.Text;
                        break;
                }
            }

            //catch
            //{
            //    MessageBox.Show("Drive Not Found:(");
            //    initializeListBox(listBox2, textBox2);
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = listBox1.SelectedItem.ToString();
                int index = listBox1.Items.IndexOf(listBox1.SelectedItem);

                if (name[name.Length - 1] == char.Parse(@"\")) targetType = Target.Drive;
                else if (index >= 0 && index < nDirectories1)
                {
                    targetType = Target.Directory;
                    name = listBox1.SelectedItem.ToString().Substring(3);
                }
                else targetType = Target.File;

                switch (targetType)
                {

                    case Target.Directory:
                        Directory.Move(Path1 + @"\" + name, Path2 + @"\" + name);
                        break;
                    case Target.File:
                        File.Move(Path1 + @"\" + name, Path2 + @"\" + name);
                        break;
                }

                adjustListBox(listBox1, Path1, textBox1, ref nDirectories1, ref nFiles1);
                adjustListBox(listBox2, Path2, textBox2, ref nDirectories2, ref nFiles2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select an Item to Move!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string name = listBox2.SelectedItem.ToString();
                int index = listBox2.Items.IndexOf(listBox2.SelectedItem);

                if (name[name.Length - 1] == char.Parse(@"\")) targetType = Target.Drive;
                else if (index >= 0 && index < nDirectories2)
                {
                    targetType = Target.Directory;
                    name = listBox2.SelectedItem.ToString().Substring(3);
                }
                else targetType = Target.File;

                switch (targetType)
                {

                    case Target.Directory:
                        Directory.Move(Path2 + @"\" + name, Path1 + @"\" + name);
                        break;
                    case Target.File:
                        File.Move(Path2 + @"\" + name, Path1 + @"\" + name);
                        break;
                }

                adjustListBox(listBox1, Path1, textBox1, ref nDirectories1, ref nFiles1);
                adjustListBox(listBox2, Path2, textBox2, ref nDirectories2, ref nFiles2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select an Item to Move!!");
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            LastAccessedPanel = 1;
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            LastAccessedPanel = 2;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            switch (LastAccessedPanel)
            {
                case 1:
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
                            adjustListBox(listBox1, Path1, textBox1, ref nDirectories1, ref nFiles1);
                            break;
                    }
                    break;
                case 2:
                    DirectoryInfo dir2 = new DirectoryInfo(Path2);
                    if (dir2.Parent == null) targetType = Target.Drive;
                    else targetType = Target.Directory;
                    switch (targetType)
                    {
                        case Target.Drive:
                            Path2 = "";
                            textBox2.Text = Path2;
                            initializeListBox(listBox2, textBox2);
                            break;
                        case Target.Directory:
                            Path2 = dir2.Parent.FullName;
                            adjustListBox(listBox2, Path2, textBox2, ref nDirectories2, ref nFiles2);
                            break;
                    }
                    break;
            }
        }
        public static void CopyDirectory(DirectoryInfo Source, DirectoryInfo Target)
        {
            foreach (DirectoryInfo SourceChildDir in Source.GetDirectories())
            {
                CopyDirectory(SourceChildDir, Target.CreateSubdirectory(SourceChildDir.Name));
            }
            foreach (FileInfo SourceChildFile in Source.GetFiles())
            {
                //File.Copy(SourceChildFile.FullName, Target.FullName + @"\" + SourceChildFile.Name);
                SourceChildFile.CopyTo(Path.Combine(Target.FullName, SourceChildFile.Name), true);
            }
        }
        private void copyBtn_Click(object sender, EventArgs e)
        {
            switch (LastAccessedPanel)
            {
                case 1:
                    string name = listBox1.SelectedItem.ToString();
                    int index = listBox1.Items.IndexOf(listBox1.SelectedItem);
                    //if (name.Length >= 3 && index >= 0 && index < nDirectories1) name = listBox1.SelectedItem.ToString().Substring(3);


                    if (name[name.Length - 1] == char.Parse(@"\")) targetType = Target.Drive;
                    else if (index >= 0 && index < nDirectories1)
                    {
                        targetType = Target.Directory;
                        name = listBox1.SelectedItem.ToString().Substring(3);
                    }
                    else targetType = Target.File;

                    switch (targetType)
                    {

                        case Target.Directory:
                            DirectoryInfo SourceDirectory = new DirectoryInfo(Path.Combine(Path1, name));
                            DirectoryInfo TargetDirectory = new DirectoryInfo(Path2);
                            TargetDirectory = TargetDirectory.CreateSubdirectory(name);
                            CopyDirectory(SourceDirectory, TargetDirectory);
                            break;
                        case Target.File:
                            FileInfo SourceFile = new FileInfo(Path.Combine(Path1, name));
                            DirectoryInfo _TargetDirectory = new DirectoryInfo(Path2);
                            SourceFile.CopyTo(Path.Combine(_TargetDirectory.FullName, SourceFile.Name), true);
                            break;
                    }
                    adjustListBox(listBox1, Path1, textBox1, ref nDirectories1, ref nFiles1);
                    adjustListBox(listBox2, Path2, textBox2, ref nDirectories2, ref nFiles2);
                    break;
                case 2:
                    string _name = listBox2.SelectedItem.ToString();
                    int _index = listBox2.Items.IndexOf(listBox2.SelectedItem);

                    if (_name[_name.Length - 1] == char.Parse(@"\")) targetType = Target.Drive;
                    else if (_index >= 0 && _index < nDirectories2)
                    {
                        targetType = Target.Directory;
                        _name = listBox2.SelectedItem.ToString().Substring(3);
                    }
                    else targetType = Target.File;

                    switch (targetType)
                    {

                        case Target.Directory:
                            DirectoryInfo SourceDirectory = new DirectoryInfo(Path.Combine(Path2, _name));
                            DirectoryInfo TargetDirectory = new DirectoryInfo(Path1);
                            TargetDirectory = TargetDirectory.CreateSubdirectory(_name);
                            CopyDirectory(SourceDirectory, TargetDirectory);
                            break;
                        case Target.File:
                            FileInfo SourceFile = new FileInfo(Path.Combine(Path2, _name));
                            DirectoryInfo _TargetDirectory = new DirectoryInfo(Path1);
                            SourceFile.CopyTo(Path.Combine(_TargetDirectory.FullName, SourceFile.Name), true);
                            break;
                    }
                    adjustListBox(listBox1, Path1, textBox1, ref nDirectories1, ref nFiles1);
                    adjustListBox(listBox2, Path2, textBox2, ref nDirectories2, ref nFiles2);
                    break;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            switch (LastAccessedPanel)
            {
                case 1:
                    string name = listBox1.SelectedItem.ToString();
                    int index = listBox1.Items.IndexOf(listBox1.SelectedItem);
                    //if (name.Length >= 3) name = listBox1.SelectedItem.ToString().Substring(3);


                    if (name[name.Length - 1] == char.Parse(@"\")) targetType = Target.Drive;
                    else if (index >= 0 && index < nDirectories1)
                    {
                        targetType = Target.Directory;
                        name = listBox1.SelectedItem.ToString().Substring(3);
                    }
                    else targetType = Target.File;

                    switch (targetType)
                    {

                        case Target.Directory:
                            Directory.Delete(Path1 + @"\" + name, true);
                            break;
                        case Target.File:
                            File.Delete(Path1 + @"\" + name);
                            break;
                    }
                    adjustListBox(listBox1, Path1, textBox1, ref nDirectories1, ref nFiles1);
                    adjustListBox(listBox2, Path2, textBox2, ref nDirectories2, ref nFiles2);
                    break;
                case 2:
                    string _name = listBox2.SelectedItem.ToString();
                    int _index = listBox2.Items.IndexOf(listBox2.SelectedItem);
                    //if (_name.Length >= 3) _name = listBox2.SelectedItem.ToString().Substring(3);

                    if (_name[_name.Length - 1] == char.Parse(@"\")) targetType = Target.Drive;
                    else if (_index >= 0 && _index < nDirectories2)
                    {
                        targetType = Target.Directory;
                        _name = listBox2.SelectedItem.ToString().Substring(3);
                    }
                    else targetType = Target.File;

                    switch (targetType)
                    {

                        case Target.Directory:
                            Directory.Delete(Path2 + @"\" + _name, true);
                            break;
                        case Target.File:
                            File.Delete(Path2 + @"\" + _name);
                            break;
                    }
                    adjustListBox(listBox1, Path1, textBox1, ref nDirectories1, ref nFiles1);
                    adjustListBox(listBox2, Path2, textBox2, ref nDirectories2, ref nFiles2);
                    break;
            }
        }
    }
}


// RESOURCES
// https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath?view=net-7.0
// https://www.c-sharpcorner.com/UploadFile/99aadd/working-with-the-directoryinfo-class-in-C-Sharp/
// https://learn.microsoft.com/en-us/dotnet/api/system.io.driveinfo.getdrives?view=net-6.0
//https://www.csharp-examples.net/open-file-with-default-application/
//https://www.geeksforgeeks.org/file-move-method-in-c-sharp-with-examples/
//https://stackoverflow.com/questions/2222718/c-sharp-delete-a-folder-and-all-files-and-folders-within-that-folder
//https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.delete?view=net-6.0#system-io-directory-delete(system-string-system-boolean)