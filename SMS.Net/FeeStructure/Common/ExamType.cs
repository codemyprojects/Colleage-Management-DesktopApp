using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Common
{
    public partial class ExamType : Form
    {
        public static int eid;
        public ExamType()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ExamTypeTextBox.Enabled = true;
            
                SqlCommand cmd = new SqlCommand();
                if (ExamTypeTextBox.Text == string.Empty)
                {
                    MessageBox.Show("Please enter examination type");
                }
                else
                {
                    cmd.CommandText = "insert into student.ExaminationInfo(ExamType) values ('" + ExamTypeTextBox.Text.Trim() + "')";
                    int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                    if (x == 1)
                    {
                        MessageBox.Show("Inserted successfully");
                        ExamTypeTextBox.Text = string.Empty;
                        BindDataGrid();

                    }
                }
            
               
            
            
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();


        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from student.ExaminationInfo where ExamId='eid'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Data deleted successfully");
                BindDataGrid();
            }


        }
        private void BindDataGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from student.ExaminationInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;


        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            eid = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            ExamTypeTextBox.Text = Convert.ToString(dataGridView1[1, e.RowIndex].Value);



        }

        private void ExamType_Load(object sender, EventArgs e)
        {
            BindDataGrid();
            AddButton.Enabled = true;
            EditButton.Enabled = false;
            DeleteButton.Enabled = false;
            SaveButton.Enabled = false;
            ExamTypeTextBox.Enabled = false;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            EditButton.Enabled = false;
            AddButton.Enabled = false;
            DeleteButton.Enabled = false;
            ExamTypeTextBox.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update student.ExaminationInfo set ExamType='" + ExamTypeTextBox.Text.Trim() + "' where ExamId='" + eid + "'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Updated successfully");
                BindDataGrid();
            }
        }
    }
}
