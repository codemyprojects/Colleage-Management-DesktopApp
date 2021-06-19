using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace SMS.Net.Reports
{
    public partial class ViewStudentByRegistration : Form
    {

        static string constring = "Data Source=(local);Initial Catalog=SMS;Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        SqlCommand com;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public ViewStudentByRegistration()
        {
            InitializeComponent();
        }

        private void ViewStudentByRegistration_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string query = "select * from student.MarksheetInfo WHERE AcademicYearId='" + Common.Report.ReportParameter.AcademicYearId + "' AND ClassId='" + Common.Report.ReportParameter.ClassId + "'";
            string query = "SELECT T1.StudentName,T2.AcademicYear,T1.StudentGender,T3.Class,T4.HomeNumber FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN student.GuardiansInfo T4 ON T1.StudentId=T4.StudentId  WHERE StudentCode='"+textBox1.Text.Trim()+"'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if (dt.Rows.Count > 0)
            {
                adp = new SqlDataAdapter(query, con);
                //adp = new SqlDataAdapter("SELECT * FROM vResultCalc	WHERE StudentId='" + Common.Report.ReportParameter.StudentId + "'", con);
                adp.Fill(ds);
                ReportDocument rd = new ReportDocument();
                rd.Load(@"E:\SMS\SMS.Net\SMS.Net\Reports\StudentRegistrationCrystalReport.rpt");
                rd.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = rd;
            }
            else
            {
                MessageBox.Show("Records not found");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN common.ReligionInfo T3 ON T1.ReligionId=T3.ReligionId INNER JOIN student.ClassInfo T5 ON T1.ClassId=T5.ClassId WHERE StudentName LIKE '" + textBox2.Text.Trim() + "%" + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           textBox1.Text = Convert.ToString(dataGridView1[1, e.RowIndex].Value);
         
        }
    }
}
