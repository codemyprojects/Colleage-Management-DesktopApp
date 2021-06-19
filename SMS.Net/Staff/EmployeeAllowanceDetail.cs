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
    public partial class EmployeeAllowanceDetail : Form
    {
        //public static int sid=0;
        public EmployeeAllowanceDetail()
        {
            InitializeComponent();
        }

        private void StaffNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(StaffNameComboBox.SelectedValue!=null)
            {
                //groupBox2.Visible = true;
                BindStaffName(Convert.ToInt32(StaffNameComboBox.SelectedValue.ToString()));
                BindDataGrid(Convert.ToInt32(StaffNameComboBox.SelectedValue.ToString()));
                //sid = Convert.ToInt32(StaffNameComboBox.SelectedValue.ToString());
            }
        }
        private void BindStaffName(Int32 StaffId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT T1.StaffId,T2.PositionName,T4.BasicSalary,T4.StaffType,T4.DateOfJoin,T4.DateOfPermanency,T4.DateOfPromotion FROM staff.StaffsInfo T1 INNER JOIN dbo.PositionInfo T2 ON T1.StaffPost=T2.PositionId INNER JOIN LevelInfo T3 ON T1.JobStatus=T3.LevelId  INNER JOIN dbo.StaffDetailInfo T4 ON T1.StaffId=T4.StaffId WHERE T1.StaffId='" + StaffId + "' ";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            foreach (DataRow dr in dt.Rows)
            {
                PostTextBox.Text = dr["PositionName"].ToString();
                BasicSalaryComboBox.Text = dr["BasicSalary"].ToString();
            }

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
        private void BindAllowance(Int32 alid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  * FROM  [dbo].[AllowanceInfo] t1 INNER JOIN dbo.AllowanceDetailInfo t2 ON t1.AllowanceId=t2.AllowanceId WHERE t2.AllowanceId='"+alid+"'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            foreach(DataRow dr in dt.Rows)
            {
                AmountTextBox.Text = dr["AllowanceAmount"].ToString();
            }
   
        }
        private void BindAllowance()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  * FROM [dbo].[AllowanceInfo] ";
            AllowanceComboBox.DisplayMember = "AllowanceName";
            AllowanceComboBox.ValueMember = "AllowanceId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            AllowanceComboBox.DataSource = dt;
          
        }

        private void EmployeeAllowanceDetail_Load(object sender, EventArgs e)
        {
            BindStaffName();
            BindAllowance();
            //BindDataGrid();
            groupBox2.Visible = false;
        }

        private void AllowanceComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (AllowanceComboBox.SelectedValue != null)
            {
                BindAllowance(Convert.ToInt32(AllowanceComboBox.SelectedValue.ToString()));
        
         

            }
        }

        private void AllowanceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO StaffAllowanceDetails(AllowanceId,StaffId) VALUES('" + Convert.ToInt32(AllowanceComboBox.SelectedValue.ToString()) + "','" + Convert.ToInt32(StaffNameComboBox.SelectedValue.ToString()) + "')";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Staff Allowance Added Successfylly!");
                BindDataGrid1(Convert.ToInt32(StaffNameComboBox.SelectedValue.ToString()));
                groupBox2.Visible = true;
                StaffNameComboBox.Text = "";
                PostTextBox.Text = string.Empty;
                BasicSalaryComboBox.Text = string.Empty;
                AllowanceComboBox.Text = "";
                AmountTextBox.Text = string.Empty;
            }
        }
        
        private void BindDataGrid(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT T3.AllowanceName ,T2.AllowanceAmount FROM StaffAllowanceDetails T1 INNER JOIN AllowanceDetailInfo T2 ON T1.AllowanceId=T2.AllowanceId INNER JOIN AllowanceInfo T3 ON T3.AllowanceId=T2.AllowanceId where T1.StaffId='" +id+ "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>=1)
            {
                groupBox2.Visible = true;
                dataGridView1.DataSource = dt;
            }
            else
            {
                groupBox2.Visible = false;
            }
          
         
        }
        private void BindDataGrid1(int sid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT T3.AllowanceName ,T2.AllowanceAmount FROM StaffAllowanceDetails T1 INNER JOIN AllowanceDetailInfo T2 ON T1.AllowanceId=T2.AllowanceId INNER JOIN AllowanceInfo T3 ON T3.AllowanceId=T2.AllowanceId where T1.StaffId='" +sid+"'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
