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
    public partial class EmployeeAttendence : Form
    {
        public int postionId;
        public int pid;
        public int staffId;
        public int statusId;
        public int totalWorkingDays;
        public int presentDays=0;
        public int absentDays=0;
        public int leaveDays=0;
        public EmployeeAttendence()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void BindDesignComboBox()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PositionInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>=1)
            {
                DesignComboBox.DisplayMember = "PositionName";
                DesignComboBox.ValueMember = "PositionId";
                DesignComboBox.DataSource = dt;
            }
        }
        private void BindComboBox4()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PositionInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if (dt.Rows.Count >= 1)
            {
                comboBox4.DisplayMember = "PositionName";
                comboBox4.ValueMember = "PositionId";
                comboBox4.DataSource = dt;
            }
        }

        private void EmployeeAttendence_Load(object sender, EventArgs e)
        {
            BindDesignComboBox();
            BindComboBox4();
            BindStatus();
        }
        private void BindEmployee(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT T1.StaffId,T2.StaffName FROM dbo.StaffDetailInfo T1 INNER JOIN staff.StaffsInfo T2 ON T1.StaffId=T2.StaffId WHERE PositionId='" + id + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>=1)
            {
                EmployeeComboBox.DisplayMember = "StaffName";
                EmployeeComboBox.ValueMember = "StaffId";
                EmployeeComboBox.DataSource = dt;
            }
        }
        private void BindEmployees(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT T1.StaffId,T2.StaffName FROM dbo.StaffDetailInfo T1 INNER JOIN staff.StaffsInfo T2 ON T1.StaffId=T2.StaffId WHERE PositionId='" + id + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if (dt.Rows.Count >= 1)
            {
                comboBox5.DisplayMember = "StaffName";
                comboBox5.ValueMember = "StaffId";
                comboBox5.DataSource = dt;
            }
        }
        private void DesignComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(DesignComboBox.SelectedValue!=null)
            {
                postionId = Convert.ToInt32(DesignComboBox.SelectedValue);
                BindEmployee(postionId);
            }
        }
        private void BindStatus()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM AttendenceInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>=1)
            {
                StatusComboBox.DisplayMember = "Staus";
                StatusComboBox.ValueMember = "ID";
                StatusComboBox.DataSource = dt;
            }
        }

        private void StatusComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(StatusComboBox.SelectedValue!=null)
            {
                statusId = Convert.ToInt32(StatusComboBox.SelectedValue);
            }
        }

        private void EmployeeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(EmployeeComboBox.SelectedValue!=null)
            {
                staffId = Convert.ToInt32(EmployeeComboBox.SelectedValue);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO dbo.EmployeeAttendenceInfo(PositionId,StaffId,StatusId,[Description],[Date]) values('"+postionId+"','"+staffId+"','"+statusId+"','"+DescriptionRichTextBox.Text+"','"+dateTimePicker1.Text+"')";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Data Inserted Successfully");
            }
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox4.SelectedValue!=null)
            {
                pid = Convert.ToInt32(comboBox4.SelectedValue);
                BindEmployees(pid);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT EmpId as [Attendence ID],T2.Staus,[Description],[Date] FROM EmployeeAttendenceInfo T1 INNER JOIN dbo.AttendenceInfo T2 ON T1.StatusId=T2.ID WHERE [Date]<='" + dateTimePicker2.Text.Trim() + "'  AND PositionId='" + pid + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>=1)
            {
                textBox1.Text = dt.Rows.Count.ToString();
                foreach(DataRow dr in dt.Rows)
                {
                    if(dr["Staus"].ToString()=="Present")
                    {
                        presentDays = presentDays + 1;
                    }
                    else if(dr["Staus"].ToString()=="Absent")
                    {
                        absentDays = absentDays + 1;
                    }
                    else
                    {
                        leaveDays = leaveDays + 1;
                    }
                }

                textBox2.Text = presentDays.ToString();
                textBox3.Text = absentDays.ToString();
                textBox4.Text = leaveDays.ToString();
                dataGridView1.DataSource = dt;
            }
          
        }

    }
}
