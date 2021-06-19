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
    public partial class StudentResultReport : Form
    {
        public StudentResultReport()
        {
            InitializeComponent();
        }

        private void StudentResultReport_Load(object sender, EventArgs e)
        {
            BindBatch();
            BindClassComboBox();
            BindExamInfo();
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
            ExamTypeComboBox.DisplayMember = "ExamType";
            ExamTypeComboBox.ValueMember = "ExamId";
            ExamTypeComboBox.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Reports.ViewStudentResultReport vsr = new Reports.ViewStudentResultReport();
            //vsr.Show();
            //this.Hide();

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

        private void ExamTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ExamTypeComboBox.SelectedValue!=null)
            {
                Common.Report.ReportParameter.ExamId = Convert.ToInt32(ExamTypeComboBox.SelectedValue);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reports.ViewStudentResultReport vsr = new Reports.ViewStudentResultReport();
            vsr.Show();
            this.Hide();

        }
    }
}
