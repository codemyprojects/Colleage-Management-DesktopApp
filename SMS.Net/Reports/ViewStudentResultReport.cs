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
    public partial class ViewStudentResultReport : Form
    {
        static string constring = "Data Source=(local);Initial Catalog=SMS;Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        SqlCommand com;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public ViewStudentResultReport()
        {
            InitializeComponent();
        }

        private void ViewStudentResultReport_Load(object sender, EventArgs e)
        {
           //string query = "select * from student.MarksheetInfo WHERE AcademicYearId='" + Common.Report.ReportParameter.AcademicYearId + "' AND ClassId='" + Common.Report.ReportParameter.ClassId + "'";
            //string query = "select * from student.MarksheetInfo T1 INNER JOIN student.ExaminationInfo T2 ON T1.ExamId=T2.ExamId  WHERE T1.AcademicYearId='"+Common.Report.ReportParameter.AcademicYearId+"' AND T1.ClassId='"+Common.Report.ReportParameter.ClassId+"' AND T1.ExamId='"+Common.Report.ReportParameter.ExamId+"'";
            string query = "SELECT T4.StudentName,T2.AcademicYear, T3.Class,T1.ExamDate ,T3.ClassId,T5.ExamType,T1.TotalMarks,T1.Result,t1.Percentage, T1.Division,T1.Remarks FROM student.MarksheetInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN student.StudentInfo T4 ON T1.StudentId=T4.StudentId INNER JOIN student.ExaminationInfo T5 ON T1.ExamId=T5.ExamId WHERE T1.AcademicYearId='" + Common.Report.ReportParameter.AcademicYearId+ "' AND T3.ClassId='" + Common.Report.ReportParameter.ClassId + "' AND T1.ExamId='" + Common.Report.ReportParameter.ExamId + "' ORDER BY Percentage DESC";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if (dt.Rows.Count > 0)
            {
                adp = new SqlDataAdapter(query, con);
                //adp = new SqlDataAdapter("SELECT * FROM vResultCalc	WHERE StudentId='" + Common.Report.ReportParameter.StudentId + "'", con);
                adp.Fill(ds);
                ReportDocument rd = new ReportDocument();
                rd.Load(@"E:\SMS\SMS.Net\SMS.Net\Reports\ResultSheetCrystalReport.rpt");
                rd.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = rd;
            }
            else
            {
                MessageBox.Show("Records not found");

            }
        
        }


    }
}
