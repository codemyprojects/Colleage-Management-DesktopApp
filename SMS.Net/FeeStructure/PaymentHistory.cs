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
    public partial class PaymentHistory : Form
    {
        int aid;
        int cid;
        int sid;
        public PaymentHistory()
        {
            InitializeComponent();
        }

        private void PaymentHistory_Load(object sender, EventArgs e)
        {
            BindBatch();
            BindClassComboBox();
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            comboBox1.DisplayMember = "AcademicYear";
            comboBox1.ValueMember = "AcademicYearId";
            comboBox1.DataSource = dt;
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            comboBox2.ValueMember = "ClassId";
            comboBox2.DisplayMember = "Class";
            comboBox2.DataSource = dt;
        }
        private void BindComboBox(int aid, int cid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId where T1.AcademicYearId='" + aid + "' AND T1.ClassId='" + cid + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            StudentNameComboBox.DisplayMember = "StudentName";
            StudentNameComboBox.ValueMember = "StudentId";
            StudentNameComboBox.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT TOP 1 GrossTotal1,RecievedAmount,Discount,BalanceAmount FROM PaymentHistoryInfo WHERE StudentId='"+sid+"' AND FeeOfYear='"+aid+"' AND ClassId='"+cid+"' ORDER BY PaymentId DESC";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count==1)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    textBox1.Text = dr["BalanceAmount"].ToString();
                    int d = Convert.ToInt32(dr["Discount"]) * Convert.ToInt32(dr["GrossTotal1"]) / 100;
                    textBox2.Text = d.ToString();
                    textBox3.Text = dr["RecievedAmount"].ToString();
                    textBox4.Text = dr["BalanceAmount"].ToString();
                }
                BindDataGrid();
            }
            else
            {
                MessageBox.Show("No Records!!");
            }

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                aid =Convert.ToInt32(comboBox1.SelectedValue);
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox2.SelectedValue!=null)
            {
                cid =Convert.ToInt32(comboBox2.SelectedValue);
                BindComboBox(aid, cid);
              
            }
        }

        private void StudentNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(StudentNameComboBox.SelectedValue!=null)
            {
                sid = Convert.ToInt32(StudentNameComboBox.SelectedValue);
            }
        }
        private void BindDataGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  GrossTotal1,Discount,GrossTotal2, RecievedAmount,BalanceAmount FROM PaymentHistoryInfo WHERE StudentId='"+sid+"' AND FeeOfYear='"+aid+"' AND ClassId='"+cid+"' ORDER BY PaymentId DESC";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;
        }
    }
}
