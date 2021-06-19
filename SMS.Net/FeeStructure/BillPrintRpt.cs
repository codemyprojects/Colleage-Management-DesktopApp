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

namespace SMS.Net.FeeStructure
{
    public partial class BillPrintRpt : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\SMS\SMS.Net\SMS.Net\bin\Debug\SMS.mdf;Integrated Security=True;User Instance=True");
        SqlCommand com;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public BillPrintRpt()
        {
            InitializeComponent();
        }

        private void BillPrintRpt_Load(object sender, EventArgs e)
        {
            CrystalAddData();
        }
        public void CrystalAddData()
        {
            //adp = new SqlDataAdapter("select * from vResultCalc", con);
            adp = new SqlDataAdapter("select * from FeeGenerationInfo", con);
            // adp.Fill(ds);
            adp.Fill(ds);
            ReportDocument rd = new ReportDocument();
            //rd.Load(@"E:\SMS\SMS.Net\SMS.Net\Reports\MarksReport.rpt");
            rd.Load(@"E:\SMS\SMS.Net\SMS.Net\FeeStructure\Bill.rpt");
            rd.SetDataSource(ds.Tables[0]);
            //rd.SetDataSource(ds.Tables[1]);
            crystalReportViewer1.ReportSource = rd;
        }
    }
}
