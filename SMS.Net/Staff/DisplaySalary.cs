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
    public partial class DisplaySalary : Form
    {
        public int staffsearchbyid;
        public static int stffid;
        public DisplaySalary()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void BindStaffName()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT t2.StaffId as StaffId, t2.StaffName,t1.Position,t1.StaffType,t1.DateOfJoin,t1.[Year],t1.[Month],t1.DatePicker,t1.BasicSalary,t1.AllowanceTotal,t1.Grade,t1.PyableTotal,t1.GrossTotal,t1.Advance,t1.ReturnedAdvance,t1.ProvidentFund,t1.Tax,t1.DeducedTotal,t1.NetTotal FROM dbo.StaffSalaryPaymentInfo t1 INNER JOIN staff.StaffsInfo t2 on t1.StaffId=t2.StaffId";
            comboBox1.DisplayMember = "StaffName";
            comboBox1.ValueMember = "StaffId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
            if(comboBox1.SelectedValue!=null)
            {
                staffsearchbyid = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                ShowInDataGrid(staffsearchbyid);
            }
        }

        private void DisplaySalary_Load(object sender, EventArgs e)
        {
            BindStaffName();
            ShowInDataGrid();
        }
        private void ShowInDataGrid(int id)
        {
           // SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "SELECT t2.StaffName,t1.Position,t1.StaffType,t1.DateOfJoin,t1.[Year],t1.[Month],t1.DatePicker,t1.BasicSalary,t1.AllowanceTotal,t1.Grade,t1.PyableTotal,t1.GrossTotal,t1.Advance,t1.ReturnedAdvance,t1.ProvidentFund,t1.Tax,t1.DeducedTotal,t1.NetTotal FROM dbo.StaffSalaryPaymentInfo t1 INNER JOIN staff.StaffsInfo t2 on t1.StaffId=t2.StaffId WHERE t1.StaffId='"+id+"'";
            //cmd.CommandText = "SELECT * FROM dbo.StaffSalaryPaymentInfo where StaffId='" + id + "'";
            //cmd.CommandText = "SELECT t2.StaffId as StaffId, t2.StaffName,t1.Position,t1.StaffType,t1.DateOfJoin,t1.[Year],t1.[Month],t1.DatePicker,t1.BasicSalary,t1.AllowanceTotal,t1.Grade,t1.PyableTotal,t1.GrossTotal,t1.Advance,t1.ReturnedAdvance,t1.ProvidentFund,t1.Tax,t1.DeducedTotal,t1.NetTotal FROM dbo.StaffSalaryPaymentInfo t1 INNER JOIN staff.StaffsInfo t2 on t1.StaffId=t2.StaffId WHERE t2.StaffName like '" + (textBox1.Text.Trim()) + "%" + "'";
            //DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            //dataGridView1.DataSource = dt;
        }
        private void ShowInDataGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM dbo.StaffSalaryPaymentInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "SELECT t2.StaffName,t1.Position,t1.StaffType,t1.DateOfJoin,t1.[Year],t1.[Month],t1.DatePicker,t1.BasicSalary,t1.AllowanceTotal,t1.Grade,t1.PyableTotal,t1.GrossTotal,t1.Advance,t1.ReturnedAdvance,t1.ProvidentFund,t1.Tax,t1.DeducedTotal,t1.NetTotal FROM dbo.StaffSalaryPaymentInfo t1 INNER JOIN staff.StaffsInfo t2 on t1.StaffId=t2.StaffId WHERE t1.StaffId='"+id+"'";
            //cmd.CommandText = "SELECT * FROM dbo.StaffSalaryPaymentInfo where StaffId='" + id + "'";
            cmd.CommandText = "SELECT t2.StaffId as StaffId, t2.StaffName,t1.Position,t1.StaffType,t1.DateOfJoin,t1.[Year],t1.[Month],t1.DatePicker,t1.BasicSalary,t1.AllowanceTotal,t1.Grade,t1.PyableTotal,t1.GrossTotal,t1.Advance,t1.ReturnedAdvance,t1.ProvidentFund,t1.Tax,t1.DeducedTotal,t1.NetTotal FROM dbo.StaffSalaryPaymentInfo t1 INNER JOIN staff.StaffsInfo t2 on t1.StaffId=t2.StaffId WHERE t2.StaffName like '"+(textBox1.Text.Trim())+"%"+"'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count==0)
            {
                MessageBox.Show("No record found");
            }
            else
            dataGridView1.DataSource = dt;
        }

    }
}
