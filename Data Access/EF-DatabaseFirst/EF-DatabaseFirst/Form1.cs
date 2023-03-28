using ConnectedModel;
using EF_DatabaseFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace EF_DatabaseFirst
{
    public partial class Form1 : Form
    {
        DataAccessEntities context;
        public Form1()
        {
            InitializeComponent();
            context = new DataAccessEntities();

            //================ Adjust Window =================//
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DeptBox.Items.Clear();
            var query = context.Departments.Select(d => d);
            foreach (var dept in query)
            {
                DeptBox.Items.Add(dept.Dept_id);
            }

        }

        private void DepAddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                context.Database.Log = log => Debug.WriteLine(log);
                var dept = context.Departments.Find(int.Parse(DeptBox.SelectedItem.ToString()));
                context.Employees.Add(
                    new Employee
                    {
                        Emp_id = int.Parse(EmpIdTextbox.Text),
                        Emp_Name = EmpNameTextbox.Text,
                        Department = dept
                    }
                );
                MessageBox.Show("Employee Data Inserted Successfully");
            }
            catch (SystemException er)
            {
                MessageBox.Show(er.Message);
            }

            context.SaveChanges();
        }

        private void DepUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                context.Database.Log = log => Debug.WriteLine(log);
                var empId = int.Parse(EmpIdTextbox.Text);
                var requiredEmp = context.Employees.Single(emp => emp.Emp_id == empId);
                requiredEmp.Emp_Name = EmpNameTextbox.Text;
                context.SaveChanges();
                MessageBox.Show("Employee DataUpdated Successfully");
            }
            catch (SystemException er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void DepDeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                context.Database.Log = log => Debug.WriteLine(log);
                var empId = int.Parse(EmpIdTextbox.Text);
                var requiredEmp = context.Employees.Single(emp => emp.Emp_id == empId);
                context.Employees.Remove(requiredEmp);
                context.SaveChanges();
                MessageBox.Show("Employee Deleted Successfully");
            }
            catch (SystemException er)
            {
                MessageBox.Show(er.Message);
            }

        }

        private void EmpAddBtn_Click(object sender, EventArgs e)
        {
            AddEmpDialogBox addDlgBox = new AddEmpDialogBox();
            DialogResult dlgResult = addDlgBox.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                //int EmpId = addDlgBox.EmpId;
                //string EmpName = addDlgBox.EmpName;
                //string deptName = DeptBox.SelectedItem.ToString();

                //ExecuteDML($"Insert into Employee values ({EmpId},'{EmpName}',{this.DeptId})", "Inserted");
                //dataGridView1.DataSource = LoadEmployees(deptName);
            }
        }

        private void EmpUpdateBtn_Click(object sender, EventArgs e)
        {
            //int rowIndex = int.Parse(dataGridView1.SelectedCells[0].RowIndex.ToString());
            //var EmpId = dataGridView1[0, rowIndex].Value;
            //string NewEmpName = "";
            //string NewDeptName = "";
            //string oldDeptName = DeptBox.SelectedItem.ToString();
            //UpdateEmpDialogBox updateDlgBox = new UpdateEmpDialogBox();
            //DialogResult dlgResult = updateDlgBox.ShowDialog();
            //if (dlgResult == DialogResult.OK)
            //{
            //    switch (updateDlgBox.RequiredUpdate)
            //    {
            //        case "Name":
            //            NewEmpName = updateDlgBox.EmpName;
            //            ExecuteDML($"UPDATE Employee SET Employee.Emp_Name = '{NewEmpName}' WHERE Employee.Emp_id = {EmpId}", "Updated");
            //            dataGridView1.DataSource = LoadEmployees(oldDeptName);
            //            break;
            //        case "Department":
            //            NewDeptName = updateDlgBox.DeptName;
            //            this.DeptId = SetDeptId(NewDeptName);
            //            ExecuteDML($"UPDATE Employee SET Employee.Dept_id = {this.DeptId} WHERE Employee.Emp_id = {EmpId}", "Updated");
            //            DeptBox.SelectedItem = NewDeptName;
            //            dataGridView1.DataSource = LoadEmployees(NewDeptName);
            //            break;
            //    }
            //}
        }

        private void EmpDeleteBtn_Click(object sender, EventArgs e)
        {
            //int rowIndex = int.Parse(dataGridView1.SelectedCells[0].RowIndex.ToString());
            //var EmpId = dataGridView1[0, rowIndex].Value;
            //string deptName = DeptBox.SelectedItem.ToString();
            //ExecuteDML($"DELETE FROM Employee WHERE Emp_id = {EmpId}", "Deleted");
            //dataGridView1.DataSource = LoadEmployees(deptName);
        }
    }
}


//string str = "";


#region Departments
//var query = context.Departments..Where(d => d.Dept_id > 2);

//var query = from dept in context.Departments
//            where dept.Dept_id > 2
//            select dept;

//foreach (var dept in query)
//{
//    str += (dept.Dept_Name + ',');
//}
//MessageBox.Show("Departments are: " + str);
#endregion
#region Employee
//var query = from emp in context.Employees
//             where emp.Department.Dept_id == 2
//             select emp;


//foreach (var emp in query)
//{
//    str += (emp.Emp_Name + ',');
//}
//MessageBox.Show("Employees in Department 2 are: " + str);
#endregion
#region Employee 2
//var query = from emp in context.Employees
//            where emp.Department.Dept_Name == "Systems" || emp.Department.Dept_Name == "IT"
//            select new { EmployeeName = emp.Emp_Name, DepartmentName = emp.Department.Dept_Name };


//foreach (var emp in query)
//{
//    str += $"Employee:{emp.EmployeeName} in Department:{emp.DepartmentName} \n";
//}
//MessageBox.Show("Employees in Department Systems and IT are: \n" + str);
#endregion
#region Lazy Loading
//var dept = context.Departments.First();

//foreach (var emp in dept.Employees)
//{
//    int id = emp.Emp_id;
//    string name = emp.Emp_Name;
//}
#endregion
#region Finding by Primary Key


//var dept = context.Departments.Find(2);

//foreach (var emp in dept.Employees)
//{
//    str += (emp.Emp_Name + ",");
//}
//MessageBox.Show(str);
#endregion

#region UPDATE & Changing EntityState property of Entry Object
//var dept = context.Departments.Find(2);

//dept.Dept_Name = "Open Source";

//context.Entry(dept).State = System.Data.Entity.EntityState.Unchanged;

//dept.Dept_Name = "Machine Learning";
//context.SaveChanges();
#endregion

#region Detached & Attach
//var dept = context.Departments.Find(2);

//dept.Dept_Name = "Open Source";

//context.Entry(dept).State = System.Data.Entity.EntityState.Detached;

//context.Departments.Attach(dept);

//context.SaveChanges();
#endregion


#region As No Tracking
//var query = (from dept in context.Departments
//            where dept.Dept_id > 2
//            select dept).AsNoTracking();
#endregion


#region Where vs Single vs Find
//var dept = context.Departments.Find(2);
//var dept = context.Departments.Single(d => d.Dept_id == 2);
//var dept = context.Departments.Where(d => d.Dept_id == 2);
#endregion

#region Insert
//var dept = new Department { Dept_id = 5, Dept_Name = "Open Source" };
//context.Departments.Add(dept);
//var emp = new Employee { Emp_id = 11, Emp_Name = "Mohanad Ali", Dept_id = 5 };
//context.Employees.Add(emp);
//context.SaveChanges();
#endregion
#region Insert Parent/Child
//try
//{
//    var dept = new Department { Dept_id = 6, Dept_Name = "Mobile Application" };
//    dept.Employees = new List<Employee>
//    {
//    new Employee {Emp_id = 12, Emp_Name = "Yahya Maged"},
//    new Employee {Emp_id = 13, Emp_Name = "Arwa Mahmoud"}
//    };
//    context.Departments.Add(dept);

//    context.SaveChanges();
//}
//catch (SystemException er)
//{
//    MessageBox.Show(er.Message);
//}
#endregion
#region Insert Parent/Child-2
//try
//{
//    var emp = new Employee
//    {
//        Emp_id = 14,
//        Emp_Name = "Ahmed Hassanin",
//        Department = new Department { Dept_id = 7, Dept_Name = "AI" },
//    };
//    context.Employees.Add(emp);
//    context.SaveChanges();
//}
//catch (SystemException er)
//{
//    MessageBox.Show(er.Message);
//}
#endregion
#region Delete
//try
//{
//    var query = context.Employees.Where(emp => emp.Dept_id == 6);
//    foreach (var emp in query)
//    {
//        context.Employees.Remove(emp);
//    }
//    var dept = context.Departments.Find(6);
//    context.Departments.Remove(dept);
//    context.SaveChanges();
//}
//catch (SystemException er)
//{
//    Console.WriteLine(er.Message);
//}
#endregion