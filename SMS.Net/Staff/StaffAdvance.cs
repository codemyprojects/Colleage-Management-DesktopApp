using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Staff
{
    public partial class StaffAdvance : Form
    {
        int sid;
        public int postionId;
        public int pid;
        public int staffId;
        public int AdvanceId;
        int aid;
        public StaffAdvance()
        {
            InitializeComponent();
        }

        private void StaffAdvance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sMSDataSet1.EmployeeAdvance' table. You can move, or remove it, as needed.
            this.employeeAdvanceTableAdapter.Fill(this.sMSDataSet1.EmployeeAdvance);
            BindStaffName();
            BindAdvance(AdvanceId);
        }
        private void BindStaffName()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM staff.StaffsInfo T1 INNER JOIN dbo.PositionInfo T2 ON T1.StaffPost=T2.PositionId INNER JOIN LevelInfo T3 ON T1.JobStatus=T3.LevelId";
            StaffNameComboBox.DisplayMember = "StaffName";
            StaffNameComboBox.ValueMember = "StaffId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            StaffNameComboBox.DataSource = dt;
        }
        private void BindAdvance(int AdvanceId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from AdvanceInfo";
            comboBox2.DisplayMember = "AdvanceName";
            comboBox2.ValueMember = "AdvanceId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox2.DataSource = dt;

        }
        private void BindStaffName(Int32 StaffId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT T1.StaffId,T2.PositionName,T4.BasicSalary,T4.StaffType,T4.DateOfJoin,T4.DateOfPermanency,T4.DateOfPromotion FROM staff.StaffsInfo T1 INNER JOIN dbo.PositionInfo T2 ON T1.StaffPost=T2.PositionId INNER JOIN LevelInfo T3 ON T1.JobStatus=T3.LevelId  INNER JOIN dbo.StaffDetailInfo T4 ON T1.StaffId=T4.StaffId WHERE T1.StaffId='" + StaffId + "' ";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            foreach (DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["PositionName"].ToString();
                textBox3.Text = dr["BasicSalary"].ToString();
            }

        }

        private void StaffNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(StaffNameComboBox.SelectedValue!=null)
            {
                sid = Convert.ToInt32(StaffNameComboBox.SelectedValue);
                BindStaffName(sid);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert INTO dbo.EmployeeAdvance(StaffId,AdvanceId,[Date],[AdvanceAmount])values('"+sid+"','"+AdvanceId+"','"+textBox1.Text.Trim()+"','"+textBox4.Text.Trim()+"')";

            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Data Inserted Successfully");
                BindDataGrid();
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox2.SelectedValue!=null)
            {
                AdvanceId = Convert.ToInt32(comboBox2.SelectedValue);
                BindAdvance(AdvanceId);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           aid = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
           //aid= Convert.ToString(dataGridView1[1, e.RowIndex].Value);
           textBox4.Text = Convert.ToString(dataGridView1[4, e.RowIndex].Value);
           textBox1.Text = Convert.ToString(dataGridView1[3, e.RowIndex].Value);
           BindDataGrid();
        }
        private void BindDataGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from dbo.EmployeeAdvance";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE from EmployeeAdvance Where AdavanceStaffId='" + aid + "'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Delete Successfully");
                BindDataGrid();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "update dbo.EmployeeAdvance SET AdvanceAmount='" + textBox4.Text + "', Date='"+ textBox1.Text +"' where AdvanceStaffId='" + aid + "'";
            cmd.CommandText = "UPDATE EmployeeAdvance SET AdvanceAmount='"+ textBox4.Text +"', Date='"+ textBox1.Text +"' WHERE AdavanceStaffId='"+aid+"'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Successfully updated");
                BindDataGrid();
            }

        }
    }

}
