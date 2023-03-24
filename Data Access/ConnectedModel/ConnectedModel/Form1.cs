using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ConnectedModel
{
    public partial class Form1 : Form
    {
        int DeptId;
        public Form1()
        {
            InitializeComponent();
            //================ Adjust Window =================//
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void LoadDepartments()
        {
            DeptBox.Items.Clear();
            sqlCommand1.CommandText = "Select Dept_Name from Department";
            SqlDataReader dReader;
            dReader = sqlCommand1.ExecuteReader();
            while (dReader.Read())
            {
                string str = dReader[0].ToString();
                DeptBox.Items.Add(str);
            }
            dReader.Close();

        }
        private List<Employee> LoadEmployees(string deptName)
        {
            List<Employee> EmployeesList = new List<Employee>();
            SqlDataReader dReader;

            sqlCommand1.CommandText = $"Select Emp_id,Emp_Name from Employee,Department WHERE Employee.Dept_id = Department.Dept_id AND Department.Dept_Name = '{deptName}'";
            dReader = sqlCommand1.ExecuteReader();
            while (dReader.Read())
            {

                string id = dReader[0].ToString();
                string name = dReader[1].ToString();
                Employee emp = new Employee(int.Parse(id), name);
                EmployeesList.Add(emp);
            }
            dReader.Close();
            return EmployeesList;

        }
        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            StatusBox.BackColor = Color.Chartreuse;
            StatusBox.Text = "Connected..";
            LoadDepartments();

        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            sqlConnection1.Close();
            StatusBox.BackColor = Color.IndianRed;
            StatusBox.Text = "DisConnected..";
        }

        private void DeptBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DeptId = SetDeptId();
            dataGridView1.DataSource = LoadEmployees(DeptBox.SelectedItem.ToString());
        }


        private int SetDeptId()
        {
            SqlDataReader dReader;
            int id = 0;
            string deptName = DeptBox.SelectedItem.ToString();
            sqlCommand1.CommandText = $"Select Dept_id from Department WHERE Dept_Name = '{deptName}'";
            dReader = sqlCommand1.ExecuteReader();
            while (dReader.Read())
            {
                id = (int)dReader[0];
            }
            dReader.Close();
            return id;

        }
        private int SetDeptId(string DeptName)
        {
            SqlDataReader dReader;
            int id = 0;
            sqlCommand1.CommandText = $"Select Dept_id from Department WHERE Dept_Name = '{DeptName}'";
            dReader = sqlCommand1.ExecuteReader();
            while (dReader.Read())
            {
                id = (int)dReader[0];
            }
            dReader.Close();
            return id;

        }
        private void ExecuteDML(string str, string State)
        {
            sqlCommand1.CommandText = str;
            int affectedRows = sqlCommand1.ExecuteNonQuery();
            MessageBox.Show(affectedRows.ToString() + " Records " + State);
        }
        private void DepAddBtn_Click(object sender, EventArgs e)
        {
            string empId = EmpIdTextbox.Text;
            string empName = EmpNameTextbox.Text;
            string deptName = DeptBox.SelectedItem.ToString();

            ExecuteDML($"INSERT INTO Employee values({empId},'{empName}',{this.DeptId})", "Inserted");
            dataGridView1.DataSource = LoadEmployees(deptName);
        }

        private void DepUpdateBtn_Click(object sender, EventArgs e)
        {
            string empId = EmpIdTextbox.Text;
            string empName = EmpNameTextbox.Text;
            string deptName = DeptBox.SelectedItem.ToString();
            ExecuteDML($"UPDATE Employee SET Emp_Name = '{empName}' WHERE Emp_id = {empId}", "Updated");
            dataGridView1.DataSource = LoadEmployees(deptName);
        }

        private void DepDeleteBtn_Click(object sender, EventArgs e)
        {
            string empId = EmpIdTextbox.Text;
            string empName = EmpNameTextbox.Text;
            string deptName = DeptBox.SelectedItem.ToString();
            ExecuteDML($"DELETE FROM Employee WHERE Emp_id = {empId}", "Deleted");
            dataGridView1.DataSource = LoadEmployees(deptName);
        }

        private void EmpAddBtn_Click(object sender, EventArgs e)
        {
            AddEmpDialogBox addDlgBox = new AddEmpDialogBox();
            DialogResult dlgResult = addDlgBox.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                int EmpId = addDlgBox.EmpId;
                string EmpName = addDlgBox.EmpName;
                string deptName = DeptBox.SelectedItem.ToString();

                ExecuteDML($"Insert into Employee values ({EmpId},'{EmpName}',{this.DeptId})", "Inserted");
                dataGridView1.DataSource = LoadEmployees(deptName);
            }
        }

        private void EmpUpdateBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = int.Parse(dataGridView1.SelectedCells[0].RowIndex.ToString());
            var EmpId = dataGridView1[0, rowIndex].Value;
            string NewEmpName = "";
            string NewDeptName = "";
            string oldDeptName = DeptBox.SelectedItem.ToString();
            UpdateEmpDialogBox updateDlgBox = new UpdateEmpDialogBox();
            DialogResult dlgResult = updateDlgBox.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                switch (updateDlgBox.RequiredUpdate)
                {
                    case "Name":
                        NewEmpName = updateDlgBox.EmpName;
                        ExecuteDML($"UPDATE Employee SET Employee.Emp_Name = '{NewEmpName}' WHERE Employee.Emp_id = {EmpId}", "Updated");
                        dataGridView1.DataSource = LoadEmployees(oldDeptName);
                        break;
                    case "Department":
                        NewDeptName = updateDlgBox.DeptName;
                        this.DeptId = SetDeptId(NewDeptName);
                        ExecuteDML($"UPDATE Employee SET Employee.Dept_id = {this.DeptId} WHERE Employee.Emp_id = {EmpId}", "Updated");
                        DeptBox.SelectedItem = NewDeptName;
                        dataGridView1.DataSource = LoadEmployees(NewDeptName);
                        break;
                }
            }
        }

        private void EmpDeleteBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = int.Parse(dataGridView1.SelectedCells[0].RowIndex.ToString());
            var EmpId = dataGridView1[0, rowIndex].Value;
            string deptName = DeptBox.SelectedItem.ToString();
            ExecuteDML($"DELETE FROM Employee WHERE Emp_id = {EmpId}", "Deleted");
            dataGridView1.DataSource = LoadEmployees(deptName);
        }
    }
}
