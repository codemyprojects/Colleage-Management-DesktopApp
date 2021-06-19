using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.FeeStructure
{
    public partial class DefineFee : Form
    {
        public int fid=0;
        public string fstatus="";
        public string ayr;
        public string cl;
        public string fee;
        public int aid;
        public int cid;
        public DefineFee()
        {
            InitializeComponent();
        }

        private void DefineFee_Load(object sender, EventArgs e)
        {
            BindDataGrid();
            BindMontlyDataGrid();
            BindComboBox();
            BindBatch();
            ClassInfo();
            BindExtraFee();
            panel2.Visible = false;
            button2.Enabled = false;
            BindMonthComboBox();
        }
        private void BindDataGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT T1.FeeId AS ID,T2.AcademicYear,T3.Class,T4.FeeStatus,T1.FeeName AS Fee FROM FeeInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN FeeStatusInfo T4 ON T1.FeeStatusId=T4.FeeStatusId WHERE T4.FeeStatus='Annually';";
           // cmd.CommandText = "SELECT FeeId,FeeName,FeeStatus FROM dbo.FeeInfo t1 inner join dbo.FeeStatusInfo t2 on t1.FeeStatusId=t2.FeeStatusId WHERE FeeStatus='Annually'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;

        }
        private void BindMontlyDataGrid()
        {
           SqlCommand cmd = new SqlCommand();
           cmd.CommandText = "SELECT FeeId,AcademicYearId,ClassId,FeeStatusId,FeeName,FeeStatus FROM dbo.FeeInfo t1 inner join dbo.FeeStatusInfo t2 on t1.FeeStatusId=t2.FeeStatusId WHERE FeeStatus='Monthly'";
            //cmd.CommandText = "SELECT DISTINCT(t1.FeeId),t1.FeeName,t2.FeeStatus,T3.AcademicYearId,T3.ClassId FROM dbo.FeeInfo t1 inner join dbo.FeeStatusInfo t2 on t1.FeeStatusId=t2.FeeStatusId  INNER JOIN dbo.FeeDetailsInfo T3 on t1.FeeId=T3.FeeId WHERE t2.FeeStatus='Monthly'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            //dataGridView2.DataSource = dt;
        }
        private void ClassInfo()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.spClassInfo", null, true);
            if (dt.Rows.Count > 0)
            {
                comboBox3.Items.Clear();
                comboBox3.ValueMember = "ClassId";
                comboBox3.DisplayMember = "Class";
                comboBox3.DataSource = dt;
            }
        }
        private void BindExtraFee()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT T1.FeeId AS ID,T2.AcademicYear,T3.Class,T4.FeeStatus,T1.FeeName AS Fee FROM FeeInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN FeeStatusInfo T4 ON T1.FeeStatusId=T4.FeeStatusId WHERE T4.FeeStatus='Other';";
            //cmd.CommandText = "SELECT FeeId,AcademicYearId,ClassId,FeeStatusId,FeeName,FeeStatus FROM dbo.FeeInfo t1 inner join dbo.FeeStatusInfo t2 on t1.FeeStatusId=t2.FeeStatusId WHERE FeeStatus='Other'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView3.DataSource = dt;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void BindComboBox()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  * FROM dbo.FeeStatusInfo WHERE FeeStatusId!=2";
            comboBox1.DisplayMember = "FeeStatus";
            comboBox1.ValueMember = "FeeStatusId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                panel2.Visible = true;
                BindComboBox();
                button2.Enabled = false;
                button4.Enabled = false;
                button1.Enabled = false;
                button7.Enabled = false;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if(comboBox1.SelectedValue!=null)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Fee Name is Required!!");
            }
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "INSERT INTO dbo.FeeInfo(AcademicYearId,ClassId,FeeName,FeeStatusId) VALUES('"+aid+"','"+cid+"','" + textBox1.Text.Trim() + "','" + comboBox1.SelectedValue.ToString() + "')";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                if (x == 1)
                {
                    MessageBox.Show("Fee Added Successfully!!!");
                    if (comboBox1.SelectedValue.ToString() == "1")
                        BindDataGrid();
                    if (comboBox1.SelectedValue.ToString() == "2")
                        BindMontlyDataGrid();
                    if (comboBox1.SelectedValue.ToString() == "3")
                        BindExtraFee();
                    //AcademicYearComboBox.Items.Clear();
                    //comboBox3.Items.Clear();
                    //textBox1.Text = string.Empty;
                    //comboBox1.Items.Clear();
                    //comboBox2.Items.Clear();
                    AcademicYearComboBox.Text = "";
                    comboBox3.Text = "";
                    textBox1.Text = string.Empty;
                    comboBox1.Text = "";
                    comboBox2.Text = "";

                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        //    fid = Convert.ToInt32(dataGridView1[0,e.RowIndex].Value);
        //    fstatus = Convert.ToString(dataGridView1[2, e.RowIndex].Value);
        //    textBox1.Text = Convert.ToString(dataGridView1[1, e.RowIndex].Value);
            fid = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            ayr = Convert.ToString(dataGridView1[1, e.RowIndex].Value);
            cl = Convert.ToString(dataGridView1[2, e.RowIndex].Value);
            //fstatus = dataGridView3[3, e.RowIndex].ToString();
            fstatus = Convert.ToString(dataGridView1[3, e.RowIndex].Value);

            AcademicYearComboBox.SelectedIndex = AcademicYearComboBox.FindString(ayr);
            comboBox3.SelectedIndex = comboBox3.FindString(cl);
            comboBox1.SelectedIndex = comboBox1.FindString(fstatus);
            textBox1.Text = Convert.ToString(dataGridView1[4, e.RowIndex].Value);
            button2.Enabled = true;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {    
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                        "Confirm Delete!!",
                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM dbo.FeeInfo WHERE FeeId='" + fid + "'";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                if(fstatus=="Annually")
                 BindDataGrid();
                if (fstatus == "Monthly")
                    BindMontlyDataGrid();
                if (fstatus == "Other")
                    BindExtraFee();

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
           // BindComboBox();
            comboBox1.SelectedIndex = comboBox1.FindString(fstatus);
            AcademicYearComboBox.SelectedIndex = AcademicYearComboBox.FindString(ayr);
            comboBox3.SelectedIndex = comboBox3.FindString(cl);
            button7.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
         

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Feename");
            }
            else
            {
                cmd.CommandText = "UPDATE dbo.FeeInfo SET AcademicYearId='" + aid + "',ClassId='"+cid+"',FeeName='" + textBox1.Text.Trim() + "',FeeStatusId='" + comboBox1.SelectedValue.ToString() + "' WHERE FeeId='" + fid + "'";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                if (x == 1)
                {
                    MessageBox.Show("Fee Item Updated Successfully!!");
                    if (comboBox1.SelectedValue.ToString() == "1")
                        BindDataGrid();
                    if (comboBox1.SelectedValue.ToString() == "2")
                        BindMontlyDataGrid();
                    if (comboBox1.SelectedValue.ToString() == "3")
                        BindExtraFee();
                }
            }
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            AcademicYearComboBox.DisplayMember = "AcademicYear";
            AcademicYearComboBox.ValueMember = "AcademicYearId";
            AcademicYearComboBox.DataSource = dt;
        }
        private void BindMonthComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spMontshInfo]", null, true);
            comboBox2.ValueMember = "MonthId";
            comboBox2.DisplayMember = "MonthName";
            comboBox2.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //fid = Convert.ToInt32(dataGridView2[0, e.RowIndex].Value);
            //fstatus = Convert.ToString(dataGridView2[2, e.RowIndex].Value);
            //textBox1.Text = Convert.ToString(dataGridView2[1, e.RowIndex].Value);
            //button2.Enabled = true;
            //button4.Enabled = true;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            fid = Convert.ToInt32(dataGridView3[0, e.RowIndex].Value);
            ayr = Convert.ToString(dataGridView3[1,e.RowIndex].Value);
            cl=Convert.ToString(dataGridView3[2,e.RowIndex].Value);
            //fstatus = dataGridView3[3, e.RowIndex].ToString();
            fstatus = Convert.ToString(dataGridView3[3, e.RowIndex].Value);

            AcademicYearComboBox.SelectedIndex = AcademicYearComboBox.FindString(ayr);
            comboBox3.SelectedIndex = comboBox3.FindString(cl);
            comboBox1.SelectedIndex = comboBox1.FindString(fstatus);
            textBox1.Text = Convert.ToString(dataGridView3[4, e.RowIndex].Value);
            button2.Enabled = true;
            button4.Enabled = true;
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox3.SelectedValue!=null)
            {
                cid = Convert.ToInt32(comboBox3.SelectedValue);
            }
        }

        private void AcademicYearComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(AcademicYearComboBox.SelectedValue!=null)
            {
                aid = Convert.ToInt32(AcademicYearComboBox.SelectedValue);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}