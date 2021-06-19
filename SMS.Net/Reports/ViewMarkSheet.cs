using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Reports
{
    public partial class ViewMarkSheet : Form
    {
        public static int sid;
        public ViewMarkSheet()
        {
            InitializeComponent();
        }
        public static int id { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
           //if(textBox1.Text!="")
           //{
           //    Common.Report.ReportParameter.StudentId = Convert.ToInt32(textBox1.Text.Trim());
           //    Reports.MarkReport m = new Reports.MarkReport();
           //    m.Show();
           //    this.Hide();
           //}
           // else
           //{
           //    MessageBox.Show("Student Id is required");
           //}
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select * from vResultCalc where StudentName like '"+textBox1.Text+"%'";
            cmd.CommandText = "select DISTINCT StudentName,StudentId from vResultCalc where StudentName like'" + textBox1.Text + "%'  AND AcademicYearId='" + Common.Report.ReportParameter.AcademicYearId + "' AND ClassId='" + Common.Report.ReportParameter.ClassId + "' AND ExamId='"+Common.Report.ReportParameter.ExamId+"'";
            DataTable dt=DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>=1)
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            AcademicYearComboBox.DisplayMember = "AcademicYear";
            AcademicYearComboBox.ValueMember = "AcademicYearId";
            AcademicYearComboBox.DataSource = dt;
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            comboBox1.ValueMember = "ClassId";
            comboBox1.DisplayMember = "Class";
            comboBox1.DataSource = dt;
        }

        private void BindExamInfo()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from student.ExaminationInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox2.DisplayMember = "ExamType";
            comboBox2.ValueMember = "ExamId";
            comboBox2.DataSource = dt;
        }

        private void ViewMarkSheet_Load(object sender, EventArgs e)
        {
            BindClassComboBox();
            BindBatch();
            BindExamInfo();
        }

        private void AcademicYearComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(AcademicYearComboBox.SelectedValue!=null)
            {
                Common.Report.ReportParameter.AcademicYearId = Convert.ToInt32(AcademicYearComboBox.SelectedValue);
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                Common.Report.ReportParameter.ClassId = Convert.ToInt32(comboBox1.SelectedValue);
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue!=null)
            {
                Common.Report.ReportParameter.ExamId = Convert.ToInt32(comboBox2.SelectedValue);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Common.Report.ReportParameter.StudentId = Convert.ToInt32(textBox1.Text.Trim());
           
           Common.Report.ReportParameter.studentName=Convert.ToString(dataGridView1[1, e.RowIndex].Value);
           
            Reports.MarkReport m = new Reports.MarkReport();
           m.Show();
           this.Hide();
        }
    }
}
