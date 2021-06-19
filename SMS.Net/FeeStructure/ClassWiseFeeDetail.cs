using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.FeeStructure
{
    public partial class ClassWiseFeeDetail : Form
    {
        public static int  fid;
        public static int fstatus;
        public static string academicYear="";
        public static string c="";
        public static int cid=1;
        public static int aid=1;
        public static int choice;
        public string fs;

        public ClassWiseFeeDetail()
        {
            InitializeComponent();
        }
        private void BindYears()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM student.AcademicYearInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            AcademicYearComboBox.DisplayMember = "AcademicYear";
            AcademicYearComboBox.ValueMember = "AcademicYearId";
            AcademicYearComboBox.DataSource = dt;
        }
        //private void BindComboBox(string FeeStatus)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SELECT FeeId,FeeName,FeeStatus FROM dbo.FeeInfo t1 inner join dbo.FeeStatusInfo t2 on t1.FeeStatusId=t2.FeeStatusId WHERE FeeStatus='" + FeeStatus + "'";
        //    FeeStatusComboBox.DisplayMember = "FeeName";
        //    FeeStatusComboBox.ValueMember = "FeeId";
        //    DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
        //    FeeStatusComboBox.DataSource = dt;

        //}
        private void ClassInfo()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.spClassInfo", null, true);
            if (dt.Rows.Count > 0)
            {
                comboBox1.Items.Clear();
                comboBox1.ValueMember = "ClassId";
                comboBox1.DisplayMember = "Class";
                comboBox1.DataSource = dt;
            }
        }
         private void BindFeeStatusComboBox()
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "SELECT  [FeeStatusId],[FeeStatus] FROM [FeeStatusInfo]";
            cmd.CommandText = "SELECT  * FROM dbo.FeeStatusInfo WHERE FeeStatusId!=2";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            FeeStatusComboBox.DisplayMember = "FeeStatus";
            FeeStatusComboBox.ValueMember = "FeeStatus";
            FeeStatusComboBox.DataSource = dt;
        }
  

        private void FeeStatusComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

 

        private void ClassWiseFeeDetail_Load(object sender, EventArgs e)
        {
            BindYears();
           // BindComboBox();
            ClassInfo();
            BindFeeStatusComboBox();
        }
     
        private void FeeStatusComboBox_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if(FeeStatusComboBox.SelectedValue!=null)
            {
                fs =Convert.ToString(FeeStatusComboBox.SelectedValue);
            }
        }

        private void AcademicYearComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(AcademicYearComboBox.SelectedValue!=null)
            {
                aid = Convert.ToInt32(AcademicYearComboBox.SelectedValue);
                
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                cid =Convert.ToInt32 (comboBox1.SelectedValue);
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {

            if (aid == 1)
            {
                MessageBox.Show("Please Select Year", "Read Message");
               // AcademicYearComboBox.SelectedIndex = AcademicYearComboBox.FindString("Select One");
            }
            else if (cid == 1)
            {
                MessageBox.Show("Please Select Class", "Read Message");
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select T1.FeeDetailId AS Sno, T2.FeeName,T1.FeeAmount from FeeDetailsInfo T1 INNER JOIN FeeInfo T2 ON T1.FeeId=T2.FeeId where T1.AcademicYearId='" + aid + "' and T1.ClassId='" + cid + "' AND T1.FeeStatus='" + fs + "'";
                // cmd.CommandText = "SELECT FeeDetailId as [S.NO],FeeName as [Fee],FeeAmount as [Amount] FROM  dbo.FeeDetailsInfo t1 INNER JOIN student.ClassInfo t2 ON t1.ClassId=t2.ClassId INNER JOIN student.AcademicYearInfo t3 ON t1.AcademicYearId=t3.AcademicYearId inner join  dbo.FeeInfo t4 on t1.FeeId=t4.FeeId WHERE FeeStatusId='" + fid + "'   AND t1.ClassId='" + cid + "' AND t1.AcademicYearId='" + aid + "' ";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                if (dt.Rows.Count != 0)
                {
                    dataGridViewFeeDetails.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No Records Please!!");
                    AcademicYearComboBox.Text = "";
                    ClassComboBox.Text = "";
                    FeeStatusComboBox.Text = "";
                }

            }
        
        }

        private void AcademicYearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
