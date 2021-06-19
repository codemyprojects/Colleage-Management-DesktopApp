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
    public partial class StaffDetails : Form
    {   public static string stype;
        public static int staffid;
        public static int levelid;
        public static int postid;

        public StaffDetails()
        {
            InitializeComponent();
        }

        private void StaffDetails_Load(object sender, EventArgs e)
        {
            BindStaffName();
            BindStaffPost();
            BindStaffLevel();
            BindGrid();
            AddNewButton.Enabled = true;
            SaveButton.Enabled = false;
            UpdateButton.Enabled = true;

        }
        private void BindStaffName()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM staff.StaffsInfo T1 INNER JOIN dbo.PositionInfo T2 ON T1.StaffPost=T2.PositionId INNER JOIN LevelInfo T3 ON T1.JobStatus=T3.LevelId ";
            StaffNameComboBox.DisplayMember = "StaffName";
            StaffNameComboBox.ValueMember = "StaffId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            StaffNameComboBox.DataSource = dt;
        }
        private void BindStaffPost()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  * FROM PositionInfo";
            PositionComboBox.DisplayMember = "PositionName";
            PositionComboBox.ValueMember = "PositionId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            PositionComboBox.DataSource = dt;
        }
        private void BindStaffLevel()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * From LevelInfo";
            comboBox2.DisplayMember = "LevelName";
            comboBox2.ValueMember = "LevelId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox2.DataSource = dt;
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            AddNewButton.Enabled = false;
            
            UpdateButton.Enabled = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            //DateTime dp1, dp2, dp3;
            SqlCommand cmd = new SqlCommand();
            if(radioButton1.Checked==true)
            {
                stype="Permanent";
            }
            if(radioButton2.Checked==true)
            {
                stype="Temporary";
            }
            dateTimePicker1.Text.ToString();
            dateTimePicker2.Text.ToString();
            dateTimePicker3.Text.ToString();
            cmd.CommandText = "INSERT INTO  [dbo].[StaffDetailInfo] ([StaffId],[LevelId],[BasicSalary],[StaffType],[DateOfJoin],[DateOfPermanency],[DateOfPromotion]) VALUES('" + staffid+ "','" + levelid + "','"+BasicSalaryTextBox.Text.Trim()+"','" + stype + "','" +dateTimePicker1.Text + "','" +dateTimePicker2.Text + "','" +dateTimePicker3.Text+ "') ";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Staff Detail Added Successfyll!!");
                BindGrid();
                SaveButton.Enabled = true;
                AddNewButton.Enabled = false;
                UpdateButton.Enabled = false;
            }
        }

        private void StaffNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(StaffNameComboBox.SelectedValue!=null)
            {
                staffid = Convert.ToInt32(StaffNameComboBox.SelectedValue.ToString());
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(PositionComboBox.SelectedValue!=null)
            {
                postid = Convert.ToInt32(PositionComboBox.SelectedValue.ToString());
              //  MessageBox.Show(postid.ToString());
            }
        }

        private void PositionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox2.SelectedValue!=null)
            {
                levelid = Convert.ToInt32(comboBox2.SelectedValue.ToString());
            }
        }

        private void PositionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(PositionComboBox.SelectedValue!=null)
            {
                //MessageBox.Show(PositionComboBox.SelectedValue.ToString());
                postid = Convert.ToInt32(PositionComboBox.SelectedValue.ToString());
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox2.SelectedValue!=null)
            {
                levelid = Convert.ToInt32(comboBox2.SelectedValue);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void BindGrid()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT t1.StaffId,t2.StaffCode,t2.StaffName,t2.StaffContact,t1.BasicSalary,t1.StaffType,DateOfJoin,DateOfPermanency,DateOfPromotion,StaffDetailId,LevelId,PositionId  FROM [dbo].[StaffDetailInfo] t1 inner join staff.StaffsInfo t2 on t1.StaffId=t2.StaffId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;

        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            

        }

        private void DeleteButtton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to delete this item?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE * FROM  [dbo].[StaffDetailInfo] where StaffId='"+staffid+"'";
                DataBaseLayer.DbOperations.ExecProc(cmd);
                BindGrid();
            }

        }

        private void CLoseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT t1.StaffId,t2.StaffCode,t2.StaffName,t2.StaffContact,t1.BasicSalary,t1.StaffType,DateOfJoin,DateOfPermanency,DateOfPromotion,StaffDetailId,LevelId,PositionId  FROM [dbo].[StaffDetailInfo] t1 inner join staff.StaffsInfo t2 on t1.StaffId=t2.StaffId WHERE t1.StaffId='" + id + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            foreach(DataRow dr in dt.Rows)
            {
                StaffNameComboBox.SelectedIndex = StaffNameComboBox.FindString(dr["StaffName"].ToString());
                SqlCommand command = new SqlCommand();
                command.CommandText = "select * from LevelInfo";
                DataTable t = DataBaseLayer.DbOperations.GetDataTable(command);
                foreach(DataRow r in t.Rows)
                {
                    if(dr["LevelId"].ToString()==r["LevelId"].ToString())
                    {
                        comboBox2.SelectedIndex = comboBox2.FindString(r["LevelName"].ToString());
                    }
                }
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from PositionInfo";
                DataTable pt = DataBaseLayer.DbOperations.GetDataTable(comm);
                foreach(DataRow p in pt.Rows)
                {
                    if (dr["PositionId"].ToString() == p["PositionId"].ToString())
                    {
                        PositionComboBox.SelectedIndex = PositionComboBox.FindString(p["PositionName"].ToString());
                    }
                }
                BasicSalaryTextBox.Text = dr["BasicSalary"].ToString();
                if (dr["StaffType"].ToString()=="Temporary")
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                }
                dateTimePicker1.Text = dr["DateOfJoin"].ToString();
                dateTimePicker2.Text = dr["DateOfPermanency"].ToString();
                dateTimePicker3.Text = dr["DateOfPromotion"].ToString();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            //DateTime dp1, dp2, dp3;
            SqlCommand cmd = new SqlCommand();
            if (radioButton1.Checked == true)
            {
                stype = "Permanent";
            }
            if (radioButton2.Checked == true)
            {
                stype = "Temporary";
            }
                dateTimePicker1.Text.ToString();
                dateTimePicker2.Text.ToString();
                dateTimePicker3.Text.ToString();
            cmd.CommandText = "UPDATE   [dbo].[StaffDetailInfo] SET PositionId='"+postid+"',[LevelId]='" + levelid + "',[BasicSalary]='" + BasicSalaryTextBox.Text.Trim() + "',[StaffType]='" + stype + "',[DateOfJoin]='" + dateTimePicker1.Text + "',[DateOfPermanency]='" + dateTimePicker2.Text + "',[DateOfPromotion]='" + dateTimePicker3.Text + "' WHERE [StaffId]='" + staffid + "' ";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Staff Detail Updated Successfyll!!");
                BindGrid();
                AddNewButton.Enabled = false;
                SaveButton.Enabled = false;
                
                UpdateButton.Enabled = true;
            }
        }
    }
}
