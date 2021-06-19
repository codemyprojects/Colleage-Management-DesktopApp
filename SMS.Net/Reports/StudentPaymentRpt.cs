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
    public partial class StudentPaymentRpt : Form
    {
        static string constring = "Data Source=(local);Initial Catalog=SMS;Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        SqlCommand com;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public int sid;
        public int aid;
        public StudentPaymentRpt()
        {
            InitializeComponent();
        }
        private void BindBatch()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText="select * from student.AcademicYearInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
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
        private void BinStudent()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT StudentId,StudentName FROM student.StudentInfo where AcademicYearId='"+aid+"' and ClassId='"+Common.Report.ReportParameter.ClassId+"'";
            DataTable dt= DataBaseLayer.DbOperations.GetDataTable(cmd);
            StudentNameComboBox.DisplayMember = "StudentName";
            StudentNameComboBox.ValueMember = "StudentId";
            StudentNameComboBox.DataSource = dt;
        }
        private void AcademicYearComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (AcademicYearComboBox.SelectedValue != null)
            {
                aid = Convert.ToInt32(AcademicYearComboBox.SelectedValue);
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                Common.Report.ReportParameter.ClassId = Convert.ToInt32(comboBox1.SelectedValue);
            }
        }

        private void StudentNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(StudentNameComboBox.SelectedValue!=null)
            {
                sid =Convert.ToInt32(StudentNameComboBox.SelectedValue);
               // BinStudent(sid);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void StudentPaymentRpt_Load(object sender, EventArgs e)
        {
            BindBatch();
            BindClassComboBox();
        
        }

        private void comboBox1_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                Common.Report.ReportParameter.ClassId =Convert.ToInt32(comboBox1.SelectedValue);
                BinStudent();
 
            }
            
        }

        private void AcademicYearComboBox_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if(AcademicYearComboBox.SelectedValue!=null)
            {
                aid = Convert.ToInt32(AcademicYearComboBox.SelectedValue);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string query = "select * from student.MarksheetInfo T1 INNER JOIN student.ExaminationInfo T2 ON T1.ExamId=T2.ExamId  WHERE T1.AcademicYearId='" + Common.Report.ReportParameter.AcademicYearId + "' AND T1.ClassId='" + Common.Report.ReportParameter.ClassId + "' AND T1.ExamId='" + Common.Report.ReportParameter.ExamId + "'";
            string query = "SELECT PaymentId as ID,DateOfPayment [Payment Date],ReceiptNo,T2.[MonthName] AS [Fee Of Month],GrossTotal1 as[Total],Discount,GrossTotal2 as [Total After Discount],RecievedAmount as Recieved,BalanceAmount as [Due Amount]  FROM dbo.PaymentHistoryInfo T1 INNER JOIN MonthsInfo T2 ON T1.FeeOfMonth=T2.MonthId WHERE StudentId='" + sid + "' ORDER BY BalanceAmount ASC";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if (dt.Rows.Count > 0)
            {
                adp = new SqlDataAdapter(query, con);
                //adp = new SqlDataAdapter("SELECT * FROM vResultCalc	WHERE StudentId='" + Common.Report.ReportParameter.StudentId + "'", con);
                adp.Fill(ds);
                ReportDocument rd = new ReportDocument();
                rd.Load(@"E:\SMS\SMS.Net\SMS.Net\Reports\CrystalReportStudentPayment.rpt");
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
