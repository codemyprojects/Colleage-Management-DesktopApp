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
    public partial class BillPayment : Form
    {
        public static int sid;
        public double discount=0;
        public double receiveamt = 0;
        public static int feegid;
        public static string Date;

        public int lMonth;
        public int year;
        public int month;
        public int c;
        public double due = 0;
        public BillPayment()
        {
            InitializeComponent();
        }

        private void BillPayment_Load(object sender, EventArgs e)
        {
            BindBatch();
          //  BindClassComboBox();
            //BindComboBox();
            BindMonthComboBox();
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            comboBox2.ValueMember = "ClassId";
            comboBox2.DisplayMember = "Class";
            comboBox2.DataSource = dt;
            textBox2.Text = GetRandomCode();
        }
        private string GetRandomCode()
        {
            var chars = "0123456789";
            var stringChars = new char[4];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return "RNO1" + finalString;

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
            //DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            //comboBox2.ValueMember = "ClassId";
            //comboBox2.DisplayMember = "Class";

        }
        private void BindStudent(int id)
        {
            SqlCommand cmd = new SqlCommand();
           // cmd.CommandText = "SELECT T1.StudentId,T1.StudentName,T2.AcademicYear,T3.ClassId,T4.FeeStatus,T4.FeeName,T4.FeeAmount,T4.[Year] FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN dbo.FeeTransferInfo T4 ON T1.StudentId=T4.StudentId  WHERE T4.[Year]='2003'";// "SELECT * FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId WHERE T1.StudentId='"+id+"'";
            cmd.CommandText = "SELECT BillGenerationId as ID,DateOfGeneration as [Date],NormalFee,ExtraFee,TotalFee FROM dbo.FeeGenerationInfo WHERE StudentId='" + id + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>=1)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    textBox3.Text = dr["TotalFee"].ToString();
                    //feegid = Convert.ToInt32(dr["FeeGenerationId"].ToString());
                    
                }
            }
            dataGridView1.DataSource = dt;
        }

        private void BindStudent()
        {
            SqlCommand cmd = new SqlCommand();
            // cmd.CommandText = "SELECT T1.StudentId,T1.StudentName,T2.AcademicYear,T3.ClassId,T4.FeeStatus,T4.FeeName,T4.FeeAmount,T4.[Year] FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN dbo.FeeTransferInfo T4 ON T1.StudentId=T4.StudentId  WHERE T4.[Year]='2003'";// "SELECT * FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId WHERE T1.StudentId='"+id+"'";
            cmd.CommandText = "SELECT TOP 1 BillGenerationId as ID,DateOfGeneration as [Date],NormalFee,ExtraFee,TotalFee FROM dbo.FeeGenerationInfo WHERE StudentId='" + sid + "' ORDER BY BillGenerationId DESC";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>=1)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please Generate Bill !");
            }
           // return dt.Rows.Count;
            
        }
        private void BindComboBox(int aid,int cid)
        { 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM student.StudentInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId where T1.AcademicYearId='"+aid+"' AND T1.ClassId='"+cid+"'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            StudentNameComboBox.DisplayMember = "StudentName";
            StudentNameComboBox.ValueMember = "StudentId";
            StudentNameComboBox.DataSource = dt;
        }

        private void StudentNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(StudentNameComboBox.SelectedValue!=null)
            {
                sid =Convert.ToInt32(StudentNameComboBox.SelectedValue);
              //  MessageBox.Show(sid.ToString());
                int monthId= lastMonth(sid);
                BindMonthComboBox(monthId);

                BindPaymentHistory(sid);
                BindStudent();
                due = 0;
                //BindStudent(sid);

            }
        }

        private void DiscountTextBox_TextChanged(object sender, EventArgs e)
        {
            discount = Convert.ToDouble(DiscountTextBox.Text.Trim());
            double d = Convert.ToDouble(textBox3.Text.Trim()) * discount / 100;
            GrossTotal2.Text = Convert.ToString(Convert.ToDouble(textBox3.Text.Trim()) - d);
        }

        private void ReceiveAmount_TextChanged(object sender, EventArgs e)
        {
            receiveamt = Convert.ToDouble(ReceiveAmount.Text.Trim());
            double gtotal=Convert.ToDouble(GrossTotal2.Text.Trim());
            BalanceAmount.Text =Convert.ToString(gtotal - receiveamt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox3.Text!=string.Empty && textBox2.Text!=string.Empty && DiscountTextBox.Text!=string.Empty && ReceiveAmount.Text!=string.Empty &&BalanceAmount.Text!=string.Empty && GrossTotal2.Text!=string.Empty && dateTimePicker1.Text!=string.Empty && c!=0 && month!=0 && year!=0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO dbo.PaymentHistoryInfo(StudentId,DateOfPayment,ReceiptNo,FeeOfYear,FeeOfMonth,ClassId,GrossTotal1,Discount,GrossTotal2,RecievedAmount,BalanceAmount) VALUES('" + sid + "','" + dateTimePicker1.Text + "','"+textBox2.Text.Trim()+"','" + year + "','" + month + "','" + c + "','" + Convert.ToDouble(textBox3.Text.Trim()) + "','" + Convert.ToDouble(DiscountTextBox.Text.Trim()) + "','" + Convert.ToDouble(GrossTotal2.Text.Trim()) + "','" + Convert.ToDouble(ReceiveAmount.Text.Trim()) + "','" + Convert.ToDouble(BalanceAmount.Text.Trim()) + "')";
                    int success = DataBaseLayer.DbOperations.ExecProc(cmd);
                    if (success == 1)
                    {
                        MessageBox.Show("Payment History Saved Succcessfully!!");
                        BindPaymentHistory(sid);
                        textBox2.Text = GetRandomCode();
                        AcademicYearComboBox.Text = "";
                        comboBox2.Text = "";
                        dateTimePicker1.Text = "";
                        StudentNameComboBox.Text="";
                        MonthComboBox.Text = "";
                        textBox2.Text = string.Empty;
                        GrossTotal2.Text = string.Empty;
                        DiscountTextBox.Text = string.Empty;
                        textBox3.Text = string.Empty;
                        ReceiveAmount.Text = string.Empty;
                        BalanceAmount.Text = string.Empty;
                    }

                    else
                        MessageBox.Show("Payment History saving failed!!");
                }
                else
                {
                    MessageBox.Show("Supply value to text boxes && Select Apropirate Value from combobox");
                }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            Date = dateTimePicker1.Text;
        }

        private void AcademicYearComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(AcademicYearComboBox.SelectedValue!=null)
            {
                year =Convert.ToInt32(AcademicYearComboBox.SelectedValue);
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                c = Convert.ToInt32(comboBox2.SelectedValue);
                BindComboBox(year, c);
            }

        }

        private void MonthComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(MonthComboBox.SelectedValue!=null)
            {
                month =Convert.ToInt32(MonthComboBox.SelectedValue);
            }
        }
        private void BindMonthComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spMontshInfo]", null, true);
            MonthComboBox.ValueMember = "MonthId";
            MonthComboBox.DisplayMember = "MonthName";
            MonthComboBox.DataSource = dt;
        }
        private void BindMonthComboBox(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from MonthsInfo where MonthId>'"+id+"'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            MonthComboBox.ValueMember = "MonthId";
            MonthComboBox.DisplayMember = "MonthName";
            MonthComboBox.DataSource = dt;
        }
        private int lastMonth(int iD)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select  top 1 FeeOfMonth from dbo.PaymentHistoryInfo where StudentId='"+iD+"' order by FeeOfMonth desc";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count==1)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    lMonth =Convert.ToInt32(dr["FeeOfMonth"]);
                }
            }
            return lMonth;
            //MonthComboBox.ValueMember = "MonthId";
            //MonthComboBox.DisplayMember = "MonthName";
            //MonthComboBox.DataSource = dt;
        }
       private void BindPaymentHistory(int studentid)
        {
           SqlCommand cm=new SqlCommand();
           cm.CommandText = "SELECT PaymentId as ID,DateOfPayment [Payment Date],ReceiptNo,T2.[MonthName] AS [Fee Of Month],GrossTotal1 as[Total],Discount,GrossTotal2 as [Total After Discount],RecievedAmount as Recieved,BalanceAmount as [Due Amount]  FROM dbo.PaymentHistoryInfo T1 INNER JOIN MonthsInfo T2 ON T1.FeeOfMonth=T2.MonthId WHERE StudentId='" + studentid + "' ORDER BY BalanceAmount ASC";
           DataTable dta=DataBaseLayer.DbOperations.GetDataTable(cm);
           if(dta.Rows.Count>=1)
           {
                dataGridView3.DataSource = dta; 
                int i = 0; 
                foreach (DataRow dr in dta.Rows)
                {
                    if(i==1)
                    {
                        break;
                    }
                    due = due + Convert.ToDouble(dr["Due Amount"].ToString());
                    i = i + 1;
                }
                //textBox1.Text = Convert.ToString(due);
                //BalanceAmount.Text = Convert.ToString(due);
                textBox3.Text = Convert.ToString(due);
                
            }
           else
           {
                    BindStudent(sid);
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "SELECT * FROM dbo.PaymentHistoryInfo WHERE StudentId='"+studentid+"'";
                    //DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                    //if(dt.Rows.Count>0)
                    //{
                    //    foreach(DataRow dr in dt.Rows)
                    //    {
                    //       due = due +Convert.ToDouble(dr["BalanceAmount"].ToString());
                    //    }
                    //    //textBox1.Text = Convert.ToString(due);
                    //    BalanceAmount.Text = Convert.ToString(due);
                    //    //textBox3.Text = Convert.ToString(due);
                    //    dataGridView3.DataSource = dt;
                    //}
          }
            

        }
       private void BindPaymentHistory()
       {
           SqlCommand cmd = new SqlCommand();
           cmd.CommandText = "SELECT * FROM dbo.PaymentHistoryInfo ORDER BY BalanceAmount ASC";
           DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
           if (dt.Rows.Count > 0)
           {
               dataGridView3.DataSource = dt;
           }

       }

       private void GrossTotal2_TextChanged(object sender, EventArgs e)
       {

       }
    }
}
