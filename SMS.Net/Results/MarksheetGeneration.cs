using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Results
{  
    public partial class MarksheetGeneration : Form
    {
        public static int totalMarks = 0;
        public float avgMatks = 0;
        public float percentage;
        public string division;
        public  int b=0;
        public static int id;
        public static int aid;
        public static int eid;
        public  static int cid;
        public int c;
        public int d;
        public MarksheetGeneration()
        {
            InitializeComponent();
        }

        private void MarksheetGeneration_Load(object sender, EventArgs e)
        {
            //BindGrid();
            BindStudent();
            BindBatch();
            BindExamInfo();
            BindClassComboBox();
        }
        private void BindGrid()
        {
            SqlCommand cmd = new SqlCommand();
           // cmd.CommandText = "SELECT * FROM  vResultCalc where StudentId='" + id + "' AND ";
            cmd.CommandText = "SELECT * FROM  vResultCalc where StudentId='"+id+"' AND AcademicYearId='"+aid+"' AND ClassId='"+cid+"'  AND ExamId='"+eid+"' ";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            if(dt.Rows.Count>0)
            {
                dataGridView1.DataSource = dt;
                foreach(DataRow dr in dt.Rows)
                {
                    totalMarks = totalMarks + Convert.ToInt32(dr["ObtainedMarks"]);
                    percentage = totalMarks / dt.Rows.Count;
                    if(dr["Result"].ToString()=="Pass")
                    {
                        //b = 0;
                        b = b + 1;
                        c = b;
                    }
                    if(dr["Result"].ToString()=="Fail")
                    {
                        b = 0;
                        b = b + 1;
                        d = b;
                        //b = b + 0;
                    }
                }
                if((c>=1) && (d!=1))
                {
                    ResultTextBox.Text = "Pass";

                }
                else
                {
                    ResultTextBox.Text = "Fail";
                }
                if((b>0)&&(percentage>=80))
                {
                    DivisionTextBox.Text = "Distinction";
                    richTextBox1.Text = "Excellent";
                }
                if ((b > 0) && (percentage >= 60) &&(percentage<80))
                {
                    DivisionTextBox.Text = "First Division";
                    richTextBox1.Text = "Very Good";
                }
                if ((b > 0) && (percentage >= 45)&&(percentage<60))
                {
                    DivisionTextBox.Text = "Second Division";
                    richTextBox1.Text = "Good";
                }
                if ((b > 0) && (percentage >= 32) &&(percentage<45))
                {
                    DivisionTextBox.Text = "Third Division";
                    richTextBox1.Text = "Satisfactory";
                }
                if((b==0)||(percentage<32) )
                {
                    DivisionTextBox.Text = "No Division";
                    richTextBox1.Text = "Labour hard";
                }
                TotalMarksTextBox.Text = Convert.ToString(totalMarks);
                PercentageTextBox.Text = Convert.ToString(percentage)+"%";
            }
            else
            {
                MessageBox.Show("No Records Please!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO student.MarksheetInfo(AcademicYearId,ExamDate,ClassId,ExamId,StudentId,TotalMarks,Percentage,Result,Division,Remarks) VALUES('" + aid + "','"+dateTimePicker1.Text+"','" + cid + "','" + eid + "','" + id + "','" + totalMarks + "','" + percentage + "','" + ResultTextBox.Text.Trim() + "','" + DivisionTextBox.Text.Trim() + "','" + richTextBox1.Text.Trim() + "')";
                //cmd.CommandText = "INSERT INTO student.MarksheetInfo(StudentId,TotalMarks,Percentage,Result,Division,Remarks) VALUES('" + id + "','" + totalMarks + "','" + percentage + "','" + ResultTextBox.Text.Trim() + "','" + DivisionTextBox.Text.Trim() + "','" + richTextBox1.Text.Trim() + "')";
                int success = DataBaseLayer.DbOperations.ExecProc(cmd);
                if (success == 1)
                    MessageBox.Show("Marks Sheet Saved Successfully!!");
                
                else
                    MessageBox.Show("Due to some problem marksheet not saved!!!");
                //AcademicYearComboBox.Text = "";
                //ExamTypeComboBox.Text = "";
                //ClassComboBox.Text = "";
                dateTimePicker1.Text = "";
                comboBox1.Text = "";
                TotalMarksTextBox.Text = string.Empty;
                PercentageTextBox.Text = string.Empty;
                ResultTextBox.Text = string.Empty;
                DivisionTextBox.Text = string.Empty;
                richTextBox1.Text = string.Empty;
                
            }
            catch(SqlException ex)
            {
                //MessageBox.Show(ex.Message);
                //MessageBox.Show(ex.Message, "Sql Exception");
                MessageBox.Show("Please Select Value From Combobox and Do not leave Text Box Empty", "Exception Occured!!");
            }
       }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                id = Convert.ToInt32(comboBox1.SelectedValue.ToString());
               // BindGrid(id);
            }
        }
        private void BindStudent()
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "SELECT * FROM  vResultCalc"
            cmd.CommandText = "SELECT DISTINCT StudentName,StudentId FROM  vResultCalc";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox1.DisplayMember="StudentName";
            comboBox1.ValueMember = "StudentId";
            comboBox1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            totalMarks = 0;
            avgMatks = 0;
            b = 0;
            percentage = 0;
            BindGrid();
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            AcademicYearComboBox.DisplayMember = "AcademicYear";
            AcademicYearComboBox.ValueMember = "AcademicYearId";
            AcademicYearComboBox.DataSource = dt;
        }

        private void BindExamInfo()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from student.ExaminationInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            ExamTypeComboBox.DisplayMember = "ExamType";
            ExamTypeComboBox.ValueMember = "ExamId";
            ExamTypeComboBox.DataSource = dt;
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            ClassComboBox.DisplayMember = "Class";
            ClassComboBox.ValueMember = "ClassId";
            ClassComboBox.DataSource = dt;
        }

        private void AcademicYearComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(AcademicYearComboBox.SelectedValue!=null)
            {
                aid = Convert.ToInt32(AcademicYearComboBox.SelectedValue);
            }
        }

        private void ExamTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ExamTypeComboBox.SelectedValue!=null)
            {
                eid =Convert.ToInt32(ExamTypeComboBox.SelectedValue);
            }
        }

        private void ClassComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ClassComboBox.SelectedValue!=null)
            {
                cid =Convert.ToInt32(ClassComboBox.SelectedValue);
            }
        }

        private void PercentageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
