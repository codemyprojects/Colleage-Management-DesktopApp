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
    public partial class ViewStaffsInfoReport : Form
    {
        static string constring = "Data Source=(local);Initial Catalog=SMS;Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        SqlCommand com;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public ViewStaffsInfoReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string query = "select * from student.MarksheetInfo WHERE AcademicYearId='" + Common.Report.ReportParameter.AcademicYearId + "' AND ClassId='" + Common.Report.ReportParameter.ClassId + "'";
            string query = "SELECT T1.StaffName,T1.StaffEmail,T1.StaffType ,T1.StaffEnrollMentDate,T2.DepartmentName,T1.StaffContact from staff.StaffsInfo T1 INNER JOIN staff.DepartmentInfo T2 ON T1.DepartmentId=T2.DepartmentId WHERE T1.StaffCode='"+textBox1.Text.Trim()+"'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            //DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if (dt.Rows.Count > 0)
            {
                adp = new SqlDataAdapter(query, con);
                //adp = new SqlDataAdapter("SELECT * FROM vResultCalc	WHERE StudentId='" + Common.Report.ReportParameter.StudentId + "'", con);
                adp.Fill(ds);
                ReportDocument rd = new ReportDocument();
                rd.Load(@"E:\SMS\SMS.Net\SMS.Net\Reports\StaffsInfoCrystalReport.rpt");
                rd.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = rd;
            }
            else
            {
                MessageBox.Show("Records not found");

            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void ViewStaffsInfoReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sMSDataSet9.StaffsInfo' table. You can move, or remove it, as needed.
            this.staffsInfoTableAdapter.Fill(this.sMSDataSet9.StaffsInfo);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1[0, e.RowIndex].Value);
        }
    }
}
