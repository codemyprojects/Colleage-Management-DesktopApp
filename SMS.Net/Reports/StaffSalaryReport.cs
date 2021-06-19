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
    public partial class StaffSalaryReport : Form
    {
        SqlCommand cmd;
        SqlCommand command;
        SqlConnection con;
        static string constring = "Data Source=(local);Initial Catalog=SMS;Integrated Security=True";
        SqlDataReader rdr;
        int sid;
        public StaffSalaryReport()
        {
            InitializeComponent();
        }

        
        private void StaffSalaryReport_Load(object sender, EventArgs e)
        {

            BindComboBox();
        
        }
        private void BindComboBox()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT T1.StaffId as StaffId,T2.StaffName as StaffName FROM dbo.StaffSalaryPaymentInfo T1  INNER JOIN staff.StaffsInfo T2 on T1.StaffId=T2.StaffId";
            DataTable dt= DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox1.DisplayMember = "StaffName";
            comboBox1.ValueMember = "StaffId";
            comboBox1.DataSource = dt;
            
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                sid =Convert.ToInt32(comboBox1.SelectedValue);
                try
                {
                    //MarksReport cr1 = new MarksReport();
                    StaffSalaryPaymentCrystalReport cr1 = new StaffSalaryPaymentCrystalReport();
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
                   // cmd.CommandText = "SELECT * FROM dbo.StaffSalaryPaymentInfo T1  INNER JOIN staff.StaffsInfo T2 on T1.StaffId=T2.StaffId WHERE T1.StaffId='"+sid+"'";//SELECT * FROM vResultCalc"; 
                    cmd.CommandText = "SELECT T1.StaffId,T2.StaffName,DateOfJoin as [Payment Date],BasicSalary,Grade,AllowanceTotal,DeducedTotal,GrossTotal,NetTotal FROM dbo.StaffSalaryPaymentInfo T1  INNER JOIN staff.StaffsInfo T2 on T1.StaffId=T2.StaffId WHERE T1.StaffId='"+sid+"'";
                    
                    
                    command.CommandText = "SELECT * FROM HotelInfo";
                    myDA.SelectCommand = cmd;
                    myDA.Fill(myDS, "DataTable1");
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
}
