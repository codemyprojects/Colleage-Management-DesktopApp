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
    public partial class AcademicYearInfo : Form
    {
        public static int aid;
        public AcademicYearInfo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
           // SaveButton.Enabled = true;
           // AddButton.Enabled = false;
            textBox1.Enabled = true;
            if(textBox1.Text==string.Empty)
            {
                MessageBox.Show("Please Enter Academic Year");
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into student.AcademicYearInfo(AcademicYear) values ('" + textBox1.Text.Trim() + "')";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                if (x == 1)
                {
                    MessageBox.Show("Academic Year inserted successfully");
                    BindDataGrid();
                    textBox1.Text = string.Empty;
                }
            }
           
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
                cmd.CommandText = "delete from student.AcademicYearInfo where AcademicYearId='" + aid + "'";
                int success = DataBaseLayer.DbOperations.ExecProc(cmd);
                if (success == 1)
                {
                    MessageBox.Show("Deleted successfully");
                    BindDataGrid();


                }
            }
        
        }
        private void BindDataGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from student.AcademicYearInfo";
           DataTable dt= DataBaseLayer.DbOperations.GetDataTable(cmd);
           dataGridView1.DataSource = dt;


        }

        private void AcademicYearInfo_Load(object sender, EventArgs e)
        {
            BindDataGrid();
            EditButton.Enabled = false;
            SaveButton.Enabled = false;
            DeleteButton.Enabled = false;
            textBox1.Enabled = false;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
            
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            EditButton.Enabled = false;
            AddButton.Enabled = false;
            DeleteButton.Enabled = false;
            textBox1.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update student.AcademicYearInfo set AcademicYear='" + textBox1.Text.Trim() + "' where AcademicYearId='" + aid + "'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Successfully updated");
                BindDataGrid();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EditButton.Enabled = true;
            DeleteButton.Enabled = true;
            aid = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            textBox1.Text = Convert.ToString(dataGridView1[1, e.RowIndex].Value);
        }
    }
}
