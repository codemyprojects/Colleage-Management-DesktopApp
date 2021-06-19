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
    public partial class SearchFee : Form
    {
        public SearchFee()
        {
            InitializeComponent();
        }

        private void SearchFee_Load(object sender, EventArgs e)
        {

        }
        private void BindGrid(int Class)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT t1.PaymentId as [S.No],t3.AcademicYear,t4.Class,t2.StudentName,t1.RollNO,t1.TotalFee,t1.PaidAmount,t1.DueAmount,t1.Narration,t1.[PaidDate] FROM StudentFeePayments t1 inner join student.StudentInfo t2 on t1.StudentId=t2.StudentId inner join student.AcademicYearInfo t3 on t3.AcademicYearId=t1.AcademicYearId inner join student.ClassInfo t4 on t4.ClassId=t1.ClassId WHERE t1.StudentId='"+StudentNameTextBox.Text.Trim()+"'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count==0)
            {
                MessageBox.Show("No Records Please!!");
            }
            else
            {
                dataGridView1.DataSource = dt;
            }
          
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(StudentNameTextBox.Text.Trim()==string.Empty)
           {
               MessageBox.Show("Student Id Required!!");
           }

            else
           {
               BindGrid(Convert.ToInt32(StudentNameTextBox.Text.Trim()));
           }
    
        }
    }
}
