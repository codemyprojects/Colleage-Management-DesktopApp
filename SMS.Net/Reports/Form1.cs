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
    public partial class Form1 : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        static string constring = "Data Source=(local);Initial Catalog=SMS;Integrated Security=True";
        SqlDataReader rdr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CrystalReport1 cr1 = new CrystalReport1();
                //The report you created.
                cmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                //The DataSet you created.
                con = new SqlConnection(constring);
                cmd.Connection = con;
                //con.Open();
                cmd.CommandText = "SELECT StaffName,HotelName,Logo FROM staff.StaffsInfo,dbo.HotelInfo WHERE StaffCode='S12'";
                //cmd.CommandText = "SELECT BillNo,BillDate,VATAmount,DiscountAmount,GrandTotal,CurrencyName from Invoice_Info,Currency where Invoice_Info.CurrencyID=Currency.ID and BillDate between @d1 and @d2 order by BillDate";
                //cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "BillDate").Value = dtpInvoiceDateFrom.Value.Date;
                //cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = dtpInvoiceDateTo.Value.Date;
                cmd.CommandType = CommandType.Text;
                myDA.SelectCommand = cmd;
                myDA.Fill(myDS, "HotelInfo");
                myDA.Fill(myDS, "StaffsInfo");
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
