using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;



namespace SMS.Net.FeeStructure
{
    public partial class BillPrint : Form
    {
        public BillPrint()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void BillPrint_Load(object sender, EventArgs e)
        {

            ////ReportDocument crp = new ReportDocument();
            ////crp.Load(@"D:\SMS\SMS.Net\SMS.Net\FeeStructure\CrystalReport1.rpt");
          
            ////crystalReportViewer1.ReportSource = crp;
            ////crystalReportViewer1.RefreshReport();

            BindBatch();
            BindClassComboBox();
            BindMonthComboBox();
        

        }
        protected void Page_Unload(object sender,EventArgs e)
        {
            ReportDocument crp = new ReportDocument();
           // crystalReportViewer1.ReportSource.
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            ComboxBatch.DisplayMember = "AcademicYear";
            ComboxBatch.ValueMember = "AcademicYear";
            ComboxBatch.DataSource = dt;
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            ComboxClass.ValueMember = "ClassId";
            ComboxClass.DisplayMember = "Class";
            ComboxClass.DataSource = dt;
        }
        private void BindMonthComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spMontshInfo]", null, true);
            ComboxMonth.ValueMember = "MonthId";
            ComboxMonth.DisplayMember = "MonthName";
            ComboxMonth.DataSource = dt;
        }
        private void BindStudent()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select T2.StudentName AS [Student] from dbo.FeeGenerationInfo T1 INNER JOIN student.StudentInfo T2 ON T1.StudentId=T2.StudentId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            BindStudent();
            ComboxBatch.Text = "";
            ComboxMonth.Text = "";
            ComboxClass.Text = "";
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CrystalReport11_InitReport(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            FeeStructure.BillPrintRpt bpr = new FeeStructure.BillPrintRpt();
            bpr.Show();
        }
       
        }

  
}
