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
    public partial class BillInfo : Form
    {
        public double TotalFee = 0;
        public string year;
        public  int yearId;
        public  int c;
        public  string month;
        public  double extrafee=0;
        public  double normalfee = 0;
        public double fee=0;
        public double ofee = 0;
        public double monthlyfee = 0;

        public int aid;
        public int cid;
        public  int sid;
        public string sname;
        //public static string DateOfGeneration;
        public BillInfo()
        {
            InitializeComponent();
            BindBatch();
            BindClassComboBox();
            BindMonthComboBox();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                aid =Convert.ToInt32(comboBox1.SelectedValue);

            }
        }

        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            comboBox1.DisplayMember = "AcademicYear";
            comboBox1.ValueMember = "AcademicYearId";
            comboBox1.DataSource = dt;
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            comboBox2.ValueMember = "ClassId";
            comboBox2.DisplayMember = "Class";
            comboBox2.DataSource = dt;
        }
        private void BindMonthComboBox()
        {
            //DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spMontshInfo]", null, true);
            //MonthComboBox.ValueMember = "MonthId";
            //MonthComboBox.DisplayMember = "MonthName";
            //MonthComboBox.DataSource = dt;
            // DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            BindStudent(yearId,c);
            comboBox1.Text = "";
            comboBox2.Text = "";
            
           // BindDatagrid3();
        }
        private void BindStudent(int year, int c)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT DISTINCT(StudentId),StudentName FROM student.StudentInfo WHERE AcademicYearId='" + aid + "' AND ClassId='" + cid + "'";
                //cmd.CommandText = "SELECT   DISTINCT(T1.StudentId),T2.StudentName FROM dbo.FeeTransferInfo T1 INNER JOIN student.StudentInfo T2 ON T1.StudentId=T2.StudentId INNER JOIN dbo.FeeInfo  T3 ON T1.FeeStatus=T3.FeeStatusId INNER JOIN dbo.FeeStatusInfo T4 ON T3.FeeStatusId=T4.FeeStatusId INNER JOIN dbo.MonthsInfo T5 ON T1.[Month]=T5.MonthId INNER JOIN student.ClassInfo T7 ON T2.ClassId=T7.ClassId WHERE AcademicYearId='"+year+"' AND T7.ClassId='"+c+"'";
                //cmd.CommandText = "SELECT   DISTINCT(T1.StudentId),T2.StudentName FROM dbo.FeeTransferInfo T1 INNER JOIN student.StudentInfo T2 ON T1.StudentId=T2.StudentId INNER JOIN dbo.FeeInfo  T3 ON T1.FeeStatus=T3.FeeStatusId INNER JOIN dbo.FeeStatusInfo T4 ON T3.FeeStatusId=T4.FeeStatusId INNER JOIN dbo.MonthsInfo T5 ON T1.[Month]=T5.MonthId WHERE T4.[Month]='" + c + "' AND T1.AcademicYearId='" + year + "'";
                //cmd.CommandText = "SELECT * FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN dbo.FeeTransferInfo T4 ON T1.StudentId=T4.StudentId WHERE T4.[Month]=1 AND T1.AcademicYearId=1 AND T3.ClassId=1";
                //cmd.CommandText = "SELECT T5.FeeId AS [Fee Id],T5.FeeName  AS Fee,T4.FeeAmount as [Amount] FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN dbo.FeeTransferInfo T4 ON T1.StudentId=T4.StudentId INNER JOIN dbo.FeeInfo T5 ON T4.FeeName=T5.FeeId WHERE T4.[Month]='"+month+"' AND T1.AcademicYearId='"+year+"' AND T3.ClassId='"+c+"'";
                //cmd.CommandText = "SELECT * FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                if(dt.Rows.Count>0)
                {

                    dataGridView1.DataSource = dt;
                    //MonthComboBox.Enabled = true;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                   // Ccombobox.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No Records Found!!");
                    //dataGridView1.DataSource = dt;

                }
           
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClassComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
        //    if (comboBox2.SelectedValue != null)
        //    {
        //        //BindClassComboBox();
        //        c = Convert.ToInt32(Ccombobox.SelectedValue);
        //    }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sid = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                sname = Convert.ToString(dataGridView1[1, e.RowIndex].Value);
                //MessageBox.Show(sid.ToString());
                //BindGrid(sid);
                extrafee = 0;
                TotalFee = 0;
                BindDataGrid2();
                BindDatagrid3();
            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //BindGrid(Convert.ToInt32(id));
        }
        //private void BindGrid(int sid)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //   // cmd.CommandText = "SELECT FeeDetailId as [S.NO],FeeName as [Fee],FeeAmount as [Amount] FROM  dbo.FeeDetailsInfo t1 INNER JOIN student.ClassInfo t2 ON t1.ClassId=t2.ClassId INNER JOIN student.AcademicYearInfo t3 ON t1.AcademicYearId=t3.AcademicYearId inner join  dbo.FeeInfo t4 on t1.FeeId=t4.FeeId WHERE t1.ClassId='" + Class + "' AND t1.FeeStatus='Monthly'";
        //   // cmd.CommandText = "SELECT * FROM dbo.FeeTransferInfo where StudentId='"+id+"'";
        //    //cmd.CommandText = "SELECT  T1.FeeTransferId,T5.[MonthName],T4.FeeStatus ,T3.FeeName,T1.FeeAmount FROM dbo.FeeTransferInfo T1 INNER JOIN student.StudentInfo T2 ON T1.StudentId=T2.StudentId INNER JOIN dbo.FeeInfo  T3 ON T1.FeeStatus=T3.FeeStatusId INNER JOIN dbo.FeeStatusInfo T4 ON T3.FeeStatusId=T4.FeeStatusId INNER JOIN dbo.MonthsInfo T5 ON T1.[Month]=T5.MonthId WHERE T1.StudentId='" + sid + "' ";
        //    cmd.CommandText = "SELECT T1.FeeTransferId AS ID , T2.FeeName , T1.FeeAmount FROM FeeTransferInfo T1 INNER JOIN FeeInfo T2 ON T1.FeeName=T2.FeeId  WHERE StudentId='" + sid + "'";
        //    DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
        //    if (dt.Rows.Count >= 1)
        //    {
        //        dataGridView2.DataSource = dt;
        //        dataGridView2.Visible = true;
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            TotalFee = TotalFee +Convert.ToDouble(dr["FeeAmount"].ToString());
        //        }
        //        TotalFeeTextBox.Text =Convert.ToString(TotalFee+monthlyfee);
        //        textBox2.Text = Convert.ToString(TotalFee);

        //    }
        //    else
        //    {
        //        MessageBox.Show("No Record Found");
        //        dataGridView1.Visible = false;
        //        TotalFeeTextBox.Text = string.Empty;
        //        // PaidAmountTextBox.Text = string.Empty;
        //        //DueAmountTextBox.Text = string.Empty;
        //    }

        //    //dataGridView2.DataSource = dt;

        //}

        private void BindDataGrid2()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT FeeDetailId as [S.NO],FeeName as [Fee],FeeAmount as [Amount] FROM  dbo.FeeDetailsInfo t1 INNER JOIN student.ClassInfo t2 ON t1.ClassId=t2.ClassId INNER JOIN student.AcademicYearInfo t3 ON t1.AcademicYearId=t3.AcademicYearId inner join  dbo.FeeInfo t4 on t1.FeeId=t4.FeeId WHERE t4.FeeStatusId=3 AND t1.AcademicYearId='" + aid + "' AND t2.classId='" + cid + "' ";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>0)
            {
                dataGridView2.DataSource = dt;
                foreach(DataRow dr in dt.Rows)
                {
                    extrafee = extrafee + Convert.ToDouble(dr["Amount"]);
                }
                textBox2.Text = Convert.ToString(extrafee);
            }
           
        }
        private void BillInfo_Load(object sender, EventArgs e)
        {
            //BindDatagrid3();
           // MonthComboBox.Enabled = false;
        }

        private void MonthComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if(MonthComboBox.SelectedValue!=null)
            //{
            //    month = MonthComboBox.SelectedValue.ToString();
            //}
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "SELECT StudentId FROM dbo.FeeGenerationInfo WHERE StudentId='"+sid+"' ORDER BY BillGenerationId DESC";
            //if(DataBaseLayer.DbOperations.GetDataTable(cm).Rows.Count==1)
           // {
                //MessageBox.Show("Bill Already Generated !!");
            //}
            //else
            //{
                SqlCommand cmd = new SqlCommand();
                // cmd.CommandText = "INSERT INTO  dbo.PaymentHistoryInfo(FeeTransferId,DateOfPayment,FeeOfYear,FeeOfMonth,GrossTotal1,Discount,GrossTotal2,RecievedAmount,BalanceAmount) VALUES(1,'"+DateOfGeneration+ "','"+year+"','"+month+"','"+Convert.ToDouble(textBox1.Text.Trim())+"','"+Convert.ToDouble(textBox2.Text.Trim())+"','"+Convert.ToDouble(TotalFeeTextBox.Text.Trim()+"','')";
                cmd.CommandText = "INSERT INTO dbo.FeeGenerationInfo(DateOfGeneration,StudentId,AcademicYearId,ClassId,[NormalFee],[ExtraFee],[TotalFee]) VALUES('" + dateTimePicker1.Text.Trim() + "','" + sid + "','" + aid + "','" + cid + "','" + monthlyfee + "','" + Convert.ToDouble(textBox2.Text.Trim()) + "','" + Convert.ToDouble(TotalFeeTextBox.Text.Trim()) + "')";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                if (x == 1)
                    MessageBox.Show("Saved Successfully");
                else
                    MessageBox.Show("Due to some problem Data not saved");
           // }

            
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {

        }
        private void BindDatagrid3()
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "SELECT FeeDetailId as [S.NO],FeeName as [Fee],FeeAmount as [Amount] FROM  dbo.FeeDetailsInfo t1 INNER JOIN student.ClassInfo t2 ON t1.ClassId=t2.ClassId INNER JOIN student.AcademicYearInfo t3 ON t1.AcademicYearId=t3.AcademicYearId inner join  dbo.FeeInfo t4 on t1.FeeId=t4.FeeId WHERE FeeStatus=1   AND t2.ClassId='" + c + "' AND t1.AcademicYearId='" + yearId + "' ";
           // cmd.CommandText = "SELECT T1.FeeId,T1.FeeName,T4.FeeStatus,T4.FeeAmount FROM dbo.FeeInfo t1 inner join dbo.FeeStatusInfo t2 on t1.FeeStatusId=t2.FeeStatusId INNER JOIN FeeStatusInfo t3 ON t1.FeeStatusId=t3.FeeStatusId INNER JOIN FeeDetailsInfo T4 ON t3.FeeStatus=T4.FeeStatus WHERE T3.FeeStatus='Monthly'";
            cmd.CommandText = "SELECT FeeDetailId as [S.NO],FeeName as [Fee],FeeAmount as [Amount] FROM  dbo.FeeDetailsInfo t1 INNER JOIN student.ClassInfo t2 ON t1.ClassId=t2.ClassId INNER JOIN student.AcademicYearInfo t3 ON t1.AcademicYearId=t3.AcademicYearId inner join  dbo.FeeInfo t4 on t1.FeeId=t4.FeeId WHERE FeeStatusId=1 AND t1.AcademicYearId='"+aid+"' AND t2.classId='"+cid+"' ";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>=1)
            {
                dataGridView3.DataSource = dt;
                foreach(DataRow dr in dt.Rows)
                {
                    if (dr["Fee"].ToString().Equals("monthly") || dr["Fee"].ToString().Equals("Monthly") || dr["Fee"].ToString().Equals("tution") || dr["Fee"].ToString().Equals("Tution") || dr["Fee"].ToString().Equals("Tution Fee"))
                    {
                       fee = 12*Convert.ToDouble(dr["Amount"]);
                    }
                    else
                    {
                        ofee = Convert.ToDouble(dr["Amount"]);
                    }
                    
                }
                monthlyfee =ofee+ fee;
                textBox1.Text =Convert.ToString(monthlyfee);
                TotalFee = monthlyfee + extrafee;
                TotalFeeTextBox.Text = Convert.ToString(TotalFee);
            }
          

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //DateOfGeneration = dateTimePicker1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                //BindClassComboBox();
                cid = Convert.ToInt32(comboBox2.SelectedValue);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        //    TotalFee =monthlyfee + extrafee;
        //    TotalFeeTextBox.Text = Convert.ToString(TotalFee);
        }

        private void TotalFeeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

     }
}