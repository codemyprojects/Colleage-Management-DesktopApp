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
    public partial class MarkReport : Form
    {
        SqlCommand cmd;
        SqlCommand command;
        SqlConnection con;
        static string constring = "Data Source=(local);Initial Catalog=SMS;Integrated Security=True";
        SqlDataReader rdr;
        public MarkReport()
        {
            InitializeComponent();
        }

        private void MarkReport_Load(object sender, EventArgs e)
        {
            //loadOrganization();
            CrystalAddData();
        }
       
        public void CrystalAddData()
        {        
             try
            {
                MarksReport cr1 = new MarksReport();
                //The report you created.
                cmd = new SqlCommand();
                command = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                //The DataSet you created.
                con = new SqlConnection(constring);
                cmd.Connection = con;
                command.Connection = con;
                //con.Open();
                //cmd.CommandText = "SELECT * FROM dbo.HotelInfo t1 inner  join vResultCalc t2 on t1.ID=t2.ID where t2.StudentId=61";
                cmd.CommandText = "SELECT * FROM vResultCalc WHERE StudentId='" + Common.Report.ReportParameter.studentName + "'";//SELECT * FROM vResultCalc"; 
                command.CommandText = "SELECT * FROM HotelInfo";
                myDA.SelectCommand = cmd;
                myDA.Fill(myDS, "vResultCalc");
                command.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.Text;
                myDA.SelectCommand = command;
                myDA.Fill(myDS, "HotelInfo");
                cr1.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = cr1;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     }
    
        

 }

