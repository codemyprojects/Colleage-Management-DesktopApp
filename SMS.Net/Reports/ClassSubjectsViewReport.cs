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
    public partial class ClassSubjectsViewReport : Form
    {
        static string constring = "Data Source=(local);Initial Catalog=SMS;Integrated Security=True";
        public static int aid;
        public static int cid;
        SqlConnection con = new SqlConnection(constring);
        SqlCommand com;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public ClassSubjectsViewReport()
        {
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "SELECT * FROM dbo.SubjectsInfo T1 INNER JOIN student.StudentInfo T2 ON T1.ClassId=T2.ClassId INNER JOIN student.AcademicYearInfo T3 ON T2.AcademicYearId=T3.AcademicYearId WHERE T1.ClassId=9 AND T3.AcademicYearId=2";
            string query = "SELECT * FROM dbo.SubjectsInfo T1 INNER JOIN student.StudentInfo T2 ON T1.ClassId=T2.ClassId INNER JOIN student.AcademicYearInfo T3 ON T2.AcademicYearId=T3.AcademicYearId WHERE T1.ClassId='"+cid+"' AND T3.AcademicYearId='"+aid+"'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if (dt.Rows.Count > 0)
            {
                adp = new SqlDataAdapter(query, con);
                //adp = new SqlDataAdapter("SELECT * FROM vResultCalc	WHERE StudentId='" + Common.Report.ReportParameter.StudentId + "'", con);
                adp.Fill(ds);
                ReportDocument rd = new ReportDocument();
                rd.Load(@"E:\SMS\SMS.Net\SMS.Net\Reports\AcademicYearwiseClassSubjectsCrystalReport.rpt");
                rd.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = rd;
            }
            else
            {
                MessageBox.Show("Records not found");
                comboBox1.SelectedIndex = comboBox1.FindString("Select One");
                AcademicYearComboBox.SelectedIndex = AcademicYearComboBox.FindString("Select One");

            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(AcademicYearComboBox.SelectedValue!=null)
            {
                aid = Convert.ToInt32(AcademicYearComboBox.SelectedValue);
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                cid = Convert.ToInt32(comboBox1.SelectedValue);
            }
        }

        private void ClassSubjectsViewReport_Load(object sender, EventArgs e)
        {
            BindBatch();
            BindClassComboBox();
        }
    }
}
