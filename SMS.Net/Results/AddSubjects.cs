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
    public partial class AddSubjects : Form
    {
        public bool logic;
        public  int sid;
        public  string year;
        public  string c;
        public AddSubjects()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            EnableDisalbleReadOnly(false);
            logic = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void EnableDisalbleReadOnly(bool b)
        {
            FullMarksTextBox.ReadOnly = b;
            PassMarksTextBox.ReadOnly = b;
            TheoryFM.ReadOnly = b;
            PracticalFM.ReadOnly = b;
            TheoryPM.ReadOnly = b;
            PracticalPM.ReadOnly = b;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            
            if(logic)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO dbo.SubjectsInfo(AcademicYearId,ClassId,SubjectName,FullMarks,PassMarks,TheoryFM,TheoryPM,PracticalFM,PracticalPM) VALUES('"+year+"','"+c+"','" + SubjectNameTextBox.Text + "','" + FullMarksTextBox.Text.Trim() + "','" + PassMarksTextBox.Text.Trim() + "','" + TheoryFM.Text.Trim() + "','" + TheoryPM.Text.Trim() + "','" + PracticalFM.Text.Trim() + "','" + PracticalPM.Text.Trim() + "')";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                if (x == 1)
                {
                    MessageBox.Show("Subjests Detail Added Successfully!!");
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "SELECT SubjectId AS [Subject ID] ,SubjectName AS [Subject],FullMarks AS [Full Marks],PassMarks AS [Pass Marks],TheoryFM AS [Theory FM],TheoryPM AS [Theory PM],PracticalFM AS [Practical FM],PracticalPM AS [Practical PM] FROM dbo.SubjectsInfo WHERE AcademicYearId='"+year+"' AND ClassId='"+c+"'";
                    DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd1);
                    dataGridView1.DataSource = dt;

                    //BindDataGrid();
                    AcademicYearComboBox.Text = "";
                    ClassComboBox.Text = "";
                    SubjectNameTextBox.Text = string.Empty;
                    FullMarksTextBox.Text = string.Empty;
                    PassMarksTextBox.Text = string.Empty;
                    TheoryFM.Text = string.Empty;
                    TheoryFM.Text = string.Empty;
                    PracticalFM.Text = string.Empty;
                    PracticalPM.Text = string.Empty;

                }
                //MessageBox.Show("Add Button Clicked!!");
            }
            if(!logic)
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "UPDATE dbo.SubjectsInfo SET SubjectName='" + SubjectNameTextBox.Text.Trim() + "',FullMarks='" + FullMarksTextBox.Text.Trim() + "',PassMarks='" + PassMarksTextBox.Text.Trim() + "',TheoryFM='" + TheoryFM + "',TheoryPM='" + TheoryPM + "',PracticalFM='" + PracticalFM + "',PracticalPM='" + PracticalPM + "' WHERE SubjectId='"+sid+"' ";
                cmd.CommandText = "UPDATE dbo.SubjectsInfo SET SubjectName='" + SubjectNameTextBox.Text + "',FullMarks='" + FullMarksTextBox.Text.Trim() + "',PassMarks='" + PassMarksTextBox.Text.Trim() + "',TheoryFM='" + TheoryFM.Text.Trim() + "',TheoryPM='" + TheoryPM.Text.Trim() + "',PracticalFM='" + PracticalFM.Text.Trim() + "',PracticalPM='" + PracticalPM.Text.Trim() + "' WHERE SubjectId='"+sid+"'";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                if (x == 1)
                {
                    MessageBox.Show("Updated Successfully!");
                    BindDataGrid();
                }
                //MessageBox.Show("Edit Button is clicked");
            }
         
          
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            logic=false;
            EnableDisalbleReadOnly(false);

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                        "Confirm Delete!!",
                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM dbo.SubjectsInfo WHERE SubjectId='" + sid + "'";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "SELECT SubjectId AS [Subject ID] ,SubjectName AS [Subject],FullMarks AS [Full Marks],PassMarks AS [Pass Marks],TheoryFM AS [Theory FM],TheoryPM AS [Theory PM],PracticalFM AS [Practical FM],PracticalPM AS [Practical PM] FROM dbo.SubjectsInfo WHERE AcademicYearId='" + year + "' AND ClassId='" + c + "'";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd1);
                dataGridView1.DataSource = dt;

                //BindDataGrid();
            }
       
        }
        private void BindDataGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT SubjectId AS [Subject ID] ,SubjectName AS [Subject],FullMarks AS [Full Marks],PassMarks AS [Pass Marks],TheoryFM AS [Theory FM],TheoryPM AS [Theory PM],PracticalFM AS [Practical FM],PracticalPM AS [Practical PM] FROM dbo.SubjectsInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;
        }
        
        private void AddSubjects_Load(object sender, EventArgs e)
        {
            BindDataGrid();
            BindBatch();
            BindClassComboBox();
            EditButton.Enabled = false;
            DeleteButton.Enabled = false;
            EnableDisalbleReadOnly(true);
        }
        private void BindBatch()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
            AcademicYearComboBox.DisplayMember = "AcademicYear";
            AcademicYearComboBox.ValueMember = "AcademicYear";
            AcademicYearComboBox.DataSource = dt;
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            ClassComboBox.ValueMember = "ClassId";
            ClassComboBox.DisplayMember = "Class";
            ClassComboBox.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EditButton.Enabled = true;
            DeleteButton.Enabled = true;

            sid =Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM dbo.SubjectsInfo WHERE SubjectId='"+sid+"'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            foreach(DataRow dr in dt.Rows)
            {
                SubjectNameTextBox.Text = dr["SubjectName"].ToString();
                FullMarksTextBox.Text = dr["FullMarks"].ToString();
                PassMarksTextBox.Text = dr["PassMarks"].ToString();
                TheoryFM.Text = dr["TheoryFM"].ToString();
                TheoryPM.Text = dr["TheoryPM"].ToString();
                if (dr["PracticalFM"].ToString() != null || dr["PracticalFM"].ToString() != string.Empty || dr["PracticalPM"].ToString()!=null || dr["PracticalPM"].ToString()!=null)
                {
                    PracticalFM.Enabled = true;
                    PracticalPM.Enabled = true;
                }
                PracticalFM.Text = dr["PracticalFM"].ToString();
                PracticalPM.Text = dr["PracticalPM"].ToString();
            }
        }

        private void FullMarksTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AcademicYearComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (AcademicYearComboBox.SelectedValue != null)
                year=Convert.ToString(AcademicYearComboBox.SelectedValue);
        }

        private void ClassComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ClassComboBox.SelectedValue != null)
            {
                c = Convert.ToString(ClassComboBox.SelectedValue);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT SubjectId AS [Subject ID] ,SubjectName AS [Subject],FullMarks AS [Full Marks],PassMarks AS [Pass Marks],TheoryFM AS [Theory FM],TheoryPM AS [Theory PM],PracticalFM AS [Practical FM],PracticalPM AS [Practical PM] FROM dbo.SubjectsInfo WHERE AcademicYearId='"+year+"' AND ClassId='"+c+"'";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                dataGridView1.DataSource = dt;
            }
        }

        private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TheoryPM_TextChanged(object sender, EventArgs e)
        {
            if(FullMarksTextBox.Text==TheoryFM.Text)
            {
                PracticalFM.Enabled = false;
                PracticalPM.Enabled = false;
            }
        }
    }
}
