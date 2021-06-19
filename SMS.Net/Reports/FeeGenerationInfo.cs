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
    public partial class FeeGenerationInfo : Form
    {
        public static int sid;
        public FeeGenerationInfo()
        {
            InitializeComponent();
        }
        public static int id { get; set; }
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            
           // cmd.CommandText = "SELECT DISTINCT StudentName,StudentId from vFeeGenerationInfo where StudentName like'" + textBox1.Text + "%'  AND AcademicYearId='" + Common.Report.ReportParameter.AcademicYearId + "' AND ClassId='" + Common.Report.ReportParameter.ClassId + "'";
            //cmd.CommandText = "SELECT T1.BillGenerationId,T2.StudentName,T3.AcademicYear,T4.Class,NormalFee,ExtraFee,TotalFee,DateOfGeneration FROM dbo.FeeGenerationInfo T1 INNER JOIN student.StudentInfo T2 on T1.StudentId=T2.StudentId INNER JOIN student.AcademicYearInfo T3 on T1.AcademicYearId=T3.AcademicYearId INNER JOIN student.ClassInfo T4 on T1.ClassId=T4.ClassId WHERE T1.BillGenerationId='"+Common.Report.ReportParameter.StudentId+"'";
            cmd.CommandText = "SELECT DISTINCT StudentName, StudentId FROM vFeeGenerationInfo WHERE StudenName like'" + textBox1.Text + "%' AND AcademicYearId='" +Common.Report.ReportParameter.AcademicYearId+ "' AND ClassId='"+Common.Report.ReportParameter.ClassId+"'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if (dt.Rows.Count>=1)
            {
                dataGridView1.DataSource = dt;
            }

        }

        private void AcademicYearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AcademicYearComboBox.SelectedValue != null)
            {
                Common.Report.ReportParameter.AcademicYearId = Convert.ToInt32(AcademicYearComboBox.SelectedValue);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                Common.Report.ReportParameter.ClassId = Convert.ToInt32(comboBox1.SelectedValue);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Common.Report.ReportParameter.studentName = Convert.ToString(dataGridView1[1, e.RowIndex].Value);

            //Reports.MarkReport m = new Reports.MarkReport();
            //m.Show();
            //this.Hide();
        }

        private void FeeGenerationInfo_Load(object sender, EventArgs e)
        {
            BindClassComboBox();
            BindBatch();
        }
    }
}
