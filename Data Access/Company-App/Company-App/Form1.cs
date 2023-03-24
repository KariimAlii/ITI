using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Company_App
{
    public partial class Form1 : Form
    {
        SqlCommand sqlInsertCommand;
        SqlCommand sqlUpdateCommand;
        SqlCommand sqlDeleteCommand;
        public Form1()
        {
            InitializeComponent();

            //SqlParameter EmpId = new SqlParameter("@EmpId", SqlDbType.Int, 0, "Emp_id");
            //SqlParameter EmpName = new SqlParameter("@EmpName", SqlDbType.NVarChar, 0, "Emp_Name");
            //SqlParameter DeptId = new SqlParameter("@DeptId", SqlDbType.Int, 0, "Dept_id");
            //SqlParameter DeptName = new SqlParameter("@DeptName", SqlDbType.NVarChar, 0, "Dept_Name");

            #region Insert Command
            sqlInsertCommand = new SqlCommand();
            sqlInsertCommand.CommandText = "Insert into [Employee] ([Emp_id],[Emp_Name],[Dept_id]) values (@EmpId,@EmpName,@DeptId)";
            sqlInsertCommand.Parameters.AddRange(new SqlParameter[]
            { new SqlParameter("@EmpId", SqlDbType.Int, 0, "Emp_id"),
              new SqlParameter("@EmpName", SqlDbType.NVarChar, 0, "Emp_Name"),
              new SqlParameter("@DeptId", SqlDbType.Int, 0, "Dept_id"),
              new SqlParameter("@DeptName", SqlDbType.NVarChar, 0, "Dept_Name")
            });
            sqlInsertCommand.Connection = sqlConnection1;
            #endregion

            #region Delete Command
            sqlDeleteCommand = new SqlCommand();
            sqlDeleteCommand.CommandText = "DELETE FROM [Employee] WHERE [Emp_id] = @EmpId";
            sqlDeleteCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@EmpId", SqlDbType.Int, 0, "Emp_id")
            });
            sqlDeleteCommand.Connection = sqlConnection1;
            #endregion

            #region Update Command
            sqlUpdateCommand = new SqlCommand();
            sqlUpdateCommand.CommandText = "UPDATE [Employee] SET [Emp_Name] = @EmpName WHERE [Emp_id] = @EmpId";


            sqlUpdateCommand.Parameters.AddRange(new SqlParameter[]
            { new SqlParameter("@EmpId", SqlDbType.Int, 0, "Emp_id"),
              new SqlParameter("@EmpName", SqlDbType.NVarChar, 0, "Emp_Name"),
              new SqlParameter("@DeptId", SqlDbType.Int, 0, "Dept_id"),
              new SqlParameter("@DeptName", SqlDbType.NVarChar, 0, "Dept_Name")
            });
            sqlUpdateCommand.Connection = sqlConnection1;
            #endregion

            #region Data Adapter
            this.sqlDataAdapter1.InsertCommand = sqlInsertCommand;
            this.sqlDataAdapter1.UpdateCommand = sqlUpdateCommand;
            this.sqlDataAdapter1.DeleteCommand = sqlDeleteCommand;
            #endregion
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Fill(dataSet11);
            sqlConnection1.Close();
            dataGridView1.DataSource = dataSet11.Tables[0];
            foreach (DataRow x in dataSet11.Tables[0].Rows)
            {
                this.DeptBox.Items.Add(x["Dept_Name"].ToString());
            }

        }

        private void DeptBox_SelectedIndexChanged(object sender, EventArgs e)
        {


            this.sqlSelectCommand1.CommandText = "SELECT Employee.*, Department.Dept_Name\r\nFROM     Department INNER JOIN\r\n        " +
$"          Employee ON Department.Dept_id = Employee.Dept_id AND Department.Dept_Name = '{this.DeptBox.SelectedItem.ToString()}'";
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;

            sqlConnection1.Open();
            sqlDataAdapter1.Fill(dataSet11);
            sqlConnection1.Close();
            dataGridView1.DataSource = dataSet11.Tables[0];
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            DataRow dRow = dataSet11.Tables[0].NewRow();
            dRow[0] = int.Parse(IdTextbox.Text);
            dRow[1] = nameTextbox.Text;
            dRow[2] = DeptBox.SelectedIndex + 1;
            dataSet11.Tables[0].Rows.Add(dRow);
            IdTextbox.Text = nameTextbox.Text = String.Empty;
        }

        private void UpdateDatabaseBtn_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Update(dataSet11);
            sqlConnection1.Close();
            MessageBox.Show("Updated Database");
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(IdTextbox.Text);
            DataRow dRow = dataSet11.Tables[0].Rows.Find(id);
            if (dRow != null)
            {
                dRow[1] = nameTextbox.Text;
                IdTextbox.Text = nameTextbox.Text = String.Empty;
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Invalid Id");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(IdTextbox.Text);
            DataRow dRow = dataSet11.Tables[0].Rows.Find(id);
            if (dRow != null)
            {
                dataSet11.Tables[0].Rows.Remove(dRow);

                //dRow.Delete();
                //dataSet11.Tables[0].AcceptChanges();
                //dataSet11.AcceptChanges();


                IdTextbox.Text = nameTextbox.Text = String.Empty;
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Invalid Id");
            }
        }
    }
}
