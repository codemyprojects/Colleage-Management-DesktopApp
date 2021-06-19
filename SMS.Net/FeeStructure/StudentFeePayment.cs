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
    public partial class StudentFeePayment : Form
    {
        public int TotalFee = 0;
        public static int PaidAmount = 0;
        public int DueAmount = 0;
        public static string yr;
        public StudentFeePayment()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                StartComboBox.Visible = true;
                label3.Visible = false;
                EndComboBox.Visible = false;
            }
        }
        private void BindMonths()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM dbo.MonthsInfo";
            DataTable dt = new DataTable();
            dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            StartComboBox.DisplayMember = "MonthName";
            StartComboBox.ValueMember = "MonthId";
            StartComboBox.DataSource = dt;
        }
        private void EndBindMonths()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM dbo.MonthsInfo";
            DataTable dt = new DataTable();
            dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            EndComboBox.DisplayMember = "MonthName";
            EndComboBox.ValueMember = "MonthId";
            EndComboBox.DataSource = dt;
        }
        private void StudentFeePayment_Load(object sender, EventArgs e)
        {
            BindMonths();
            EndBindMonths();
            StartComboBox.Visible = false;
            label3.Visible = false;
            EndComboBox.Visible = false;
            BindClassComboBox();
            panel1.Visible = false;
            BindYears();
            BindSection();
           
           // BindGrid();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
                StartComboBox.Visible = true;
                label3.Visible = true;
                EndComboBox.Visible = true;
            }
        }
        private void BindGrid(int Class,string year)
        {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT FeeDetailId as [S.NO],AcademicYear as [Year],Class,FeeName as [Fee],FeeAmount as [Amount] FROM  dbo.FeeDetailsInfo t1 INNER JOIN student.ClassInfo t2 ON t1.ClassId=t2.ClassId INNER JOIN student.AcademicYearInfo t3 ON t1.AcademicYearId=t3.AcademicYearId inner join  dbo.FeeInfo t4 on t1.FeeId=t4.FeeId WHERE t1.ClassId='" + Class + "' AND T3.AcademicYearId='"+year+"'";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                if(dt.Rows.Count>1)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
                    foreach (DataRow dr in dt.Rows)
                    {
                        TotalFee = TotalFee + Convert.ToInt32(dr["Amount"].ToString());
                    }
                    TotalFeeTextBox.Text = Convert.ToString(TotalFee);
                }
                else
                {
                    MessageBox.Show("No Record Found");
                    dataGridView1.Visible = false;
                    TotalFeeTextBox.Text = string.Empty;
                    PaidAmountTextBox.Text = string.Empty;
                    DueAmountTextBox.Text = string.Empty;
                }
             
            
   
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //public string GetYear(string year)
        //{
        //    return year;
        //}
        private void ClassComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ClassComboBox.SelectedValue!=null)
            {
                TotalFee = 0;
                BindGrid(Convert.ToInt32(ClassComboBox.SelectedValue.ToString()),yr);
                BindStudent(Convert.ToInt32(ClassComboBox.SelectedValue.ToString()));
            }
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            ClassComboBox.DisplayMember = "Class";
            ClassComboBox.ValueMember = "ClassId";
            ClassComboBox.DataSource = dt;
        }

        private void PaidAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            if(PaidAmountTextBox.Text==string.Empty)
            {
                PaidAmount = 0;
            }
            else
            {
                PaidAmount = Convert.ToInt32(PaidAmountTextBox.Text.Trim());
                DueAmountTextBox.Text = Convert.ToString(Convert.ToInt32(TotalFeeTextBox.Text.Trim()) - PaidAmount);
            }
     
            
        }

        private void PayButtton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into dbo.StudentFeePayments(PaidDate,AcademicYearId,ClassId,SectionId,StudentId,RollNO,TotalFee,PaidAmount,DueAmount,Narration) values ('" + dateTimePicker1.Text.Trim() + "','" + Convert.ToInt32(AcademicYearComboBox.SelectedValue.ToString()) + "','" + Convert.ToInt32(ClassComboBox.SelectedValue.ToString()) + "','" + Convert.ToInt32(SectionComboBox.SelectedValue.ToString()) + "','" + Convert.ToInt32(StudentNameComboBox.SelectedValue.ToString()) + "','" + RollNo.Text.Trim() + "','" + Convert.ToDouble(TotalFeeTextBox.Text.Trim()) + "','" + Convert.ToDouble(PaidAmountTextBox.Text.Trim()) + "','" + Convert.ToDouble(DueAmountTextBox.Text.Trim()) + "','" + richTextBox1.Text.Trim() + "') ";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Student Payment Added Successfully!!");
            }
        }
        private void BindYears()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from student.AcademicYearInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            AcademicYearComboBox.DisplayMember = "AcademicYear";
            AcademicYearComboBox.ValueMember = "AcademicYearId";
            AcademicYearComboBox.DataSource = dt;
        }
        private void BindSection()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from student.SectionInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            SectionComboBox.DisplayMember = "SectionName";
            SectionComboBox.ValueMember = "SectionId";
            SectionComboBox.DataSource = dt;
        }
        private void BindStudent(int cid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM student.StudentInfo WHERE  ClassId='"+cid+"'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count==0)
            {
                MessageBox.Show("No Record Found");
                //StudentNameComboBox.Items.Clear();
            }
            else
            {
                StudentNameComboBox.DisplayMember = "StudentName";
                StudentNameComboBox.ValueMember = "StudentId";
                StudentNameComboBox.DataSource = dt;

            }
           
        }

        private void StudentNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(StudentNameComboBox.SelectedValue!=null)
            {

            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TotalFeeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void AcademicYearComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(AcademicYearComboBox.SelectedValue!=null)
            {
                yr = AcademicYearComboBox.SelectedValue.ToString();//GetYear(AcademicYearComboBox.SelectedValue.ToString());
            }
        }
    }
}
